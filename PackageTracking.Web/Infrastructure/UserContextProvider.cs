using PackageTracking.Core.Interfaces;
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
            var userContext = HttpContext.Current.Items[Constantes.UserContext];
            return (IUserContext)userContext;
        }
    }
}