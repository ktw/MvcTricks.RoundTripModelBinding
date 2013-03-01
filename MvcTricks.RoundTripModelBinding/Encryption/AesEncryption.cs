using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MvcTricks.RoundTripModelBinding.Encryption
{
    internal class AesEncryption
    {

        internal static byte[] Encrypt(byte[] data)
        {
            byte[] output = null;
            using (var aes = new AesManaged())
            {
                using (var encryptor = aes.CreateEncryptor(Configuration.Default.EncryptionKey, Configuration.Default.EncryptionIV))
                {
                    using (var dataStream = new MemoryStream())
                    {
                        using (var encryptionStream = new CryptoStream(dataStream, encryptor, CryptoStreamMode.Write))
                        {                            
                            encryptionStream.Write(data, 0, data.Length);
                            encryptionStream.FlushFinalBlock();
                            dataStream.Position = 0;
                            byte[] transformedBytes = new byte[dataStream.Length];
                            dataStream.Read(transformedBytes, 0, transformedBytes.Length);
                            encryptionStream.Close();
                            dataStream.Close();
                            output = transformedBytes;
                        }
                    }
                }
            }
            return output;
        }

        internal static byte[] Decrypt(byte[] data)
        {
            byte[] output = null;
            using (var aes = new AesManaged())
            {
                using (var decryptor = aes.CreateDecryptor(Configuration.Default.EncryptionKey, Configuration.Default.EncryptionIV))
                {
                    using (var dataStream = new MemoryStream())
                    {
                        using (var encryptionStream = new CryptoStream(dataStream, decryptor, CryptoStreamMode.Write))
                        {
                            encryptionStream.Write(data, 0, data.Length);
                            encryptionStream.FlushFinalBlock();
                            dataStream.Position = 0;
                            byte[] transformedBytes = new byte[dataStream.Length];
                            dataStream.Read(transformedBytes, 0, transformedBytes.Length);
                            encryptionStream.Close();
                            dataStream.Close();
                            output = transformedBytes;
                        }
                    }
                }
            }
            return output;
        }

    }
}
