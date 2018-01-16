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
using PackageTracking.Core;

namespace PackageTracking.Web.Infrastructure
{
    public class ApiAuthFilter : AuthorizationFilterAttribute
    {
        public ApiAuthFilter()
        {}

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AuthentificationService authentificationService = new AuthentificationService(actionContext);
            if (!authentificationService.IsAuthorized())
            {
                base.OnAuthorization(actionContext);
            }
            else
                return;
        }
    }
}