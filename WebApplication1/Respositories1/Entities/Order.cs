using System;
using System.Collections.Generic;

namespace Respositories1.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? MemberId { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Member? Member { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
