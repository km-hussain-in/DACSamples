using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServerApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        private VisitorModel model = new VisitorModel();

        // GET: Home
        public ActionResult Index()
        {
            return View(model.ReadVisitors());
        }

        public ActionResult Register()
        {
            return View(new Visitor());
        }

        [HttpPost]
        public ActionResult Register(Visitor input)
        {
            if(ModelState.IsValid)
            {
                model.WriteVisitor(input.Name);
                return RedirectToAction("Index");
            }

            return View(input);
        }
    }
}