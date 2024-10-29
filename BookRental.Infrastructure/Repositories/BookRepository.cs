using BookRental.Domain.Entities;
using BookRental.Domain.Repositories;
using BookRental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookRental.Infrastructure.Repositories;

internal class BookRepository(BookRentalDbContext dbContext) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetBooksByGenre(string genre)
    {
        var books = await dbContext.Books.Where(x => x.Genre != null && x.Genre.Contains(genre)).ToListAsync();
        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByName(string name)
    {
        var books = await dbContext.Books.Where(x => x.Title != null && x.Title.Contains(name)).ToListAsync();
        return books;

    }
    
    public async Task<Book?> GetBookById(Guid bookId)
    {
        var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
        return book;
    }
}
