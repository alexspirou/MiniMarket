using MediatR;
using UserService.EfCore;
using UserService.MediatR.Requests;
using UserService.Models;

namespace UserService.MediatR.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, User>
{
    private readonly AppDbContext _context;

    public GetUserByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        return user ?? new User(); ;
    }
}