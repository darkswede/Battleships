using Microsoft.AspNetCore.Mvc;

namespace Battleships.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
