using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace MvcTricks.RoundTripModelBinding.Serialization
{
    /// <summary>
    /// DateTime converter for the <see cref="System.Web.Script.Serialization.JavaScriptSerializer"/>, which enables correct serialization and deserialization of DateTime and DateTime? values.
    /// </summary>
    public class DateTimeConverter : JavaScriptConverter
    {
        /// <summary>
        /// Supported types are DateTime and DateTime?.
        /// </summary>
        /// <value></value>
        /// <returns>An array with the DateTime and DateTime? types.</returns>
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new Type[] { typeof(DateTime), typeof(DateTime?) }; }
        }

        /// <summary>
        /// Serializes DateTime and DateTime? objects as ticks, to eliminate timezone differences.
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
                DateTime value = (DateTime)obj;
                result["Ticks"] = value.Ticks;
            }
            else
                result["Ticks"] = null;
            return result;
        }

        /// <summary>
        /// Deserializes the ticks value into either a DateTime or a DateTime? value.
        /// </summary>
        /// <param name="dictionary">An <see cref="T:System.Collections.Generic.IDictionary`2"/> instance of property data stored as name/value pairs.</param>
        /// <param name="type">The type of the resulting object.</param>
        /// <param name="serializer">The <see cref="T:System.Web.Script.Serialization.JavaScriptSerializer"/> instance.</param>
        /// <returns>The deserialized object.</returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            if ((type == typeof(DateTime)) || (type == typeof(DateTime?)))
            {
                // Hmmm... The serializer does not enter here in case of a null value, so we can forget about deserializing from null.
                long ticks = Convert.ToInt64(dictionary["Ticks"]);
                return new DateTime(ticks);
            }
            return null;
        }
    }

}
