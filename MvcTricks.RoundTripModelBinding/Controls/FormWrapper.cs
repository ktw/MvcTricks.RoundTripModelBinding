using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MvcTricks.RoundTripModelBinding.TypeManagement;
using MvcTricks.RoundTripModelBinding.Serialization;

namespace MvcTricks.RoundTripModelBinding.Controls
{
    internal class FormWrapper
    {
        /// <summary>
        /// Gets the wrapped form.
        /// </summary>
        public System.Web.Mvc.Html.MvcForm Form { get; private set; }
        ViewContext viewContext;

        private FormWrapper(System.Web.Mvc.Html.MvcForm form, ViewContext viewContext, StorageModes mode)
        {
            this.Form = form;
            this.viewContext = viewContext;
            viewContext.Writer.WriteLine(SerializedModel.Create(viewContext.ViewData.Model, mode));
        }

        internal static FormWrapper Create(System.Web.Mvc.Html.MvcForm form, ViewContext viewContext)
        {
            return new FormWrapper(form, viewContext, Configuration.Default.StorageMode);
        }

        internal static FormWrapper Create(System.Web.Mvc.Html.MvcForm form, ViewContext viewContext, StorageModes mode)
        {
            return new FormWrapper(form, viewContext, mode);
        }

    }
}
