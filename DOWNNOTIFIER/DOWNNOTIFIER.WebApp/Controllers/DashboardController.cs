using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.Notification.Concrete;
using DOWNNOTIFIER.WebApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DOWNNOTIFIER.WebApp.Controllers
{
    [UserCheck]
    public class DashboardController : Controller
    {
        private readonly IApplicationBL _application;
        private readonly EMailNotification _emailNotification;

        public DashboardController(IApplicationBL application, EMailNotification emailNotification)
        {
            _application = application;
            _emailNotification = emailNotification;
        }

        public IActionResult Index()
        {
            return View(_application.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> SendEMail(int applicationId, string state)
        {
            var parameters = new Dictionary<string, object>();

            await _emailNotification.SendNotification(parameters);

            return Ok();
        }
    }
}
