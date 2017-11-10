using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Ciphering
/// </summary>
public static class Ciphering
{
    private static string EncryptionKey = "MAKV2SPBNI9921245";

    public static string Encrypt(string clearText)
    {
        string EncryptedText = string.Empty;
        byte[] ClearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes Encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            Encryptor.Key = pdb.GetBytes(32);
            Encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, Encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(ClearBytes, 0, ClearBytes.Length);
                    cs.Close();
                }
                EncryptedText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return EncryptedText;
    }

    public static string Decrypt(string CipherText)
    {
        string DecryptedText = string.Empty;
        CipherText = CipherText.Replace(" ", "+");
        byte[] CipherBytes = Convert.FromBase64String(CipherText);
        using (Aes Encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            Encryptor.Key = pdb.GetBytes(32);
            Encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, Encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(CipherBytes, 0, CipherBytes.Length);
                    cs.Close();
                }
                DecryptedText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return DecryptedText;
    }
}