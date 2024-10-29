using BookRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.Application.Rents
{
    public interface IRentService
    {
        Task<BookStatistics> GetBookStatistics();
        Task<IEnumerable<Rental>> GetOverdueRentalDetails();
        Task<IEnumerable<Rental>> GetRentalHistory(Guid userId);
        Task MarkOverdueRentals();
        Task RentBook(Guid bookId, Guid userId);
        Task ReturnBook(Guid bookRentId);
    }
}
