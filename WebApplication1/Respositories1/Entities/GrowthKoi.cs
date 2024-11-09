using System;
using System.Collections.Generic;

namespace Respositories1.Entities;

public partial class GrowthKoi
{
    public int GrowthId { get; set; }

    public int? KoiId { get; set; }

    public string? Image { get; set; }

    public double? Size { get; set; }

    public double? Weight { get; set; }

    public string? BodyShape { get; set; }

    public int? Age { get; set; }

    public double? Price { get; set; }

    public DateOnly? GrowDate { get; set; }

    public virtual Koi? Koi { get; set; }
}
