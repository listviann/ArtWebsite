using ArtWebsite.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Controllers
{
    public class PaintingsController : Controller
    {
        private readonly DataManager _dataManager;

        public PaintingsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("PaintingInfo", _dataManager.Paintings.GetPaintingById(id));
            }

            ViewBag.PageTextField = _dataManager.PagesTextFields.GetPageTextFieldByCodeWord("PaintingInfo");
            return View(_dataManager.Paintings.GetPaintings());
        }
    }
}
