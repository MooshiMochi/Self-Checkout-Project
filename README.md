# Self-Checkout Automatic Age Verification

This is a system that allows for users to create an account and verify their identity using an ID document. Once their identity has been verified the system
can use it to check whether the user is old enough to buy a certain age restricted product.

## Technologies Used

The application is built using Python and Visual Basic .NET, and relies on the .NET Framework. It also uses the following libraries:

[Visual Basic]

- System.Text.RegularExpressions
- System.Net
- System.Web.Script.Serialization

[Python]

- pytesseract
- pillow
- fastapi[all]
- uvicorn
- aiosqlite
- qrcode
- python-dotenv
- pyotp
- numpy
- opencv-python
- cmake

## Key Features

- User registration
- Input validation
- API integration
- Image display

## Installation

To install and run the application, you will need to have Visual Studio installed on your computer and the Windows OS.
As of right now the current system cannot be run on any OS other than Windows.

1. Clone the project repository from GitHub.
2. Install PyTesseract and add the tesseract executable to your PATH variables. (Set the tesseract executable to this path: C:\Program Files\Tesseract-OCR\tesseract.exe)
3. Open the project in Visual Studio.
4. Build and run the project from within Visual Studio using the command `.\setup.bat`

## Configuration

The configuration for the project should have been completed during the Installation process however, if for whatever
reason the configuration process did not take place follow the instructions listed below:

1. Open a command prompt or terminal in the root directory of the project and execute the following command:
   `cp .env.example .env`
2. Open the newly created `.env` file and edit the SECRET_KEY constant.

## Contributing

Contributions for this project are closed due to the fact that this is an INDIVIDUAL programmed solution.

## License

The project is licensed under the 'Do whatever you want with this' license.
