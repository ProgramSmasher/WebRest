using System;
using System.Collections.Generic;

namespace WebRest.EF.Models;

public partial class Gender
{
    public string GenderId { get; set; } = null!;

    public string GenderName { get; set; } = null!;

    public string GenderCrtdId { get; set; } = null!;

    public DateTime GenderCrtdDt { get; set; }

    public string GenderUpdtId { get; set; } = null!;

    public DateTime GenderUpdtDt { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
