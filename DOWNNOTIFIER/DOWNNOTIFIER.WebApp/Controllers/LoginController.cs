using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.Extension;
using DOWNNOTIFIER.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DOWNNOTIFIER.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserBL _user;

        public LoginController(IUserBL user)
        {
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            model.Username = model.Username.ToSHA256();
            model.Password = model.Password.ToSHA256();

            var dto = _user.GetByCridential(model.Username, model.Password);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, dto.Name),
                new Claim(ClaimTypes.Surname, dto.Surname),
                new Claim(ClaimTypes.Role, dto.UserRole.Name),
            };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrinciple = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrinciple, new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            });

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
