using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBWebApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        ProductModel model = new ProductModel();

        // GET: Home
        public ActionResult Index()
        {
            return View(model.Products.ToList());
        }

        public ActionResult Details(int id)
        {
            ViewBag.SelectedProductId = id;
            Product product = model.Products.Find(id);
            model.Entry(product).Collection(p => p.Orders).Load(); //explicit loading
            return View(product.Orders);
        }

        public ActionResult Edit(int id)
        {
            return View(new Product { Id = id });
        }

        [HttpPost]
        public ActionResult Edit(Product input)
        {
            if(ModelState.IsValid)
            {
                model.Entry(input).State = System.Data.Entity.EntityState.Modified;
                model.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(input);
        }
    }
}