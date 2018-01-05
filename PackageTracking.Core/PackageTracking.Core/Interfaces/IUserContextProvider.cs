using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageTracking.Core.Interfaces
{
    public interface IUserContextProvider
    {
        IUserContext GetUserContext();
    }
}
