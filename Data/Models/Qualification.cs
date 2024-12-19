using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Qualification
{   
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int TypeId { get; set; }
    public int UserId {  get; set; }

    [ForeignKey(nameof(TypeId))]
    public virtual QualificationType Type { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
}
