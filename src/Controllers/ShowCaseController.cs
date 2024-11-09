using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
using LibraryManagementSystem.Models.Classes;

namespace LibraryManagementSystem.Controllers
{
    public class ShowCaseController : Controller
    {
        // GET: ShowCase
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value1 = db.BOOK.ToList();
            cs.Value2 = db.ABOUTUS.ToList();

            //var values = db.BOOK.ToList();
            return View(cs);
        }
        
        [HttpPost]
        public ActionResult Index(CONTACTUS cu) 
        {
            db.CONTACTUS.Add(cu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}