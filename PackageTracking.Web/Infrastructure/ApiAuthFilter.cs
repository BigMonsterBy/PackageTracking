using PackageTracking.Web.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web;

namespace PackageTracking.Web.Infrastructure
{
    public class ApiAuthFilter : AuthorizationFilterAttribute
    {
        private readonly IUserService userService;
        public ApiAuthFilter()
        {
            var resolver = System.Web.Mvc.DependencyResolver.Current;
            userService = (IUserService)resolver.GetService(typeof(IUserService));
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (HttpContext.Current.User?.Identity?.IsAuthenticated == true)
                return;

            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
                return;

            var userCookie = actionContext.Request.Headers.GetCookies(Constantes.UserCookieName);
            if (userCookie.Any())
            {
                if (int.TryParse(userCookie.First()[Constantes.UserCookieName].Value, out int userId))
                {
                    var user = userService.GetUser(userId);
                    userService.SetPrincipal(user);
                    return;
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}