import hashlib
import os
import secrets
import time

from dotenv import load_dotenv

load_dotenv()

SECRET_KEY = os.getenv("SECRET_KEY")

assert SECRET_KEY is not None, "500 Invalid Secret Key!"


def generate_token(username: str, password_hash: str) -> str:
    """
    __Summary__

    Generates a token for a user based on their username and password hash.

    __Arguments__

    * username (str): The username of the user
    * password_hash (str): The hash of the user's password

    __Returns__

    * str: The generated 16 character token
    """
    random_value = secrets.token_urlsafe(16)
    timestamp = str(time.time())
    token = hashlib.sha256(
        (random_value + username + timestamp + SECRET_KEY + password_hash).encode(
            "utf-8"
        )
    ).hexdigest()[:16]
    return token


def hash_password(password: str) -> str:
    """
    __Summary__

    Hashes a password using SHA3-256.

    __Arguments__

    * password (str): The password to hash

    __Returns__

    * str: The hashed password

    __Example__

    >>> hash_password("password")
    b'c0067d4af4e87f00dbac63b6156828237059172d1bbeac67427345d6a9fda484'
    """
    return hashlib.sha3_256(password.encode()).hexdigest()
