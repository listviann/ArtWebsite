using ArtWebsite.Domain;
using ArtWebsite.Domain.Entities;
using ArtWebsite.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageTextFieldItemsController : Controller
    {
        private readonly DataManager _dataManager;

        public PageTextFieldItemsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new PageTextField() : _dataManager.PagesTextFields.GetPageTextFieldById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(PageTextField entity)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PagesTextFields.Save(entity);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            return View(entity);
        }

        public IActionResult Index()
        {
            return View(_dataManager.PagesTextFields.GetPagesTextFields());
        }
    }
}
