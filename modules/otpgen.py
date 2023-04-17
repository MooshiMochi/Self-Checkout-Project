from base64 import b32encode

import pyotp
import qrcode
from PIL import Image


def token_to_key(access_token: str) -> str:
    """
    ___Summary___

    Prepares the access token for use in the QR code.

    __Arguments__

    * `access_token` (`str`): The access token to be used for verification.

    __Returns__

    * `str`: The prepared access token with a length of 16 characters.
    """
    return b32encode(access_token.encode("utf-8")).decode("utf-8")[:16]


def generate_authenticator_setup_qr_code(
        username: str,
        access_token: str,
        issuer_name: str = "Self-Checkout Age Verification",
) -> Image:
    """
    __Summary__

    Generates a QR code for the user to scan.

    __Arguments__

    * `username` (`str`): The username of the user.
    * `access_token` (`str`): The access token to be used for verification.

    __Returns__

    * `qrcode.image.pil.PilImage`: The QR code image.
    """
    secret_key = token_to_key(access_token)
    uri = pyotp.totp.TOTP(secret_key).provisioning_uri(
        username, issuer_name=issuer_name
    )
    img = qrcode.make(uri)
    return img


def check_code(code: str, access_token: str) -> bool:
    """
    __Summary__

    Checks whether the code is valid or not.

    __Arguments__

    * `code` (`str`): The code to be checked.
    * `access_token` (`str`): The access token to be used for verification.

    __Returns__

    * `bool`: Whether the code is valid or not.
    """
    secret_key = token_to_key(access_token)
    return pyotp.totp.TOTP(secret_key).verify(code)
