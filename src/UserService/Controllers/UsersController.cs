using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.EfCore;
using UserService.Models;

namespace UserService.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public UsersController(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        return Ok(new User());
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        return Ok(new User());

    }
}
