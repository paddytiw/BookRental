
using BookRental.Domain.Entities;

namespace BookRental.Application.Users;

public interface IUserService
{
    Task<Guid> Create(User user);
}
