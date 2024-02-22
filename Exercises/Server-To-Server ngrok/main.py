from flask import Flask
from datetime import datetime

app = Flask(__name__)

@app.route('/')
def LandingPage():
    return str(datetime.now())

if __name__ == '__main__':
    app.run(port=8000)
