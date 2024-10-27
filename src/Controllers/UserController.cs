using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index()
        {
            var values = db.USER.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UserAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserAdd(USER u)
        {
            if (!ModelState.IsValid)
            {
                return View("UserAdd");
            }
            db.USER.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
            //return View();
        }
        public ActionResult UserDelete(int id)
        {
            var user = db.USER.Find(id);
            db.USER.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UserGet(int id)
        {
            var user = db.USER.Find(id);
            return View("UserGet", user);
        }
        public ActionResult UserUpdate(USER s)
        {
            var userUpdate = db.USER.Find(s.ID);
            userUpdate.NAME = s.NAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}