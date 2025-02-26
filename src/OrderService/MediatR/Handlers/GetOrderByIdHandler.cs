using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.EfCore;
using OrderService.MediatR.Requests;
using OrderService.Models;

namespace OrderService.MediatR.Handlers;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, Order>
{
    private readonly OrderDbContext _context;

    public GetOrderByIdHandler(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<Order> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Order
            .Include(x=> x.OrderItems)
            .Where(x => x.Id == request.Id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        return user;
    }
}