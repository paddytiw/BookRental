using AutoMapper;
using BookRental.Application.Books.Dtos;
using BookRental.Domain.Entities;

namespace BookRental.Application.Rents.Dto;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
    }
}
