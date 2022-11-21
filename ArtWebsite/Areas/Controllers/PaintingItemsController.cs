using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Areas.Controllers
{
    [Area("Admin")]
    public class PaintingItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
