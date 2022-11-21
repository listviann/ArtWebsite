using Microsoft.AspNetCore.Mvc;

namespace ArtWebsite.Areas.Controllers
{
    [Area("Admin")]
    public class AuthorItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
