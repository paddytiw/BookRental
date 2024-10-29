using BookRental.Domain.Entities;

namespace BookRental.Domain.Repositories;
public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksByName(string name);
    Task<IEnumerable<Book>> GetBooksByGenre(string genre);
    Task<Book?> GetBookById(Guid bookId);


}
