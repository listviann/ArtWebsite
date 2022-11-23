using ArtWebsite.Domain;
using ArtWebsite.Domain.Entities;
using ArtWebsite.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryItemsController : Controller
    {
        private readonly DataManager _dataManager;

        public CategoryItemsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Category() : _dataManager.Categories.GetCategoryById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Category entity)
        {
            if (ModelState.IsValid)
            {
                _dataManager.Categories.Save(entity);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            return View(entity);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Categories.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        public IActionResult Index()
        {
            return View(_dataManager.Categories.GetCategories());
        }
    }
}
