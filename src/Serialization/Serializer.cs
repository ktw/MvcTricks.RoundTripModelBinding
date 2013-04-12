using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;

namespace MvcTricks.RoundTripModelBinding.Serialization
{
    internal class Serializer
    {

        static Serializer()
        {
            JsConfig<System.Net.Mail.MailAddress>.SerializeFn = a => a.ToString();
            JsConfig<System.Net.Mail.MailAddress>.DeSerializeFn = a => { return new System.Net.Mail.MailAddress(a); };

            JsConfig<System.Net.IPAddress>.SerializeFn = a => a.ToString();
            JsConfig<System.Net.IPAddress>.DeSerializeFn = a => { return System.Net.IPAddress.Parse(a); };

        }

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
