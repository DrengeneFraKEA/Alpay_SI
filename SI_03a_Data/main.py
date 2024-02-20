from flask import Flask
import requests

net_endpoint = "http://localhost:5298/SI02a/"

app = Flask(__name__)

@app.route('/')
def Home():
    return "Hello, World!"

@app.route('/txt')
def Txt():
    url = net_endpoint + "txt"
    return requests.get(url).text
    
@app.route('/xml')
def Xml():
    url = net_endpoint + "xml"
    return requests.get(url).text

@app.route('/csv')
def Csv():
    url = net_endpoint + "csv"
    return requests.get(url).text

@app.route('/yaml')
def Yaml():
    url = net_endpoint + "yaml"
    return requests.get(url).text

@app.route('/json')
def Json():
    url = net_endpoint + "json"
    return requests.get(url).text

if __name__ == '__main__':
    app.run(port=8000)