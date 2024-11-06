using System;
using System.Collections.Generic;

namespace Respositories1.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateOnly? JoinDate { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? User { get; set; }
}
