using System;
using System.Collections.Generic;

namespace Respositories1.Entities;

public partial class Pond
{
    public int PondId { get; set; }

    public double? Size { get; set; }

    public string? Name { get; set; }

    public double? PumpCapacity { get; set; }

    public double? DrainCount { get; set; }

    public double? Volume { get; set; }

    public double? Depth { get; set; }

    public string? Image { get; set; }

    public int UserId { get; set; }


    public virtual ICollection<MessageAlbertWater> MessageAlbertWaters { get; set; } = new List<MessageAlbertWater>();

    public virtual ICollection<WaterParameter> WaterParameters { get; set; } = new List<WaterParameter>();
}
