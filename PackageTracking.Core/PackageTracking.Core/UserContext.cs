using PackageTracking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Core
{
    public class UserContext : IUserContext
    {
        public int UserId { get; set; }
    }
}
