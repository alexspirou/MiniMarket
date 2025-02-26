using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.EfCore;
using OrderService.MediatR.Requests;
using OrderService.Models;

namespace OrderService.Controllers;

[ApiController]
[Route("api/order/[action]")]
public class OrderController : ControllerBase
{
    private readonly OrderDbContext _context;
    private readonly IMediator _mediator;

    public OrderController(OrderDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(Guid id)
    {
        var command = new GetOrderByIdRequest(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderRequest request)
    {
         var result = await _mediator.Send(request);
        return Ok(result);

    }    
    
    [HttpPost]
    public async Task<ActionResult<OrderItem>> CreateOrderItem([FromBody] CreateOrderItemRequest request)
    {
         var result = await _mediator.Send(request);
        return Ok(result);

    }
}
