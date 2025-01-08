namespace Web.Models.Project;

public class ProjectViewModel
{
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public UserViewModel Owner { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ProjectUserViewModel> Collaborators { get; set; }
    public bool IsCollaborator { get; set; }
}
