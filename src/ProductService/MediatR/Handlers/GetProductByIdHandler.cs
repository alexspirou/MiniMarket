using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.EfCore;
using ProductService.MediatR.Requests;
using ProductService.Models;

namespace ProductService.MediatR.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, Product>
{
    private readonly ProductDbContext _context;

    public GetProductByIdHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _context.Product.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
        if (user == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        return user;
    }
}