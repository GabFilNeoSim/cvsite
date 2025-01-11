using System.ComponentModel.DataAnnotations;

namespace Web.Models.Auth;

public class RegisterViewModel
{
    [Required(ErrorMessage = "First name is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Only letters are allowed, no special characters.")]
    [StringLength(20)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Only letters are allowed, no special characters.")]
    [StringLength(20)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Passwords must match")]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [RegularExpression("^[a-zA-ZåäöÅÄÖ0-9\\s\\-,]+$", ErrorMessage = "Address can only contain letters, numbers, spaces, commas, and hyphens.")]
    [StringLength(50)]
    public string Address { get; set; }
}
