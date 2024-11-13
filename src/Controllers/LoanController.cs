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

        public ActionResult Index()
        {
            var values = db.LOANS.Where(x => x.OPERATIONSSTATE == false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult GiveLoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GiveLoan(LOANS l)
        {
            db.LOANS.Add(l);
            db.SaveChanges();
            return View();
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