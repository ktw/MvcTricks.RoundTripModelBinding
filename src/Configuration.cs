using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcTricks.RoundTripModelBinding.Serialization;

namespace MvcTricks.RoundTripModelBinding
{

    /// <summary>
    /// The default configuration.
    /// </summary>
    public class Configuration
    {

        private static readonly object syncLock = new object();
        private static bool isSet = false;
        private static Configuration settings;
        private const StorageModes DEFAULT_STORAGE_MODE = StorageModes.Compress;


        /// <summary>
        /// Gets the encryption key. (Set this when using a web farm)
        /// </summary>
        public byte[] EncryptionKey { get; private set; }

        /// <summary>
        /// Gets the encryption IV.  (Set this when using a web farm)
        /// </summary>
        public byte[] EncryptionIV { get; private set; }
        
        /// <summary>
        /// Gets the storage mode for the model.
        /// </summary>
        public StorageModes StorageMode { get; private set; }
        
        /// <summary>
        /// Gets or sets the default configuration.
        /// </summary>
        /// <value>
        /// The default configuration.
        /// </value>
        public static Configuration Default
        {
            get
            {
                if (settings == null)
                {
                    lock (syncLock)
                    {
                        settings = new Configuration();
                    }
                }
                return settings;
            }
            set
            {
                if (value != null)
                {
                    if (!isSet)
                    {
                        lock (syncLock)
                        {
                            settings = value;
                            isSet = true;
                        }
                    }
                    else

                        throw new ArgumentException("The Settings property can only be set once!");
                }
                else
                    throw new ArgumentNullException();
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
            : this(DEFAULT_STORAGE_MODE, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="storageMode">The storage mode.</param>
        public Configuration(StorageModes storageMode)
            : this(storageMode, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="storageMode">The storage mode.</param>
        /// <param name="encryptionKey">The encryption key.</param>
        /// <param name="encryptionIV">The encryption IV.</param>
        public Configuration(StorageModes storageMode, byte[] encryptionKey, byte[] encryptionIV)
        {
            this.StorageMode = storageMode;
            if ((encryptionKey != null) || (encryptionIV != null))
            {
                this.EncryptionKey = encryptionKey;
                this.EncryptionIV = encryptionIV;
            }
            else
                SetDefaultEncryptionSettings();
        }

        private void SetDefaultEncryptionSettings()
        {
            this.EncryptionKey = Encoding.Default.GetBytes(Guid.NewGuid().ToString("N"));
            this.EncryptionIV = Encoding.Default.GetBytes(Guid.NewGuid().ToString("N").Substring(0, 16));                                    
        }

    }
}
