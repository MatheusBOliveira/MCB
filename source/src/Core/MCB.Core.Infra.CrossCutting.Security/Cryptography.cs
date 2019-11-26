using MCB.Core.Infra.CrossCutting.Security.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MCB.Core.Infra.CrossCutting.ExtensionMethods;

namespace MCB.Core.Infra.CrossCutting.Security
{
    public class Cryptography 
        : ICryptography
    {
        // Properties
        public byte[] Key { get; set; }
        public byte[] SubKey { get; set; }

        // Contructors
        public Cryptography()
        {

        }
        public Cryptography(byte[] key, byte[] subKey)
        {
            Key = key;
            SubKey = subKey;
        }

        // Private Methods
        /*
         * https://docs.microsoft.com/pt-br/dotnet/api/system.security.cryptography.rijndael?view=netcore-3.0
         */
        private byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }
        private string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        // Public Methods
        public (byte[] hashByte, string hashString) Encrypt(string input)
        {
            try
            {
                byte[] encrypted;

                using (Rijndael myRijndael = Rijndael.Create())
                    encrypted = EncryptStringToBytes(input, Key, SubKey);

                return (encrypted, BitConverter.ToString(encrypted));
            }
            catch (Exception)
            {
                return (null, null);
            }
        }
        public string Decrypt(byte[] input)
        {
            try
            {
                var decrypted = string.Empty;

                using (Rijndael myRijndael = Rijndael.Create())
                    decrypted = DecryptStringFromBytes(input, Key, SubKey);

                return decrypted;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public (byte[] hashByte, string hashString) EncryptWithHash(string input, string key = null)
        {
            try
            {
                using (var sha512Hash = SHA512.Create())
                {
                    var data = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes($"{input}{key ?? ".!.@.#."}{input}"));
                    return (data, BitConverter.ToString(data));
                }
            }
            catch (Exception)
            {
                return (null, null);
            }
        }
    }
}


