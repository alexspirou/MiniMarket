using MediatR;
using OrderService.EfCore;
using OrderService.MediatR.Requests;
using OrderService.Models;

namespace OrderService.MediatR.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, Order>
{
    private readonly OrderDbContext _context;

    public CreateOrderHandler(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<Order> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {

        var order = new Order()
        {
            TotalPrice = request.TotalPrice,
            UserId = request.UserId
        };

        _context.Order.Add(order);
        await _context.SaveChangesAsync();

        return order;
    }
}