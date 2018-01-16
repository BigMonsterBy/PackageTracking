using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace PackageTracking.Web.Infrastructure.Services
{
    public class AuthentificationService
    {
        private HttpActionContext actionContext;
        private AuthorizationContext authorizationContext;
        private UserService userService;
        public AuthentificationService(HttpActionContext actionContext)
        {
            this.actionContext = actionContext;
            userService = GetUserService();
        }
        public AuthentificationService(AuthorizationContext authorizationContext)
        {
            this.authorizationContext = authorizationContext;
            userService = GetUserService();
        }

        private UserService GetUserService()
        {
            return (UserService)DependencyResolver.Current.GetService<IUserService>();
        }

        private bool IsAnonymousDefined(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
        private bool IsAnonymousDefined(AuthorizationContext authorizationContext)
        {
            return authorizationContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any();
        }

        private bool IsUserAuthentificated()
        {
            return HttpContext.Current.User?.Identity?.IsAuthenticated==true;
        }

        private bool IsCookiePlaced()
        {
            var userCookie = CookieService.GetCookie(Constantes.UserCookieName);
            if (userCookie != null)
            {
                if (int.TryParse(userCookie.Value, out int userId))
                {
                    var user = userService.GetUser(userId);
                    int offset = Int16.Parse(CookieService.GetCookieStringValue(Constantes.UserTimeOffset));
                    userService.SetPrincipal(user, offset);
                    return true;
                }
            }
            return false;
        }

        public bool IsAuthorized()
        {
            if(actionContext!=null)
            {
                if (IsAnonymousDefined(actionContext))
                    return true;
            }
            else
            {
                if (IsAnonymousDefined(authorizationContext))
                    return true;
            }
            if (IsUserAuthentificated())
                return true;
            return IsCookiePlaced();
        }
    }
}