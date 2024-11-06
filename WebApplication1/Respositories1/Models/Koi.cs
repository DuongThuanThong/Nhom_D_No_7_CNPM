using System;
using System.Collections.Generic;

namespace Respositories1.Models;

public partial class Koi
{
    public int KoiId { get; set; }

    public string Name { get; set; } = null!;

    public int? Gender { get; set; }

    public string? Breed { get; set; }

    public string? Origin { get; set; }

    public virtual ICollection<Feed> Feeds { get; set; } = new List<Feed>();

    public virtual ICollection<GrowthKoi> GrowthKois { get; set; } = new List<GrowthKoi>();
}
