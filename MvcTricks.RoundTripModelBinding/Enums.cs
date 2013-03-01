using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTricks.RoundTripModelBinding
{
    /// <summary>
    /// Storage modes for the model.
    /// </summary>
    public enum StorageModes : byte
    {
        /// <summary>
        /// Stored only, bigger output, but fastest.
        /// </summary>
        Store = 0,
        /// <summary>
        /// Copressed output.
        /// </summary>
        Compress = 1,
        /// <summary>
        /// Compressed and encrypted output.
        /// </summary>
        CompressAndEncrypt = 2
    }
}
