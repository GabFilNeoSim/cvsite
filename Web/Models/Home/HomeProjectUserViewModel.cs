namespace Web.Models.Home;

public class HomeProjectUserViewModel
{
    public string Id { get; set; }
    public string? AvatarUri { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsOwner { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsDeactivated { get; set; }
}
