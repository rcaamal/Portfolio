using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WideWorldImporters.Models;

namespace WideWorldImporters.Controllers
{
    public class HomeController : Controller
    {
        Model db = new Model();

        public ActionResult Index()
        {
            return View();
        }

           

        
        public ActionResult WorldWideImporters(string searching)
        {

            return View(db.People.Where(x => x.FullName.StartsWith(searching) || searching == null).ToList());
        }

        public ActionResult Company(string search)
        {
            return View(db.Suppliers.Where(a => a.SupplierName.StartsWith(search) || search == null).ToList());
        }

        public ActionResult Purchases(string search)
        {
            return View(db.InvoiceLines.Where(a => a.Description.StartsWith(search) || search == null).ToList());
        }

        public ActionResult Profit(string scan)
        {
            return View(db.InvoiceLines.Where(a => a.Description.StartsWith(scan) || scan == null).ToList());
        }


    }
}