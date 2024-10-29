using AutoMapper;
using BookRental.Application.Books;
using BookRental.Application.Rents;
using BookRental.Application.Rents.Dto;
using BookRental.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BookRental.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BookRentalController(IRentService rentService, IMapper mapper) : ControllerBase
    {
        [HttpPost("{bookId}/rent")]
        public async Task<IActionResult> RentBook([FromRoute]Guid bookId, [FromQuery]Guid userId)
        {
             await rentService.RentBook(bookId, userId);

            return NoContent();
        }

        [HttpPost("return/{rentId}")]
        public async Task<IActionResult> ReturnBook([FromRoute]Guid rentId)
        {
            await rentService.ReturnBook(rentId);

            return NoContent();
        }

        [HttpGet("history/{userId}")]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetRentalHistory([FromRoute]Guid userId)
        {
            var history = await rentService.GetRentalHistory(userId);

            var mappedHistory = mapper.Map<IEnumerable<RentalDto>>(history);

            return Ok(mappedHistory);

        }

        [HttpGet("statistics")]
        public async Task<ActionResult<BookStatistics>> GetBookStatistics()
        {
            var bookStatistics = await rentService.GetBookStatistics();
            return Ok(bookStatistics);

        }

        [HttpGet("markOverdue")]
        public async Task MarkOverdueRentals()
        {
            await rentService.MarkOverdueRentals();
        }

        [HttpGet("overdueRentals")]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetOverdueRentalDetails()
        {
            var overdueRentals = await rentService.GetOverdueRentalDetails();

            var mappedHistory = mapper.Map<IEnumerable<RentalDto>>(overdueRentals);

            return Ok(overdueRentals);
        }
    }
}
