using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace MvcTricks.RoundTripModelBinding.Serialization
{

    /// <summary>
    /// MailAddress serialization.
    /// </summary>
    public class MailAddressSerializer : JsonSerializer<MailAddress>
    {

        //http://stackoverflow.com/questions/8030538/how-to-implement-custom-jsonconverter-in-json-net-to-deserialize-a-list-of-base
        //http://blog.maskalik.com/asp-net/json-net-implement-custom-serialization

        /// <summary>
        /// Reads Json.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var address = jObject["Address"].Value<string>();
            var name = jObject["Name"].Value<string>();
            //var temp = new SerializationWapper<string>();
            //var text = serializer.Deserialize<string>(reader);
            //    serializer.Populate(jObject.CreateReader(), temp);
            return new MailAddress(address, name);
        }

        /// <summary>
        /// Creates a MailAddress.
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        protected override MailAddress Create(Type objectType, JObject jObject)
        {
            return null;
        }

        /// <summary>
        /// Writes the Json
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mailAddress = value as MailAddress;
            if (mailAddress != null)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("Address");
                writer.WriteValue(mailAddress.Address);
                writer.WritePropertyName("Name");
                writer.WriteValue(mailAddress.DisplayName);
                writer.WriteEndObject();
            }
        }
    }
}
