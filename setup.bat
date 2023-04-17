@echo off

goto main

:dlib_install
set "PYTHON_EXE=%VIRTUAL_ENV%\Scripts\python.exe"

if not exist %PYTHON_EXE% (
  echo Creating virtual environment...
  python -m venv venv
)

@REM echo Activating virtual environment...
@REM call %VIRTUAL_ENV%\Scripts\activate.bat

echo Installing prerequisites...
pip install numpy setuptools cmake wheel

echo Cloning dlib repository...
git clone https://github.com/davisking/dlib.git

echo Building and installing dlib...
cd dlib
mkdir build
cd build
cmake -G "Visual Studio 16 2019" ..
cmake --build . --config Release
cd ..
%PYTHON_EXE% setup.py install

echo Cleaning up...
cd ..
rmdir /s /q dlib

echo Done.
goto :eof


:main
set "PYTHON_EXE=%VIRTUAL_ENV%\Scripts\python.exe"

if not exist %PYTHON_EXE% (
  echo Creating virtual environment...
  python -m venv venv
)

@REM echo Activating virtual environment...
@REM call %VIRTUAL_ENV%\Scripts\activate.bat

echo Updating pip...
%PYTHON_EXE% -m pip install --upgrade pip

echo Installing dependencies...
%PYTHON_EXE% -m pip install -r requirements.txt

echo Checking for dlib...
%PYTHON_EXE% -c "import dlib"
if %errorlevel% neq 0 (
  echo Installing dlib from binary...
  call :dlib_install
) else (
  echo dlib found...
)

cls

echo Checking if .env file exists...
if not exist .env (
  echo Creating .env file...
  copy .env.example .env > nul
  echo Please edit the SECRET_KEY variable in the .env file.
)

echo Setup complete!
goto :eof