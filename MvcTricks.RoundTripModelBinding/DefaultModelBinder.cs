using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcTricks.RoundTripModelBinding
{

    /// <summary>
    /// Modelbinder for deserializing a model persisted between roundtrips.  (Inherits <see cref="System.Web.Mvc.DefaultModelBinder"/>) 
    /// The model is merged with posted values.
    /// </summary>
    public class DefaultModelBinder : RoundTripModelBinder
    {

        /// <summary>
        /// Default Modelbinder for deserializing a model persisted between roundtrips. (Inherits <see cref="System.Web.Mvc.DefaultModelBinder"/>) 
        /// The model is merged with posted values, using the default configuration.
        /// </summary>
        public DefaultModelBinder()
        {
        }

        /// <summary>
        /// Default Modelbinder for deserializing a model persisted between roundtrips.  (Inherits <see cref="System.Web.Mvc.DefaultModelBinder"/>)
        /// The model is merged with posted values, using the provided configuration.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        public DefaultModelBinder(Configuration configuration)
        {
            Configuration.Default = configuration;
        }

    }
}
