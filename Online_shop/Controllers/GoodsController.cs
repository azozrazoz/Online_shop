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
    public class GoodsController : Controller
    {
        private Online_shopContext db = new Online_shopContext();

        // GET: Goods
        public async Task<ActionResult> Index()
        {
            return View(await db.Goods.ToListAsync());
        }

        // GET: Goods/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,Price,PathToPicture")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Goods.Add(goods);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(goods);
        }

        // GET: Goods/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Goods/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,Price,PathToPicture")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goods).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(goods);
        }

        // GET: Goods/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Goods goods = await db.Goods.FindAsync(id);
            db.Goods.Remove(goods);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);  
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Buy(int? id)
        {
            Goods goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return HttpNotFound();
            }

            return View(goods);
            /*if (id != null && userId != null)
            {
                Goods goods = await db.Goods.FindAsync(id);
                Users user = await db.Users.FindAsync(userId);
                if (goods != null && user != null)
                {
                    return View();
                }
            }
            return RedirectToAction("Register");*/
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Buy(Users user, List<Goods> goods)
        {
            if (user != null && goods != null)
            {
                db.Orders.Add(new Orders { Goods = goods, User = user });
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
