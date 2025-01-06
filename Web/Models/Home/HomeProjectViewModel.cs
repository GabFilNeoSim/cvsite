namespace Web.Models.Home;

public class HomeProjectViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<HomeProjectUserViewModel> Users { get; set; }
}
