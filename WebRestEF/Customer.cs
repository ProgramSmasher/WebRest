using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string CustomerFirstName { get; set; } = null!;

    public string? CustomerMiddleName { get; set; }

    public string CustomerLastName { get; set; } = null!;

    public DateTime? CustomerDateOfBirth { get; set; }

    public string CustomerCrtdId { get; set; } = null!;

    public DateTime CustomerCrtdDt { get; set; }

    public string CustomerUpdtId { get; set; } = null!;

    public DateTime CustomerUpdtDt { get; set; }

    public string? CustomerGenderId { get; set; }

    public virtual Gender? CustomerGender { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
