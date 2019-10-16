using System;
using System.Security.Cryptography;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Security
{
    public class Cryptography
    {
        // Properties
        public string Key { get; set; }

        // Contructors
        public Cryptography()
        {

        }
        public Cryptography(string key)
        {
            Key = key;
        }

        // Private Methods
        private TripleDESCryptoServiceProvider GetTripleDESCryptoServiceProvider()
        {
            var keyByteArray = new byte[16];
            for (var i = 0; i < 16; i += 2)
            {
                var unicodeBytes = BitConverter.GetBytes(Key[i % Key.Length]);
                Array.Copy(unicodeBytes, 0, keyByteArray, i, 2);
            }

            var serviceProvider = new TripleDESCryptoServiceProvider
            {
                Key = keyByteArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            return serviceProvider;
        }

        // Public Methods
        public string Encrypt(string input)
        {
            try
            {
                var toEncryptArray = UTF8Encoding.UTF8.GetBytes(input);
                var serviceProvider = GetTripleDESCryptoServiceProvider();
                var transform = serviceProvider.CreateEncryptor();
                var resultArray = transform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                serviceProvider.Clear();

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public string Decrypt(string input)
        {
            try
            {
                var toEncryptArray = Convert.FromBase64String(input);
                var serviceProvider = GetTripleDESCryptoServiceProvider();
                var transform = serviceProvider.CreateDecryptor();
                var resultArray = transform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                serviceProvider.Clear();

                return Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public string EncryptWithHash(string input)
        {
            try
            {
                using (var md5Hash = MD5.Create())
                {
                    var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes($"{input}.!.@.#.{input}"));
                    var hashStringBuilder = new StringBuilder();

                    for (var i = 0; i < data.Length; i++)
                    {
                        hashStringBuilder.Append(data[i].ToString("x2"));
                    }

                    return hashStringBuilder.ToString();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}


