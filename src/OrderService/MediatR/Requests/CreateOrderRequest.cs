using MediatR;
using OrderService.Enums;
using OrderService.Models;

namespace OrderService.MediatR.Requests
{
    public record struct CreateOrderRequest(Guid UserId, decimal TotalPrice ) : IRequest<Order>;
}
