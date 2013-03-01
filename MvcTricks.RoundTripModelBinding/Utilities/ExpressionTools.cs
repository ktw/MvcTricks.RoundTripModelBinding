using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Linq.Expressions;

namespace MvcTricks.RoundTripModelBinding.Utilities
{
    internal class ExpressionTools
    {

        internal static string GetElementNameFromModel<TModel, TProperty>(ViewDataDictionary<TModel> viewData, Expression<Func<TModel, TProperty>> expression)
        {
            return GetElementNameFromModel(viewData, ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, viewData), ExpressionHelper.GetExpressionText(expression));
        }

        internal static string GetElementNameFromModel(ViewDataDictionary viewData, ModelMetadata modelMetadata, string expression)
        {
            string name = viewData.TemplateInfo.GetFullHtmlFieldName(expression);
            if (string.IsNullOrEmpty(name))
                return modelMetadata.ModelType.FullName;
            return name;
        }

    }
}
