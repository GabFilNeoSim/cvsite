using System.Xml.Serialization;
using Web.Models.Profile;
using Web.Models.Profile.Skill;

namespace Web.Models;

[XmlRoot("Profile")]
public class ExportProfileModel
{
    [XmlElement("User")]
    public UserViewModel User { get; set; }

    [XmlArray("OwnedProjects")]
    [XmlArrayItem("Project")]
    public List<ProfileProjectViewModel> OwnedProjects { get; set; }

    [XmlArray("CollaboratingProjects")]
    [XmlArrayItem("Project")]
    public List<ProfileProjectViewModel> CollaboratingProjects { get; set; }

    [XmlArray("WorkExperience")]
    [XmlArrayItem("Qualification")]
    public List<QualificationViewModel> WorkExperience { get; set; }

    [XmlArray("Education")]
    [XmlArrayItem("Qualification")]
    public List<QualificationViewModel> Education { get; set; }

    [XmlArray("Skills")]
    [XmlArrayItem("Skill")]
    public List<SkillViewModel> Skills { get; set; }
}
