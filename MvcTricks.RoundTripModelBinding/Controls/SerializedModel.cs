using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcTricks.RoundTripModelBinding.Controls
{
    internal class SerializedModel
    {

        internal static MvcHtmlString Create(object model)
        {
            return Create(TypeManagement.TypeManager.GetTypeId(model.GetType()), model);
        }

        internal static MvcHtmlString Create(object model, StorageModes mode)
        {
            return Create(TypeManagement.TypeManager.GetTypeId(model.GetType()), model, mode);
        }

        internal static MvcHtmlString Create(string key, object model)
        {
            return Create(key, model, Configuration.Default.StorageMode);
        }

        internal static MvcHtmlString Create(string key, object model, StorageModes mode)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes["type"] = "hidden";
            tagBuilder.Attributes["name"] = key;
            tagBuilder.Attributes["value"] = Serialization.ModelData.Serialize(model, mode);
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }

    }
}
