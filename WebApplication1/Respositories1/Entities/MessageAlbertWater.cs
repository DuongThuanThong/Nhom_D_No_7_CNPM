using System;
using System.Collections.Generic;

namespace Respositories1.Entities;

public partial class MessageAlbertWater
{
    public int MessageAlbertId { get; set; }

    public int? PondId { get; set; }

    public int? WaterParamId { get; set; }

    public string? MessageType { get; set; }

    public string? MessageContain { get; set; }

    public virtual Pond? Pond { get; set; }

    public virtual WaterParameter? WaterParam { get; set; }
}
