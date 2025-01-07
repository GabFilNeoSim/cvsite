using Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Security.Claims;
using Web.Models;
using Web.Models.Project;

namespace Web.Controllers;

[Route("projects")]
public class ProjectController : BaseController
{
    public ProjectController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }

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
            }).Single(),
            CreatedAt = p.CreatedAt,
            Collaborators = _context.UserProjects.Where(up => up.ProjectId == p.Id).Select(u => new ProjectUserViewModel
            {
                Id = u.User.Id,
                AvatarUri = u.User.AvatarUri,
                FirstName = u.User.FirstName,
                LastName = u.User.LastName,
                IsOwner = u.User.Id == p.OwnerId,
                Private = u.User.Private
            }).ToList()
        }).ToListAsync();
        return View(projects);
    }

    [Authorize]
    [HttpGet("my-projects")]
    public async Task<IActionResult> MyProjects()
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        List<ProjectViewModel> projects = await _context.Projects.Where(p => p.OwnerId == userId).Select(p => new ProjectViewModel
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
                Private = u.User.Private
            }).ToList()
        }).ToListAsync();

        return View(projects);
    }
}
