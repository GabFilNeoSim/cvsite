using System.ComponentModel.DataAnnotations;

namespace Web.Models.Profile.Skill;

public class AddSkillViewModel
{
    public int SkillId { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    public string UserId { get; set; }
}