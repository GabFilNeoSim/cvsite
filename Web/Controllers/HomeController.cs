using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models;
using Microsoft.AspNetCore.Identity;
using Models;
using Web.Models.Home;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers;

public class HomeController : BaseController
{
	public HomeController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }

    public async Task<IActionResult> Index()
    {
		var model = new HomeViewModel
        {
            // Get all users
			Users = await _context.Users.Where(x => !x.IsDeactivated).Select(x => new UserViewModel
            {
                Id = x.Id,
                AvatarUri = x.AvatarUri,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Description = x.Description,
                Private = x.Private
            }).ToListAsync(),

			// Get latest project
			LatestProject = await _context.Projects
                .OrderByDescending(y => y.CreatedAt)
                .Select(p => new HomeProjectViewModel
                {
                    Title = p.Title,
                    Description = p.Description,

					// Fetching associated users for the project
					Users = _context.UserProjects.Where(up => up.ProjectId == p.Id).Select(u => new HomeProjectUserViewModel
                    {
                        Id = u.User.Id,
                        AvatarUri = u.User.AvatarUri,
                        FirstName = u.User.FirstName,
                        LastName = u.User.LastName,
                        IsOwner = u.User.Id == p.OwnerId,
                        IsPrivate = u.User.Private,
                        IsDeactivated = u.User.IsDeactivated
                    }).ToList()
                })
                .FirstAsync()
        };

		return View(model);
    }

	// An HTTP GET method to search for users by a query string.
	[HttpGet("home/users")]
    public async Task<IActionResult> SearchUsers([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return Ok(new List<SearchUserViewModel>());
        }

        string[] queryParts = query.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        // Get all users that is not private nor is deactivated.
        var searchableUsers = _context.Users
            .Where(u => (User.Identity.IsAuthenticated || !u.Private) && !u.IsDeactivated);

        // Filter users by name.
        var nameMatches = searchableUsers.Where(u =>
            queryParts.Any(part => (u.FirstName + " " + u.LastName).ToLower().Contains(part)));

        // Filter users by skill.
        var skillMatches = searchableUsers.Where(u =>
            queryParts.Any(part => u.Skills.Any(s => s.Skill.Title.ToLower().Contains(part))));

        // Combine name & skill matches.
        var combinedMatches = nameMatches.Intersect(skillMatches);

        // If only one part is in the query, include the user that matches either the name or a skill.
        var result = queryParts.Length == 1
            ? nameMatches.Union(skillMatches)
            : combinedMatches;

        // Select and convert the result into the model.
        var users = await result
            .Select(u => new SearchUserViewModel
            {
                Id = u.Id,
                Name = $"{u.FirstName} {u.LastName}",
                Avatar = u.AvatarUri
            })
            .ToListAsync();

        return Ok(users);
    }
}