import datetime
import requests
def GetVoiceOfText(text):
   PrivateKey = "XXXXXXXXXXXXXXXX"          # Private key is here
   PublicKey = "XXXXXXXXXXXXXXXXXXXXXXXXX"  # Public key is here
   Data = "fa#true#" + text + "#" + datetime.datetime.now().strftime("%Y%m%d%I%M%S%f")[:-3]
   SignedData = GetSignedData(Data, PrivateKey)
   r = requests.post('http://api.rohamai.com/api/v1/TTS/TextToSpeech',
                 headers={'Content-Type': 'multipart/form-data',
                          'Accept': 'application/json', 'Public-Key': PublicKey},
                 params={'SignedData': SignedData})
    return r.json()