using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        // GET: Panel

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        //[Authorize]
        public ActionResult Index()
        {
            var userMail = (string)Session["EMail"];
            //var values = db.USER.FirstOrDefault(z => z.EMAIL == userMail);
            var values = db.ANNOUNCEMENT.ToList();
            var d1 = db.USER.Where(x=>x.EMAIL == userMail).Select(y=>y.NAME).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = db.USER.Where(x => x.EMAIL == userMail).Select(y => y.SURNAME).FirstOrDefault();
            ViewBag.d2 = d2;
            var d3 = db.USER.Where(x => x.EMAIL == userMail).Select(y => y.IMAGE).FirstOrDefault();
            ViewBag.d3 = d3;
            var d4 = db.USER.Where(x => x.EMAIL == userMail).Select(y => y.USERNAME).FirstOrDefault();
            ViewBag.d4 = d4;
            var d5 = db.USER.Where(x => x.EMAIL == userMail).Select(y => y.SCHOOLNAME).FirstOrDefault();
            ViewBag.d5 = d5;
            var d6 = db.USER.Where(x => x.EMAIL == userMail).Select(y => y.PHONE).FirstOrDefault();
            ViewBag.d6 = d6;
            var d7 = db.USER.Where(x => x.EMAIL == userMail).Select(y => y.EMAIL).FirstOrDefault();
            ViewBag.d7 = d7;
            var userId = db.USER.Where(x => x.EMAIL == userMail).Select(y => y.ID).FirstOrDefault();
            var d8 = db.LOANS.Where(x => x.USER_ID == userId).Count();
            ViewBag.d8 = d8;
            var d9 = db.MESSAGE.Where(x => x.RECEIVER == userMail).Count();
            ViewBag.d9 = d9;
            var d10 = db.ANNOUNCEMENT.Count();
            ViewBag.d10 = d10;
            return View(values);
        }
        [HttpPost]
        public ActionResult Index2(USER u)
        {
            var user = (string)Session["EMail"];
            var member = db.USER.FirstOrDefault(x => x.EMAIL == user);
            member.PASSWORD = u.PASSWORD;
            member.NAME = u.NAME;
            member.IMAGE = u.IMAGE;
            member.SCHOOLNAME = u.SCHOOLNAME;
            member.USERNAME = u.USERNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Books()
        {
            var kullanici = (string)Session["EMail"];
            var id = db.USER.Where(x => x.EMAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.LOANS.Where(x => x.USER_ID == id).ToList();
            return View(degerler);
        }

        //[Authorize]
        public ActionResult Announcements()
        {
            var announcementList = db.ANNOUNCEMENT.ToList();
            return View(announcementList);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["EMail"];
            var id = db.USER.Where(x => x.EMAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var findUser = db.USER.Find(id);
            return PartialView("Partial2", findUser);
        }
    }
}