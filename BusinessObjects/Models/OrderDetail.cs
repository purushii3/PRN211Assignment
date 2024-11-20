using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class OrderDetail
{
    public string OrderId { get; set; } = null!;

    public int KoiFishId { get; set; }

    public int Quantity { get; set; }

    public double? Price { get; set; }

    public bool Status { get; set; }
    public virtual KoiFish? KoiFish { get; set; }

    public virtual Order Order { get; set; } = null!;
}
