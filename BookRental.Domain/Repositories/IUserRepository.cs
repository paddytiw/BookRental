using BookRental.Domain.Entities;

namespace BookRental.Domain.Repositories;

public interface IUserRepository
{
    Task<Guid> Create(User user);
}
