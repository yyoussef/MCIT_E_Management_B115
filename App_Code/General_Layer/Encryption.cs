using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for Encryption
/// </summary>
public class Encryption
{
	public Encryption()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string Decrypt(string pstrText)
    {
        pstrText = pstrText.Replace(" ", "+");

        string pstrDecrKey = "1239;[pewGKG)NisarFidesTech";
        byte[] byKey = { };
        byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
        byte[] inputByteArray = new byte[pstrText.Length];

        byKey = System.Text.Encoding.UTF8.GetBytes(pstrDecrKey.Substring(0, 8));
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        inputByteArray = Convert.FromBase64String(pstrText);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        return encoding.GetString(ms.ToArray());
    }
    public static string Encrypt(string pstrText)
    {
        string pstrEncrKey = "1239;[pewGKG)NisarFidesTech";
        byte[] byKey = { };
        byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
        byKey = System.Text.Encoding.UTF8.GetBytes(pstrEncrKey.Substring(0, 8));
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] inputByteArray = Encoding.UTF8.GetBytes(pstrText);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return Convert.ToBase64String(ms.ToArray());
    }

}
