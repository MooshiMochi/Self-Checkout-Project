from base64 import b64encode
from io import BytesIO

import qrcode
from PIL import Image

from classes.errors import AccountDoesNotExistError, CannotVerifyAccountError, AccountAlreadyVerifiedError
from modules.cv2_utils import CV2Image
from modules.database import Database
from modules.ocr import process_image, read_text, get_date_of_birth


def generate_qr(data: str | int) -> str:
    """
    __Summary__

    Generate a QR code from the given data.

    __Arguments__

    * data (str | int): The data to encode in the QR code

    __Returns__

    * str: The base64 encoded QR code
    """
    qr = qrcode.QRCode(
        version=1,
        error_correction=qrcode.constants.ERROR_CORRECT_L,
        box_size=10,
        border=4,
    )
    qr.add_data(data)
    qr.make(fit=True)
    img = qr.make_image(fill_color="black", back_color="white")

    buffer = BytesIO()
    buffer.seek(0)
    img.save(buffer, format="PNG")
    return b64encode(buffer.getvalue()).decode("utf-8")


def compress_image(data: bytes, max_size: int = 0.95) -> bytes:
    """Compresses a bytes image into a smaller size.
    
    Parameters:
        - data (bytes): The image data to compress.
        - max_size (int): The maximum size of the image in MB.
        
    Returns:
        - bytes: The compressed image data.
    """

    max_size = max_size * (1024 ** 2)

    image = Image.open(BytesIO(data))

    while len(data) > max_size:
        # Reduce the image size by 10%
        size = int(image.size[0] * 0.9), int(image.size[1] * 0.9)
        image = image.resize(size, Image.ANTIALIAS)

        # Save the compressed image to a buffer
        buffer = BytesIO()
        image.save(buffer, format="JPEG")
        data = buffer.getvalue()
    return data


async def verify_account(image: CV2Image, db: Database, customer_id: int):
    """Verify the account using the given image.

    Parameters:
        - image (bytes): The image to verify the account with.
        - db (Database): The database to use.
        - customer_id (int): The customer ID to verify.

    Raises:
        - AccountDoesNotExistError: The customer is not registered.
        - AccountAlreadyVerifiedError: The customer is already verified.
        - CannotVerifyAccountError: The customer could not be verified.
    """

    if not await db.customer_registered(customer_id):
        raise AccountDoesNotExistError("Customer is not registered.")

    if await db.customer_verified(customer_id):
        raise AccountAlreadyVerifiedError(customer_id)

    # preprocess the image
    processed_img = process_image(image)

    # Get the text from the processed image
    img_text = read_text(processed_img)
    # get the text from the raw image
    raw_img_text = read_text(image)

    # Get the date of birth from the text
    dobs = [get_date_of_birth(img_text), get_date_of_birth(raw_img_text)]
    if not any(dobs):
        raise CannotVerifyAccountError(customer_id)
    else:
        dob = min([x for x in dobs if x is not None]).date()
        await db.verify_account(customer_id, dob)
