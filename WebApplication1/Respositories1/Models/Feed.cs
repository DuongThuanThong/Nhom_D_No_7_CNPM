using System;
using System.Collections.Generic;

namespace Respositories1.Models;

public partial class Feed
{
    public int FeedId { get; set; }

    public int? FishId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? FeedingTime { get; set; }

    public virtual Koi? Fish { get; set; }
}
