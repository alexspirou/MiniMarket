using MediatR;
using ProductService.EfCore;
using ProductService.MediatR.Requests;
using ProductService.Models;

namespace ProductService.MediatR.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, Product>
{
    private readonly ProductDbContext _context;

    public CreateProductHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        _context.Product.Add(request.Proudct);
        await _context.SaveChangesAsync();

        return request.Proudct;
    }
}