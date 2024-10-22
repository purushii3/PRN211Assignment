using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string? Address { get; set; }

    public string Phone { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
