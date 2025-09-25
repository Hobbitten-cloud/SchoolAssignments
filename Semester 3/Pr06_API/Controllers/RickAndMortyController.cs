using Microsoft.AspNetCore.Mvc;
using Pr06_API.Services;

namespace Pr06_API.Controllers
{
    public class RickAndMortyController : Controller
    {
        public readonly IRickAndMortyHttpService _rickAndMorty;

        public RickAndMortyController(IRickAndMortyHttpService rickAndMorty)
        {
            _rickAndMorty = rickAndMorty;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var character = await _rickAndMorty.GetCharacaterByIdAsync(id);

            return View(character);
        }

        [HttpGet]
        public async Task<IActionResult> ViewAllCharacters()
        {
            var AllCharacters = await _rickAndMorty.GetAllCharacters();

            return View(AllCharacters);
        }
    }
}
