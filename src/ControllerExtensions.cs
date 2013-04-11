using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Serialization = MvcTricks.RoundTripModelBinding.Serialization;
using System.Linq.Expressions;

namespace System.Web.Mvc
{
    /// <summary>
    /// Controller extensions for handling serialized models, which are persisted between roundtrips.
    /// </summary>
    public static partial class ControllerExtensions
    {

        /// <summary>
        /// Deserializes a model persisted between roundtrips. 
        /// Posted values are not merged with the model values.
        /// </summary>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <param name="controller">The controller.</param>
        /// <returns>Returns an instance of the model, containing the persisted values.</returns>
        public static T GetRoundTripModel<T>(this Controller controller)
        {
            return GetRoundTripModel<T>(controller, MvcTricks.RoundTripModelBinding.TypeManagement.TypeManager.GetTypeId(typeof(T)));
        }

        /// <summary>
        /// Deserializes a model persisted between roundtrips.
        /// Posted values are not merged with the model values.
        /// </summary>
        /// <typeparam name="T">The type of the model.</typeparam>
        /// <param name="controller">The controller.</param>
        /// <param name="key">The target key for the data. (For special cases with multiple instances)</param>
        /// <returns>
        /// Returns an instance of the model, containing the persisted values.
        /// </returns>
        public static T GetRoundTripModel<T>(this Controller controller, string key)
        {
            return Serialization.ModelData.Deserialize<T>(controller.Request, key);
        }

    }
}
