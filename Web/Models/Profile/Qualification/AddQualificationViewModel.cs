using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class AddQualificationViewModel
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Start date is required")]
    public DateOnly StartDate { get; set; } = new DateOnly();

    public DateOnly? EndDate { get; set; }

    [Required(ErrorMessage = "Qualification type is required")]
    public int TypeId { get; set; }

    // Hidden
    public int? QualId { get; set; }
    public string? UserId { get; set; }
    public ICollection<SelectListItem> Types { get; set; }
}
