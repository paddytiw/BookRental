
using BookRental.Domain.Entities;
using BookRental.Domain.Repositories;

namespace BookRental.Application.Users;

public class UserService(IUserRepository userRepository) : IUserService
{
    public Task<Guid> Create(User user)
    {
        return userRepository.Create(user);
    }
}
