using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int UserId { get; set; }

    public int ServiceId { get; set; }

    public double? TotalMoney { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Service Service { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
