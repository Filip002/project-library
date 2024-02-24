using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Entities
{
    public class LibraryDbContext : DbContext
    {
        private string _connectionString =
           "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;";
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .IsRequired();
            
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
