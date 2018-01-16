using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackageTracking.Web.Infrastructure.Services;
using System.Web.Mvc;
using PackageTracking.Web;
using System.Web.Routing;
using PackageTracking.Core;
using System.Web.Http.Controllers;

namespace PackageTracking.Web.Infrastructure
{
    public class WebAuthFilter : IAuthorizationFilter
    {
        public WebAuthFilter()
        { }
        

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            AuthentificationService authentificationService = new AuthentificationService(filterContext);
            if (!authentificationService.IsAuthorized())
            {
                var urlHelper = new UrlHelper(filterContext.RequestContext);
                filterContext.Result = new RedirectResult(urlHelper.Action("Logon", "Home"));
            }
            else
                return;
        }
    }
}