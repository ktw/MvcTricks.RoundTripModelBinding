using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TypeManagement = MvcTricks.RoundTripModelBinding.TypeManagement;
using Serialization = MvcTricks.RoundTripModelBinding.Serialization;
using Archiving = MvcTricks.RoundTripModelBinding.Archiving;

namespace MvcTricks.RoundTripModelBinding.Serialization
{
    /// <summary>
    /// Handles serializing, deserializing model data.
    /// </summary>
    public class ModelData
    {

        /// <summary>
        /// Serialize the model for persisting between roundtrips.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Returns a string with the serialized data.</returns>
        public static string Serialize(object model)
        {
            return Archiving.Archiver.Archive(Serializer.Serialize(model), Configuration.Default.StorageMode);
        }

        /// <summary>
        /// Serialize the model for persisting between roundtrips.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="mode">The storage mode.</param>
        /// <returns>
        /// Returns a string with the serialized data.
        /// </returns>
        public static string Serialize(object model, StorageModes mode)
        {
            return Archiving.Archiver.Archive(Serializer.Serialize(model), mode);
        }

        /// <summary>
        /// Deserialize the model persisted in the request collection.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns>Returns the model.</returns>
        public static T Deserialize<T>(HttpRequestBase request)
        {
            if (request == null)
                return default(T);
            return Deserialize<T>(request, null);
        }

        /// <summary>
        /// Deserialize the model persisted in the request collection.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="key">The key wich stores the data in the request collection.</param>
        /// <returns>Returns the model.</returns>
        public static T Deserialize<T>(HttpRequestBase request, string key)
        {
            if ((request == null) || (string.IsNullOrWhiteSpace(key)))
                return default(T);
            var serialized = request[key];
            return Deserialize<T>(serialized);
        }

        /// <summary>
        /// Deserialize the model.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="serialized">The serialized data.</param>
        /// <returns>Returns the model.</returns>
        public static T Deserialize<T>(string serialized)
        {
            if (string.IsNullOrWhiteSpace(serialized))
                return default(T);
            return (T)Deserialize(typeof(T), serialized);
        }

        /// <summary>
        /// Deserialize the model persisted in the request collection.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="request">The request.</param>
        /// <returns>Returns the model.</returns>
        public static object Deserialize(Type modelType, HttpRequestBase request)
        {
            if ((modelType == null) || (request == null))
                return null;
            return Deserialize(modelType, request, TypeManagement.TypeManager.GetTypeId(modelType));
        }

        /// <summary>
        /// Deserialize the model persisted in the request collection.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="request">The request.</param>
        /// <param name="key">The key wich stores the data in the request collection.</param>
        /// <returns>Returns the model.</returns>
        public static object Deserialize(Type modelType, HttpRequestBase request, string key)
        {
            if ((modelType == null) || (request == null) || (string.IsNullOrWhiteSpace(key)))
                return null;
            var serialized = request[key];
            return Deserialize(modelType, serialized);
        }

        /// <summary>
        /// Deserialize the model.
        /// </summary>
        /// <param name="modelType">Type of the model.</param>
        /// <param name="serialized">The serialized data.</param>
        /// <returns>Returns the model.</returns>
        public static object Deserialize(Type modelType, string serialized)
        {
            // Check for null and bad input:
            if ((modelType == null) || (string.IsNullOrWhiteSpace(serialized)))
                return null;
            // Trap bad base64:
            try
            {
                var json = Archiving.Archiver.Unarchive(serialized);
                var model = Serializer.Deserialize(json, modelType);
                return model;
            }
            catch {
                return null;
            }
        }
        
    }
}
