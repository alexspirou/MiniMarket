using MediatR;
using UserService.Models;

namespace UserService.MediatR.Requests
{
    public record struct CreateUserRequest(User User): IRequest<User>;
}
