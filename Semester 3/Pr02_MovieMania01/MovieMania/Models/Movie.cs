namespace MovieMania.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int DurationInMinutes { get; set; }
        public string? Description { get; set; }
        public int? Rating { get; set; }
    }
}
