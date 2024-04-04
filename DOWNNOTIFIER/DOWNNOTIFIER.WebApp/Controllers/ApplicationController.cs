using DOWNNOTIFIER.BusinessLayer.Abstract;
using DOWNNOTIFIER.DataTransferObject;
using DOWNNOTIFIER.WebApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DOWNNOTIFIER.WebApp.Controllers
{
    [UserCheck]
    public class ApplicationController : Controller
    {
        private readonly IApplicationBL _application;

        public ApplicationController(IApplicationBL application)
        {
            _application = application;
        }

        public IActionResult Index()
        {
            return View(_application.GetAll());
        }

        public IActionResult Edit(int id)
        {
            return View(_application.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(ApplicationDTO model)
        {
            model.UpdatedBy = 7;
            model.UpdatedDate = DateTime.Now;

            _application.Edit(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var model = _application.GetById(id);

            _application.Remove(model);

            return RedirectToAction("Index");
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(ApplicationDTO model)
        {
            model.CreatedBy = 7;
            model.CreatedDate = DateTime.Now;

            _application.AddNew(model);

            return RedirectToAction("Index");
        }
    }
}
