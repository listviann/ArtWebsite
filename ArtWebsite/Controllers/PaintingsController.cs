using ArtWebsite.Domain;
using ArtWebsite.Domain.Entities;
using ArtWebsite.Models;
using ArtWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;

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

            ViewBag.PageTextField = _dataManager.PagesTextFields.GetPageTextFieldByCodeWord("Gallery");
            //return View(_dataManager.Paintings.GetPaintings()
            //    .Select(x => new PaintingViewModel
            //{
            //    PaintingId = x.Id,
            //    PaintingTitle = x.Title,
            //    PaintingImagePath = x.ImagePath,
            //    PaintingAuthorName = x.Author!.Name,
            //    PaintingCategoryName = x.Category!.Name,
            //    PaintingDateCreated = x.DateCreated
            //}).ToList());

            return View(_dataManager.Paintings.GetPaintingModels());
        }

        
    }
}
