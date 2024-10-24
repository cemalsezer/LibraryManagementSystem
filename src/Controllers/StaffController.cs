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
            db.STAFF.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}