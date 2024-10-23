using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var books = db.BOOK.ToList();
            return View(books);
        }
        [HttpGet]
        public ActionResult BookAdd()
        {
            List<SelectListItem> value1= (from i in db.CATEGORY.ToList()
                                          select new SelectListItem
                                          {
                                              Text=i.NAME,
                                              Value=i.ID.ToString()
                                          }).ToList();
            ViewBag.vl1=value1;

            List<SelectListItem> value2 = (from i in db.AUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME + ' ' + i.SURNAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vl2 = value2;
            return View();
        }
        [HttpPost]
        public ActionResult BookAdd(BOOK b)
        {
            var category = db.CATEGORY.Where(c => c.ID == b.CATEGORY1.ID).FirstOrDefault();
            var author = db.AUTHOR.Where(a=>a.ID == b.AUTHOR1.ID).FirstOrDefault();
            b.CATEGORY1 = category;
            b.AUTHOR1 = author;
            db.BOOK.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookDelete(int id)
        {
            var book = db.BOOK.Find(id);
            db.BOOK.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookGet(int id)
        {
            var book = db.BOOK.Find(id);
            List<SelectListItem> value1 = (from i in db.CATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            List<SelectListItem> value2 = (from i in db.AUTHOR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.NAME + ' ' + i.SURNAME,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.vl2 = value2;
            return View("BookGet", book);
        }
        public ActionResult BookUpdate(BOOK b)
        {
            var book = db.BOOK.Find(b.ID);
            book.NAME = b.NAME;
            book.PUBLISHDATE = b.PUBLISHDATE;
            book.PAGE=b.PAGE;
            book.PUBLISHER = b.PUBLISHER;
            var category = db.CATEGORY.Where(c => c.ID == b.CATEGORY1.ID).FirstOrDefault();
            var author = db.AUTHOR.Where(a=>a.ID == b.AUTHOR1.ID).FirstOrDefault();
            book.CATEGORY = category.ID;
            b.AUTHOR = author.ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}