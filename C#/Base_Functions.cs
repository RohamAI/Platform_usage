private static string StandardKey(string Key)
{
    var ret = Regex.Replace(Key, "[^a-zA-Z0-9]", "");
    return ret.Substring(0,16);
}

private static string Encrypt(string input, string key)
{
    byte[] inputArray = Encoding.UTF8.GetBytes(input);
    AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
    string _Key = StandardKey(key);
    AES.KeySize = 256;
    AES.BlockSize = 128;
    AES.Mode = CipherMode.ECB;
    AES.Padding = PaddingMode.PKCS7;
    AES.GenerateKey();
    AES.Key = Encoding.ASCII.GetBytes(_Key);
    ICryptoTransform cTransform = AES.CreateEncryptor();
    byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
    AES.Clear();
    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
}

private string GetSignedData(string _toHash , string PrivateKey)
{
    string _SignData = Encrypt(_toHash, PrivateKey);
    return _SignData;
}