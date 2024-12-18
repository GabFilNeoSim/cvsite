using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models;

public class Project
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public int OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public virtual User Owner { get; set; }

    public virtual List<User> Users { get; set; } = [];
}
