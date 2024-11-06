using System;
using System.Collections.Generic;

namespace Respositories1.Models;

public partial class Shop
{
    public int ShopId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string ContactInfo { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
