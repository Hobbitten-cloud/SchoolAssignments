using Microsoft.EntityFrameworkCore;
using Pr12_CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr12_CleanArchitecture.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Event>().ToTable("Events");

            builder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Name = "Stor Svømme dag",
                    Date = DateTime.Now,
                    Description = "En vandrig dag",
                    Capacity = 40,
                }
            );
        }

    }
}
