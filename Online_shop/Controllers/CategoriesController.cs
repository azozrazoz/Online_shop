using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_shop.Data;
using Online_shop.Models;

namespace Online_shop.Controllers
{
    public class CategoriesController : Controller
    {
        private Online_shopContext db = new Online_shopContext();

        // GET: Categories
        public async Task<ActionResult> Index(int? id)
        {
            Categories category = await db.Categories.FindAsync(id);

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Goods = await db.Goods.Include(c => c.Categories).ToListAsync();

            return View(category);
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = await db.Categories.FindAsync(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
