using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.LOANS.Where(x => x.OPERATIONSSTATE == true).ToList();
            return View(values);
        }
    }
}