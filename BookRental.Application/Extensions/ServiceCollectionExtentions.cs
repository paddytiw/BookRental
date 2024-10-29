using BookRental.Application.Books;
using BookRental.Application.Rents;
using BookRental.Application.Users;
using BookRental.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.Application.Extensions;

public static class ServiceCollectionExtentions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IRentService, RentService>();
        services.AddScoped<IUserService, UserService>();

        services.AddAutoMapper(typeof(ServiceCollectionExtentions).Assembly);


    }
}
