using MediatR;
using ProductService.Models;

namespace ProductService.MediatR.Requests
{
    public record struct CreateProductRequest(Product Proudct): IRequest<Product>;
}
