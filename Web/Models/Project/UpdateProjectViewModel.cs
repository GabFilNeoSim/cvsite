using System.ComponentModel.DataAnnotations;

namespace Web.Models.Project;

public class UpdateProjectViewModel
{
    public int ProjectId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
}