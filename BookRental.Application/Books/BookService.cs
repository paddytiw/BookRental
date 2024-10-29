using BookRental.Domain.Entities;
using BookRental.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace BookRental.Application.Books;

internal class BookService(IBookRepository bookRepository,
                           ILogger<BookService> logger) : IBookService
{
    public async Task<Book?> GetBook(Guid bookId)
    {
        logger.LogInformation("Getting Book information");

        return await bookRepository.GetBookById(bookId);
    }

    public async Task<IEnumerable<Book>> SearchBooks(string name, string genre)

    {
        logger.LogInformation("Search for Books by Name and/or Genre");

        var books = new List<Book>();

        if (!string.IsNullOrEmpty(name))
        {
            books.AddRange(await bookRepository.GetBooksByName(name));
        }

        if (!string.IsNullOrEmpty(genre))
        {
            var genreBooks = await bookRepository.GetBooksByGenre(genre);

            //Add only distinct found books
            books.AddRange(genreBooks.Except(books));
        }

        return books;
    }
  
}
