using BookRental.Domain.Entities;

namespace BookRental.Domain.Repositories;
public interface IRentRepository
{
    Task<Guid> RentBook(Rental rentalBook);
    Task<bool> ReturnBook(Guid bookRentId);
    Task<IEnumerable<Rental>> GetRentalHistory(Guid userId);
    Task<BookStatistics> GetBookStatistics();
    Task<IEnumerable<Rental>> GetOverdueRentalDetails();
    Task MarkOverdueRentals();
}
