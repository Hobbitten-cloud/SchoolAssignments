using Microsoft.AspNetCore.Mvc;
using TimeSlot.Models;
using TimeSlot.Persistence;
using TimeSlot.ViewModels;

namespace TimeSlot.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            var bookings = InMemoryBookingRepository.GetAll();
            return View(bookings);
        }

        public IActionResult Add(int? id)
        {
            ViewBag.Action = "add";

            var bookingVM = new BookingViewModel
            {
                Rooms = InMemoryRoomRepository.GetAll()
            };

            var date = DateTime.Now;
            bookingVM.Booking.StartTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
            bookingVM.Booking.EndTime = new DateTime(date.Year, date.Month, date.Day, date.Hour + 1, date.Minute, 0);

            if (id != null) bookingVM.Booking.RoomId = id.Value;

            return View(bookingVM);
        }

        [HttpPost]
        public IActionResult Add(BookingViewModel bookingVM)
        {
            if (!ModelState.IsValid)
            {
                bookingVM.Rooms = InMemoryRoomRepository.GetAll();
                ViewBag.Action = "add";

                return View(bookingVM);
            }

            InMemoryBookingRepository.Add(bookingVM.Booking);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            BookingViewModel bookingVM = new BookingViewModel
            {
                Booking = InMemoryBookingRepository.GetById(id ?? 0),
                Rooms = InMemoryRoomRepository.GetAll()
            };

            ViewBag.Action = "edit";

            return View(bookingVM);
        }

        [HttpPost]
        public IActionResult Edit(BookingViewModel bookingVM)
        {
            if (!ModelState.IsValid)
            {
                bookingVM.Rooms = InMemoryRoomRepository.GetAll();

                ViewBag.Action = "edit";

                return View(bookingVM);
            }

            InMemoryBookingRepository.Update(bookingVM.Booking);
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            InMemoryBookingRepository.Delete(id);

            return RedirectToAction("Index");   
        }
    }
}
