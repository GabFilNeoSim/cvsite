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
    public async Task<IActionResult> SearchUsers([FromQuery] string search)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return Ok(new List<SearchUserViewModel>());
        }

        var searchTerms = search.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        // Get users based on search criteria
        var users = await _context.Users
            .Where(u =>
                searchTerms.All(term =>
                    u.FirstName.Contains(term) ||
                    u.LastName.Contains(term) ||
                    u.Skills.Any(s => s.Skill.Title.Contains(term))
                ))
            .Select(u => new SearchUserViewModel
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName,
                Avatar = u.AvatarUri
            }).ToListAsync();

        return Ok(users);
    }
}