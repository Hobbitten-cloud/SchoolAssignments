using MovieMania.Models;

namespace MovieMania.Persistence
{
    public class DirectorRepository
    {
        private static List<Director> directors = new List<Director> 
        {
            new Director
            {
                DirectorId = 1,
                FirstName = "Christopher",
                LastName = "Nolan"
            },
            new Director
            {
                DirectorId = 2,
                FirstName = "Lana",
                LastName = "Wachowski"
            },
            new Director
            {
                DirectorId = 3,
                FirstName = "Jon",
                LastName = "Favreau"
            },
            new Director
            {
                DirectorId = 4,
                FirstName = "John",
                LastName = "Lasseter"
            },
            new Director
            {
                DirectorId = 5,
                FirstName = "Andrew",
                LastName = "Stanton"
            },
            new Director
            {
                DirectorId = 6,
                FirstName = "Tommy",
                LastName = "Wiseau"
            },
            new Director
            {
                DirectorId = 7,
                FirstName = "Denis",
                LastName = "Villeneuve"
            }
        };

        public static List<Director> GetAll()
        {
            return directors;
        }

        public static Director? GetById(int id)
        {
            return directors.FirstOrDefault(x => x.DirectorId == id);
        }

        public static void Add(Director director)
        {
            if (director == null) return;
            director.DirectorId = directors.Any() ? directors.Max(x => x.DirectorId) + 1 : 1;
            directors.Add(director);
        }

        public static void Delete(int directorId)
        {
            directors.RemoveAll(x => x.DirectorId == directorId);
        }

        public static void Update(int directorId, Director director)
        {
            var directorToUpdate = GetById(directorId);
            if (directorToUpdate != null)
            {
                directorToUpdate.FirstName = director.FirstName;
                directorToUpdate.LastName = director.LastName;
            }
        }
    }
}
