﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();
}
