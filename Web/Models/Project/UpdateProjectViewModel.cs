using System.ComponentModel.DataAnnotations;

namespace Web.Models.Project;

public class UpdateProjectViewModel
{
    public int ProjectId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; }
}