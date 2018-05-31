using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;

public class GameSaveDataController : MonoBehaviour
{

	public string fileName = "";
	public string key = "";

	void Awake ()
	{
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public string getSaveDataContent ()
	{
		string gameDataFile = GetDataPath () + "/" + fileName;
		StreamReader sReader = File.OpenText (gameDataFile);
		string dataString = sReader.ReadToEnd ();
		sReader.Close ();
		string dataStr = AESDecrypt (dataString, key);
		return dataStr;
	}

	public void saveData (string dataStr)
	{
		string aesStr = AESEncrypt (dataStr, key);
		StreamWriter writer;
		writer = File.CreateText (GetDataPath () + "/" + fileName);
		writer.Write (aesStr);
		writer.Close ();
	}

	public bool isSaveDataExist ()
	{
		return File.Exists (GetDataPath () + "/" + fileName);
	}

	private static string GetDataPath ()
	{
		return Application.persistentDataPath;
	}

	public static string AESEncrypt (string Data, string Key)
	{  
		MemoryStream mStream = new MemoryStream ();  
		RijndaelManaged aes = new RijndaelManaged ();  

		byte[] plainBytes = Encoding.UTF8.GetBytes (Data);  
		byte[] bKey = new byte[32];
		Array.Copy (Encoding.UTF8.GetBytes (Key.PadRight (bKey.Length)), bKey, bKey.Length);  

		aes.Mode = CipherMode.ECB;  
		aes.Padding = PaddingMode.PKCS7;  
		aes.KeySize = 128;  
		//aes.Key = _key;  
		aes.Key = bKey;  
		//aes.IV = _iV;  
		CryptoStream cryptoStream = new CryptoStream (mStream, aes.CreateEncryptor (), CryptoStreamMode.Write);  
		try {  
			cryptoStream.Write (plainBytes, 0, plainBytes.Length);  
			cryptoStream.FlushFinalBlock ();  
			return Convert.ToBase64String (mStream.ToArray ());  
		} finally {  
			cryptoStream.Close ();  
			mStream.Close ();  
			aes.Clear ();  
		}  
	}

	public static string AESDecrypt (String Data, String Key)
	{  
		Byte[] encryptedBytes = Convert.FromBase64String (Data);  
		Byte[] bKey = new Byte[32];  
		Array.Copy (Encoding.UTF8.GetBytes (Key.PadRight (bKey.Length)), bKey, bKey.Length);  

		MemoryStream mStream = new MemoryStream (encryptedBytes);  
		//mStream.Write( encryptedBytes, 0, encryptedBytes.Length );  
		//mStream.Seek( 0, SeekOrigin.Begin );  
		RijndaelManaged aes = new RijndaelManaged ();  
		aes.Mode = CipherMode.ECB;  
		aes.Padding = PaddingMode.PKCS7;  
		aes.KeySize = 128;  
		aes.Key = bKey;  
		//aes.IV = _iV;  
		CryptoStream cryptoStream = new CryptoStream (mStream, aes.CreateDecryptor (), CryptoStreamMode.Read);  
		try {  
			byte[] tmp = new byte[encryptedBytes.Length + 32];  
			int len = cryptoStream.Read (tmp, 0, encryptedBytes.Length + 32);  
			byte[] ret = new byte[len];  
			Array.Copy (tmp, 0, ret, 0, len);  
			return Encoding.UTF8.GetString (ret);  
		} finally {  
			cryptoStream.Close ();  
			mStream.Close ();  
			aes.Clear ();  
		}  
	}
}
