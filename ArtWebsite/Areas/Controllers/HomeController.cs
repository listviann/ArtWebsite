using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
