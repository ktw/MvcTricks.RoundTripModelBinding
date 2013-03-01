using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace MvcTricks.RoundTripModelBinding.Serialization
{
    internal class Serializer
    {

        private static JavaScriptSerializer GetSerializer()
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(Configuration.Default.JavascriptConverters);
            return serializer;
        }

        internal static string Serialize(object data)
        {
            return GetSerializer().Serialize(data);
        }

        internal static T Deserialize<T>(string data)
        {
            return GetSerializer().Deserialize<T>(data);
        }

        internal static object Deserialize(string data, Type targetType)
        {
            return GetSerializer().Deserialize(data, targetType);
        }

    }
}
