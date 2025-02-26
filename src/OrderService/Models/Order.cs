using OrderService.Enums;
using OrderService.Models;

namespace OrderService.Models;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public Guid UserId { get; set; }
    public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public decimal TotalPrice { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
}