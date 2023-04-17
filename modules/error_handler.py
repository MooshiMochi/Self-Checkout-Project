from fastapi.requests import Request
from fastapi.responses import JSONResponse

from classes.errors import *
from classes.states import EMPTY


async def on_error(request: Request, exc: Exception):
    print("Error Occurred:", exc)

    response_content = {
        "status": "error",
        "success": False,
    }
    status_code = 500

    if isinstance(exc, AccountExistsError):
        status_code = 400

        if exc.customer_id is not EMPTY:
            response_content[
                "message"
            ] = f"Account with the ID '{exc.customer_id}' already exists."
        else:
            response_content["message"] = f"Account '{exc.username}' already exists."

    elif isinstance(exc, AccountDoesNotExistError):
        status_code = 400

        if exc.customer_id is not EMPTY:
            response_content[
                "message"
            ] = f"Account with the ID '{exc.customer_id}' does not exist."
        else:
            response_content["message"] = f"Account '{exc.username}' does not exist."

    elif isinstance(exc, MissingRequiredParameterError):
        status_code = 400
        response_content[
            "message"
        ] = f"The required parameter '{exc.parameter}' is missing."

    elif isinstance(exc, DynamicError):
        status_code = exc.status_code
        response_content["message"] = exc.message

    elif isinstance(exc, InvalidCredentialsError):
        status_code = 400
        response_content[
            "message"
        ] = f"Invalid credentials for account '{exc.username}'."

    elif isinstance(exc, NoDocumentsFoundError):
        status_code = 400
        response_content["message"] = "No documents found."

    elif isinstance(exc, InvalidQRCodeError):
        status_code = 400
        response_content["message"] = "Invalid QR code provided."

    elif isinstance(exc, InvalidTokenError):
        status_code = 400
        response_content["message"] = "Invalid token provided."

    elif isinstance(exc, ImagesNotSamePersonError):
        status_code = 400
        response_content["message"] = "Images are not of the same person."

    elif isinstance(exc, AccountNotVerifiedError):
        status_code = 400
        response_content["message"] = "Account is not verified. Upload a document to verify."

    elif isinstance(exc, AccountAlreadyVerifiedError):
        status_code = 400
        response_content["message"] = "Account is already verified."

    elif isinstance(exc, CannotVerifyAccountError):
        status_code = 400
        response_content["message"] = "Cannot verify account. Upload a new image of the ID to verify."

    elif isinstance(exc, NoFaceFoundError):
        status_code = 400
        response_content["message"] = "No face found in image. Please try again."

    else:
        response_content["message"] = str(exc)
        # print(str(exc))  # the exception will be raised regardless. I don't know how to silence it
        # therefore there is no need to print the exception a 2nd time here.

    return JSONResponse(
        status_code=status_code,
        content=response_content,
    )
