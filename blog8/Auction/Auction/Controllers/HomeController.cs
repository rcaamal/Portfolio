using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Auction.Models;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        public AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            // get the most recent bids and order by time in descending/only take 10
            return View(db.Bids.OrderByDescending(x => x.TimeStamp).Take(10).ToList());
        }
    }
}