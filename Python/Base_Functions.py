import re
import base64
from Crypto.Cipher import AES
from pkcs7 import PKCS7Encoder
def standard_key(key):
   return re.sub(r'\W+', '', key)[:16]

def Encrypt(input_string, key):
   _key = standard_key(key)
   input_string = input_string.encode(encoding="utf-8")
   aes = AES.new(standard_key(_key), AES.MODE_ECB)
   aes.block_size = 128
   return base64.b64encode(aes.encrypt(PKCS7Encoder().encode(input_string)))

def GetSignedData(_toHash , PrivateKey):
   _SignData = Encrypt(_toHash, PrivateKey)
   return _SignData