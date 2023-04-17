
import requests

r = requests.get("http://127.0.0.1:8000/load?username=test@test123.test")

print(r.status_code)

print(r.json())