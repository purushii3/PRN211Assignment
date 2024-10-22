using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public double? PriceConsign { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
