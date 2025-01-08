using System.Xml.Serialization;

namespace Web.Models.Profile;

public class ProfileProjectViewModel
{
    [XmlIgnore]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
