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
        public ActionResult Index()
        {
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
    }
}