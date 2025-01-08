using Web.Models.Profile;
using Web.Models.Profile.Skill;

namespace Web.Models;

public class ExportProfileModel
{
    public UserViewModel User { get; set; }
    public List<ProfileProjectViewModel> OwnedProjects { get; set; }
    public List<ProfileProjectViewModel> CollaboratingProjects { get; set; }
    public List<QualificationViewModel> WorkExperience { get; set; }
    public List<QualificationViewModel> Education { get; set; }
    public List<SkillViewModel> Skills { get; set; }
}
