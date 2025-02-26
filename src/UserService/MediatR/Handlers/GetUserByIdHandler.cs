using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.EfCore;
using UserService.MediatR.Requests;
using UserService.Models;

namespace UserService.MediatR.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, User>
{
    private readonly UserDbContext _context;

    public GetUserByIdHandler(UserDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (user == null)
        {
            throw new KeyNotFoundException("User not found");
        }
        return user;
    }
}