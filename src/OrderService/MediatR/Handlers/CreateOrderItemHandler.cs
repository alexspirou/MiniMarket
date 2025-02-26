using MediatR;
using OrderService.EfCore;
using OrderService.MediatR.Requests;
using OrderService.Models;

namespace OrderService.MediatR.Handlers;

public class CreateOrderItemHandler : IRequestHandler<CreateOrderItemRequest, OrderItem>
{
    private readonly OrderDbContext _context;

    public CreateOrderItemHandler(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<OrderItem> Handle(CreateOrderItemRequest request, CancellationToken cancellationToken)
    {

        var orderItem = new OrderItem()
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            Price = request.Price,
            Quantity = request.Quantity,
        };

        _context.OrderItems.Add(orderItem);
        await _context.SaveChangesAsync();

        return orderItem;
    }
}
