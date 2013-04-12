using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTricks.RoundTripModelBinding.Serialization
{

    /// <summary>
    /// Serialization handling interface.
    /// </summary>
    /// <typeparam name="T">The handled type.</typeparam>
    public interface ISerializationHandler<T>
    {

        /// <summary>
        /// Serializes a value.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>Returns a string.</returns>
        string Serialize(T value);

        /// <summary>
        /// Deserializes a value.
        /// </summary>
        /// <param name="value">The value to deserialize.</param>
        /// <returns>Returns an instance of the handled type.</returns>
        T Deserialize(string value);

    }
}
