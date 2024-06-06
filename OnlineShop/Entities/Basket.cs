using System;
using System.Collections.Generic;

namespace OnlineShop.Entities;

public partial class Basket
{
    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public int ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
