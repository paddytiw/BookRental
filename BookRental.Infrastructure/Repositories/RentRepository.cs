using BookRental.Application.Books;
using BookRental.Domain.Entities;
using BookRental.Domain.Repositories;
using BookRental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Net;

namespace BookRental.Infrastructure.Repositories;

internal class RentRepository(BookRentalDbContext dbContext) : IRentRepository
{
    public async Task<Guid> RentBook(Rental rentalBook)
    {
        var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == rentalBook.BookId);

        if (book == null || book.IsRented) return Guid.Empty;

        book.IsRented = true;

        dbContext.BookRentals.Add(rentalBook);
        dbContext.SaveChanges();
        return rentalBook.Id;
    }

    public async Task<bool> ReturnBook(Guid bookRentId)
    {
        var rental = await dbContext.BookRentals.Include(x=>x.Book).FirstOrDefaultAsync(x => x.Id == bookRentId);
        if (rental == null || rental.ReturnedOn != null) return false;

        rental.ReturnedOn = DateTime.Now;
        if(rental.Book != null) rental.Book.IsRented = false;

        dbContext.SaveChanges();

        return true;
    }

    public async Task<IEnumerable<Rental>> GetRentalHistory(Guid userId)
    {
        return await dbContext.BookRentals
                              .Include(x => x.Book)
                              .Where(x => x.UserId == userId)
                              .ToListAsync();
    }

    public async Task MarkOverdueRentals()
    {
        var overdueRentals = await dbContext.BookRentals
                                      .Where(r => !r.ReturnedOn.HasValue && 
                                                   r.RentedOn < DateTime.Now.AddDays(-14))
                                      .ToListAsync();

        foreach (var rental in overdueRentals)
        {
            rental.IsOverdue = true;
        }

        dbContext.SaveChanges();
    }

    public async Task<IEnumerable<Rental>> GetOverdueRentalDetails()
    {
        var overdueRentals = await dbContext.BookRentals
                                    .Include(b => b.Book)
                                    .Include(u => u.User)
                                    .Where(r => r.IsOverdue)
                                    .ToListAsync();

        return overdueRentals;
    }

    public async Task<BookStatistics> GetBookStatistics()
    {
        var mostOverdueBook = await dbContext.BookRentals
                                       .Where(r => r.IsOverdue)
                                       .OrderBy(r => r.RentedOn)
                                       .Select(r => r.Book)
                                       .FirstOrDefaultAsync();

        var mostPopularBook = await dbContext.BookRentals
                                       .GroupBy(r => r.BookId)
                                       .OrderByDescending(g => g.Count())
                                       .Select(g => g.First().Book)
                                       .FirstOrDefaultAsync();

        var leastPopularBook = await dbContext.BookRentals
                                        .GroupBy(r => r.BookId)
                                        .OrderBy(g => g.Count())
                                        .Select(g => g.First().Book)
                                        .FirstOrDefaultAsync();

        return new BookStatistics
        {
            MostOverdueBook = mostOverdueBook,
            MostPopularBook = mostPopularBook,
            LeastPopularBook = leastPopularBook
        };
    }

    private static TimeSpan Overdue(Rental r)
    {
        if(r.ReturnedOn == null)
        {
            return r.RentedOn - DateTime.Now.AddDays(-14);
        }

        return new TimeSpan(0);
    }
}
