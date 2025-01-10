using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

// Data fields that allow controlled access for getting and setting values
public class Qualification
{   
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public string Location { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int TypeId { get; set; }
    public virtual QualificationType Type { get; set; }

    public string UserId {  get; set; }
    public virtual User User { get; set; }
}
