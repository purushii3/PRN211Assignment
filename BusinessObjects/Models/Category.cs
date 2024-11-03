using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Category
{
    public Category() => KoiFishes = new HashSet<KoiFish>();

    public Category(int categoryId, string categoryName) 
    {
        this.CategoryId = categoryId;
        this.CategoryName = categoryName;
    }
    
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<KoiFish> KoiFishes { get; set; }
}
