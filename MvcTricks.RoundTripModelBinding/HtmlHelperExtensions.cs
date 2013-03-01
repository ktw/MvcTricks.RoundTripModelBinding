using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Controls = MvcTricks.RoundTripModelBinding.Controls;
using Utilities = MvcTricks.RoundTripModelBinding.Utilities;
using MvcTricks.RoundTripModelBinding;

namespace System.Web.Mvc
{
    /// <summary>
    /// HtmlHelper extensions for serializing models, which persists data between roundtrips.
    /// </summary>
    public static partial class HtmlHelperExtensions
    {

        /// <summary>
        /// Serialize the model for persisting between roundtrips.
        /// Use either a <see cref="RoundTripModelAttribute"/> on the model parameter posted to a controller action, or on of the controller extensions, to get the data back.
        /// The <see cref="RoundTripModelAttribute"/> merges the original model with the posted values, so it is ready for use.
        /// The controller extensions gets an object with the original data, and does not merge with posted values.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The HtmlHelper.</param>
        /// <returns>
        /// Returns a <see cref="MvcHtmlString"/> containing a hidden input field.
        /// </returns>
        public static MvcHtmlString RoundTripModel<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return Controls.SerializedModel.Create(htmlHelper.ViewData.Model);
        }

        /// <summary>
        /// Serialize the model for persisting between roundtrips.
        /// Use either a <see cref="RoundTripModelAttribute"/> on the model parameter posted to a controller action, or on of the controller extensions, to get the data back.
        /// The <see cref="RoundTripModelAttribute"/> merges the original model with the posted values, so it is ready for use.
        /// The controller extensions gets an object with the original data, and does not merge with posted values.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The HtmlHelper.</param>
        /// <param name="mode">The storage mode.</param>
        /// <returns>
        /// Returns a <see cref="MvcHtmlString"/> containing a hidden input field.
        /// </returns>
        public static MvcHtmlString RoundTripModel<TModel>(this HtmlHelper<TModel> htmlHelper, MvcTricks.RoundTripModelBinding.StorageModes mode)
        {
            return Controls.SerializedModel.Create(htmlHelper.ViewData.Model, mode);
        }

        /// <summary>
        /// Serialize the model for persisting between roundtrips. 
        /// Use either a <see cref="RoundTripModelAttribute"/> on the model parameter posted to a controller action, or on of the controller extensions, to get the data back.
        /// The <see cref="RoundTripModelAttribute"/> merges the original model with the posted values, so it is ready for use. 
        /// The controller extensions gets an object with the original data, and does not merge with posted values.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HtmlHelper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>Returns a <see cref="MvcHtmlString"/> containing a hidden input field.</returns>
        public static MvcHtmlString RoundTripModelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return RoundTripModelFor(htmlHelper, Utilities.ExpressionTools.GetElementNameFromModel(htmlHelper.ViewData, expression), ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model);
        }

        /// <summary>
        /// Serialize the model for persisting between roundtrips.
        /// Use either a <see cref="RoundTripModelAttribute"/> on the model parameter posted to a controller action, or on of the controller extensions, to get the data back.
        /// The <see cref="RoundTripModelAttribute"/> merges the original model with the posted values, so it is ready for use.
        /// The controller extensions gets an object with the original data, and does not merge with posted values.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HtmlHelper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="mode">The storage mode.</param>
        /// <returns>
        /// Returns a <see cref="MvcHtmlString"/> containing a hidden input field.
        /// </returns>
        public static MvcHtmlString RoundTripModelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, StorageModes mode)
        {
            return RoundTripModelFor(htmlHelper, Utilities.ExpressionTools.GetElementNameFromModel(htmlHelper.ViewData, expression), ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model, mode);
        }

        /// <summary>
        /// Serialize the model for persisting between roundtrips. 
        /// Use either a <see cref="RoundTripModelAttribute"/> on the model parameter posted to a controller action, or on of the controller extensions, to get the data back.
        /// The <see cref="RoundTripModelAttribute"/> merges the original model with the posted values, so it is ready for use. 
        /// The controller extensions gets an object with the original data, and does not merge with posted values.
        /// </summary>
        /// <param name="htmlHelper">The HtmlHelper.</param>
        /// <param name="model">The model to serialize.</param>
        /// <returns>Returns a <see cref="MvcHtmlString"/> containing a hidden input field.</returns>
        public static MvcHtmlString RoundTripModelFor(this HtmlHelper htmlHelper, object model)
        {
            return Controls.SerializedModel.Create(model);
        }

        /// <summary>
        /// Serialize the model for persisting between roundtrips.
        /// Use either a <see cref="RoundTripModelAttribute"/> on the model parameter posted to a controller action, or on of the controller extensions, to get the data back.
        /// The <see cref="RoundTripModelAttribute"/> merges the original model with the posted values, so it is ready for use.
        /// The controller extensions gets an object with the original data, and does not merge with posted values.
        /// </summary>
        /// <param name="htmlHelper">The HtmlHelper.</param>
        /// <param name="model">The model to serialize.</param>
        /// <param name="mode">The storage mode.</param>
        /// <returns>
        /// Returns a <see cref="MvcHtmlString"/> containing a hidden input field.
        /// </returns>
        public static MvcHtmlString RoundTripModelFor(this HtmlHelper htmlHelper, object model, StorageModes mode)
        {
            return Controls.SerializedModel.Create(model, mode);
        }

        /// <summary>
        /// Serialize the model for persisting between roundtrips.
        /// Use either a <see cref="RoundTripModelAttribute"/> on the model parameter posted to a controller action, or on of the controller extensions, to get the data back.
        /// The <see cref="RoundTripModelAttribute"/> merges the original model with the posted values, so it is ready for use.
        /// The controller extensions gets an object with the original data, and does not merge with posted values.
        /// </summary>
        /// <param name="htmlHelper">The HTML.</param>
        /// <param name="key">The target key for the data. (For special cases with multiple instances)</param>
        /// <param name="model">The model to serialize.</param>
        /// <returns>Returns a <see cref="MvcHtmlString"/> containing a hidden input field.</returns>
        public static MvcHtmlString RoundTripModelFor(this HtmlHelper htmlHelper, string key, object model)
        {
            return Controls.SerializedModel.Create(key, model);
        }

        /// <summary>
        /// Serialize the model for persisting between roundtrips.
        /// Use either a <see cref="RoundTripModelAttribute"/> on the model parameter posted to a controller action, or on of the controller extensions, to get the data back.
        /// The <see cref="RoundTripModelAttribute"/> merges the original model with the posted values, so it is ready for use.
        /// The controller extensions gets an object with the original data, and does not merge with posted values.
        /// </summary>
        /// <param name="htmlHelper">The HTML.</param>
        /// <param name="key">The target key for the data. (For special cases with multiple instances)</param>
        /// <param name="model">The model to serialize.</param>
        /// <param name="mode">The storage mode.</param>
        /// <returns>
        /// Returns a <see cref="MvcHtmlString"/> containing a hidden input field.
        /// </returns>
        public static MvcHtmlString RoundTripModelFor(this HtmlHelper htmlHelper, string key, object model, StorageModes mode)
        {
            return Controls.SerializedModel.Create(key, model, mode);
        }

    }
}
