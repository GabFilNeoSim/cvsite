using System.Xml.Serialization;

namespace Web.Models.Profile.Skill;

public class SkillViewModel
{
    [XmlIgnore]
    public int SkillId { get; set; }
    public string Title { get; set; }
}