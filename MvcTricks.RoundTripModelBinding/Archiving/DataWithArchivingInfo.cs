using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTricks.RoundTripModelBinding.Archiving
{
    internal class DataWithArchivingInfo
    {

        internal bool IsEncrypted { get; private set; }
        internal byte[] Data { get; private set; }
        internal StorageModes Mode { get; private set; }

        internal static DataWithArchivingInfo FromProcessedData(byte[] data)
        {
            return new DataWithArchivingInfo()
            {
                IsEncrypted = true,
                Data = RemoveModeFromData(data),
                Mode = GetModeFromData(data)
            };
        }

        internal static DataWithArchivingInfo FromUnprocessedData(byte[] data, StorageModes mode)
        {
            return new DataWithArchivingInfo()
            {
                IsEncrypted = false,
                Data = AddModeToData(data, mode),
                Mode = mode
            };
        }

        private static StorageModes GetModeFromData(byte[] data)
        {
            return (StorageModes)data[data.Length - 1];
        }

        private static byte[] AddModeToData(byte[] data, StorageModes mode)
        {
            var output = new byte[data.Length + 1];
            output[data.Length] = (byte)mode;
            data.CopyTo(output, 0);
            return output;
        }

        private static byte[] RemoveModeFromData(byte[] data)
        {
            var output = new byte[data.Length - 1];
            Buffer.BlockCopy(data, 0, output, 0, output.Length);
            return output;
        }

    }
}
