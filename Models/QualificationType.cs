namespace Models;

// Data fields that allow controlled access for getting and setting values
public class QualificationType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Qualification> Qualifications { get; set; } = [];
}

