import sys

sys.path.append("..")


def detect_face_test():
    import os

    from modules.cv2_utils import (
        convert_to_grayscale,
        detect_faces_and_rotation,
        draw_faces,
        load_image,
        rotate_image,
        show_images,
    )

    test_image = "./samples/roman_cam.jpg"

    assert os.path.exists(test_image), "File does not exist!"

    image = load_image(test_image)
    grey_img = convert_to_grayscale(image)
    angle_n_faces = detect_faces_and_rotation(grey_img)
    fixed_image = rotate_image(image, angle_n_faces[0])
    face_coords = angle_n_faces[1]
    drawn_face = draw_faces(fixed_image, face_coords)

    show_images(drawn_face)


def calculate_age_test():
    from datetime import datetime, timedelta

    sample_dob = "22.09.2004"
    customer_dob = datetime.strptime(sample_dob, "%d.%m.%Y").date()
    age = (datetime.now().date() - customer_dob) // timedelta(days=365.2425)
    print(f"The calculated age is: {age}")


if __name__ == "__main__":
    calculate_age_test()
