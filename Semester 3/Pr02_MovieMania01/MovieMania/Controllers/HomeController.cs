using Microsoft.AspNetCore.Mvc;

namespace MovieMania.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
