using mvcRickAndMorty.Models;
using mvcRickAndMorty.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace mvcRickAndMorty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRickAndMortyHttpService _rickAndMortyService;

        public HomeController(ILogger<HomeController> logger, IRickAndMortyHttpService rickAndMortyService)
        {
            _logger = logger;
            _rickAndMortyService = rickAndMortyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchCharacter(int characterId)
        {
            if (characterId <= 0)
            {
                ModelState.AddModelError("", "Please enter a valid character ID.");
                return View("Index");
            }

            var character = await _rickAndMortyService.GetCharacterByIdAsync(characterId);

            if (character == null)
            {
                ModelState.AddModelError("", "Character not found.");
                return View("Index");
            }

            return View("CharacterDetails", character);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> AllCharacters(int page = 1)
        {
            var charactersPage = await _rickAndMortyService.GetAllCharactersAsync(page);

            if (charactersPage == null || !charactersPage.Results.Any())
            {
                ModelState.AddModelError("", "No characters found.");
                return View("Index");
            }

            ViewData["CurrentPage"] = page;

            return View("AllCharacters", charactersPage);
        }




    }
}
