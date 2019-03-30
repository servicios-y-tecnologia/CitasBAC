using BAC.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appcitas.Services
{
    public static class CryptoService
    {
        public static string Decryt(string data)
        {
            string dataDecrypted = string.Empty;
            CryptoAes aes = new CryptoAes("8@c9@n@m@");
            try
            {
                if (data != null)
                {
                    if (data.Trim().Length != 0)
                        dataDecrypted = aes.Decrypt(data);
                }
            }
            catch
            {
                dataDecrypted = "Error en Decrypt";
            }
            return dataDecrypted;
        }
        public static string Encrypt(string data)
        {
            string dataEncrypted = string.Empty;
            CryptoAes aes = new CryptoAes("8@c9@n@m@");
            try
            {
                if (data != null)
                {
                    if (data.Trim().Length != 0)
                        dataEncrypted = aes.Encrypt(data);
                }
            }
            catch
            {
                dataEncrypted = "Error en Encrypt";
            }
            return dataEncrypted;
        }
    }
}