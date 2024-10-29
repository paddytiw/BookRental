using BookRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Infrastructure.Persistence
{
    internal class BookRentalDbContext(DbContextOptions<BookRentalDbContext> options) : DbContext(options)
    {
        internal DbSet<Book> Books { get; set; }
        internal DbSet<User> Users { get; set; }
        internal DbSet<Rental> BookRentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rental>()
                        .HasOne(x => x.Book)
                        .WithMany(x => x.Rentals)
                        .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Rental>()
                        .HasOne(x => x.User)
                        .WithMany(x => x.Rentals)
                        .HasForeignKey(x => x.UserId);
        }
    }
}
