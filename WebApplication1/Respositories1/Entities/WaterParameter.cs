using System;
using System.Collections.Generic;

namespace Respositories1.Entities;

public partial class WaterParameter
{
    public int WaterParamId { get; set; }

    public int? PondId { get; set; }

    public decimal? Salt { get; set; }

    public decimal? Temperature { get; set; }

    public decimal? Ph { get; set; }

    public decimal? O2 { get; set; }

    public decimal? No2 { get; set; }

    public decimal? No3 { get; set; }

    public decimal? Po4 { get; set; }

    public DateTime? MeasureDate { get; set; }

    public virtual ICollection<MessageAlbertWater> MessageAlbertWaters { get; set; } = new List<MessageAlbertWater>();

    public virtual Pond? Pond { get; set; }
}
