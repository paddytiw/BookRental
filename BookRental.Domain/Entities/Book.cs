namespace BookRental.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Genre { get; set; }
        public bool IsRented { get; set; }

        public List<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
