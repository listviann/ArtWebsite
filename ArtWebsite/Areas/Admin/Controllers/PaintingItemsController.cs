﻿using ArtWebsite.Domain;
using ArtWebsite.Domain.Entities;
using ArtWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaintingItemsController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PaintingItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            _dataManager = dataManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Painting() : _dataManager.Paintings.GetPaintingById(id);
            List<Author> authors = _dataManager.Authors.GetAuthors().ToList();
            ViewBag.Authors = new SelectList(authors, "Id", "Name");

            List<Category> categories = _dataManager.Categories.GetCategories().ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Painting entity, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    entity.ImagePath = imageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "images/", imageFile.FileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }
                }

                _dataManager.Paintings.Save(entity);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }

            return View(entity);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Paintings.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        public IActionResult Index()
        {
            return View(_dataManager.Paintings.GetPaintings());
        }
    }
}
