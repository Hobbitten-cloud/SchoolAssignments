using Microsoft.AspNetCore.Mvc;
using TimeSlot.Persistence;

namespace TimeSlot.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            var rooms = InMemoryRoomRepository.GetAll();
            return View(rooms);
        }
    }
}
