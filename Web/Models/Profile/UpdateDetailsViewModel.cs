using System.ComponentModel.DataAnnotations;

namespace Web.Models.Profile;

public class UpdateDetailsViewModel
{
    [Required(ErrorMessage = "First name is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Only letters are allowed, no special characters.")]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Only letters are allowed, no special characters.")]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ0-9\\s\\-,]+$", ErrorMessage = "Address can only contain letters, numbers, spaces, commas, and hyphens.")]
    [MaxLength(150)]
    public string Address { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; }

    public bool IsPrivate { get; set; }

}
