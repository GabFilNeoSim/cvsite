using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Project
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public virtual User Owner { get; set; }

    public virtual ICollection<UserProject> Users { get; set; } = [];
}
