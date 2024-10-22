using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class KoiFish
{
    public int KoiFishId { get; set; }

    public string KoiFishName { get; set; } = null!;

    public string KoiFishImage { get; set; } = null!;

    public int? KoiFishQuantity { get; set; }

    public double? KoiFishPrice { get; set; }

    public string? Origin { get; set; }

    public int? HealthStatus { get; set; }

    public string? AwardCertificate { get; set; }

    public double? Weight { get; set; }

    public double? Length { get; set; }

    public bool Status { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
