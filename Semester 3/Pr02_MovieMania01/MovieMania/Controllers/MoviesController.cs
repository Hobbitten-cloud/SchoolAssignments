using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;
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
            ViewBag.action = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            ViewBag.action = "add";

            if (ModelState.IsValid == true)
            {
                MovieRepository.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.action = "edit";
            var movie = MovieRepository.GetById(id.HasValue ? id.Value : 0);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            ViewBag.action = "edit";

            if (ModelState.IsValid == true)
            {
                MovieRepository.Update(movie.MovieId, movie);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            MovieRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
