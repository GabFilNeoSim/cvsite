using System.ComponentModel.DataAnnotations;

namespace Web.Models.Profile.Skill;

public class AddSkillViewModel
{
    public int SkillId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    public string UserId { get; set; }
}