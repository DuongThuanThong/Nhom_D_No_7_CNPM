using System;
using System.Collections.Generic;

namespace Respositories1.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Koi> Kois { get; set; } = new List<Koi>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
