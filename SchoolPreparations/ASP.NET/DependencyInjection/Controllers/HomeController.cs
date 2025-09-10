using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSenderService _service;
        public HomeController(IEmailSenderService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            _service.SendEmail("Hello world");
            return View();
        }
    }
}
