using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class OrdersLine
{
    public string OrdersLineId { get; set; } = null!;

    public string OrdersLineOrdersId { get; set; } = null!;

    public string OrdersLineProductId { get; set; } = null!;

    public byte OrdersLineQty { get; set; }

    public decimal OrdersLinePrice { get; set; }

    public string OrdersLineCrtdId { get; set; } = null!;

    public DateTime OrdersLineCrtdDt { get; set; }

    public string OrdersLineUpdtId { get; set; } = null!;

    public DateTime OrdersLineUpdtDt { get; set; }

    public virtual Order OrdersLineOrders { get; set; } = null!;

    public virtual Product OrdersLineProduct { get; set; } = null!;
}
