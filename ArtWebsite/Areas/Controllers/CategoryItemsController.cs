﻿using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Areas.Controllers
{
    [Area("Admin")]
    public class CategoryItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
