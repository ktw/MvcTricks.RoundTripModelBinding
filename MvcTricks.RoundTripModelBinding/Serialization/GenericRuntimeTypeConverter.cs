//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web.Script.Serialization;

//namespace MvcTricks.RoundTripModelBinding.Serialization
//{
//    internal class GenericRuntimeTypeConverter<T> : JavaScriptConverter
//    {

//        private readonly ITypeSerializer<T> serializer;

//        internal GenericRuntimeTypeConverter(ITypeSerializer<T> converter)
//        {
//            this.serializer = converter;
//        }

//        /// <summary>
//        /// The types supported by this converter.
//        /// </summary>
//        /// <value></value>
//        /// <returns>An array with the types supported by this converter.</returns>
//        public override IEnumerable<Type> SupportedTypes
//        {
//            get { return new Type[] { typeof(T) }; }
//        }

//        /// <summary>
//        /// Serializes the object.
//        /// </summary>
//        /// <param name="obj">The object to serialize.</param>
//        /// <param name="serializer">The object that is responsible for the serialization.</param>
//        /// <returns>
//        /// An object that contains key/value pairs that represent the object’s data.
//        /// </returns>
//        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
//        {
//            return this.serializer.Serialize((T)obj);
//        }

//        /// <summary>
//        /// Deserializes the value.
//        /// </summary>
//        /// <param name="dictionary">An <see cref="T:System.Collections.Generic.IDictionary`2"/> instance of property data stored as name/value pairs.</param>
//        /// <param name="type">The type of the resulting object.</param>
//        /// <param name="serializer">The <see cref="T:System.Web.Script.Serialization.JavaScriptSerializer"/> instance.</param>
//        /// <returns>
//        /// The deserialized object.
//        /// </returns>
//        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
//        {
//            return (T)this.serializer.Deserialize(dictionary);
//        }

//    }
//}
