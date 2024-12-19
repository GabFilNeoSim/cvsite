namespace Data.Models;

public class Skill
{
    public int Id { get; set; }

    public string Title { get; set; }

    public virtual List<User> Users { get; set; } = [];
}

