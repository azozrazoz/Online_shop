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
    public class UsersController : Controller
    {
        private Online_shopContext db = new Online_shopContext();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,Password,PasswordConfirm")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email,Password,PasswordConfirm")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Users users = await db.Users.FindAsync(id);
            db.Users.Remove(users);
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Include = "Id,Name,Email,Password,PasswordConfirm")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);

                HttpCookie cookie = new HttpCookie("user_id");
                cookie.Values["user_id"] = users.Id.ToString();
                Response.Cookies.Add(cookie);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        [HttpGet]
        public async Task<ActionResult> Buy(int? userId, int? id)
        {
            if (id != null && userId != null)
            {
                Goods goods = await db.Goods.FindAsync(id);
                Users user = await db.Users.FindAsync(userId);
                if (goods != null && user != null)
                {
                    return View();
                }
            }
            return HttpNotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Buy(Users user, Goods goods)
        {
            if (user != null && goods != null)
            {
                Orders order = await db.Orders.Where(c => c.User.Id == user.Id).FirstOrDefaultAsync();

                if (order == null)
                {
                    List<Goods> goodList = new List<Goods> { goods };

                    db.Orders.Add(new Orders { Goods = goodList, User = user });
                }
                else
                {
                    order.Goods.Add(goods);
                    await db.SaveChangesAsync();
                }

                return RedirectToAction("Index", "Orders");
            }

            return RedirectToAction("Index", "Orders");
        }
    }
}
