using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
using System.Web.Security;


namespace LibraryManagementSystem.Controllers
{
    [AllowAnonymous]
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
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}