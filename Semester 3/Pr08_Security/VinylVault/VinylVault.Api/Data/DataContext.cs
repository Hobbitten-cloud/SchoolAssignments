using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VinylVault.Shared.Models;

namespace VinylVault.Api.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Define your DbSets here. Example:
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Record>().HasData(
                new Record { Id = 1, Artist = "Pink Floyd", Album = "The Dark Side of the Moon", Year = 1973 },
                new Record { Id = 2, Artist = "Daft Punk", Album = "Discovery", Year = 2001 },
                new Record { Id = 3, Artist = "Fleetwood Mac", Album = "Rumours", Year = 1977 },
                new Record { Id = 4, Artist = "Nirvana", Album = "Nevermind", Year = 1991 },
                new Record { Id = 5, Artist = "Michael Jackson", Album = "Thriller", Year = 1982 },
                new Record { Id = 6, Artist = "The Beatles", Album = "Abbey Road", Year = 1969 },
                new Record { Id = 7, Artist = "Kendrick Lamar", Album = "To Pimp a Butterfly", Year = 2015 },
                new Record { Id = 8, Artist = "Radiohead", Album = "OK Computer", Year = 1997 },
                new Record { Id = 9, Artist = "Queen", Album = "A Night at the Opera", Year = 1975 },
                new Record { Id = 10, Artist = "The Prodigy", Album = "The Fat of the Land", Year = 1997 },
                new Record { Id = 11, Artist = "Kanye West", Album = "808s & heartbreak", Year = 2008 },
                new Record { Id = 12, Artist = "Tame Impala", Album = "Currents", Year = 2015 },
                new Record { Id = 13, Artist = "Bob Marley & The Wailers", Album = "Legend", Year = 1984 },
                new Record { Id = 14, Artist = "Bladee", Album = "Cold Visions", Year = 2024 },
                new Record { Id = 15, Artist = "Arctic Monkeys", Album = "AM", Year = 2013 }
            );
        }
    }
}
