using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Models;

// Data fields that allow controlled access for getting and setting values
public class User : IdentityUser
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(100)]
    public string Address { get; set; }

    [Required]
    [MaxLength(255)]
    public string AvatarUri { get; set; } = "default.png";

    public string? Description { get; set; }

    [Required]
    public bool Private { get; set; } = false;

    [Required]
    public int VisitCount { get; set; } = 0;

    [Required]
    public bool IsDeactivated { get; set; } = false;

    // Navigation
    public virtual ICollection<UserSkill> Skills { get; set; } = [];

    public virtual ICollection<Qualification> Qualifications { get; set; } = [];

    public virtual ICollection<UserProject> Projects { get; set; } = [];

    public virtual ICollection<Message> SentMessages { get; set; } = [];

    public virtual ICollection<Message> ReceivedMessages { get; set; } = [];
}
