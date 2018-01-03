using PackageTracking.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PackageTracking.Web;

namespace PackageTracking.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var userCookie = HttpContext.Request.Cookies[Constantes.UserCookieName];
            if (userCookie == null)
            {
                return RedirectToAction("Logon");
            }
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ViewResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(LogonViewModel model)
        {
            var apiUserController = DependencyResolver.Current.GetService<Api.UserController>();

            if (apiUserController.Login(model.Name, model.Password).StatusCode == System.Net.HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("*", "Somethig went wrong");
                return View(model);
            }
        }
    }
}
