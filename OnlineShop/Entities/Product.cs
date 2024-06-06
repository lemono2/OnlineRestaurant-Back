using System;
using System.Collections.Generic;

namespace OnlineShop.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal? ProductPrice { get; set; }

    public bool? HasNuts { get; set; }

    public string? ProductImage { get; set; }

    public bool? IsVegetarian { get; set; }

    public int? Spiciness { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
