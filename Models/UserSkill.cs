﻿namespace Models;

public class UserSkill
{
    public string UserId { get; set; }

    public int SkillId { get; set; }

    public virtual User User { get; set; }

    public virtual Skill Skill { get; set; }
}
