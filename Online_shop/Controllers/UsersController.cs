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
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Web.Services.Description;
using Microsoft.AspNetCore.Identity;

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

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind(Include = "Email,Password,")] LoginModel model)
        {
            if (model != null)
            {
                Users user = await db.Users.Where(u => u.Email == model.Email).FirstAsync();
                if (user != null)
                {
                    if (user.Password == model.Password)
                    {
                        HttpCookie user_id = new HttpCookie("user_id");
                        user_id.Name = "user_id";
                        user_id.Value = user.Id.ToString();
                        user_id.HttpOnly = true;

                        HttpCookie ip = new HttpCookie("ip");
                        ip.Name = "ip";
                        ip.Value = Request.UserHostAddress;
                        ip.HttpOnly = true;

                        HttpCookie browser = new HttpCookie("browser");
                        browser.Name = "browser";
                        browser.Value = HttpContext.Request.Browser.Browser;
                        browser.HttpOnly = true;


                        Response.Cookies.Add(user_id);
                        Response.Cookies.Add(ip);
                        Response.Cookies.Add(browser);
                        return RedirectToAction("Index", "Home");
                    }
                }

                return PartialView("LoginError");
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Include = "Id,Name,Email,Password,PasswordConfirm,PhoneNumber")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);

                HttpCookie user_id = new HttpCookie("user_id");
                user_id.Name = "user_id";
                user_id.Value = users.Id.ToString();
                user_id.HttpOnly = true;                

                HttpCookie ip = new HttpCookie("ip");
                ip.Name = "ip";
                ip.Value = Request.UserHostAddress;
                ip.HttpOnly = true;

                HttpCookie browser = new HttpCookie("browser");
                browser.Name = "browser";
                browser.Value = HttpContext.Request.Browser.Browser;
                browser.HttpOnly = true;


                Response.Cookies.Add(user_id);
                Response.Cookies.Add(ip);
                Response.Cookies.Add(browser);

                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(users);
        }
    }
}
