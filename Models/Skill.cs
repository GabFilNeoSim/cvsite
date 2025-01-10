namespace Models;

// Data fields that allow controlled access for getting and setting values
public class Skill
{
    public int Id { get; set; }

    public string Title { get; set; }

    public virtual ICollection<UserSkill> Users { get; set; } = [];
}

