using BookRental.Domain.Entities;
using BookRental.Domain.Exceptions;
using BookRental.Domain.Repositories;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace BookRental.Application.Rents;

public class RentService(IRentRepository rentRepository,
                         ILogger<RentService> logger) : IRentService
{
    public async Task<BookStatistics> GetBookStatistics()
    {
        logger.LogInformation("Get Book statistics");

        return await rentRepository.GetBookStatistics();
    }

    public async Task<IEnumerable<Rental>> GetOverdueRentalDetails()
    {
        logger.LogInformation("Get overdue rental details");

        return await rentRepository.GetOverdueRentalDetails();
    }

    public async Task<IEnumerable<Rental>> GetRentalHistory(Guid userId)
    {
        logger.LogInformation("Get Rental history");

        return await rentRepository.GetRentalHistory(userId);
    }

    public async Task MarkOverdueRentals()
    {
        logger.LogInformation("Mark overdue rentals");

        await rentRepository.MarkOverdueRentals();
    }

    public async Task RentBook(Guid bookId, Guid userId)
    {
        logger.LogInformation("Renting a book");

        var rental = new Rental { BookId = bookId, UserId = userId, RentedOn = DateTime.Now };

        var rentId = await rentRepository.RentBook(rental);

        if (rentId == Guid.Empty) throw new NotFoundException($"Book not available for {bookId}.");
    }

    public async Task ReturnBook(Guid bookRentId)
    {
        logger.LogInformation("Returning a book");

        var isreturned =  await rentRepository.ReturnBook(bookRentId);

        if (!isreturned) throw new NotFoundException($"Book not available for {bookRentId}.");
    }

    public async Task SendOverdueEmailAsync(User user, Book book)
    {
        var client = new SendGridClient("SENDGRID_API_KEY");
        var from = new EmailAddress("noreply@bookrental.com", "Book Rental");
        var to = new EmailAddress(user.Email, user.Name);
        var subject = "Overdue Book Notification";
        var plainTextContent = $"Your book '{book.Title}' is overdue.";
        var htmlContent = $"<strong>Your book '{book.Title}' is overdue.</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        await client.SendEmailAsync(msg);
    }
}
