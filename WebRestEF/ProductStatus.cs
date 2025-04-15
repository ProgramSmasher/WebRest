using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class ProductStatus
{
    public string ProductStatusId { get; set; } = null!;

    public string ProductStatusDesc { get; set; } = null!;

    public string ProductStatusCrtdId { get; set; } = null!;

    public DateTime ProductStatusCrtdDt { get; set; }

    public string ProductStatusUpdtId { get; set; } = null!;

    public DateTime ProductStatusUpdtDt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
