using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryManagementSystem.Models.Entity;


namespace LibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: AdminLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ADMIN admin) {
            var infos = db.ADMIN.FirstOrDefault(x=>x.ADMINEMAIL==admin.ADMINEMAIL && x.PASSWORD==admin.PASSWORD);
            if (infos != null) 
            {
                FormsAuthentication.SetAuthCookie(infos.ADMINEMAIL, false);
                Session["ADMINEMAIL"] = infos.ADMINEMAIL.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
    }
}