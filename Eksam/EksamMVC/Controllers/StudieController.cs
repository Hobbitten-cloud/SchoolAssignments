using EksamMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EksamMVC.Controllers
{
    public class StudieController : Controller
    {
        public IActionResult Index()
        {
            var study = new List<studiegruppemedlemmer>() 
            { 
                new studiegruppemedlemmer { Name = "hejsa", Age = 43},
                new studiegruppemedlemmer { Name = "yes", Age = 454}
            };

            return View(study);
        }
    }
}
