using LibraryManagementSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.ANNOUNCEMENT.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAnnouncement(ANNOUNCEMENT t)
        {
            db.ANNOUNCEMENT.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAnnouncement(int id)
        {
            var announcement = db.ANNOUNCEMENT.Find(id);
            db.ANNOUNCEMENT.Remove(announcement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailAnnouncement(ANNOUNCEMENT p)
        {
            var announcement = db.ANNOUNCEMENT.Find(p.ID);
            return View("DetailAnnouncement", announcement);
        }
        public ActionResult UpdateAnnouncement(ANNOUNCEMENT t)
        {
            var announcement = db.ANNOUNCEMENT.Find(t.ID);
            announcement.AN_CATEGORY = t.AN_CATEGORY;
            announcement.TEXT = t.TEXT;
            announcement.DATE = t.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}