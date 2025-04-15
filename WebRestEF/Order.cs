using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class Order
{
    public string OrdersId { get; set; } = null!;

    public DateTime OrdersDate { get; set; }

    public string OrdersCustomerId { get; set; } = null!;

    public string OrdersCrtdId { get; set; } = null!;

    public DateTime OrdersCrtdDt { get; set; }

    public string OrdersUpdtId { get; set; } = null!;

    public DateTime OrdersUpdtDt { get; set; }

    public virtual ICollection<OrderState> OrderStates { get; set; } = new List<OrderState>();

    public virtual Customer OrdersCustomer { get; set; } = null!;

    public virtual ICollection<OrdersLine> OrdersLines { get; set; } = new List<OrdersLine>();
}
