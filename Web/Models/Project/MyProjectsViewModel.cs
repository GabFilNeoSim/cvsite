namespace Web.Models.Project;

public class MyProjectsViewModel
{
    public List<ProjectViewModel> OwnedProjects { get; set; }
    public List<ProjectViewModel> CollaboratingProjects { get; set; }
}
