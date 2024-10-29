
using BookRental.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookRental.API.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
            catch (DbUpdateConcurrencyException concurrencyEx)
            {
                var errorMessage = "Another user has already rented this book.";
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(errorMessage);

                logger.LogWarning(concurrencyEx, errorMessage);
            }
            catch (NotFoundException notFound)
			{
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFound.Message);

                logger.LogWarning(notFound, notFound.Message);

            }
            catch (Exception ex)
			{
				logger.LogError(ex, ex.Message);

				context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Something went wrong");
			}
        }
    }
}
