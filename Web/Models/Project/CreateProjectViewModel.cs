using System.ComponentModel.DataAnnotations;

namespace Web.Models.Project;

public class CreateProjectViewModel
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
}