using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTricks.RoundTripModelBinding.TypeManagement
{
    internal class TypeManager
    {

        private static readonly object syncLock = new object();
        private static Dictionary<string, string> typeIdentifiers = new Dictionary<string, string>();

        internal static string GetTypeId(Type type)
        {
            string id = null;
            lock (syncLock)
            {
                if (!typeIdentifiers.ContainsKey(type.FullName))
                {
                    var b64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(type.FullName));
                    typeIdentifiers.Add(type.FullName, b64);
                }
                id = typeIdentifiers[type.FullName];
            }
            return id;
        }

    }
}
