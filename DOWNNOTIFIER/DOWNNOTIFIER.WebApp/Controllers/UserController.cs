using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.DataTransferObject;
using DOWNNOTIFIER.Extension;
using DOWNNOTIFIER.WebApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DOWNNOTIFIER.WebApp.Controllers
{
    //[UserCheck]
    public class UserController : Controller
    {
        private readonly IUserBL _user;
        private readonly IUserRoleBL _userRole;

        public UserController(IUserBL user, IUserRoleBL userRole)
        {
            _user = user;
            _userRole = userRole;
        }

        public IActionResult Index()
        {
            return View(_user.GetAll());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.UserRole = _userRole.GetAll();

            return View(_user.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(UserDTO model)
        {
            model.Username = model.Username.ToSHA256();
            model.Password = model.Password.ToSHA256();

            _user.Edit(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = _user.GetById(id);

            _user.Remove(model);

            return RedirectToAction("Index");
        }

        public IActionResult AddNew()
        {
            ViewBag.UserRole = _userRole.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult AddNew(UserDTO model)
        {
            model.Username = model.Username.ToSHA256();
            model.Password = model.Password.ToSHA256();

            _user.AddNew(model);

            return RedirectToAction("Index");
        }
    }
}
