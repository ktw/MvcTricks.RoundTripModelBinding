using MvcTricks.RoundTripModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mvc4Test
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Specify the default storage mode, and encryption keys
            var config = new MvcTricks.RoundTripModelBinding.Configuration(
                StorageModes.CompressAndEncrypt,
                    Encoding.Default.GetBytes("Lorem ipsum dolor sit amet amet."), // 32 bytes Key
                    Encoding.Default.GetBytes("Donec tincidunt.") // 16 bytes IV
            );

            MvcTricks.RoundTripModelBinding.Configuration.RegisterSerializationHandlerFor<System.Net.Mail.MailAddress>(
                s => { return "svend@svendsen.com"; }, 
                d => { return new System.Net.Mail.MailAddress("poul@poulsen.dk"); }
            );

            // Add the modelbinder as the default modelbinder:
            ModelBinders.Binders.DefaultBinder = new MvcTricks.RoundTripModelBinding.DefaultModelBinder();


        }
    }
}