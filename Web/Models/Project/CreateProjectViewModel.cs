using System.ComponentModel.DataAnnotations;

namespace Web.Models.Project;

public class CreateProjectViewModel
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; }
}