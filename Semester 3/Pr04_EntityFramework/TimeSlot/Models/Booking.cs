using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TimeSlot.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }




        [Required]
        [Display(Name = "Room")]
        public int RoomId { get; set; }

        [ValidateNever]
        [BindNever]
        public Room Room { get; set; } = null!;
    }
}
