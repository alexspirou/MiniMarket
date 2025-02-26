using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Orders;

public record OrderItemCreated
{
    Guid OrderItemId { get; set; }
    DateTime CreatedTime { get; set; }
}
