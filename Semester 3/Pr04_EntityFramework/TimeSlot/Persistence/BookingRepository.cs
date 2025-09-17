using TimeSlot.Data;
using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> bookings;
        private readonly TimeSlotContext _timeSlot;

        public BookingRepository(TimeSlotContext timeSlot)
        {
            _timeSlot = timeSlot;
        }

        public void Add(Booking booking)
        {
            if (booking == null) return;

            booking.BookingId = bookings.Any() ? bookings.Max(x => x.BookingId) + 1 : 1;

            bookings.Add(booking);
        }

        public void Delete(int id)
        {
            bookings.RemoveAll(x => x.BookingId == id);
        }

        public List<Booking> GetAll()
        {
            if (bookings != null && bookings.Count > 0)
            {
                foreach (var booking in bookings)
                {
                    booking.Room = InMemoryRoomRepository.GetById(booking.RoomId) ?? new Room();
                }
            }

            return bookings ?? new List<Booking>();
        }

        public Booking? GetById(int id)
        {
            var booking = bookings.FirstOrDefault(x => x.BookingId == id);

            if (booking != null)
            {
                booking.Room = InMemoryRoomRepository.GetById(booking.RoomId) ?? new Room();
            }
            return booking;
        }

        public void Update(Booking booking)
        {
            var bookingToUpdate = GetById(booking.BookingId);
            if (bookingToUpdate != null)
            {
                bookingToUpdate.Title = booking.Title;
                bookingToUpdate.StartTime = booking.StartTime;
                bookingToUpdate.EndTime = booking.EndTime;
                bookingToUpdate.RoomId = booking.RoomId;
            }
        }
    }
}
