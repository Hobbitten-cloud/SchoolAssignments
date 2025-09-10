using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public static class InMemoryBookingRepository 
    {
        private static List<Booking> bookings = new List<Booking>
        {
            new Booking
            {
                BookingId = 1,
                Title = "Vejledning m. Jens",
                StartTime = new DateTime(2025, 9, 16, 10, 30, 0),
                EndTime = new DateTime(2025, 9, 16, 11, 30, 0),
                RoomId = 1
            },
            new Booking
            {
                BookingId = 2,
                Title = "Møde - Team 3",
                StartTime = new DateTime(2025, 9, 15, 13, 30, 0),
                EndTime = new DateTime(2025, 9, 15, 15, 30, 0),
                RoomId = 2
            },
            new Booking
            {
                BookingId = 3,
                Title = "Ledermøde",
                StartTime = new DateTime(2025, 9, 19, 8, 30, 0),
                EndTime = new DateTime(2025, 9, 19, 10, 30, 0),
                RoomId = 3
            }
        };

        public static Booking? GetById(int id)
        {
            var booking = bookings.FirstOrDefault(x => x.BookingId == id);

            if (booking != null)
            {
                booking.Room = InMemoryRoomRepository.GetById(booking.RoomId) ?? new Room();
            }
            return booking;
        }

        public static List<Booking> GetAll()
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

        public static void Add(Booking booking)
        {
            if (booking == null) return;

            booking.BookingId = bookings.Any() ? bookings.Max(x => x.BookingId) + 1 : 1;

            bookings.Add(booking);
        }

        public static void Update(Booking booking)
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
        public static void Delete(int id)
        {
            bookings.RemoveAll(x => x.BookingId == id);
        }
    }
}
