using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.EfCore;
using ProductService.MediatR.Requests;
using ProductService.Models;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly ProductDbContext _context;
    private readonly IMediator _mediator;

    public ProductController(ProductDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(Guid id)
    {
        var command = new GetProductByIdRequest(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody]Product product)
    {
        var command = new CreateProductRequest(product!);
         var result = await _mediator.Send(command);
        return Ok(result);

    }
}
