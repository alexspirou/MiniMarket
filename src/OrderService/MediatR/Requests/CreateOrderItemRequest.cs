using MediatR;
using OrderService.Models;

namespace OrderService.MediatR.Requests;

public record struct CreateOrderItemRequest(Guid OrderId, Guid ProductId, int Quantity ,decimal Price) : IRequest<OrderItem>;
