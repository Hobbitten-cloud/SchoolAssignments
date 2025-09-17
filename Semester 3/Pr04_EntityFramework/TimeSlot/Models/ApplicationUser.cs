using Microsoft.AspNetCore.Identity;

namespace TimeSlot.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Booking>? bookings { get; set; }
    }
}