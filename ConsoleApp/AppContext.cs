using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Books
        public DbSet<Book> Books { get; set; }

        // Объекты таблицы Authors
        public DbSet<Author> Authors { get; set; }

        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS01;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
