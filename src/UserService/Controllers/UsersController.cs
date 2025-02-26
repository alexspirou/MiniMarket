using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.EfCore;
using UserService.MediatR.Requests;
using UserService.Models;

namespace UserService.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserDbContext _context;
    private readonly IMediator _mediator;

    public UsersController(UserDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var command = new GetUserByIdRequest(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody]User? user)
    {
        var command = new CreateUserRequest(user!);
         var result = await _mediator.Send(command);
        return Ok(result);

    }
}
