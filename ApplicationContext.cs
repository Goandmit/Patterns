using Microsoft.EntityFrameworkCore;

namespace Patterns
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals => Set<Animal>();        

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AnimalsAppDB.db");
        }
    }
}
