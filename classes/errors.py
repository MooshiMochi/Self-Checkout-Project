from classes.states import EMPTY


class BaseError(Exception):
    """Base class for all errors in this package."""

    def __init__(self, error: str):
        self.error = error


class AccountExistsError(BaseError):
    """Raised when an account already exists."""

    def __init__(self, username: str = EMPTY, customer_id: int = EMPTY):
        super().__init__(
            f"Account {username if username is not EMPTY else customer_id} already exists"
        )
        self.username = username
        self.customer_id = customer_id


class AccountDoesNotExistError(BaseError):
    """Raised when an account does not exist."""

    def __init__(self, username: str = EMPTY, customer_id: int = EMPTY):
        super().__init__(
            f"Account {username if username is not EMPTY else customer_id} does not exist"
        )
        self.customer_id = username
        self.username = EMPTY


class MissingRequiredParameterError(BaseError):
    """Raised when a required parameter is missing."""

    def __init__(self, parameter: str):
        super().__init__(f"Missing required parameter {parameter}")
        self.parameter = parameter


class InvalidCredentialsError(BaseError):
    """Raised when the provided credentials are invalid."""

    def __init__(self, username: str):
        super().__init__(f"Invalid credentials for account {username}")
        self.username = username


class DynamicError(BaseError):
    """Raised when a dynamic error occurs."""

    def __init__(self, message: str, status_code: int = 400):
        super().__init__(message)
        self.message = message
        self.status_code = status_code


class InvalidTokenError(BaseError):
    """Raised when an invalid token is provided."""

    def __init__(self, token: str):
        super().__init__(f"The token {token} is not valid")
        self.token = token


class NoDocumentsFoundError(BaseError):
    """Raised when no documents are found."""

    def __init__(self, customer_id: int):
        super().__init__(f"No documents found for customer ID {customer_id}")


class InvalidQRCodeError(BaseError):
    """Raised when an invalid QR code is provided."""

    def __init__(self):
        super().__init__(f"The QR code provided is not valid")


class ImagesNotSamePersonError(BaseError):
    """Raised when the images are not of the same person."""

    def __init__(self):
        super().__init__(f"The ID stored does not belong to the person in the camera image.")


class AccountNotVerifiedError(BaseError):
    """Raised when the account is not verified."""

    def __init__(self, customer_id: int):
        super().__init__(f"The account with customer ID {customer_id} is not verified")


class AccountAlreadyVerifiedError(BaseError):
    """Raised when the account is already verified."""

    def __init__(self, customer_id: int):
        super().__init__(f"The account with customer ID {customer_id} is already verified")


class CannotVerifyAccountError(BaseError):
    """Raised when the account cannot be verified."""

    def __init__(self, customer_id: int):
        super().__init__(
            f"The account with customer ID {customer_id} cannot be verified. Please a better image of the ID.")
        self.customer_id = customer_id


class NoFaceFoundError(BaseError):
    """Raised when no face is found in the image."""

    def __init__(self):
        super().__init__(f"No face found in the image")
