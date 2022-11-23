using ArtWebsite.Domain;
using ArtWebsite.Domain.Entities;
using ArtWebsite.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorItemsController : Controller
    {
        private DataManager _dataManager;

        public AuthorItemsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Author() : _dataManager.Authors.GetAuthorById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Author entity)
        {
            if (ModelState.IsValid)
            {
                _dataManager.Authors.Save(entity);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            return View(entity);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Authors.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        public IActionResult Index()
        {
            return View(_dataManager.Authors.GetAuthors());
        }
    }
}
