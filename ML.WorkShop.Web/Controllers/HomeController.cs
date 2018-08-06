using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ML.WorkShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Basis()
        {
            return View("Basis");
        }

        public ActionResult Lesson1()
        {
            

            return View();
        }
    }
}