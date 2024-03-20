from flask import Flask, request
from pyngrok import ngrok
from datetime import datetime
import json
import requests
import subscriber

subscribers = {}

app = Flask(__name__)

@app.route('/')
def LandingPage():
    return "home"

@app.route('/subscribe', methods=['POST'])
def Subscribe():
    json_data = request.json
        
    tmp_index = len(subscribers)
    tmp_id = json_data.get('id')
    tmp_events = json_data.get('events')
    tmp_returnurl = json_data.get('returnurl')
        
    if (tmp_id == None or tmp_events == None or tmp_returnurl == None):
        return "Failed: Unexpected data provided in body"
        
    tmp_subscriber = subscriber.Subscriber(id=tmp_id, events=tmp_events, return_url=tmp_returnurl)
    
    with open("database.txt", "a") as file:
        file.write(json.dumps(json_data) + "," + "\n")
        
    subscribers[tmp_index] = tmp_subscriber
    return "subscribed"
    
@app.route('/unsubscribe', methods=['POST'])
def Unsubscribe():
    json_data = request.json
    subscriber_id = json_data.get('id')
    tmp_index = None
        
    for index, subscriber in subscribers.items():
        if subscriber.id == subscriber_id:
            tmp_index = index
            break
            
    if tmp_index != None:
        subscribers.pop(tmp_index)
        db_copy = ""
        for index, subscriber in subscribers.items():
            json_sub = json.dumps({"id": subscriber.id, "events": subscriber.events, "returnurl": subscriber.return_url})
            db_copy += json_sub + "," + "\n"
        with open("database.txt", "w") as file:
            file.write(db_copy)
        return "unsubscribed"
    else:
        return "subscriber id not found"
    
@app.route('/ping')
def PingAllSubscribers():
    urls = []
    
    for (key, subscriber) in subscribers.items():
        urls.append(subscriber.return_url)
    
    headers = {'Content-Type': 'application/json'}
    payload = {"date": str(datetime.now()), "total_subscribers": len(subscribers)}
    
    json_payload = json.dumps(payload)

    for returnurl in urls:
        try:
            requests.post(returnurl, data=json_payload, headers=headers)
        except:
            pass
    return "pinged"

def LoadSubscribersFromDatabase():
    with open("database.txt", "r") as file:
        content = file.read()
        if (content == ""):
            return
        subscribers_array = content.split(',\n')
        if (subscribers_array[-1] == ""):
            del subscribers_array[-1]
        for sub in subscribers_array:
            jsoned_subscriber = json.loads(sub)
            tmp_index = len(subscribers)
            tmp_id = jsoned_subscriber.get('id')
            tmp_events = jsoned_subscriber.get('events')
            tmp_returnurl = jsoned_subscriber.get('returnurl')
            tmp_subscriber = subscriber.Subscriber(id=tmp_id, events=tmp_events, return_url=tmp_returnurl)
            subscribers[tmp_index] = tmp_subscriber
    
        
if __name__ == '__main__':
    ngrok_tunnel = ngrok.connect(8888)
    print("Ngrok Tunnel URL:", ngrok_tunnel.public_url)
    
    # If any subscribers are found in the 'database', then add to subscribers dictionary.
    LoadSubscribersFromDatabase()

    app.run(port=8888)