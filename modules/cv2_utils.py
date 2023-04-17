import os
from typing import Literal

import cv2
import numpy as np
from numpy import ndarray

model_path = os.path.join(os.path.pardir, r"models\nn4.small2.v1.t7")
alt_model_path = r"models\nn4.small2.v1.t7"
if not os.path.exists(model_path):
    model_path = alt_model_path
if not os.path.exists(model_path):
    raise FileNotFoundError(
        "Face detection model file not found. Path entered: " + model_path
    )

FACE_DETECTION_MODEL = cv2.dnn.readNetFromTorch(model_path)
FACE_CASCADE = cv2.CascadeClassifier(
    cv2.data.haarcascades + "haarcascade_frontalface_default.xml"
)


class CV2Image(cv2.Mat, ndarray):
    """A wrapper for cv2 images used for type hinting"""

    pass


def show_images(*cv2_images: list[CV2Image]) -> None:
    for i, img in enumerate(cv2_images):
        cv2.namedWindow(f"Image {i}", cv2.WINDOW_NORMAL)
        cv2.resizeWindow(f"Image {i}", 800, 600)
        cv2.imshow(f"Image {i}", img)

    cv2.waitKey(0)
    cv2.destroyAllWindows()


def load_image(path_or_bytes: str | bytes) -> CV2Image:
    if isinstance(path_or_bytes, str):
        try:
            return cv2.imread(path_or_bytes)
        except Exception as e:
            print(f"Error loading image from path: {e}")

        path_or_bytes = path_or_bytes.encode()
    nparr = np.frombuffer(path_or_bytes, np.uint8)
    return cv2.imdecode(nparr, cv2.IMREAD_COLOR)


def rotate_image(image: CV2Image, angle: Literal[0, 90, 180, 270] | int) -> CV2Image:
    if angle == 90:
        return cv2.rotate(image, cv2.ROTATE_90_CLOCKWISE)
    elif angle == 180:
        return cv2.rotate(image, cv2.ROTATE_180)
    elif angle == 270:
        return cv2.rotate(image, cv2.ROTATE_90_COUNTERCLOCKWISE)
    else:
        return image


def convert_to_grayscale(image: CV2Image) -> CV2Image:
    return cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)


def draw_face(image: CV2Image, face: tuple[int, int, int, int]) -> CV2Image:
    x, y, w, h = face
    cv2.rectangle(image, (x, y), (x + w, y + h), (0, 255, 0), 2)
    return image


def draw_faces(
    image: CV2Image, image_faces: list[tuple[int, int, int, int]]
) -> CV2Image:
    for face in image_faces:
        image = draw_face(image, face)
    return image


def filter_faces(
    faces: list[tuple[int, int, int, int]]
) -> list[tuple[int, int, int, int]]:
    # Filter out faces that are too small
    return [face for face in faces if face[2] * face[3] > 10000]


def detect_faces_and_rotation(
    grey_image: CV2Image,
) -> tuple[int, list[tuple[int, int, int, int]]]:
    global FACE_CASCADE

    faces = []
    angle = 0
    for i in range(4):
        faces = FACE_CASCADE.detectMultiScale(
            grey_image, scaleFactor=1.3, minNeighbors=5, minSize=(30, 30)
        )
        faces = filter_faces(faces)
        if len(faces) > 0:
            break
        angle += 90
        grey_image = rotate_image(grey_image, 90)
    else:
        print("No faces found")

    angle = 0 if angle == 360 else angle
    return angle, faces


def cut_face(image: CV2Image, faces: list[tuple[int, int, int, int]]) -> list[CV2Image]:
    # Cut the faces out of the image
    return [image[y : y + h, x : x + w] for (x, y, w, h) in faces[:1]][0]


def convert_to_bytes(image: CV2Image) -> bytes:
    return cv2.imencode(".jpg", image)[1].tobytes()


def read_qr_code(image: CV2Image) -> str | None:
    """
    __Summary__

    Reads the QR code from an image.

    __Arguments__

    * `image` (`CV2Image`): The image to be read.

    __Returns__

    * `str | None`: The access token if the QR code is valid, None otherwise.
    """

    detector = cv2.QRCodeDetector()
    data, _, _ = detector.detectAndDecode(image)
    if data:
        return data
