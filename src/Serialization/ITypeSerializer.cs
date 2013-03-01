//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace MvcTricks.RoundTripModelBinding.Serialization
//{
//    /// <summary>
//    /// Interface for implementing a custom type serializer.
//    /// </summary>
//    public interface ITypeSerializer
//    {

//        /// <summary>
//        /// The types supported by this converter.
//        /// </summary>
//        /// <value></value>
//        /// <returns>An array with the types supported by this converter.</returns>
//        IEnumerable<Type> SupportedTypes { get; }
        
//        /// <summary>
//        /// Serializes the object.
//        /// </summary>
//        /// <param name="obj">The object to serialize.</param>
//        /// <returns>
//        /// An object that contains key/value pairs that represent the object’s data.
//        /// </returns>
//        IDictionary<string, object> Serialize(object obj);

//        /// <summary>
//        /// Deserializes the value.
//        /// </summary>
//        /// <param name="dictionary">An <see cref="T:System.Collections.Generic.IDictionary`2"/> instance of property data stored as name/value pairs.</param>
//        /// <param name="type">The type of the resulting object.</param>
//        /// <returns>The deserialized object.</returns>
//        object Deserialize(IDictionary<string, object> dictionary, Type type);

//    }

//    /// <summary>
//    /// Interface for implementing a custom type converter.
//    /// </summary>
//    /// <typeparam name="T">The type supported by this converter.</typeparam>
//    public interface ITypeSerializer<T>
//    {

//        /// <summary>
//        /// Serializes the object.
//        /// </summary>
//        /// <param name="obj">The object to serialize.</param>
//        /// <returns>
//        /// An object that contains key/value pairs that represent the object’s data.
//        /// </returns>
//        IDictionary<string, object> Serialize(T obj);

//        /// <summary>
//        /// Deserializes the value.
//        /// </summary>
//        /// <param name="dictionary">An <see cref="T:System.Collections.Generic.IDictionary`2"/> instance of property data stored as name/value pairs.</param>
//        /// <returns>
//        /// The deserialized object.
//        /// </returns>
//        T Deserialize(IDictionary<string, object> dictionary);

//    }

//}
