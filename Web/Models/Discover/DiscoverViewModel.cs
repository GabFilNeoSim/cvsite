namespace Web.Models.Discover;

public class DiscoverViewModel
{
    public string UserId { get; set; }
    public string UserFullname { get; set; }
    public List<DiscoverUserViewModel> SimilarUsers { get; set; }
}
