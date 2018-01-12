using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackageTracking.Web.Infrastructure.Services;
using System.Web.Mvc;
using PackageTracking.Web;
using System.Web.Routing;
using PackageTracking.Core;

namespace PackageTracking.Web.Infrastructure
{
    public class WebAuthFilter : IAuthorizationFilter
    {
        private readonly IUserService userService;
        public WebAuthFilter()
        {
            userService = DependencyResolver.Current.GetService<IUserService>();
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.User?.Identity?.IsAuthenticated == true)
                return;

            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any())
                return;

            var userCookie = filterContext.HttpContext.Request.Cookies.Get(Constantes.UserCookieName);
            if (userCookie != null)
            {
                if (int.TryParse(userCookie.Value, out int userId))
                {
                    var user = userService.GetUser(userId);
                    //replace null with the correct TimeZoneInfo
                    var userContext =(UserContext) HttpContext.Current.Items[Constantes.UserContext];
                    userService.SetPrincipal(user, userContext.UserTimeZone);
                    return;
                }
            }
            var urlHelper = new UrlHelper(filterContext.RequestContext);
            filterContext.Result = new RedirectResult(urlHelper.Action("Logon", "Home"));
        }
    }
}