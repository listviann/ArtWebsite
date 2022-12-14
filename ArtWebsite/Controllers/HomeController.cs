using ArtWebsite.Domain;
using ArtWebsite.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.PagesTextFields.GetPageTextFieldByCodeWord("Index"));
        }
    }
}
