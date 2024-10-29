using BookRental.Application.Rents;
using BookRental.Application.Users;
using BookRental.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookRental.API.Controllers;

[ApiController]
[Route("api/user")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        var userId = await userService.Create(user);

        if (userId == Guid.Empty) return BadRequest("User not created.");

        return Ok();
    }
}
