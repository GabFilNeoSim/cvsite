using Web.Models.Profile.Skill;

namespace Web.Models.Profile;

public class ProfileViewModel
{
    public UserViewModel User { get; set; }

    public List<QualificationViewModel> Work { get; set; }
    public int WorkCount => Work.Count;

    public List<QualificationViewModel> Education { get; set; }
    public int EducationCount => Education.Count;

    public List<SkillViewModel> Skills { get; set; }

    public List<SkillViewModel> UnusedSkills { get; set; }

    public List<ProfileProjectViewModel> Projects { get; set; }

    public bool IsProfileOwner { get; set; }
}
