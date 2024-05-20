from flask import Flask, redirect, url_for, session, request
from pyngrok import ngrok
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import Flow
from google_auth_oauthlib.flow import InstalledAppFlow
import json
import os 
os.environ['OAUTHLIB_INSECURE_TRANSPORT'] = '1' # Makes oauth2 able to run on http instead of raising exception, as oauth2 MUST run on https.

CLIENT_ID = ''
CLIENT_SECRET = ''
CLIENT_SECRET_FILE = "client_secret.json"
SCOPES = ['openid', 'https://www.googleapis.com/auth/userinfo.profile', 'https://www.googleapis.com/auth/userinfo.email']
app = Flask(__name__)
app.secret_key = b'_5#y2L"F4Q8z\n\xec]/'

@app.route('/')
def home():
    return 'Oauth example page'

@app.route('/login')
def login():
    global SECRET_TOKEN
    # Create google flow object, using client_secret.json file - provided when you signed up on google for oauth access.
    flow = InstalledAppFlow.from_client_secrets_file(CLIENT_SECRET_FILE, scopes=SCOPES)
    flow.redirect_uri = url_for('callback', _external=True)
    authorization_url, state = flow.authorization_url(access_type='offline', prompt='select_account')

    session['state'] = state # Save the token from google
    SECRET_TOKEN = session['state']
    return redirect(authorization_url) # this is the /callback - also the one written in google oauth

@app.route('/callback')
def callback():
    # Create google flow object, but this time also use the state token we recieved from login.
    flow = InstalledAppFlow.from_client_secrets_file(CLIENT_SECRET_FILE, scopes=SCOPES, state=session['state'])
    flow.redirect_uri = url_for('callback', _external=True)
    flow.fetch_token(authorization_response=request.url) # This line fetches the access token and other credentials from the OAuth provider (google)

    return redirect(url_for('index'))

@app.route('/index')
def index():
    try:
      print(SECRET_TOKEN)
      return "This is the secret page"
    except:
      return "You are not logged in!"

if __name__ == '__main__':
    # Read creds from client_secret.json
    with open('client_secret.json', 'r') as f:
        client_secret_data = json.load(f)
        CLIENT_ID = client_secret_data['web']['client_id']
        CLIENT_SECRET = client_secret_data['web']['client_secret']

    app.run()