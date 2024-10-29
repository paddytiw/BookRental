using BookRental.Domain.Entities;
using BookRental.Domain.Exceptions;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BookRental.API.Middlewares.Tests;

public class ErrorHandlingMiddlewareTests
{
    [Fact]
    public async void InvokeAsync_WhenNoExceptionThrown_ShouldCallNextDelegate()
    {
        //arrange
        var loggerMock =new Mock<ILogger<ErrorHandlingMiddleware>>();

        var middleware = new ErrorHandlingMiddleware(loggerMock.Object);

        var context = new DefaultHttpContext();

        var nextDelegate = new Mock<RequestDelegate>();

        //act

        await middleware.InvokeAsync(context, nextDelegate.Object);

        //assert
        nextDelegate.Verify(next => next.Invoke(context),Times.Once);
    }

    [Fact]
    public async void InvokeAsync_WhenNotFoundExceptionThrown_ShouldSetStatusCode404()
    {
        //arrange
        var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();

        var middleware = new ErrorHandlingMiddleware(loggerMock.Object);

        var context = new DefaultHttpContext();

        var notFoundException = new NotFoundException("Error found");

        //act

        await middleware.InvokeAsync(context, _ => throw notFoundException);

        //assert
        context.Response.StatusCode.Should().Be(404);
    }
}