using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class CustomerAddress
{
    public string CustomerAddressId { get; set; } = null!;

    public string CustomerAddressCustomerId { get; set; } = null!;

    public string CustomerAddressAddressId { get; set; } = null!;

    public string CustomerAddressAddressTypeId { get; set; } = null!;

    public bool CustomerAddressActvInd { get; set; }

    public bool CustomerAddressDefaultInd { get; set; }

    public string CustomerAddressCrtdId { get; set; } = null!;

    public DateTime CustomerAddressCrtdDt { get; set; }

    public string CustomerAddressUpdtId { get; set; } = null!;

    public DateTime CustomerAddressUpdtDt { get; set; }
}
