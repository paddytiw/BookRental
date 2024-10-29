using BookRental.Domain.Entities;

namespace BookRental.Application.Books
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> SearchBooks(string name, string genre);
        Task<Book?> GetBook(Guid bookId);

    }
}