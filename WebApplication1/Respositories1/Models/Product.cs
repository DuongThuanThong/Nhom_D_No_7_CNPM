using System;
using System.Collections.Generic;

namespace Respositories1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? StockQuantity { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
