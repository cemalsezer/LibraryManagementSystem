using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeBookResult() 
        {
            return Json(liste(), JsonRequestBehavior.AllowGet);
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>
            {
                new Class1 { Publisher = "Yildiz", Value = 5 },
                new Class1 { Publisher = "Alfa", Value = 9 }
            };
            return cs;
        }
    }
}