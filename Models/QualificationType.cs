using System.ComponentModel.DataAnnotations;

namespace Models;

public class QualificationType
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public virtual ICollection<Qualification> Qualifications { get; set; } = [];
}

