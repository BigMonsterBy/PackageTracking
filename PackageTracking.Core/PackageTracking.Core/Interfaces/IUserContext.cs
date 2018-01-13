using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Core.Interfaces
{
    public interface IUserContext
    {
        int UserId { get; }
        int UserTimeOffset { get; set; }
    }
}
