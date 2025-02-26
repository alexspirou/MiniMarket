using MediatR;
using OrderService.Models;

namespace OrderService.MediatR.Requests;

public record struct GetOrderByIdRequest(Guid Id) : IRequest<Order>;