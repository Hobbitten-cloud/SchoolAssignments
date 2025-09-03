using System.ComponentModel.DataAnnotations;

namespace MovieMania.Models
{
    public class Director
    {
        public int DirectorId { get; set; }

        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        public string FullName { get; }
    }
}
