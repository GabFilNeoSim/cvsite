using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class UpdateQualificationViewModel
{   
    [Required(ErrorMessage = "Title is required")]
    [StringLength(150)]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Location is required")]
    [StringLength(150)]
    public string Location { get; set; }

    [Required(ErrorMessage = "Start date is required")]
    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [Required(ErrorMessage = "Qualification type is required")]
    public int TypeId { get; set; }

    // Hidden
    public int? QualId { get; set; }
    public string? UserId { get; set; }
    public ICollection<SelectListItem> Types { get; set; }
}
