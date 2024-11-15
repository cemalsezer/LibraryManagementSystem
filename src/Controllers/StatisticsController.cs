using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    public class StatisticsController : Controller
    {
        DBKUTUPHANEEntities db  = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values1 = db.USER.Count();
            var values2 = db.BOOK.Count();
            var values3 = db.BOOK.Where(x => x.STATUS == false).Count();
            var values4 = db.PUNISHMENT.Sum(x => x.MONEY);
            ViewBag.vls1 = values1;
            ViewBag.vls2 = values2;
            ViewBag.vls3 = values3;
            ViewBag.vls4 = values4;
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }
        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ImageUpload(HttpPostedFileBase files)
        {
            if (files.ContentLength > 0) 
            {
                string fileUrl = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName
                    (files.FileName));
                files.SaveAs(fileUrl);
            }
            return RedirectToAction("Gallery");
        }
        public ActionResult LinqCard()
        {
            var value1 = db.BOOK.Count();
            var value2 = db.USER.Count();
            var value3 = db.PUNISHMENT.Sum(x => x.MONEY);
            var value4 = db.BOOK.Where(x => x.STATUS == false).Count();
            var value5 = db.CATEGORY.Count();
            var value8 = db.authormostbooks().FirstOrDefault();
            var value9 = db.BOOK.GroupBy(x => x.PUBLISHER).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            var value11 = db.CONTACTUS.Count();

            ViewBag.vls1 = value1;
            ViewBag.vls2 = value2;
            ViewBag.vls3 = value3;
            ViewBag.vls4 = value4;
            ViewBag.vls5 = value5;
            ViewBag.vls8 = value8;
            ViewBag.vls9 = value9;
            ViewBag.vls11 = value11;

            return View();
        }
    }
}