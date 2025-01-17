﻿namespace Models;

public class UserProject
{
    public string UserId { get; set; }

    public int ProjectId { get; set; }

    public virtual User User { get; set; }

    public virtual Project Project { get; set; }
}
