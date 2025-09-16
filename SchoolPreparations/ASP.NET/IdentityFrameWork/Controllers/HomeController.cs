using Microsoft.AspNetCore.Mvc;

namespace IdentityFrameWork.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
