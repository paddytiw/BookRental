using BookRental.Domain.Entities;
using BookRental.Domain.Repositories;
using BookRental.Infrastructure.Persistence;

namespace BookRental.Infrastructure.Repositories;

internal class UserRepository(BookRentalDbContext dbContext) : IUserRepository
{
    public async Task<Guid> Create(User user)
    {
        var isUserExists = dbContext.Users.Any(x=>x.Email == user.Email);

        if(isUserExists) return Guid.Empty; 

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        return user.Id;
    }
}
