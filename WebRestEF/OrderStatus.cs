using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class OrderStatus
{
    public string OrderStatusId { get; set; } = null!;

    public string OrderStatusDesc { get; set; } = null!;

    public string? OrderStatusNextOrderStatusId { get; set; }

    public string OrderStatusCrtdId { get; set; } = null!;

    public DateTime OrderStatusCrtdDt { get; set; }

    public string OrderStatusUpdtId { get; set; } = null!;

    public DateTime OrderStatusUpdtDt { get; set; }

    public virtual ICollection<OrderStatus> InverseOrderStatusNextOrderStatus { get; set; } = new List<OrderStatus>();

    public virtual ICollection<OrderState> OrderStates { get; set; } = new List<OrderState>();

    public virtual OrderStatus? OrderStatusNextOrderStatus { get; set; }
}
