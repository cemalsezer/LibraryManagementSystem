using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.AUTHOR.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AuthorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorAdd(AUTHOR author)
        {
            if(!ModelState.IsValid)
            {
                return View("AuthorAdd");
            }
            db.AUTHOR.Add(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorDelete(int id)
        {
            var author = db.AUTHOR.Find(id);
            db.AUTHOR.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorGet(int id)
        {
            var author = db.AUTHOR.Find(id);
            return View("AuthorGet", author);
        }
        public ActionResult AuthorUpdate(AUTHOR author)
        {
            var authorInfo = db.AUTHOR.Find(author.ID);
            authorInfo.NAME = author.NAME;
            authorInfo.SURNAME = author.SURNAME;
            authorInfo.DETAIL = author.DETAIL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}