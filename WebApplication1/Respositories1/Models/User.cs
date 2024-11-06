using System;
using System.Collections.Generic;

namespace Respositories1.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
