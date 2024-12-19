using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Models;

public class User : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    public string Address { get; set; }

    public string? AvatarUri { get; set; }

    public bool Private { get; set; } = false;

    // Navigation
    public virtual List<Skill> Skills { get; set; } = [];

    public virtual List<Qualification> Qualifications { get; set; } = [];

    public virtual List<Project> Projects { get; set; } = [];
}
