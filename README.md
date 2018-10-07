# Platform_usage
## Step 1: Base Functions
Use sample code of base functions [C#](https://github.com/RohamAI/Platform_usage/blob/master/C%23/Base_Functions.cs), [Python](https://github.com/RohamAI/Platform_usage/blob/master/Python/Base_Functions.py).
## Step 2: Call RESTful API
Use sample code of how to call AI APIs [C#](https://github.com/RohamAI/Platform_usage/blob/master/C%23/Call%20RESTful.cs), [Python](https://github.com/RohamAI/Platform_usage/blob/master/Python/Call%20RESTful.py).
### URLs and SignedData:
#### Speech Recognition API 
```
Url: http://api.rohamai.com/api/v1/ASR/Recognize
SignedData Template: Language#Now
```
#### Text To Speech API
```
Url: http://api.rohamai.com/api/v1/TTS/TextToSpeech
SignedData Template: Language#true#Text#Now
```
#### Face Recognition API
```
Url: http://api.rohamai.com/api/v1/Face/FaceVerification 
SignedData Template: Language#ActionID#PicCount#Now 
```

#### Chatbot API
```
Url: http://api.rohamai.com/api/v1/UND/GetAnswer
SignedData Template: Language#CommandType#Command#Now
```
## Step 3: Output Template
#### Text To Speech Output Template:
```
{
  Url:"Sound Output Url"
}
```
#### Speech Recognition Output Template.
```
{
  Text:"Text of your voice",
  Phonetic:"Phonetic of text"
}
```
#### Face Recognition Output Template.
```
{
  ResultIndex:  int,
  ResultMessage:  "Message of ResultIndex",
  SimilarPercent:  double  // Similar Percent of 2 Photos
}
```
#### Chatbot Output Template.
```
{
  Response:
    [
      {  ActionID  :  "ID of Action",
         SubActionID  :  "ID of SubAction",
         SpeakerText:  "User Command",
         TypeOf:  "Type of response body",
         Parameters:  "Parameters that fetch from command",
         ResponseBody:  object
      }
    ]  
}
```
