from flask import Flask, request
from pyngrok import ngrok
from datetime import datetime
import json
import requests
import subscriber

app = Flask(__name__)

@app.route('/', methods=['POST'])
def MyEndpoint():
    payload = request.json
    print(payload)
    return "home"

if __name__ == '__main__':
    ngrok_tunnel = ngrok.connect(6666)
    print("Ngrok Tunnel URL:", ngrok_tunnel.public_url)
    app.run(port=6666)
