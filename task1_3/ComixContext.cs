using Microsoft.EntityFrameworkCore;
using task1_3.Tables;


namespace task1_3
{
    public class ComixContext : DbContext
    {
        
        public ComixContext()
        {
            Database.EnsureCreated();

        }
        public  DbSet<Author> Authors { get; set; }
        public  DbSet<Comix> Comics{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("" +
                "Server=DESKTOP-72K0F26;" +
                "Database=ComicsLibrary;" +
                "Trusted_Connection=True;");
        }
        
    }
}
