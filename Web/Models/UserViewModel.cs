namespace Web.Models;

public class UserViewModel
{   
    public string Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string? AvatarUri { get; set; }

    public string? Description { get; set; }

    public bool Private { get; set; }
}