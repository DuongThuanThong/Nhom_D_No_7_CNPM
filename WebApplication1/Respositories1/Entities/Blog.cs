using System;
using System.Collections.Generic;

namespace Respositories1.Entities;

public partial class Blog
{
    public int BlogId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? AuthorId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Views { get; set; }

    public virtual User? Author { get; set; }
}
