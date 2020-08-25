using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VgNetDapperModels.RSAEncryption
{
    /// <summary>
    /// Helper Class to use BouncyCastle.Crypto dll [RSA encryption]
    /// </summary>
    public class RSAEncriptionHelpers
    {
        public const int VGEST_ENCODING_PAGE = 1252;
        /// <summary>
        /// Encripts Data using RSA methology with VisualGest Private Key
        /// </summary>
        /// <param name="plainText">string data to Encrypt</param>
        /// <returns></returns>
        public static string Encrypt(string plainText, int encodingPageNumber) //TODO:  = VGEST_ENCODING_PAGE
        {
            string executableLocation = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pemFilename = Path.Combine(executableLocation, "RSAEncryption\\VGestKeys\\vGestPrivateKey.pem");

            PemReader pr = new PemReader(
                (StreamReader)File.OpenText(pemFilename)
            );
            AsymmetricCipherKeyPair keys = (AsymmetricCipherKeyPair)pr.ReadObject();
            ISigner sig = SignerUtilities.GetSigner("SHA1withRSA");
            sig.Init(true, keys.Private);

            /* Get the bytes to be signed from the string */
            var bytes = Encoding.GetEncoding(encodingPageNumber).GetBytes(plainText);

            /* Calc the signature */
            sig.BlockUpdate(bytes, 0, bytes.Length);
            byte[] signature = sig.GenerateSignature();

            /* Base 64 encode the sig so its 8-bit clean */
            var signedString = Convert.ToBase64String(signature);

            return signedString;
        }

        /// <summary>
        /// Decrypts data using RSA methology with VisualGest PUBLIC KEY
        /// </summary>
        /// <param name="cipherText">string data to Decrypt</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, int encodingPageNumber = VGEST_ENCODING_PAGE)
        {
            string executableLocation = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pemFilename = Path.Combine(executableLocation, "RSAEncryption\\VGestKeys\\VGPubKey.pem");

            //string pemFilename = "RSAEncryption\\VGestKeys\\VGPubKey.pem";

            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            
            RsaKeyParameters keys;
            using (var reader = File.OpenText(pemFilename))
                keys = (RsaKeyParameters)new PemReader(reader).ReadObject();

            // Pure mathematical RSA implementation
            RsaEngine eng = new RsaEngine();

            // PKCS1 v1.5 paddings
            // Pkcs1Encoding eng = new Pkcs1Encoding(new RsaEngine());

            // PKCS1 OAEP paddings
            //OaepEncoding eng = new OaepEncoding(new RsaEngine());
            eng.Init(false, keys);

            int length = cipherTextBytes.Length;
            int blockSize = eng.GetInputBlockSize();
            List<byte> plainTextBytes = new List<byte>();
            for (int chunkPosition = 0;
                chunkPosition < length;
                chunkPosition += blockSize)
            {
                int chunkSize = Math.Min(blockSize, length - chunkPosition);
                plainTextBytes.AddRange(eng.ProcessBlock(
                    cipherTextBytes, chunkPosition, chunkSize
                ));
            }
            return Encoding.GetEncoding(encodingPageNumber).GetString(plainTextBytes.ToArray());
        }
    }
}
