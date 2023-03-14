using Online_shop.Data;
using Online_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_shop.Controllers
{
    public class ProfileController : Controller
    {
        private Online_shopContext db = new Online_shopContext();
        // GET: Profile
        [Authorize]
        public ActionResult Index()
        {
            string[] keys = Request.Cookies.AllKeys;
            if (keys.Where(c => c == "user_id") != null || 
                keys.Where(c => c == "ip") != null || 
                keys.Where(c => c == "browser") != null)
            {
                Users user = db.Users
                    .Where(u => u.Id == Convert.ToInt32(keys.Where(c => c == "user_id")))
                    .FirstOrDefault();

                return View(user);
            }
            return RedirectToAction("Login", "Users");
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
