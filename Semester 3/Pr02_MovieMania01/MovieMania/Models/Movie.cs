using System.ComponentModel.DataAnnotations;

namespace MovieMania.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2025)]
        public int ReleaseYear { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int DurationInMinutes { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(1, 10)]
        public int? Rating { get; set; }
    }
}
