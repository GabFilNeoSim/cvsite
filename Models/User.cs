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

    public string? AvatarUri { get; set; } = "default.png";

    public string? Description { get; set; }

    public bool Private { get; set; } = false;

    public int VisitCount { get; set; } = 0;

    // Navigation
    public virtual ICollection<UserSkill> Skills { get; set; } = [];

    public virtual ICollection<Qualification> Qualifications { get; set; } = [];

    public virtual ICollection<UserProject> Projects { get; set; } = [];

    public virtual ICollection<Message> SentMessages { get; set; } = [];

    public virtual ICollection<Message> ReceivedMessages { get; set; } = [];
}
