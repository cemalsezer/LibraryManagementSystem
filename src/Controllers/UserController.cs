using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace LibraryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public ActionResult Index(int page = 1)
        {
            //var values = db.USER.ToList();
            var values = db.USER.ToList().ToPagedList(page, 5);
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
            userUpdate.SURNAME = s.SURNAME;
            userUpdate.EMAIL = s.EMAIL;
            userUpdate.USERNAME = s.USERNAME;
            userUpdate.PASSWORD = s.PASSWORD;
            userUpdate.SCHOOLNAME = s.SCHOOLNAME;
            userUpdate.PHONE = s.PHONE;
            userUpdate.IMAGE = s.IMAGE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}