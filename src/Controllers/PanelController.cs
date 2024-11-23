using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        [Authorize]
        public ActionResult Index()
        {
            var userMail = (string)Session["EMail"];
            var values = db.USER.FirstOrDefault(z => z.EMAIL == userMail);
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
        //public ActionResult Announcements()
        //{
        //    //var duyurulistesi = db.ANNOUNCEMENTS.ToList();
        //    //return View(duyurulistesi);
        //}
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}