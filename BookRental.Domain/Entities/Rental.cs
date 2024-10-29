using System.ComponentModel.DataAnnotations;

namespace BookRental.Domain.Entities
{
    public class Rental
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public bool IsOverdue { get; set; }
        public Book? Book { get; set; }
        public User? User { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
