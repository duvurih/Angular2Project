using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hk.Utilities.Utilities
{
    public class CryptoService: ICrypto
    {
        byte[] bytes = ASCIIEncoding.ASCII.GetBytes("HKApp");

        public CryptoService()
        {

        }

        public string Encrypt(string toEncrypt)
        {
            if (String.IsNullOrEmpty(toEncrypt))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }

            using (DESCryptoServiceProvider cryptoProvier = new DESCryptoServiceProvider())
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvier.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write))
                    {
                        using (StreamWriter write = new StreamWriter(cryptoStream))
                        {
                            write.Write(toEncrypt);
                            write.Flush();
                            cryptoStream.FlushFinalBlock();
                            write.Flush();
                            byte[] encryptedData = memoryStream.ToArray();

                            string urlEncoded = HttpServerUtility.UrlTokenEncode(encryptedData);
                            return urlEncoded;
                        }
                    }
                }
            }
        }

        public string Decrypt(string encryptedData)
        {
            if (String.IsNullOrEmpty(encryptedData))
            {
                throw new ArgumentNullException("This string which needs to be decrypted can not be null.");
            }
            byte[] urlDecoded = HttpServerUtility.UrlTokenDecode(encryptedData);

            using (DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider())
            {
                using (MemoryStream memoryStream = new MemoryStream(urlDecoded))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            string decrypted = reader.ReadToEnd();
                            return decrypted;
                        }
                    }
                }
            }

        }
    }
}
