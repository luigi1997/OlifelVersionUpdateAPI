using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CryptographyAES
{
    /// <summary>
    /// Classe de apoio para criptografia AES (Advanced Encryption Standard (AES)) 
    /// </summary>
    public static class AESCypher
    {
        /// <summary>
        /// Niveis de criptografia AES
        /// Criptografia de 128, 192 e 256 Bits.
        /// </summary>
        public enum AESCryptographyLevel : int
        {
            /// <summary>
            /// Criptografia AES 128 Bits
            /// </summary>
            AES_128 = 128,

            /// <summary>
            /// Criptografia AES 192 Bits
            /// </summary>
            AES_192 = 192,

            /// <summary>
            /// Criptografia AES 256 Bits
            /// </summary>
            AES_256 = 256
        }

        #region Private
        // Encrypt a byte array into a byte array using a key and an IV 
        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {

            // Create a MemoryStream that is going to accept the encrypted bytes 
            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();
            alg.Key = Key;

            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        // Decrypt a byte array into a byte array using a key and an IV 
        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {

            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }


        #endregion

        #region Public
        /// <summary>
        /// Criptografa string usando Rijndael (128,192,256 Bits).
        /// </summary>
        /// <param name="data">string a ser criptografada</param>
        /// <param name="password">senha de criptografia</param>
        /// <param name="bits">Nível de criptografia (128,192,256 bits)</param>
        /// <returns>string criptografada</returns>
        public static string Encrypt(string data, string password, AESCryptographyLevel bits)
        {


            byte[] clearBytes = Encoding.Unicode.GetBytes(data);


            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,


                new byte[] { 0x00, 0x01, 0x02, 0x1C, 0x1D, 0x1E, 0x03, 0x04, 0x05, 0x0F, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });


            if (bits == AESCryptographyLevel.AES_128)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else if (bits == AESCryptographyLevel.AES_192)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else if (bits == AESCryptographyLevel.AES_256)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else
            {
                return string.Concat(bits);
            }
        }

        /// <summary>
        /// Descriptografa string usando Rijndael (128,192,256 Bits).
        /// </summary>
        /// <param name="data">string a ser descriptografada</param>
        /// <param name="password">senha de descriptografia</param>
        /// <param name="bits">Nível de descriptografia (128,192,256 bits)</param>
        /// <returns>string descriptografada</returns>
        public static string Decrypt(string data, string password, AESCryptographyLevel bits)
        {
            byte[] cipherBytes = Convert.FromBase64String(data);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,

                new byte[] { 0x00, 0x01, 0x02, 0x1C, 0x1D, 0x1E, 0x03, 0x04, 0x05, 0x0F, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });

            if (bits == AESCryptographyLevel.AES_128)
            {
                byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                return Encoding.Unicode.GetString(decryptedData);
            }
            else if (bits == AESCryptographyLevel.AES_192)
            {
                byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                return Encoding.Unicode.GetString(decryptedData);
            }
            else if (bits == AESCryptographyLevel.AES_256)
            {
                byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return Encoding.Unicode.GetString(decryptedData);
            }
            else
            {
                return string.Concat(bits);
            }

        }

        #endregion



    }
}
