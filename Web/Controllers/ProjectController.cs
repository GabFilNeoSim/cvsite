using Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Web.Models;
using Web.Models.Project;

namespace Web.Controllers;

[Route("projects")]
public class ProjectController : BaseController
{
    public ProjectController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }

    // Displays all projects with their details including owners and collaborators.
    [HttpGet("all")]
    public async Task<IActionResult> Index()
    {
        var projects = await _context.Projects.Select(p => new ProjectViewModel
        {
            ProjectId = p.Id,
            Title = p.Title,
            Description = p.Description,
            Owner = _context.Users.Where(u => u.Id == p.OwnerId).Select(um => new UserViewModel
            {
                Id = um.Id,
                AvatarUri = um.AvatarUri,
                FirstName = um.FirstName,
                LastName = um.LastName,
                Private = um.Private
            }).SingleOrDefault(),
            CreatedAt = p.CreatedAt,
            Collaborators = _context.UserProjects.Where(up => up.ProjectId == p.Id).Select(u => new ProjectUserViewModel
            {
                Id = u.User.Id,
                AvatarUri = u.User.AvatarUri,
                FirstName = u.User.FirstName,
                LastName = u.User.LastName,
                IsOwner = u.User.Id == p.OwnerId,
                Private = u.User.Private,
                IsDeactivated = u.User.IsDeactivated
            }).ToList()
        }).ToListAsync();
        return View(projects);
    }

    // Displays the current user's owned and collaborating projects.
    [Authorize]
    [HttpGet("my-projects")]
    public async Task<IActionResult> MyProjects()
    {
        string? userId = GetUserIdFromClaim();
        if (userId == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        // Fetch owned projects
        List<ProjectViewModel> ownedProjects = await _context.Projects.Where(p => p.OwnerId == userId).Select(p => new ProjectViewModel
        {
            ProjectId = p.Id,
            Title = p.Title,
            Description = p.Description,
            Owner = _context.Users.Where(u => u.Id == p.OwnerId).Select(um => new UserViewModel
            {
                Id = um.Id,
                AvatarUri = um.AvatarUri,
                FirstName = um.FirstName,
                LastName = um.LastName,
                Private = um.Private
            }).Single(),
            CreatedAt = p.CreatedAt,
            Collaborators = _context.UserProjects.Where(up => up.ProjectId == p.Id).Select(u => new ProjectUserViewModel
            {
                Id = u.User.Id,
                AvatarUri = u.User.AvatarUri,
                FirstName = u.User.FirstName,
                LastName = u.User.LastName,
                IsOwner = u.User.Id == p.OwnerId,
                Private = u.User.Private,
                IsDeactivated = u.User.IsDeactivated
            }).ToList()
        }).ToListAsync();

        // Fetch collaborating projects
        List<ProjectViewModel> collaboratingProjects = await _context.UserProjects.Where(p => p.User.Id == userId && p.Project.Owner.Id != userId).Select(p => new ProjectViewModel
        {
            ProjectId = p.Project.Id,
            Title = p.Project.Title,
            Description = p.Project.Description,
            Owner = _context.Users.Where(u => u.Id == p.Project.OwnerId).Select(um => new UserViewModel
            {
                Id = um.Id,
                AvatarUri = um.AvatarUri,
                FirstName = um.FirstName,
                LastName = um.LastName,
                Private = um.Private
            }).Single(),
            CreatedAt = p.Project.CreatedAt,
            Collaborators = p.Project.Users.Select(u => new ProjectUserViewModel
            {
                Id = u.User.Id,
                AvatarUri = u.User.AvatarUri,
                FirstName = u.User.FirstName,
                LastName = u.User.LastName,
                IsOwner = u.User.Id == u.Project.OwnerId,
                Private = u.User.Private,
                IsDeactivated = u.User.IsDeactivated
            }).ToList()
        }).ToListAsync();

        var model = new MyProjectsViewModel
        {
            OwnedProjects = ownedProjects,
            CollaboratingProjects = collaboratingProjects
        };

        return View(model);
    }

    // Allows a user to join a project.
    [Authorize]
    [HttpPost("join/{pid}")]
    public async Task<IActionResult> JoinProject(int pid)
    {
        string? userId = GetUserIdFromClaim();
        if (userId == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        // Check if project exists
        int? projectId = await _context.Projects.Where(p => p.Id == pid).Select(p => p.Id).SingleOrDefaultAsync();
        if (projectId == null)
        {
            return Error("Project not found", "This project does not exist, please try again.");
        }

        // Check if user is already a collaborator
        bool isInProject = await _context.UserProjects.AnyAsync(p => p.User.Id == userId && p.Project.Id == projectId);
        if (isInProject)
        {
            TempData["NotifyType"] = "error";
            TempData["NotifyMessage"] = "You have already joined this project!";
            return RedirectToAction("Index");
        }

        // Add user to the project
        var userProject = new UserProject
        {
            ProjectId = (int)projectId,
            UserId = userId
        };

        _context.UserProjects.Add(userProject);
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully joined project";

        return RedirectToAction("Index");   
    }

    // Allows a user to leave a project.
    [Authorize]
    [HttpPost("leave/{pid}")]
    public async Task<IActionResult> LeaveProject(int pid)
    {
        string? userId = GetUserIdFromClaim();
        if (userId == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        // Check if project exists
        int? projectId = await _context.Projects.Where(p => p.Id == pid).Select(p => p.Id).SingleOrDefaultAsync();
        if (projectId == null)
        {
            return Error("Project not found", "This project does not exist, please try again.");
        }

        // Check if user is part of the project
        bool isInProject = await _context.UserProjects.AnyAsync(p => p.User.Id == userId && p.Project.Id == projectId);
        if (!isInProject)
        {
            return Error("User not in project", "User not in the project");
        }

        // Remove user from project
        var userProject = new UserProject
        {
            ProjectId = (int)projectId,
            UserId = userId
        };

        _context.UserProjects.Remove(userProject);
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully left the project";

        return RedirectToAction("MyProjects");
    }

    // Displays the form to update project details.
    [Authorize]
    [HttpGet("edit/{pid}")]
    public async Task<IActionResult> UpdateProject(int pid)
    {
        string? userId = GetUserIdFromClaim();
        if (userId == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        // Fetch project to be updated
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == pid);
        if (project == null)
        {
            return Error("Unknown Project", "Project not found!");
        }

        var model = new UpdateProjectViewModel
        {
            ProjectId = project.Id,
            Title = project.Title,
            Description = project.Description
        };

        return View(model);
    }

    // view and return update projekt form
    [Authorize]
    [HttpPost("edit/{pid}")]
    public async Task<IActionResult> UpdateProject(int pid, UpdateProjectViewModel model)
    {
        string? userId = GetUserIdFromClaim();
        if (userId == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Fetch the project and update fields
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == pid);
        if (project == null)
        {
            return Error("Unknown Project", "Project not found!");
        }

        if (project.Title != model.Title) project.Title = model.Title;
        if (project.Description != model.Description) project.Description = model.Description;

        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully edited project";

        return RedirectToAction("MyProjects", "Project");
    }
    // view and return create form
    [Authorize]
    [HttpGet("create")]
    public async Task<IActionResult> CreateProject()
    {
        var model = new CreateProjectViewModel();

        return View(model);
    }

    // Handles the creation of a new project.
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> CreateProject(CreateProjectViewModel model)
    {
        string? userId = GetUserIdFromClaim();
        if (userId == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Create new project and associate it with the current user as the owner
        var project = new Project
        {
            Title = model.Title,
            Description = model.Description,
            OwnerId =  userId
        };


        _context.Projects.Add(project);

         await _context.SaveChangesAsync();

        var userProject = new UserProject
        {
            ProjectId = project.Id,
            UserId = userId
        };
        _context.UserProjects.Add(userProject);

        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully created project";

        return RedirectToAction("MyProjects", "Project");
    }

    // delete project from database
    [Authorize]
    [HttpPost("delete/{pid}")]
    public async Task<IActionResult> DeleteProject(int pid)
    {
        string? userId = GetUserIdFromClaim();
        if (userId == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        // Retrieves and removes project from database
        var project = await _context.Projects.SingleOrDefaultAsync(p => p.Id == pid);
        if (project == null)
        {
            return Error("Unknown Project", "Project not found!");
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully deleted project";

        return RedirectToAction("MyProjects", "Project");
    }
}
