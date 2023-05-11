import re
from datetime import datetime

import cv2
import numpy as np
import pytesseract

from modules.cv2_utils import CV2Image, load_image

pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"


# Path: modules\ocr.py
def deskew_image(image: CV2Image) -> CV2Image:
    # Compute the skew angle of the image
    coords = np.column_stack(np.where(image > 0))
    angle = cv2.minAreaRect(coords)[-1]

    # If the angle is less than -45 degrees, then we need to add 90 degrees to the angle
    if angle < -45:
        angle = -(90 + angle)
    # Otherwise, just take the negative of the angle
    else:
        angle = -angle

    # Rotate the image to deskew it
    (h, w) = image.shape[:2]
    center = (w // 2, h // 2)
    _M = cv2.getRotationMatrix2D(center, angle, 1.0)
    _rotated = cv2.warpAffine(
        image, _M, (w, h), flags=cv2.INTER_CUBIC, borderMode=cv2.BORDER_REPLICATE
    )

    return _rotated


def process_image(image: CV2Image) -> CV2Image:
    # Convert image to grayscale
    gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

    # Apply Gaussian blur to smooth the image
    blurred = cv2.GaussianBlur(gray, (5, 5), 0)

    # Perform adaptive thresholding to create a binary image
    thresholded = cv2.adaptiveThreshold(
        blurred, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 61, 3
    )

    # Perform morphological operations to remove noise and fill in gaps
    kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (5, 5))
    closed = cv2.morphologyEx(thresholded, cv2.MORPH_CLOSE, kernel)
    opened = cv2.morphologyEx(closed, cv2.MORPH_OPEN, kernel)

    # Perform erosion to reduce the size of text regions
    eroded = cv2.erode(opened, kernel, iterations=1)

    # Perform dilation to restore the size of text regions
    dilated = cv2.dilate(eroded, kernel, iterations=1)

    # Perform deskewing to correct any skew in the image
    deskewed = deskew_image(dilated)

    flipped = cv2.flip(deskewed, -1)

    # show_images(thresholded, flipped)

    # resize the image to a better resolution
    resized = cv2.resize(flipped, (0, 0), fx=1, fy=2, interpolation=cv2.INTER_CUBIC)

    # show_images(resized)
    # Return the preprocessed image
    return resized


def draw_boxes(image: CV2Image) -> CV2Image:
    boxes = pytesseract.image_to_boxes(image, lang="eng", config="--psm 11")
    for b in boxes.splitlines():
        b = b.split(" ")
        image = cv2.rectangle(
            image,
            (int(b[1]), image.shape[0] - int(b[2])),
            (int(b[3]), image.shape[0] - int(b[4])),
            (0, 255, 0),
            2,
        )

    return image


def read_text(image: CV2Image, psm: int = 11) -> str:
    """
    __Summary__

    Read the text from the preprocessed image

    __Arguments__

    * image_path (str): The path to the preprocessed image

    __Returns__

    * str: The text from the image
    """
    # use Tesseract to process the preprocessed image and extract the text
    _text = pytesseract.image_to_string(
        image, lang="eng", config=f"--psm {psm} --oem 3"
    )
    if not isinstance(_text, str):
        return "".join(_text)
    else:
        return _text


def get_date_of_birth(text: str) -> datetime | None:
    # remove any invalid characters from the dates
    dates = re.findall(r"\d\d[.,]\d\d[.,]\d\d\d\d", text)
    dates2 = re.findall(r"\d\d.?\d\d.?\d\d\d\d", text)

    dates.extend(dates2)

    # remove any invalid characters from the dates
    dates = [re.sub(r"\D", "/", date) for date in dates]
    dates = list(set(dates))

    if not dates:
        return None

    # convert dates to datetime objects
    dates = [datetime.strptime(date, "%d/%m/%Y") for date in dates]
    # select the earliest date
    return min(dates)


if __name__ == "__main__":
    import os

    pytesseract.pytesseract.tesseract_cmd = (
        r"C:\Program Files\Tesseract-OCR\tesseract.exe"
    )

    parent_dir = os.path.pardir
    img_paths = ["test/samples/sarah_dvla.jpg", "test/samples/morgan_dvla.jpeg"]
    img_paths = [os.path.join(parent_dir, path) for path in img_paths]
    for p in img_paths:
        assert os.path.exists(p), f"File not found: {p}"

    images = [load_image(path) for path in img_paths]
    # grey = [convert_to_grayscale(image) for image in images]
    # angles = [detect_faces_and_rotation(image, FACE_CASCADE)[0] for image in grey]
    # rotated = [rotate_image(image, angle) for image, angle in zip(images, angles)]

    preprocessed = process_image(images[0])
    img_text = read_text(preprocessed, psm=11)

    print(img_text)

    dob = get_date_of_birth(img_text)
    print(dob.date() if dob else "No date of birth found")
