using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.WebApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DOWNNOTIFIER.WebApp.Controllers
{
    [UserCheck]
    public class DashboardController : Controller
    {
        private readonly IApplicationBL _application;

        public DashboardController(IApplicationBL application)
        {
            _application = application;
        }

        public IActionResult Index()
        {
            return View(_application.GetAll());
        }
    }
}
