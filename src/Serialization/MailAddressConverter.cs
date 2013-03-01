using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Net.Mail;

namespace MvcTricks.RoundTripModelBinding.Serialization
{

    /// <summary>
    /// MailAddress converter for the <see cref="System.Web.Script.Serialization.JavaScriptSerializer"/>, which enables correct serialization and deserialization of MailAddress values.
    /// </summary>
    public class MailAddressConverter : JavaScriptConverter
    {

        /// <summary>
        /// Supported type is MailAddress.
        /// </summary>
        /// <value></value>
        /// <returns>An array with the MailAddress type.</returns>
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new Type[] { typeof(MailAddress) }; }
        }

        /// <summary>
        /// Serializes MailAddress objects.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="serializer">The object that is responsible for the serialization.</param>
        /// <returns>
        /// An object that contains key/value pairs that represent the object’s data.
        /// </returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (obj != null)
            {
                MailAddress value = (MailAddress)obj;
                result["MailAddress"] = value.ToString();
            }
            else
                result["MailAddress"] = null;
            return result;
        }

        /// <summary>
        /// Deserializes the ticks value into a MailAddress value.
        /// </summary>
        /// <param name="dictionary">An <see cref="T:System.Collections.Generic.IDictionary`2"/> instance of property data stored as name/value pairs.</param>
        /// <param name="type">The type of the resulting object.</param>
        /// <param name="serializer">The <see cref="T:System.Web.Script.Serialization.JavaScriptSerializer"/> instance.</param>
        /// <returns>The deserialized object.</returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            // Hmmm... The serializer does not enter here in case of a null value, so we can forget about deserializing from null.
            if (type == typeof(MailAddress))
                return new MailAddress((string)dictionary["MailAddress"]);
            return null;
        }

    }
}
