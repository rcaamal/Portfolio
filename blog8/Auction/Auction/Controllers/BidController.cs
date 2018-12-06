
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.Models;

namespace Auction.Controllers
{
    public class BidController : Controller
    {
        public class BidsController : Controller
        {
            private AuctionContext db = new AuctionContext();

            // GET: Bids
            // Orders the bids by most recent to earliest
            public ActionResult Index()
            {
                // set var bids to get buyer and item
                var bids = db.Bids.Include(b => b.Buyer1).Include(b => b.Item);

                return View(bids.OrderByDescending(model => model.TimeStamp).ToList());
            }

            // GET: Bids/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bid bid = db.Bids.Find(id);
                if (bid == null)
                {
                    return HttpNotFound();
                }
                return View(bid);
            }

            // GET: Bids/Create
            public ActionResult Create()
            {
                ViewBag.Buyer = new SelectList(db.Buyers, "ID", "Name");
                ViewBag.ItemID = new SelectList(db.Items, "ID", "Name");
                return View();
            }

            // POST: Bids/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "ID,ItemID,Buyer,Price,TimeStamp")] Bid bid)
            {
                if (ModelState.IsValid)
                {
                    bid.TimeStamp = DateTime.Now;
                    db.Bids.Add(bid);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Buyer = new SelectList(db.Buyers, "ID", "Name", bid.Buyer);
                ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", bid.ItemID);
                return View(bid);
            }

            // GET: Bids/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bid bid = db.Bids.Find(id);
                if (bid == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Buyer = new SelectList(db.Buyers, "ID", "Name", bid.Buyer);
                ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", bid.ItemID);
                return View(bid);
            }

            // POST: Bids/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "ID,ItemID,Buyer,Price,TimeStamp")] Bid bid)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bid).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Buyer = new SelectList(db.Buyers, "ID", "Name", bid.Buyer);
                ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", bid.ItemID);
                return View(bid);
            }

            // POST: Bids/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Bid bid = db.Bids.Find(id);
                db.Bids.Remove(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
}