using PackageTracking.Core;
using PackageTracking.Core.Interfaces;
using PackageTracking.Web.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackageTracking.Web.Infrastructure
{
    public class UserContextProvider : IUserContextProvider
    {
        public IUserContext GetUserContext()
        {
            //var userContext = HttpContext.Current.Items[Constantes.UserContext];
            UserContext userContext = new UserContext(Int16.Parse(CookieService.GetCookieStringValue(Constantes.UserCookieName)),
                Int16.Parse(CookieService.GetCookieStringValue(Constantes.UserTimeOffset)));
            return userContext;
        }
    }
}