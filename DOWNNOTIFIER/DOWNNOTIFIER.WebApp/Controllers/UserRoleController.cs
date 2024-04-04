using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace DOWNNOTIFIER.WebApp.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleBL _userRole;

        public UserRoleController(IUserRoleBL userRole)
        {
            _userRole = userRole;
        }

        public IActionResult Index()
        {
            return View(_userRole.GetAll());
        }

        public IActionResult Edit(int id)
        {
            return View(_userRole.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(UserRoleDTO model)
        {
            _userRole.Edit(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = _userRole.GetById(id);

            _userRole.Remove(model);

            return RedirectToAction("Index");
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(UserRoleDTO model)
        {
            _userRole.AddNew(model);

            return RedirectToAction("Index");
        }
    }
}
