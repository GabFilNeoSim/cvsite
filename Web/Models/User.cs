using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class User
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Firstname { get; set; }

    [MaxLength(100)]
    public string Lastname { get; set; }

    public string Address { get; set; }

    public string AvatarUri { get; set; }   

    public bool Private { get; set; }

    public virtual List<Skill> Skills { get; set; } = [];

    public virtual List<Qualification> Qualifications { get; set; } = [];

    public virtual List<Project> Projects { get; set; } = [];
}
