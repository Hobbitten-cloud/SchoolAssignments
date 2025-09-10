using Microsoft.AspNetCore.Mvc;
using MovieMania.Persistence;

namespace MovieMania.Controllers
{
    public class DirectorsController : Controller
    {
        public IActionResult Index()
        {
            var directors = DirectorRepository.GetAll();
            return View(directors);
        }
    }
}
