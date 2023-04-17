import os

from cv2_utils import convert_to_grayscale, load_image, rotate_image
from faceDetect import detect_faces_and_rotation, is_same_person

if __name__ == "__main__":
    img_paths = [
        "./samples/roman_dvla_id.jpg",
        "./samples/roman_oyster_id.jpg",
        "./samples/roman_cam.jpg",
        "./samples/derek_mugshot.jpg",
    ]

    customer_document = "../test/samples/roman_dvla_id.jpg"
    cam_img_bytes = "../test/samples/roman_cam.jpg"

    assert os.path.exists(customer_document), "Customer document not found."
    assert os.path.exists(cam_img_bytes), "Camera image not found."

    images = [load_image(customer_document), load_image(cam_img_bytes)]
    gray_images = [convert_to_grayscale(image) for image in images]
    angles_n_faces = [
        detect_faces_and_rotation(gray_image) for gray_image in gray_images
    ]
    rotated_images = [
        rotate_image(image, angle_n_face[0])
        for image, angle_n_face in zip(images, angles_n_faces)
    ]
    face_coords = [angle_n_face[1] for angle_n_face in angles_n_faces]

    if not face_coords[0] or not face_coords[1]:
        raise Exception("No faces found in the images.")

    same_person: bool = is_same_person(
        rotated_images[0], rotated_images[1], face_coords[0], face_coords[1]
    )

    assert same_person == True
    print("Same person!")
