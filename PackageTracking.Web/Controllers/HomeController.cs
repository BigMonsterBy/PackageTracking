using PackageTracking.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackageTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ViewResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Logon(LogonViewModel model)
        {
            return View(model);
        }
    }
}
