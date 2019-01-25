using task1_3.Configurations;
using Microsoft.EntityFrameworkCore;
using task1_3.Tables;
using System.Configuration;

namespace task1_3
{
    public class ComixContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comix> Comics { get; set; }

        public ComixContext()
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfigurations());
            modelBuilder.ApplyConfiguration(new ComixConfigurations());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);//open

            }
        }
    }
}
