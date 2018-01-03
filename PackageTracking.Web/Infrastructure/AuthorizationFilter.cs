using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PackageTracking.Web.Infrastructure.Services;
using System.Web.Mvc;
using PackageTracking.Web;

namespace PackageTracking.Web.Infrastructure
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly IUserService userService;
        public AuthorizationFilter()
        {
            userService = DependencyResolver.Current.GetService<IUserService>();
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userCookie = filterContext.HttpContext.Request.Cookies.Get(Constantes.UserCookieName);
            if (userCookie != null)
            {
                if (int.TryParse(userCookie.Value, out int userId))
                {
                    var user = userService.GetUser(userId);
                    userService.SetPrincipal(user);
                }
            }
        }
    }
}