using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;

namespace MvcTricks.RoundTripModelBinding.Serialization
{
    internal class Serializer
    {

        internal static string Serialize(object data)
        {
            return TypeSerializer.SerializeToString(data);
        }

        internal static T Deserialize<T>(string data)
        {
            return TypeSerializer.DeserializeFromString<T>(data);
        }

        internal static object Deserialize(string data, Type targetType)
        {
            return TypeSerializer.DeserializeFromString(data, targetType);
        }

    }
}
