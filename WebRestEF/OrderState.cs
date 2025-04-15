using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class OrderState
{
    public string OrderStateId { get; set; } = null!;

    public string OrderStateOrdersId { get; set; } = null!;

    public string OrderStateOrderStatusId { get; set; } = null!;

    public DateTime OrderStateEffDate { get; set; }

    public string OrderStateCrtdId { get; set; } = null!;

    public DateTime OrderStateCrtdDt { get; set; }

    public string OrderStateUpdtId { get; set; } = null!;

    public DateTime OrderStateUpdtDt { get; set; }

    public virtual OrderStatus OrderStateOrderStatus { get; set; } = null!;

    public virtual Order OrderStateOrders { get; set; } = null!;
}
