using System.ComponentModel.DataAnnotations;

namespace Models;

public class Qualification
{   
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    [MaxLength(150)]
    public string Location { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int TypeId { get; set; }
    public virtual QualificationType Type { get; set; }

    public string UserId {  get; set; }
    public virtual User User { get; set; }
}
