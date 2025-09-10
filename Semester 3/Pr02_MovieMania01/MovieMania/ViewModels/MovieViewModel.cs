using MovieMania.Models;

namespace MovieMania.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Director>? Directors { get; set; }
    }
}
