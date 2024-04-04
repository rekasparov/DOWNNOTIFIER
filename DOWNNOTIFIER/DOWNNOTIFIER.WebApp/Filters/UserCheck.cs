using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DOWNNOTIFIER.WebApp.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UserCheck : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectToActionResult("Index", "Login", null);
        }
    }
}
