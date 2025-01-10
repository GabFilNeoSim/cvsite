﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

// Data fields that allow controlled access for getting and setting values
public class UserProject
{
    public string UserId { get; set; }

    public int ProjectId { get; set; }

    public virtual User User { get; set; }

    public virtual Project Project { get; set; }
}
