using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.IO;
using MvcTricks.RoundTripModelBinding.Compression;
using MvcTricks.RoundTripModelBinding.Encryption;

namespace MvcTricks.RoundTripModelBinding.Archiving
{
   
    internal class Archiver
    {

        internal static string Archive(string text, StorageModes mode)
        {
            var data = Encoding.UTF8.GetBytes(text);
            byte[] archivedData = null;
            switch (mode)
            {
                case StorageModes.CompressAndEncrypt:
                    archivedData = AesEncryption.Encrypt(DeflateCompression.Compress(data));
                    break;
                case StorageModes.Compress:
                    archivedData = DeflateCompression.Compress(data);
                    break;
                case StorageModes.Store:
                    archivedData = data;
                    break;
            }
            var dataWithEncryptionInfo = DataWithArchivingInfo.FromUnprocessedData(archivedData, mode);
            return Convert.ToBase64String(dataWithEncryptionInfo.Data);
        }

        internal static string Unarchive(string text)
        {
            var data = Convert.FromBase64String(text);
            byte[] unarchivedData = null;
            var dataWithEncryptionInfo = DataWithArchivingInfo.FromProcessedData(data);
            var mode = dataWithEncryptionInfo.Mode;
            switch (mode)
            {
                case StorageModes.CompressAndEncrypt:
                    unarchivedData = DeflateCompression.Decompress(AesEncryption.Decrypt(dataWithEncryptionInfo.Data));
                    break;
                case StorageModes.Compress:
                    unarchivedData = DeflateCompression.Decompress(dataWithEncryptionInfo.Data);
                    break;
                case StorageModes.Store:
                    unarchivedData = dataWithEncryptionInfo.Data;
                    break;
            }
            return Encoding.UTF8.GetString(unarchivedData);
        }
    }

}
