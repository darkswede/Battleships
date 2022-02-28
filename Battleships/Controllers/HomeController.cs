using Battleships.Models;
using Battleships.Services;
using Microsoft.AspNetCore.Mvc;

namespace Battleships.Controllers
{
    public class HomeController : Controller
    {
        public IGameService _gameService;

        public HomeController(IGameService gameService)
        {
            _gameService = gameService;
        }

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
            var game = _gameService.GetOrCreateGame();
            game.PlayTurn(coordinates);

            return RedirectToAction(nameof(RunGame));
        }
    }
}
