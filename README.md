MvcTricks.RoundTripModelBinding
===============================

Utility for persisting state on MVC pages.<br />
This is an effort to simplify model binding, by automatically persisting the the model data, which is else lost when sending data to and from the client.<br />
It is not an attempt to reinvent asp.net viewstate!
<br />
The main purpose is to avoid using a bunch of hidden values in views, for id's, collections and other values, which might even come from database queries.<br />
<br />
<br />
The current release uses the System.Web.Script.Serialization.JavaScriptSerializer internally.<br />
So if the JavaScriptSerializer likes it, it is probably usable here too.<br />
Currently these custom converters (serializers) are implemented:<br />
<ul>
    <li>DateTimeConverter (DateTime, DateTime?)</li>
    <li>MailAddressConverter (MailAddress)</li>
</ul>
<h1>Warning!</h1>
Do not use it on classes which are lazy loadable, like NHibernate entities.<br />
Bad things will happen.<br />
<br />
<hr />

<h1>Getting started - The easy way</h1>

<b>Download the package from NuGet</b><br />
<br>
Search for "MvcTricks.RoundTripModelBinding" in your IDE, or run this packagemanager command:<br />
PM> Install-Package MvcTricks.RoundTripModelBinding<br>
<br />

<b>Register the modelbinder</b><br />

Method 1, setting the modelbinder as always on, using default settings:<br />
Edit your Global.asax.cs file, and add the following to the Application_Start method:<br />
<br />
<pre>
protected void Application_Start()
{
    AreaRegistration.RegisterAllAreas();

    RegisterGlobalFilters(GlobalFilters.Filters);
    RegisterRoutes(RouteTable.Routes);

    // Add the modelbinder as the default modelbinder:
    ModelBinders.Binders.DefaultBinder = new MvcTricks.RoundTripModelBinding.DefaultModelBinder();
}
</pre>
<br />
Method 2, setting the modelbinder as always on, using secure settings, and specifying own encryption parameters:<br />
Edit your Global.asax.cs file, and add the following to the Application_Start method:
<pre>
protected void Application_Start()
{
    AreaRegistration.RegisterAllAreas();

    RegisterGlobalFilters(GlobalFilters.Filters);
    RegisterRoutes(RouteTable.Routes);

    // Specify the default storage mode, and encryption keys
    var config = new MvcTricks.RoundTripModelBinding.Configuration(
        StorageModes.CompressAndEncrypt,
            Encoding.Default.GetBytes("Lorem ipsum dolor sit amet amet."), // 32 bytes Key
            Encoding.Default.GetBytes("Donec tincidunt.") // 16 bytes IV
    );

    // Add the modelbinder as default:
    ModelBinders.Binders.DefaultBinder = new MvcTricks.RoundTripModelBinding.DefaultModelBinder(config);
}
</pre>
<br />
See http://msdn.microsoft.com/en-us/library/system.security.cryptography.aesmanaged.aspx for info on the AesManaged class.<br />
<br />
<br />
<b>Register the namespace in web.config</b><br />
<pre>
&lt;configuration&gt;
    &lt;system.web&gt;
        &lt;namespaces&gt;
            &lt;pages&gt;
                &lt;add namespace="MvcTricks.RoundTripModelBinding" /&gt;
            &lt;/pages&gt;
        &lt;/namespaces&gt;
    &lt;/system.web&gt;
&lt;/configuration&gt;
</pre>
<br />
<br />
<b>Use the modelbinder</b><br />
<br />
The model will automatically be filled with data, before it is returned to the action method.<br />

Method 1, Using the modelbinder to persist the model, using a MvcForm extension:<br />
<pre>
&lt;% using (Html.BeginForm().AppendRoundTripModel(ViewContext)) { %&gt;
...
&lt;% } %&gt;
</pre>
<br />
Method 2, Using the modelbinder to persist the model, using a HtmlHelper extension:<br />
<pre>
&lt;% using (Html.BeginForm()) { %&gt;
    &lt;%= Html.RoundTripModel() %&gt;
&lt;% } %&gt;
</pre>
<br />
Method 3, Using the modelbinder to persist any object, using a HtmlHelper extension, and extract it manually from the controller:<br />
<pre>
&lt;% using (Html.BeginForm()) { %&gt;
    &lt;%= Html.RoundTripModelFor("key_to_identify_value", myObject) %&gt;
&lt;% } %&gt;
</pre>
<br />
And from the controller:<br />
<pre>
public class MyController : Controller
{
  
	[HttpPost]
	public ActionResult MyAction(FormCollection form)
	{
		MyObject otherViewModel = this.GetRoundTripModel&lt;MyObject&gt;("key_to_identify_value");
	}
	
}
</pre>
