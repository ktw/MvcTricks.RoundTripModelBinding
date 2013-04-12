using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mvc4Test.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.IndexModel() { 
                Email = new System.Net.Mail.MailAddress("info@nowhere.com", "Info"), 
                IpAddress = Dns.Resolve(Dns.GetHostName()).AddressList[0],
                Date = DateTime.Now,  
                Children = new Models.IndexChildModel[] {
                    new Models.IndexChildModel() { Index = 0 },
                    new Models.IndexChildModel() { Index = 1 },
                    new Models.IndexChildModel() { Index = 2 },
                    new Models.IndexChildModel() { Index = 3 },
                    new Models.IndexChildModel() { Index = 4 }
                }
            });
        }

        [HttpPost]
        public ActionResult Index(Models.IndexModel model)
        {
            return View(model);
        }
    }
}
