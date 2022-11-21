using ArtWebsite.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly DataManager _dataManager;

        public AuthorsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("AuthorInfo", _dataManager.Authors.GetAuthorById(id));
            }

            ViewBag.PageTextField = _dataManager.PagesTextFields.GetPageTextFieldByCodeWord("AuthorInfo");
            return View(_dataManager.Authors.GetAuthors());
        }
    }
}
