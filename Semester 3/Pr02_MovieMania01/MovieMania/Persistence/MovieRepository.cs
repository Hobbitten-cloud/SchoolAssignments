using MovieMania.Models;

namespace MovieMania.Persistence
{
    public class MovieRepository
    {
        private static List<Movie> movies = new List<Movie> {
        new Movie
        {
            MovieId = 1,
            Title = "Inception",
            ReleaseYear = 2010,
            DurationInMinutes = 148,
            Description = "A mind-bending thriller about dreams within dreams.",
            Rating = 9
        },
        new Movie
        {
            MovieId = 2,
            Title = "The Matrix",
            ReleaseYear = 1999,
            DurationInMinutes = 136,
            Description = "A hacker discovers reality is a simulation.",
            Rating = 10
        },
        new Movie
        {
            MovieId = 3,
            Title = "Interstellar",
            ReleaseYear = 2014,
            DurationInMinutes = 169,
            Description = "Astronauts travel through a wormhole to save humanity.",
            Rating = 8
        },
        new Movie
        {
            MovieId = 4,
            Title = "The Lion King",
            ReleaseYear = 1994,
            DurationInMinutes = 88,
            Description = "A young lion prince flees his kingdom only to learn the true meaning of responsibility.",
            Rating = 7
        },
        new Movie
        {
            MovieId = 5,
            Title = "Toy Story",
            ReleaseYear = 1995,
            DurationInMinutes = 81,
            Description = "Toys come to life when humans aren’t around.",
            Rating = 10
        },
        new Movie
        {
            MovieId = 6,
            Title = "The Dark Knight",
            ReleaseYear = 2008,
            DurationInMinutes = 152,
            Description = "Batman faces the Joker in a battle for Gotham's soul.",
            Rating = 10
        },
        new Movie
        {
            MovieId = 7,
            Title = "Finding Nemo",
            ReleaseYear = 2003,
            DurationInMinutes = 100,
            Description = "A clownfish sets out on a journey to find his missing son.",
            Rating = 8
        },
        new Movie
        {
            MovieId = 8,
            Title = "The Room",
            ReleaseYear = 2003,
            DurationInMinutes = 99,
            Description = "The best worst movie ever made.",
            Rating = 10
        },
        new Movie
        {
            MovieId = 9,
            Title = "Blade Runner 2049",
            ReleaseYear = 2017,
            DurationInMinutes = 164,
            Description = "A young blade runner uncovers a long-buried secret.",
            Rating = 8
        },
        new Movie
        {
            MovieId = 10,
            Title = "Dune",
            ReleaseYear = 2021,
            DurationInMinutes = 155,
            Description = "The son of a noble family becomes the protector of a desert planet.",
            Rating = 9
        }
    };

        public static List<Movie> GetAll()
        {
            return movies;
        }

        public static Movie? GetById(int id)
        {
            return movies.FirstOrDefault(x => x.MovieId == id);
        }

        public static void Add(Movie movie)
        {
            if (movie == null) return;

            movie.MovieId = movies.Any() ? movies.Max(x => x.MovieId) + 1 : 1;

            movies.Add(movie);
        }

        public static void Delete(int movieId)
        {
            movies.RemoveAll(x => x.MovieId == movieId);
        }

        public static void Update(int movieId, Movie movie)
        {
            var movieToUpdate = GetById(movieId);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.ReleaseYear = movie.ReleaseYear;
                movieToUpdate.DurationInMinutes = movie.DurationInMinutes;
                movieToUpdate.Description = movie.Description;
                movieToUpdate.Rating = movie.Rating;
            }
        }
    }
}
