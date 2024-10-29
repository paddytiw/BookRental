using BookRental.Domain.Repositories;
using BookRental.Infrastructure.Persistence;
using BookRental.Infrastructure.Repositories;
using BookRental.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookRental.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BookDb");
            services.AddDbContext<BookRentalDbContext>(option => option.UseSqlServer(connectionString));

            services.AddScoped<IBookSeeder, BookSeeder>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
