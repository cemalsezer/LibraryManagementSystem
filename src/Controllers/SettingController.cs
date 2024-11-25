using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    public class SettingController : Controller
    {
        // GET: Setting
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index()
        {
            var users = db.ADMIN.ToList();
            return View(users);
        }
        public ActionResult Index2()
        {
            var users = db.ADMIN.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult NewAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(ADMIN admin)
        {
            db.ADMIN.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var admin = db.ADMIN.Find(id);
            db.ADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var admin = db.ADMIN.Find(id);
            return View("UpdateAdmin",admin);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(ADMIN a)
        {
            var admin = db.ADMIN.Find(a.ID);
            admin.ADMINEMAIL = a.ADMINEMAIL;
            admin.PASSWORD = a.PASSWORD;
            admin.AUTHORITY = a.AUTHORITY;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

    }
}