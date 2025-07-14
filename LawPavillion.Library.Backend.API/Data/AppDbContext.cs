using Microsoft.EntityFrameworkCore;
using LawPavillion.Library.Backend.API.Entities;


namespace LawPavillion.Library.Backend.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Configure entity models and seed data.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding initial book records into the database
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", ISBN = "1234567890123", PublishedDate = new DateTime(1949, 6, 8) },
                new Book { Id = 2, Title = "Law Pavillion", Author = "Aldous Huxley", ISBN = "1234567890124", PublishedDate = new DateTime(1932, 8, 31) },
                new Book { Id = 3, Title = "2001", Author = "George Bush", ISBN = "1234567890125", PublishedDate = new DateTime(2000, 7, 8) },
                new Book { Id = 4, Title = "Brave Law", Author = "Aldous Smith", ISBN = "1234567890126", PublishedDate = new DateTime(1935, 9, 30) }
            );

            // I'm enforcing unique username constraint for users
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // I'm enforcing unique isbn constraint for duplicate records
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();

        }
    }
}
