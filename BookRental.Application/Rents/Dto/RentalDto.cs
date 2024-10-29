using BookRental.Domain.Entities;

namespace BookRental.Application.Rents.Dto;

public class RentalDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime RentedOn { get; set; }
    public DateTime? ReturnedOn { get; set; }
    public bool IsOverdue { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public bool IsRented
    {
        get
        {
            return (ReturnedOn == null);
        }
    }
}
