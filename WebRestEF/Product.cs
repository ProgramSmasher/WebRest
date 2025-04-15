using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDesc { get; set; } = null!;

    public string ProductProductStatusId { get; set; } = null!;

    public string ProductCrtdId { get; set; } = null!;

    public DateTime ProductCrtdDt { get; set; }

    public string ProductUpdtId { get; set; } = null!;

    public DateTime ProductUpdtDt { get; set; }

    public virtual ICollection<OrdersLine> OrdersLines { get; set; } = new List<OrdersLine>();

    public virtual ICollection<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();

    public virtual ProductStatus ProductProductStatus { get; set; } = null!;
}
