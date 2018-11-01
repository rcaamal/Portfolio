using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matience.Models;
using Matience.DAL;


namespace Matience.Controllers
{
    public class HomeController : Controller
    {
        public TendentCollection T = new TendentCollection();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tendent user = T.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult AllUsers()
        {
            return View(T.Users);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,AptName,UNumber,Explanation")] Tendent user)
        {
            if (ModelState.IsValid)
            {
                T.Users.Add(user);
                T.SaveChanges();
                return RedirectToAction("AllUsers");
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tendent user = T.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Edit([Bind(Include = "ID, FirstName, LastName, PhoneNumber, AptName, UNumber, Explanation")] Tendent user)
        {
            if (ModelState.IsValid)
            {
                T.Entry(user).State = EntityState.Modified;
                T.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tendent user = T.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tendent user = T.Users.Find(id);
            T.Users.Remove(user);
            T.SaveChanges();
            return RedirectToAction("Index");
        }
    
    }
}