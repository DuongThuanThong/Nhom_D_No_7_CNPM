﻿using System;
using System.Collections.Generic;

namespace Respositories1.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
