using MediatR;
using UserService.Models;

namespace UserService.MediatR.Requests;

public record struct GetUserByIdRequest(Guid Id) : IRequest<User>;