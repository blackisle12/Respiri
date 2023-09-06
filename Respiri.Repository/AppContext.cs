using Microsoft.EntityFrameworkCore;
using Respiri.Repository.Entity;

namespace Respiri.Repository
{
    public class AppContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AppDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (var i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Person>().HasData(new Person
                {
                    Id = i,
                    FirstName = $"Person {i}",
                    LastName = $"Sur {i}"
                });
            }
        }
    }
}
