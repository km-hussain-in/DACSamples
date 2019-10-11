using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApp.Controllers
{
    using System.Web.Mvc;

    public class ClockController : Controller
    {
        public ActionResult Time()
        {
            return Content(DateTime.Now.ToString());
        }
    }
}