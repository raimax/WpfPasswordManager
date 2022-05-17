using Crypto.AES;
using System.IO;

namespace PasswordManager
{
    public static class Encryption
    {
        public static string EncryptText(string text, string key)
        {
            return AES.EncryptString(key, text);
        }

        public static string DectyptString(string encryptedText, string key)
        {
            return AES.DecryptString(key, encryptedText);
        }

        public static FileInfo EncryptFile(string fileName, string key)
        {
            return AES.EncryptFile(key, fileName, "encrypted." + fileName);
        }

        public static FileInfo DecryptFile(string encryptedFileName, string key)
        {
            return AES.DecryptFile(key, encryptedFileName, encryptedFileName.Split("encrypted.")[1]);
        }
    }
}
