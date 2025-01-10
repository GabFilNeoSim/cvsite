using System.ComponentModel.DataAnnotations;

namespace Web.Models.Profile;

public class UpdateDetailsViewModel
{
    [Required(ErrorMessage = "First name is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Only letters are allowed, no special characters.")]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Only letters are allowed, no special characters.")]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ0-9\\s\\-,]+$", ErrorMessage = "Address can only contain letters, numbers, spaces, commas, and hyphens.")]
    [StringLength(150)]
    public string Address { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public bool IsPrivate { get; set; }

}
