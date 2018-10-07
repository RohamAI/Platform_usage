public async void GetVoiceOfText()
{       
    MultipartFormDataContent _sendData = new MultipartFormDataContent();
    HttpResponseMessage _res;
    string PrivateKey = "XXXXXXX";      //Private key is here
    string PublicKey = "XYXYXYXYXY";    //Public key is here
    string Data = "fa#true#Your text here.#" + DateTime.Now.ToString("yyyyMMddhhmmssFFF");
    string SignedData = GetSignedData(Data, PrivateKey);
    _sendData.Add(new StringContent(SignedData), "SignedData");
    _sendData.Headers.Add("Public-Key", PublicKey);
    try
    {
        HttpClient http = new HttpClient();
        MultipartFormDataContent form = _sendData;
        _res = await http.PostAsync(URL, form);
        _res.EnsureSuccessStatusCode();
        http.Dispose();
        if (_res.IsSuccessStatusCode)
        {
            string data = await _res.Content.ReadAsStringAsync();
            var json = Newtonsoft.Json.Linq.JObject.Parse(data);
            lblResponseCommand.Text= json["Url"].Value<string>();
        }
        else
        {
            //Error Handle
        }
    }
    catch (Exception ex)
    {
        //Exception Handle
    }
}