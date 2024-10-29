namespace BookRental.Domain.Entities;
public class BookStatistics
{
    public Book? MostOverdueBook { get; set; }
    public Book? MostPopularBook { get; set; }
    public Book? LeastPopularBook { get; set; }
}
