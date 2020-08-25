using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VgNetDapperDataExtended.Helpers
{
    internal static class Security
    {        
        /// <summary>
        /// Encripta uma string com o algoritmo Visualgest
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string VgEncrypt(string text)
        {
            string result = string.Empty;
            int asciiCode = 0;
            int salt = 10;
            foreach (char c in text.ToArray())
            {
                asciiCode = (int)c;
                salt = asciiCode <= 245 ? 10 : -246;
                //if(asciiCode <= 245)
                //{
                //    if(asciiCode <= 116)
                //    {
                //        salt = 10;
                //    }
                //    else
                //    {
                //        salt = asciiCode > 116 && asciiCode <= 126 ? 44 : 0;
                //    }
                //}
                //else
                //{
                //    salt = -246;
                //}
                result = Convert.ToChar(asciiCode + salt) + result;
            }
            return result;
        }

        /// <summary>
        /// Desincripta uma string codificada com algoritmo Visualgest
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        internal static string VgDecrypt(string code)
        {
            string result = string.Empty;
            int asciiCode = 0;
            int salt = 10;
            foreach (char c in code.ToArray())
            {
                asciiCode = (int)c;
                salt = asciiCode >= 10 ? -10 : 246;
                //if(asciiCode >= 10)
                //{
                //    if(asciiCode <= 126)
                //    {
                //        salt = -10;
                //    }
                //    else
                //    {
                //        salt = asciiCode > 159 && asciiCode <= 169 ? -44 : 0;
                //    }
                //}
                //else
                //{
                //    salt = 246;
                //}

                result = Convert.ToChar(asciiCode + salt) + result;
            }
            return result;
        }

        /// <summary>
        /// Devolve a string indicada com o prefixo de tamanho 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefixSize"></param>
        /// <returns></returns>
        internal static string ReadVgStr(string str, int prefixSize = 2)
        {
            int strSize = 0;
            if (Int32.TryParse(str.Substring(0, prefixSize), out strSize))
                return str.Substring(prefixSize, strSize);
            else
                return string.Empty;
        }

        /// <summary>
        /// Cria o Hash através do algoritmo SHA512 para uma password em texto
        /// </summary>
        /// <param name="passwordInClearText">Password</param>
        /// <param name="saltValue">Salt</param>
        /// <returns>Representação em string do Hash</returns>
        internal static string HashPasswordBySHA512(string passwordInClearText, string saltValue)
        {
            int saltValueSize = saltValue.Length;
            UnicodeEncoding encoding = new UnicodeEncoding();
            HashAlgorithm hash = HashAlgorithm.Create("SHA512");

            if (passwordInClearText != null && hash != null && encoding != null)
            {
                if (saltValue == null)
                {
                    saltValueSize = 8;
                    saltValue = GenerateSalt(saltValueSize);
                }

                // Converter salt para byte
                byte[] binarySaltValue = System.Text.ASCIIEncoding.UTF8.GetBytes(saltValue);

                // Converter password para byte
                byte[] valueToHash = new byte[saltValueSize + encoding.GetByteCount(passwordInClearText)];
                byte[] binaryPassword = encoding.GetBytes(passwordInClearText);

                // Copiar o valor de salt e da password para o buffer
                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, saltValueSize);

                byte[] hashValue = hash.ComputeHash(valueToHash);

                // hash password
                string hashedPassword = null;
                foreach (byte hexdigit in hashValue)
                {
                    hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }

                // Return the hashed password as a string.
                return hashedPassword;
            }

            return null;
        }

        /// <summary>
        /// Geração aleatória do Salt
        /// </summary>
        /// <param name="saltSize">salt byte size</param>
        /// <returns></returns>
        internal static string GenerateSalt(int saltSize)
        {
            ASCIIEncoding charSet = new ASCIIEncoding();
            byte[] salt = new Byte[saltSize];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);
            return charSet.GetString(salt);
        }

        /// <summary>
        /// Cria o salt através da data e hora
        /// </summary>
        /// 
        internal static string GenerateSalt(DateTime date)
        {
            char hours = (char)(date.Hour + 64);
            char minutes = (char)(date.Minute + 65);
            char seconds = (char)(date.Second + 66);
            string time = hours.ToString() + minutes.ToString() + seconds.ToString();
            return date.ToString("yyMdd") + time;
        }

        /// <summary>
        /// Verifica se uma password digitada é tem o hash igual ao guardado
        /// </summary>
        /// <param name="inputedClearTextPass">password digitada</param>
        /// <param name="savedHashedPass">hash gravado</param>
        /// <param name="salt"></param>
        /// <returns>Verdadeiro se a password indicada gerar o mesmo hash, senão falso</returns>
        internal static bool CheckPassword(string inputedClearTextPass, string savedHashedPass, string salt)
        {
            string hashPassToCheck = HashPasswordBySHA512(inputedClearTextPass, salt);
            return Equals(hashPassToCheck, savedHashedPass);
        }
    }
}
