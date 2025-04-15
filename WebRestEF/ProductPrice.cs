using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class ProductPrice
{
    public string ProductPriceId { get; set; } = null!;

    public string ProductPriceProductId { get; set; } = null!;

    public DateTime ProductPriceEffDate { get; set; }

    public decimal ProductPricePrice { get; set; }

    public string ProductPriceCrtdId { get; set; } = null!;

    public DateTime ProductPriceCrtdDt { get; set; }

    public string ProductPriceUpdtId { get; set; } = null!;

    public DateTime ProductPriceUpdtDt { get; set; }

    public virtual Product ProductPriceProduct { get; set; } = null!;
}
