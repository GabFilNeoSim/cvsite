namespace Models;

public class Skill
{
    public int Id { get; set; }

    public string Title { get; set; }

    public virtual ICollection<UserSkill> Users { get; set; } = [];
}

