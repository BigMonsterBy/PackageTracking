using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackageTracking.Web.Infrastructure.Services
{
    public class CookieService
    {
        public static void AddCookie(string key, object value)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(key, value.ToString()));
        }

        public static string GetCookieStringValue(string key)
        {
            return HttpContext.Current.Request.Cookies[key].Value;
        }

        public static HttpCookie GetCookie(string key)
        {
            return HttpContext.Current.Request.Cookies[key];
        }
    }
}