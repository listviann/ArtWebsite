using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Areas.Controllers
{
    [Area("Admin")]
    public class PageTextFieldItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
