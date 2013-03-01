using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Controls = MvcTricks.RoundTripModelBinding.Controls;

namespace System.Web.Mvc
{
    /// <summary>
    /// MvcFormExtensions extensions for serializing models, which persists data between roundtrips.
    /// </summary>
    public static partial class MvcFormExtensions
    {

        /// <summary>
        /// Extends a <see cref="System.Web.Mvc.Html.MvcForm"/>, and appends a serialized model to the generated form.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="viewContext">The view context.</param>
        /// <returns>Returns the form.</returns>
        public static System.Web.Mvc.Html.MvcForm AppendRoundTripModel(this System.Web.Mvc.Html.MvcForm form, ViewContext viewContext)
        {
            return Controls.FormWrapper.Create(form, viewContext).Form;
        }

        /// <summary>
        /// Extends a <see cref="System.Web.Mvc.Html.MvcForm"/>, and appends a serialized model to the generated form.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="viewContext">The view context.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>
        /// Returns the form.
        /// </returns>
        public static System.Web.Mvc.Html.MvcForm AppendRoundTripModel(this System.Web.Mvc.Html.MvcForm form, ViewContext viewContext, MvcTricks.RoundTripModelBinding.StorageModes mode)
        {
            return Controls.FormWrapper.Create(form, viewContext, mode).Form;
        }

    }
}
