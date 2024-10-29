using AutoMapper;
using BookRental.Application.Books;
using BookRental.Application.Books.Dtos;
using BookRental.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookRental.API.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController(IBookService bookService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> SearchBooks(string name, string genre)
    {
        var books = await bookService.SearchBooks(name, genre);

        var mappedBooks = mapper.Map<IEnumerable<BookDto>>(books);

        return Ok(mappedBooks);
    }
}
