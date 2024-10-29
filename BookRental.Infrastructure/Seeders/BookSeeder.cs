using BookRental.Domain.Entities;
using BookRental.Infrastructure.Persistence;

namespace BookRental.Infrastructure.Seeders;
internal class BookSeeder(BookRentalDbContext dbContext) : IBookSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Books.Any())
            {
                var books = GetBooks();
                dbContext.Books.AddRange(books);
                await dbContext.SaveChangesAsync();
            }

        }
    }

    private List<Book> GetBooks()
    {
        var books = new List<Book>
        {
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", Genre = "Classics" },
            new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "9780060935467", Genre = "Classics" },
            new Book { Title = "1984", Author = "George Orwell", ISBN = "9780451524935", Genre = "Dystopian" },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "9780141199078", Genre = "Romance" },
            new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780316769488", Genre = "Classics" },
            new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "9780547928227", Genre = "Fantasy" },
            new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", ISBN = "9781451673319", Genre = "Science Fiction" },
            new Book { Title = "The Book Thief", Author = "Markus Zusak", ISBN = "9780375842207", Genre = "Historical Fiction" },
            new Book { Title = "Moby-Dick", Author = "Herman Melville", ISBN = "9781503280786", Genre = "Classics" },
            new Book { Title = "War and Peace", Author = "Leo Tolstoy", ISBN = "9781400079988", Genre = "Historical Fiction" }
        };

        return books;
    }
}

