using AutoMapper;
using BookRental.Domain.Entities;

namespace BookRental.Application.Rents.Dto;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<Rental, RentalDto>()
            .ForMember(x => x.Title, opt => opt.MapFrom(src => src.Book == null ? null : src.Book.Title))
            .ForMember(x => x.Author, opt => opt.MapFrom(src => src.Book == null ? null : src.Book.Author))
            .ForMember(x => x.ISBN, opt => opt.MapFrom(src => src.Book == null ? null : src.Book.ISBN))
            .ForMember(x => x.Genre, opt => opt.MapFrom(src => src.Book == null ? null : src.Book.Genre));

    }
}
