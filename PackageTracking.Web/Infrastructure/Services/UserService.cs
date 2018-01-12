using PackageTracking.Core;
using PackageTracking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace PackageTracking.Web.Infrastructure.Services
{
    public interface IUserService
    {
        User GetUser(int userId);
        User GetUser(string userName, string userPassword);
        void SetPrincipal(User user, TimeZoneInfo userTimeZone);
    }

    public class UserService : IUserService
    {
        private readonly PackageTrackingContext packageTrackingContext;

        public UserService(PackageTrackingContext context)
        {
            packageTrackingContext = context;
        }

        public User GetUser(int userId)
        {
            return packageTrackingContext.User.Find(userId);
        }

        public User GetUser(string userName, string userPassword)
        {
            userPassword = Chipher.GetMd5Hash(userPassword);
            return packageTrackingContext.User.Single(u => u.Name == userName && u.Password == userPassword);
        }

        public void SetPrincipal(User user, TimeZoneInfo userTimeZone)
        {
            var webIdentity = new WebIdentity { Name = user.Name, IsAuthenticated = true };
            var webPrincipal = new WebPrincipal { Identity = webIdentity };

            Thread.CurrentPrincipal = webPrincipal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = webPrincipal;
                //add time zone info to user context
                HttpContext.Current.Items[Constantes.UserContext] = new UserContext { UserId = user.UserId, UserTimeZone=userTimeZone };
            }
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(Constantes.UserCookieName, user.UserId.ToString()));
        }

    }

    public  class WebPrincipal : IPrincipal
    {
        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }

    public class WebIdentity : IIdentity
    {
        public string Name { get; set; }

        public string AuthenticationType => throw new NotImplementedException();

        public bool IsAuthenticated { get; set; }
    }

}