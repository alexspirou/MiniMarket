using MediatR;
using UserService.EfCore;
using UserService.MediatR.Requests;
using UserService.Models;

namespace UserService.MediatR.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, User>
{
    private readonly UserDbContext _context;

    public CreateUserHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        _context.Users.Add(request.User);
        await _context.SaveChangesAsync();

        return request.User;
    }
}