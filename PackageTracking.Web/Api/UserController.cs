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
using PackageTracking.Web.Infrastructure.Services;
using PackageTracking.Web;

namespace PackageTracking.Web.Api
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly PackageTrackingContext packageTrackingContext;
        private readonly IUserService _userService;

        public UserController(PackageTrackingContext context, IUserService userService)
        {
            packageTrackingContext = context;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Login(string userName, string userPassword, int userTimeOffset)
        {
            try
            {
                var user = _userService.GetUser(userName, userPassword);
                _userService.SetPrincipal(user, userTimeOffset);
                var us = packageTrackingContext.User.Find(user.UserId);
                us.LastLogOn = DateTime.UtcNow;
                packageTrackingContext.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
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
    }
}