using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.CATEGORY.Where(x => x.STATUS == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(CATEGORY c)
        {
            db.CATEGORY.Add(c);
            db.SaveChanges();
            return View();
        }

        public ActionResult CategoryDelete(int id) 
        {
            var category = db.CATEGORY.Find(id);
            //db.CATEGORY.Remove(category);
            category.STATUS = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryGet(int id)
        {
            var category = db.CATEGORY.Find(id);
            return View("CategoryGet",category);
        }
        public ActionResult CategoryUpdate(CATEGORY c)
        {
            var categoryUpdate = db.CATEGORY.Find(c.ID);
            categoryUpdate.NAME=c.NAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}