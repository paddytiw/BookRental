using BookRental.Domain.Entities;
using BookRental.Domain.Exceptions;
using BookRental.Domain.Repositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BookRental.Application.Rents.Tests;

public class RentServiceTests
{
    private readonly Mock<IRentRepository> _rentRepository;
    private readonly Mock<ILogger<RentService>> _logger;

    private readonly RentService _rentServiceMock;

    public RentServiceTests()
    {
        _rentRepository = new Mock<IRentRepository>();
        _logger = new Mock<ILogger<RentService>>();

        _rentServiceMock = new RentService(_rentRepository.Object, _logger.Object);

    }

    [Fact()]
    public async Task RentBook_WithValidRequest_ShouldRentBookSuccessfully()
    {
        Guid bookId = Guid.NewGuid();
        Guid userId = Guid.NewGuid();

        var newRentId = Guid.NewGuid();
        _rentRepository.Setup(x=>x.RentBook(It.IsAny<Rental>())).Returns(Task.FromResult(newRentId));

        Func<Task> act = async() => await _rentServiceMock.RentBook(bookId, userId);

        await act.Should().NotThrowAsync<NotFoundException>();
    }


    [Fact()]
    public async Task RentBook_WithNonExistingBook_ShouldThrowNotFoundException()
    {
        Guid bookId = Guid.NewGuid();
        Guid userId = Guid.NewGuid();

        _rentRepository.Setup(x => x.RentBook(It.IsAny<Rental>())).Returns(Task.FromResult(Guid.Empty));

        Func<Task> act = async () => await _rentServiceMock.RentBook(bookId, userId);

        await act.Should().ThrowAsync<NotFoundException>();
    }
}