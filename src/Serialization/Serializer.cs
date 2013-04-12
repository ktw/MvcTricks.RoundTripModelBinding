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
            // Register the common troublemakers:
            RegisterHandler<System.Net.Mail.MailAddress>(
                s => { return s.ToString(); }, 
                d => { return new System.Net.Mail.MailAddress(d); }
            );
            RegisterHandler<System.Net.IPAddress>(
                s => { return s.ToString(); },
                d => { return System.Net.IPAddress.Parse(d); }
            );
        }

        internal static void RegisterHandler<T>(Func<T, string> serializer, Func<string, T> deserializer)
        {
            JsConfig<T>.SerializeFn = s => { return ((serializer == null) ? null : serializer(s)); };
            JsConfig<T>.DeSerializeFn = d => { return ((deserializer == null) ? default(T) : deserializer(d)); };
        }

        internal static void RegisterHandler<T>(ISerializationHandler<T> handler)
        {
            RegisterHandler<T>(handler.Serialize, handler.Deserialize);
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
