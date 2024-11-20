using System;
using System.Collections.Generic;

namespace Respositories1.Entities;

public partial class Koi
{
    public int KoiId { get; set; }

    public string Name { get; set; } = null!;

    public int? Gender { get; set; }

    public string? Breed { get; set; }

    public string? Origin { get; set; }

    public int? PondId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Feed> Feeds { get; set; } = new List<Feed>();

    public virtual ICollection<GrowthKoi> GrowthKois { get; set; } = new List<GrowthKoi>();

    public virtual Pond? Pond { get; set; }

    public virtual User? User { get; set; }
}
