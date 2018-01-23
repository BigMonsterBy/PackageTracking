using PackageTracking.Data;
using System.Web.Mvc;

namespace PackageTracking.Web.Controllers
{
    [Authorize]
    public class WebController : Controller
    {
        protected readonly PackageTrackingContext _packageTrackingContext;

        public WebController(PackageTrackingContext packageTrackingContext)
        {
            _packageTrackingContext = packageTrackingContext;
        }
    }
}