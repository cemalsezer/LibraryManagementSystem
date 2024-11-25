using LibraryManagementSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;


namespace LibraryManagementSystem.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var userMail = (string)Session["EMail"].ToString();
            var messages = db.MESSAGE.Where(x => x.RECEIVER == userMail.ToString()).ToList(); ;
            return View(messages);
        }

        public ActionResult Outgoing()
        {
            var userMail = (string)Session["EMail"].ToString();
            var messages = db.MESSAGE.Where(x => x.SENDER == userMail.ToString()).ToList(); ;
            return View(messages);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(MESSAGE t)
        {
            var userMail = (string)Session["EMail"].ToString();
            t.SENDER = userMail.ToString();
            t.DATE = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.MESSAGE.Add(t);
            db.SaveChanges();
            return RedirectToAction("Outgoing", "Message");
        }
        public PartialViewResult Partial1()
        {
            var userMail = (string)Session["EMail"].ToString();
            var inboxValue = db.MESSAGE.Where(x => x.RECEIVER == userMail).Count();
            ViewBag.d1= inboxValue;
            var outgoingValue = db.MESSAGE.Where(x => x.SENDER == userMail).Count();
            ViewBag.d2 = outgoingValue;

            return PartialView();
        }
    }
}