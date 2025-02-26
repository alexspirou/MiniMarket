using MediatR;
using ProductService.Models;

namespace ProductService.MediatR.Requests;

public record struct GetProductByIdRequest(Guid Id) : IRequest<Product>;