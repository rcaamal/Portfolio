using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace Interactive.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        

        [HttpGet]
        public ActionResult MetricConverter()

        {   string num = Request.QueryString["num"];
            string metric = Request.QueryString["metric"];

            ViewBag.num = num;
            ViewBag.metric = metric;
             if (!String.IsNullOrEmpty(num))
            {
               if (metric[0] == 'i')
                {
                    ViewBag.i = Convert.ToDouble(num) * 1609344;
                    return View();
                }

                else if (metric[0] == 'c')
                {
                    ViewBag.c = Convert.ToDouble(num) * 160934.4;
                    return View();
                }

                else if (metric[0] == 'm')
                {
                    ViewBag.m = Convert.ToDouble(num) * 1609.344;

                    return View();
                }

                else if (metric[0] == 'k')
                {
                    ViewBag.k = Convert.ToDouble(num) * 1.609344;

                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage("Invalid input");
                    return View();
                }

            }
            return View();
        
        }

        public ActionResult Color()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Color(String fColor, String sColor)
        {
            Color color = ColorTranslator.FromHtml(fColor);
            Color color2 = ColorTranslator.FromHtml(sColor);
                 

            return View();
        }





        [HttpGet]
        public ActionResult Message()
        {
            // I want the query string values
            Debug.WriteLine(Request.QueryString["user_name"]);
            Debug.WriteLine(Request.QueryString["user_email"]);
            Debug.WriteLine(Request.QueryString["user_message"]);

            string name = Request.QueryString["user_name"];
            if (name != null)
            {
                string message = "Hello " + name + "! Welcome.";
                ViewBag.message = message;
                // Same as 
                //ViewData["message"] = message;
            }

            return View();
        }

        public ActionResult Message2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Message2(string user_name, string user_email, string user_message)
        {
            Debug.WriteLine(user_name);
            Debug.WriteLine(user_email);
            Debug.WriteLine(user_message);
            return View();
        }

    }
}