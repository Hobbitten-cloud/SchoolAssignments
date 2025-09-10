using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TimeSlot.Models;

namespace TimeSlot.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
