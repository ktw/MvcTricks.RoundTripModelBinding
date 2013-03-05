using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MvcTricks.RoundTripModelBinding.Serialization
{
    internal class Serializer
    {

        private static IList<JsonConverter> GetConverters()
        {
            return new JsonConverter[] {
                new MailAddressSerializer()
            };
        }

        private static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                Error = (s, e) => { DumpError(s, e); },
                Converters = GetConverters()
            };
        }

        internal static string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data, GetSerializerSettings());
        }

        internal static T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, GetSerializerSettings());
        }

        internal static object Deserialize(string data, Type targetType)
        {
            return JsonConvert.DeserializeObject(data, targetType, GetSerializerSettings());
        }

        private static void DumpError(object sender, ErrorEventArgs args)
        {
            args.ErrorContext.Handled = true;
            if (System.Diagnostics.Debugger.IsAttached)
                throw new ArgumentException(string.Format("Error creating type for property '{0}'!", args.ErrorContext.Member), args.ErrorContext.Error);
        }

    }
}
