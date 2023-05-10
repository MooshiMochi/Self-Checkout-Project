import os

import cv2
import numpy as np

from modules.cv2_utils import (
    FACE_DETECTION_MODEL,
    CV2Image,
    convert_to_grayscale,
    detect_faces_and_rotation,
    draw_faces,
    load_image,
    rotate_image,
)


# Path: modules\faceDetect.py
def get_face_embedding(face: CV2Image, model: cv2.dnn) -> np.ndarray:
    # Preprocess the face image
    face = cv2.cvtColor(face, cv2.COLOR_BGR2RGB)  # Convert to RGB color space
    face = cv2.resize(face, (96, 96))  # Resize to 96x96
    face = (face - 127.5) / 128  # Normalize pixel values to [-1, 1]

    # Get the face embedding
    blob = cv2.dnn.blobFromImage(
        np.float32(face), 1.0, (96, 96), (0, 0, 0), swapRB=True, crop=False
    )
    model.setInput(blob)
    embedding = model.forward()

    return embedding


def is_same_person(
    image_a: CV2Image,
    image_b: CV2Image,
    face_a_coords: list[tuple[int, int, int, int]],
    face_b_coords: list[tuple[int, int, int, int]],
    threshold: float = 0.6,
):
    # Get the first face in each image
    (x_a, y_a, w_a, h_a) = face_a_coords[0]
    (x_b, y_b, w_b, h_b) = face_b_coords[0]

    # Extract the face region from each image
    face_a = image_a[y_a : y_a + h_a, x_a : x_a + w_a]
    face_b = image_b[y_b : y_b + h_b, x_b : x_b + w_b]

    embedding_a = get_face_embedding(face_a, FACE_DETECTION_MODEL)
    embedding_b = get_face_embedding(face_b, FACE_DETECTION_MODEL)

    embedding_a = np.squeeze(np.asarray(embedding_a))
    embedding_b = np.squeeze(np.asarray(embedding_b))

    # Compare the face embeddings using cosine similarity
    similarity = np.dot(embedding_a, embedding_b) / (
        np.linalg.norm(embedding_a) * np.linalg.norm(embedding_b)
    )
    print(f"Image similarity: {similarity}")
    if similarity >= threshold:
        return True
    else:
        return False


if __name__ == "__main__":
    """
    The following code is used to test the face detection and recognition functions.
    It also shows how to use the functions.
    """

    parent_dir = os.path.pardir

    img_paths = [
        "test/samples/roman_dvla_id.jpg",
        "test/samples/roman_oyster_id.jpg",
        "test/samples/roman_cam.jpg",
        "test/samples/derek_mugshot.jpg",
        "test/samples/sarah_dvla.jpg",
        "test/samples/sarah_cam.jpg",
    ]
    img_paths = [os.path.join(parent_dir, path) for path in img_paths]
    for p in img_paths:
        assert os.path.exists(p), f"File {p} does not exist"

    images = [load_image(path) for path in img_paths]
    grey_images = [convert_to_grayscale(image) for image in images]
    angles_n_faces = [
        detect_faces_and_rotation(grey_image) for grey_image in grey_images
    ]
    fixed_images = [
        rotate_image(image, angle)
        for image, angle in zip(images, [angle for angle, _ in angles_n_faces])
    ]
    faces_coords = [faces for _, faces in angles_n_faces]
    grey_images = [convert_to_grayscale(face) for face in fixed_images]
    drawn_faces = [
        draw_faces(image, faces) for image, faces in zip(fixed_images, faces_coords)
    ]

    images_to_use = grey_images

    dvla_face, dvla_f_coords = images_to_use[0], faces_coords[0]
    oyster_face, oyster_f_coords = images_to_use[1], faces_coords[1]
    cam_face, cam_f_coords = images_to_use[2], faces_coords[2]
    derek_face, derek_f_coords = images_to_use[3], faces_coords[3]
    sarah_dvla_face, sarah_dvla_f_coords = images_to_use[4], faces_coords[4]
    sarah_cam_face, sarah_cam_f_coords = images_to_use[5], faces_coords[5]

    dvla_n_cam = is_same_person(dvla_face, cam_face, dvla_f_coords, cam_f_coords)
    print(f"Is Roman's DVLA ID the same person as his camera? {dvla_n_cam}")

    derek_n_cam = is_same_person(derek_face, cam_face, derek_f_coords, cam_f_coords)
    print(f"Is Derek's mugshot the same person as Roman's camera? {derek_n_cam}")

    camp_n_cam = is_same_person(cam_face, cam_face, cam_f_coords, cam_f_coords)
    print(f"Is Roman's camera the same person as Roman's camera? {camp_n_cam}")

    oyster_n_cam = is_same_person(oyster_face, cam_face, oyster_f_coords, cam_f_coords)
    print(f"Is Roman's Oyster ID the same person as Roman's camera? {oyster_n_cam}")

    oyster_n_dvla = is_same_person(
        oyster_face, dvla_face, oyster_f_coords, dvla_f_coords
    )
    print(f"Is Roman's Oyster ID the same person as Roman's DVLA ID? {oyster_n_dvla}")

    oyster_n_derek = is_same_person(
        oyster_face, derek_face, oyster_f_coords, derek_f_coords
    )
    print(f"Is Roman's Oyster ID the same person as Derek's mugshot? {oyster_n_derek}")

    sarah_dvla_n_sarah_cam = is_same_person(
        sarah_dvla_face, sarah_cam_face, sarah_dvla_f_coords, sarah_cam_f_coords
    )
    print(
        f"Is Sarah's DVLA ID the same person as Sarah's camera? {sarah_dvla_n_sarah_cam}"
    )
