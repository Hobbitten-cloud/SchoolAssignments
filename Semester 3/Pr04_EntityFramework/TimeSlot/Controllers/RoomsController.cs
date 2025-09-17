using Microsoft.AspNetCore.Mvc;
using TimeSlot.Persistence;

namespace TimeSlot.Controllers
{
    public class RoomsController : Controller
    {
        private RoomRepository _roomRepo;
        public RoomsController(RoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public IActionResult Index()
        {
            var rooms = _roomRepo.GetAll();
            return View(rooms);
        }
    }
}
