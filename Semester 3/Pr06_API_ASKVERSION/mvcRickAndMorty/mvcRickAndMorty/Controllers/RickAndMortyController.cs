using Microsoft.AspNetCore.Mvc;

namespace mvcRickAndMorty.Controllers
{
    public class RickAndMortyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
