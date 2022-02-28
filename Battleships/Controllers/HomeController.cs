using Battleships.Models;
using Microsoft.AspNetCore.Mvc;

namespace Battleships.Controllers
{
    public class HomeController : Controller
    {
        public Game Game { get; set; } = new Game();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RunGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RunGame(Coordinates coordinates)
        {
            Game.PlayTurn(coordinates);

            return RedirectToAction("RunGame");
        }
    }
}
