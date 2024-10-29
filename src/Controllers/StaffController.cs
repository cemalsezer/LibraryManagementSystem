using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.STAFF.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult StaffAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StaffAdd(STAFF s)
        {
            if(!ModelState.IsValid)
            {
                return View("StaffAdd");
            }
            db.STAFF.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffDelete(int id)
        {
            var staff = db.STAFF.Find(id);
            db.STAFF.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffGet(int id)
        {
            var staff = db.STAFF.Find(id);
            return View("StaffGet", staff);
        }
        public ActionResult StaffUpdate(STAFF s)
        {
            var staffUpdate = db.STAFF.Find(s.ID);
            staffUpdate.NAME = s.NAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}