using AutoMapper;
using BookRental.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace BookRental.Application.Rents.Dto.Tests;

public class RentalProfileTests
{
    [Fact()]
    public void CreateMap_RentalToRentalDto_MapsCorrectly()
    {
        var configuration = new MapperConfiguration(cfg => { 
                cfg.AddProfile<RentalProfile>();
        });

        var mapper = configuration.CreateMapper();

        var rental = new Rental()
        {
            Id = new Guid("1414b352-4c3c-40d1-65eb-08dcf77673da"),
            BookId = new Guid("7b341ed2-9182-4d2d-b3e2-08dcf7731d78"),
            IsOverdue = false,
            RentedOn = DateTime.Now,
            ReturnedOn = null,
            UserId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        };

        var rentalDto = mapper.Map<Rental>(rental);

        rentalDto.Should().NotBeNull();
        rentalDto.Id.Should().Be(rental.Id);
        rentalDto.BookId.Should().Be(rental.BookId);    
        rentalDto.RentedOn.Should().Be(rental.RentedOn);    
        rentalDto.ReturnedOn.Should().Be(rental.ReturnedOn);
        rentalDto.UserId.Should().Be(rental.UserId);    
    }

    [Fact()]
    public void CreateMap_RentalToRentalDto_BookDetailsMapsCorrectly()
    {
        var configuration = new MapperConfiguration(cfg => {
            cfg.AddProfile<RentalProfile>();
        });

        var mapper = configuration.CreateMapper();

        var rental = new Rental()
        {
            Book = new Book()
            {
                Id = new Guid("1414b352-4c3c-40d1-65eb-08dcf77673da"),
                Author = "author",
                Genre = "Comics",
                ISBN = "IFSTSCDS",
                Title = "New Title",
                IsRented = false,
            }
        };

        var rentalDto = mapper.Map<Rental>(rental);

        rentalDto.Book.Should().NotBeNull();
        rentalDto?.Book?.Id.Should().Be(rental.Book.Id);
        rentalDto?.Book?.Author.Should().Be(rental.Book.Author);
        rentalDto?.Book?.Genre.Should().Be(rental.Book.Genre);
        rentalDto?.Book?.ISBN.Should().Be(rental.Book.ISBN);
        rentalDto?.Book?.Title.Should().Be(rental.Book.Title);
    }
}