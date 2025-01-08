using System.Xml.Serialization;

namespace Web.Models;

public class QualificationViewModel
{
    [XmlIgnore]
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public string Location { get; set; }

    public string StartDate { get; set; }

    public string? EndDate { get; set; } 
}