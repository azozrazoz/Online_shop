using Online_shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_shop.Controllers
{
    public class HomeController : Controller
    {
        private Online_shopContext db = new Online_shopContext();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "О нас";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Наши контакты";

            return View();
        }
    }
}