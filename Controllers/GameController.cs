using GameStore.Models;
using GameStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GameStore.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameService _gameService;

        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        // GET: Games
        public IActionResult Index()
        {
            var games = _gameService.GetAllGames();
            return View(games);  // Rendera listan på en vy
        }
    }
}