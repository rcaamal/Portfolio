using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace Interactive.Controllers
{
    public class ColorChooser : Controller
    {
        // GET: ColorChooser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Color()
        {
            return View();
        }
        
    }
}
