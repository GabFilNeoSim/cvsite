using System.ComponentModel.DataAnnotations;

namespace Web.Models.Project;

public class CreateProjectViewModel
{
    [Required(ErrorMessage = "A title is required")]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required(ErrorMessage = "A description is required")]
    [MaxLength(255)]
    public string Description { get; set; }
}