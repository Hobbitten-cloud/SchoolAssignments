using System.ComponentModel.DataAnnotations;

namespace TimeSlot.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }
        public List<Booking>? Bookings { get; set; }
    }
}
