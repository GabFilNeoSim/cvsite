namespace Models;

public class QualificationType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual List<Qualification> Qualifications { get; set; } = [];
}

