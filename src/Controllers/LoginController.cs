using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
using System.Web.Security;


namespace LibraryManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(USER u)
        {
            var info = db.USER.FirstOrDefault(x => x.EMAIL == u.EMAIL && x.PASSWORD == u.PASSWORD);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.EMAIL, false);
                Session["Email"] = info.EMAIL.ToString();
                //TempData["id"] = info.ID.ToString();
                //TempData["Name"] = info.NAME.ToString();
                //TempData["Surname"] = info.SURNAME.ToString();
                //TempData["UserName"] = info.USERNAME.ToString();
                //TempData["Sifre"] = info.PASSWORD.ToString();
                //TempData["University"] = info.SCHOOLNAME.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}