﻿using LibraryManagementSystem.Models.Entity;
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
            var values = db.LOANS.ToList();
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
        public ActionResult ReturnLoan(int id)
        {
          var loan = db.LOANS.Find(id);
            return View("ReturnLoan",loan);
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