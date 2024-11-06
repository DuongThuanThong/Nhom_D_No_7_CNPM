using System;
using System.Collections.Generic;

namespace Respositories1.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int Quantify { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
