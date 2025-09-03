using Microsoft.AspNetCore.Mvc;
using MovieMania.Persistence;

namespace MovieMania.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            var movies = MovieRepository.GetAll();
            return View(movies);
        }

        public IActionResult Add()
		{
			return View();
		}
	}
}
