using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace MvcTricks.RoundTripModelBinding.Compression
{
    internal class DeflateCompression
    {

        private const int DEFAULT_BUFFER_SIZE = 10240;

        internal static byte[] Compress(byte[] data)
        {
            byte[] output = null;
                    using (var dataStream = new MemoryStream())
                    {
                        using (var deflateStream = new DeflateStream(dataStream, CompressionMode.Compress))
                        {
                            deflateStream.Write(data, 0, data.Length);
                            deflateStream.Close();
                            output = dataStream.ToArray();
                        }
            }
            return output;
        }

        internal static byte[] Decompress(byte[] data)
        {
            var output = new List<byte[]>();
            using (var dataStream = new MemoryStream(data))
            {
                dataStream.Position = 0;
                using (var deflateStream = new DeflateStream(dataStream, CompressionMode.Decompress))
                {                        
                    var buffer = new byte[DEFAULT_BUFFER_SIZE];
                    int length;
                    int bytesRead = 0;
                    while ((length = deflateStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        output.Add(buffer.Take(length).ToArray());
                        bytesRead += length;
                    }
                }
            }
            return output.SelectMany(b => b).ToArray();
        }

    }
}
