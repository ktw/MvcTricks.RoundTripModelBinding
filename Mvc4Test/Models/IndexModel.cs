using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Mvc4Test.Models
{
    public class IndexModel
    {

        public MailAddress Email { get; set; }
        public DateTime Date { get; set; }
        public IndexChildModel[] Children { get; set; }

    }

    public class IndexChildModel
    {

        public int Index { get; set; }

    }

}