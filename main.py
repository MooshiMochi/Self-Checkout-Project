import os
from base64 import b64decode, b64encode
from datetime import datetime, timedelta
from hashlib import sha3_256
from io import BytesIO
from json import dump, loads
from typing import Optional

import uvicorn
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from fastapi.requests import Request
from fastapi.responses import JSONResponse

from classes.errors import *
from modules.cv2_utils import (
    convert_to_bytes,
    convert_to_grayscale,
    detect_faces_and_rotation,
    load_image,
    read_qr_code,
    rotate_image,
)
from modules.database import Database
from modules.error_handler import on_error
from modules.faceDetect import is_same_person
from modules.otpgen import check_code, generate_authenticator_setup_qr_code
from modules.tokens import hash_password
from modules.utils import compress_image, generate_qr, verify_account

with open("test/test_info.json", "r") as f:
    test_info = loads(f.read())


class API(FastAPI):
    def __init__(self, *args, **kwargs) -> None:
        super().__init__(*args, **kwargs)
        if not os.path.exists("database.db"):
            open("database.db", "w").close()

        self.db: Database = Database("database.db")


app = API()

app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["POST", "GET"],
    allow_headers=["*"],
)

app.add_exception_handler(Exception, on_error)


@app.on_event("startup")
async def startup():
    await app.db.async_init()


@app.post("/register")
async def register(request: Request):
    data = await request.body()
    data = loads(data)

    username = data["email"]
    password = data["password"]
    pass_hash = hash_password(password)
    first_name = data["firstName"]
    last_name = data["lastName"]
    date_of_birth = data["DoB"]

    if not await app.db.account_registered(username):

        await app.db.register_customer(
            username, pass_hash, first_name, last_name, date_of_birth
        )
        return JSONResponse(
            status_code=200,
            content={
                "status": "success",
                "message": "Registered successfully",
                "success": True,
            },
        )

    else:
        raise AccountExistsError(username)


@app.post("/login")
async def login(request: Request):
    data = await request.body()
    data = loads(data)

    hashed_password = sha3_256(data["password"].encode()).hexdigest()
    username = data.get("username")

    if not await app.db.account_registered(username):
        raise AccountDoesNotExistError(username)

    if await app.db.credentials_match(username, hashed_password):
        customer_id = await app.db.get_customer_id(username)
        return JSONResponse(
            status_code=200,
            content={
                "status": "success",
                "message": "Logged in successfully",
                "success": True,
                "customerID": int(customer_id),
            },
        )

    raise InvalidCredentialsError(username)


@app.get("/load")
async def load(request: Request, username: Optional[str] = None):
    if not await app.db.account_registered(username=username):
        raise AccountDoesNotExistError(username)

    customer_id = (
        await app.db.fetch_one(
            "SELECT customer_id FROM customers WHERE username = ?", username
        )
    )[0]

    if customer_id is None:  # means there's no account with that username
        raise AccountDoesNotExistError(username)

    customer_details = await app.db.fetch_one(
        "SELECT first_name, last_name, DoB, verified FROM personal_details WHERE customer_id = ?",
        customer_id,
    )

    customer_documents = await app.db.fetch_one(
        "SELECT document_data FROM documents WHERE customer_id = ? LIMIT 1",
        customer_id,
    )

    response_content = {
        "status": "OK",
        "message": "Document loaded successfully.",
        "success": True,
        "document": None,
        "customer_id": int(customer_id),
        "firstName": customer_details[0],
        "lastName": customer_details[1],
        "DoB": customer_details[2],
        "verified": customer_details[3],
    }

    if customer_documents:
        customer_document = customer_documents[0]
        customer_document = compress_image(customer_document)
        customer_document = b64encode(customer_document).decode("utf-8")

        response_content["document"] = customer_document
    else:
        response_content["message"] = "Document not found."

    return JSONResponse(
        status_code=200,
        content=response_content,
    )


@app.get("/api/users")
async def users(request: Request, email: Optional[str] = None):
    return JSONResponse(
        status_code=200,
        content={
            "status": "success",
            "success": True,
            "exists": await app.db.account_registered(email)
            if email is not None
            else False,
        },
    )


@app.get("/status")
async def status(request: Request) -> JSONResponse:
    # check whether the API is running
    return JSONResponse(status_code=200, content={"status": True, "success": True})


@app.post("/renew-pass")
async def renew_password(request: Request):
    data = await request.body()
    data = loads(data)

    username = data.get("email")
    password = data.get("password")
    pass_hash = sha3_256(password.encode()).hexdigest()

    if not await app.db.account_registered(username):
        raise AccountDoesNotExistError(username)

    else:
        await app.db.execute(
            "UPDATE customers SET password = ? WHERE username = ?",
            pass_hash,
            username,
        )
        return JSONResponse(
            status_code=200,
            content={
                "status": "success",
                "message": "Password changed successfully",
                "success": True,
            },
        )


@app.get("/get_authenticator_secret")
async def get_authenticator_secret(request: Request, username: str):
    if not await app.db.account_registered(username):
        raise AccountDoesNotExistError(username=username)

    token = await app.db.get_token(username)

    if token is None:
        raise InvalidCredentialsError(username)

    qr_code = generate_authenticator_setup_qr_code(username, token)

    buffer = BytesIO()
    buffer.seek(0)
    qr_code.save(buffer, format="PNG")

    b64_encoded_qr_code = b64encode(buffer.getvalue()).decode()

    # return the QR code as a base64 encoded string
    return JSONResponse(
        status_code=200,
        content={
            "status": "success",
            "message": "QR code generated successfully",
            "success": True,
            "qr_code": b64_encoded_qr_code,
        },
    )


@app.get("/verify-code")
async def _code(
    request: Request, username: Optional[str] = None, code: Optional[str] = None
):
    if username is None or code is None:
        raise MissingRequiredParameterError("username or code")

    access_token = await app.db.get_token(username)

    is_valid: bool = check_code(code, access_token)

    response = JSONResponse(
        status_code=200,
        content={
            "status": "success",
            "message": f"Code is {'not' if not is_valid else ''} valid",
            "success": True,
            "code_valid": is_valid,
        },
    )

    return response


@app.post("/upload")
async def upload(request: Request):
    data = await request.body()
    data = loads(data)

    picture_bytes = data.get("picture").strip()
    username = data.get("username")

    if not username:
        raise MissingRequiredParameterError("username")

    elif picture_bytes is None:
        raise MissingRequiredParameterError("picture")

    if not await app.db.account_registered(username):
        raise AccountDoesNotExistError(username)

    customer_id = await app.db.get_customer_id(username)

    picture_bytes = b64decode(picture_bytes)
    image = load_image(picture_bytes)
    try:

        await verify_account(image, app.db, customer_id)
    except (
        AccountAlreadyVerifiedError,
        CannotVerifyAccountError,
        AccountDoesNotExistError,
    ):
        pass

    # fix the image orientation
    gray = convert_to_grayscale(image)
    angles_n_faces = detect_faces_and_rotation(gray)
    rotated = rotate_image(image, angles_n_faces[0])

    # convert the image to a byte array
    picture_bytes = convert_to_bytes(rotated)

    await app.db.insert_document(
        int(customer_id),
        picture_bytes,
    )
    return JSONResponse(
        status_code=200,
        content={
            "status": "success",
            "message": "Picture uploaded successfully",
            "success": True,
        },
    )


@app.get("/make_qr")
async def make_qr(request: Request, data: str):
    qr_code = generate_qr(data)

    # return the QR code as a base64 encoded string
    return JSONResponse(
        status_code=200,
        content={
            "status": "success",
            "message": "QR code generated successfully",
            "success": True,
            "qr_code": qr_code,
        },
    )


@app.post("/read_qr")
async def read_qr(request: Request) -> JSONResponse:
    data = await request.body()
    data = loads(data)

    qr_code = data.get("b64_qr_code")
    if qr_code is None:
        raise MissingRequiredParameterError("b64_qr_code")

    qr_code_blob = b64decode(qr_code)
    qr_code = load_image(qr_code_blob)
    customer_id = read_qr_code(qr_code)
    if not customer_id:
        raise InvalidQRCodeError()

    return JSONResponse(
        status_code=200,
        content={
            "status": "success",
            "message": "QR code read successfully",
            "success": True,
            "customer_id": customer_id,
        },
    )


@app.post("/check_age")
async def check_age(request: Request, customer_id: int):
    data = await request.body()
    data = loads(data)

    cam_img_bytes = data.get("b64_cam_img")
    if cam_img_bytes is None:
        raise MissingRequiredParameterError("b64_cam_img")

    if not await app.db.customer_registered(customer_id):
        raise AccountDoesNotExistError(customer_id=customer_id)

    customer_document = await app.db.fetch_document(customer_id)
    if not customer_document:
        raise NoDocumentsFoundError(customer_id)

    images = [load_image(customer_document), load_image(b64decode(cam_img_bytes))]
    gray_images = [convert_to_grayscale(image) for image in images]
    angles_n_faces = [
        detect_faces_and_rotation(gray_image) for gray_image in gray_images
    ]
    rotated_images = [
        rotate_image(image, angle_n_face[0])
        for image, angle_n_face in zip(images, angles_n_faces)
    ]
    face_coords = [angle_n_face[1] for angle_n_face in angles_n_faces]

    if not face_coords[0] or not face_coords[1]:
        raise NoFaceFoundError()

    same_person: bool = is_same_person(
        rotated_images[0], rotated_images[1], face_coords[0], face_coords[1]
    )
    if not same_person:
        raise ImagesNotSamePersonError()

    customer_details = await app.db.fetch_personal_details(customer_id)
    if not customer_details:
        raise AccountDoesNotExistError(customer_id=customer_id)

    customer_dob = customer_details[-2]
    verified = customer_details[-1]
    if not verified:
        raise AccountNotVerifiedError(customer_id=customer_id)

    customer_dob = datetime.strptime(customer_dob, "%Y-%m-%d").date()
    age = (datetime.now().date() - customer_dob) // timedelta(days=365.2425)
    return JSONResponse(
        status_code=200,
        content={
            "status": "success",
            "message": "Customer is old enough",
            "success": True,
            "age": age,
        },
    )


@app.get("/load_test_data")
async def load_test_data(request: Request, test_num: int, verified: int = 0):

    morgan_cam = load_image("test/samples/morgan_cam.jpeg")
    morgan_dvla = load_image("test/samples/morgan_dvla.jpeg")

    sarah_cam = load_image("test/samples/sarah_cam.jpg")
    sarah_dvla = load_image("test/samples/sarah_dvla.jpg")

    if test_num == 1:
        dvla_img = morgan_dvla
        cam_img_bytes = convert_to_bytes(morgan_cam)
        dvla_img_bytes = convert_to_bytes(morgan_dvla)
        test_key = "test_1"
    else:
        dvla_img = sarah_dvla
        cam_img_bytes = convert_to_bytes(sarah_cam)
        dvla_img_bytes = convert_to_bytes(sarah_dvla)
        test_key = "test_2"

    customer_id = test_info[test_key]["customers"]["customer_id"]
    username = await app.db.fetch_one(
        "SELECT username FROM customers WHERE customer_id = $1", customer_id
    )
    username = username[0] if username else None
    condition_to_register_test_account = (
        customer_id is None and username is None
    ) or username != test_info[test_key]["customers"]["username"]
    if condition_to_register_test_account:
        test_1_pwd_hash = hash_password(test_info["test_1"]["customers"]["password"])
        customer_id = await app.db.register_customer(
            test_info[test_key]["customers"]["username"],
            test_1_pwd_hash,
            test_info[test_key]["personal_details"]["first_name"],
            test_info[test_key]["personal_details"]["last_name"],
            test_info[test_key]["personal_details"]["DoB"],
        )
        test_info[test_key]["customers"]["customer_id"] = customer_id
        test_info[test_key]["personal_details"]["customer_id"] = customer_id
        test_info[test_key]["documents"]["customer_id"] = customer_id

        with open("test/test_info.json", "w") as f:
            dump(test_info, f, indent=4)

        await app.db.insert_document(customer_id, dvla_img_bytes)

    if verified == 1:
        await verify_account(dvla_img, app.db, customer_id)

    elif verified == 0:
        if not await app.db.customer_verified(customer_id):
            raise DynamicError("Account is already not verified!", 400)

        await app.db.execute(
            "UPDATE personal_details SET verified = $1 WHERE customer_id = $2",
            False,
            customer_id,
        )

    b64_qr_code = generate_qr(customer_id)

    return JSONResponse(
        status_code=200,
        content={
            "status": "success",
            "message": f"Test {test_num} loaded successfully",
            "success": True,
            "cam_picture": b64encode(cam_img_bytes).decode(),
            "id_picture": b64encode(dvla_img_bytes).decode(),
            "qr_picture": b64_qr_code,
        },
    )


if __name__ == "__main__":
    uvicorn.run("main:app", host="127.0.0.1", port=8000, reload=True)
