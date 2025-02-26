﻿using OrderService.Models;
using System.Text.Json.Serialization;

namespace OrderService.Models;
public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    [JsonIgnore]
    public Order Order { get; set; } = null!;
}
