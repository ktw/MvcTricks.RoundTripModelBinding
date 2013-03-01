using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TypeManagement = MvcTricks.RoundTripModelBinding.TypeManagement;
using Serialization = MvcTricks.RoundTripModelBinding.Serialization;

namespace MvcTricks.RoundTripModelBinding
{
    /// <summary>
    /// Modelbinder for deserializing a model persisted between roundtrips. (Inherrits <see cref="System.Web.Mvc.DefaultModelBinder"/>) 
    /// The model is merged with posted values.
    /// </summary>
    public class RoundTripModelBinder : System.Web.Mvc.DefaultModelBinder
    {

        private bool isKeyBased;
        private string key;

        /// <summary>
        /// Modelbinder for deserializing a model persisted between roundtrips. (Inherrits <see cref="System.Web.Mvc.DefaultModelBinder"/>) 
        /// The model is merged with posted values.
        /// </summary>
        public RoundTripModelBinder()
        {
            this.isKeyBased = false;
        }

        /// <summary>
        /// Modelbinder for deserializing a model persisted between roundtrips.  (Inherrits <see cref="System.Web.Mvc.DefaultModelBinder"/>) 
        /// The model is merged with posted values.
        /// (Used from within the attribute)
        /// </summary>
        internal RoundTripModelBinder(string key)
        {
            this.key = key;
            this.isKeyBased = true;
        }

        /// <summary>
        /// Creates the specified model type by using the specified controller context and binding context.
        /// If a serialized model is found in the post collecion, it will be used to create the model.
        /// </summary>
        /// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param>
        /// <param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param>
        /// <param name="modelType">The type of the model object to return.</param>
        /// <returns>A data object of the specified type.</returns>
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var typeKey = ((this.isKeyBased) ? key : TypeManagement.TypeManager.GetTypeId(modelType));
            var hasData = (!string.IsNullOrWhiteSpace(controllerContext.HttpContext.Request[typeKey]));
            if (hasData)
                return Serialization.ModelData.Deserialize(modelType, controllerContext.HttpContext.Request);
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }


    }
}
