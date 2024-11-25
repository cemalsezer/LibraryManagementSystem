using LibraryManagementSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;


namespace LibraryManagementSystem.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            var values = db.LOANS.Where(x => x.OPERATIONSSTATE == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult GiveLoan()
        {
            List<SelectListItem> value1 = (from x in db.USER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NAME + " " + x.SURNAME,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> value2 = (from y in db.BOOK.Where(x => x.STATUS == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.NAME,
                                               Value = y.ID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from z in db.STAFF.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.NAME,
                                               Value = z.ID.ToString()
                                           }).ToList();

            ViewBag.vl1 = value1;
            ViewBag.vl2 = value2;
            ViewBag.vl3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult GiveLoan(LOANS l)
        {
            var d1 = db.USER.Where(x => x.ID == l.USER.ID).FirstOrDefault();
            var d2 = db.BOOK.Where(y => y.ID == l.BOOK.ID).FirstOrDefault();
            var d3 = db.STAFF.Where(z => z.ID == l.STAFF.ID).FirstOrDefault();
            l.USER = d1;
            l.BOOK = d2;
            l.STAFF = d3;
            db.LOANS.Add(l);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReturnLoan(LOANS p)
        {
            var loan = db.LOANS.Find(p.ID);
            DateTime d1 = DateTime.Parse(loan.DUEDATE.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.vls = d3.TotalDays;
            return View("ReturnLoan", loan);

        }
        public ActionResult LoanUpdate(LOANS loan)
        {
            var l = db.LOANS.Find(loan.ID);
            l.USERRETURN = loan.USERRETURN;
            l.OPERATIONSSTATE = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}