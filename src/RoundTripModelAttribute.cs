using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcTricks.RoundTripModelBinding
{
    /// <summary>
    /// Deserializes a model persisted between roundtrips. 
    /// The model is merged with posted values.
    /// </summary>
    public class RoundTripModelAttribute : CustomModelBinderAttribute
    {

        private readonly string key;

        /// <summary>
        /// Deserializes a model persisted between roundtrips. 
        /// The model is merged with posted values.
        /// </summary>
        public RoundTripModelAttribute() : this(null)
        {
        }

        /// <summary>
        /// Deserializes a model persisted between roundtrips. 
        /// The model is merged with posted values.
        /// </summary>
        public RoundTripModelAttribute(string key)
        {
            if ((!string.IsNullOrWhiteSpace(key)) && (Constants.BAD_KEYS.Contains(key.ToLower())))
                throw new ArgumentException(string.Format("The key {0} is not valid for the {1}", key ?? string.Empty, GetType().Name));
            this.key = key;
        }

        /// <summary>
        /// Retrieves the associated model binder.
        /// </summary>
        /// <returns>
        /// A reference to an object that implements the <see cref="T:System.Web.Mvc.IModelBinder"/> interface.
        /// </returns>
        public override IModelBinder GetBinder()
        {
            return new RoundTripModelBinder(key);
        }

    }
}
