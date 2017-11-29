using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PackageTracking.Data;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace PackageTracking.Web.Api
{
    public class UserController : ApiController
    {
        private readonly PackageTrackingContext packageTrackingContext;

        public UserController(PackageTrackingContext context)
        {
            packageTrackingContext = context;
        }

        [HttpPost]
        public HttpResponseMessage Login(string userName, string userPassword)
        {
            try
            {
                var user = packageTrackingContext.User.Single(u => u.Name == userName && u.Password == userPassword);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            var users = packageTrackingContext.User;
            return users.Select(u => u.Name);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private void SetPrincipal(User user)
        {
            var webIdentity = new WebIdentity { Name = user.Name, IsAuthenticated = true };
            var webPrincipal = new WebPrincipal { Identity = webIdentity };

            Thread.CurrentPrincipal = webPrincipal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = webPrincipal;
            }
        }

        private class WebPrincipal : IPrincipal
        {
            public IIdentity Identity { get; set; }

            public bool IsInRole(string role)
            {
                throw new NotImplementedException();
            }
        }

        private class WebIdentity : IIdentity
        {
            public string Name { get; set; }

            public string AuthenticationType => throw new NotImplementedException();

            public bool IsAuthenticated { get; set; }
        }
    }
}