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
            Users = await _context.Users.Where(x => !x.Private).Select(x => new UserViewModel
            {
                Id = x.Id,
                AvatarUri = x.AvatarUri,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Description = x.Description
            }).ToListAsync(),

            LatestProject = await _context.Projects
                .OrderByDescending(y => y.CreatedAt)
                .Select(p => new HomeProjectViewModel
                {
                    Title = p.Title,
                    Description = p.Description,
                    Users = _context.UserProjects.Where(up => up.ProjectId == p.Id).Select(u => new HomeProjectUserViewModel
                    {
                        Id = u.User.Id,
                        AvatarUri = u.User.AvatarUri,
                        FirstName = u.User.FirstName,
                        LastName = u.User.LastName,
                        IsOwner = u.User.Id == p.OwnerId,
                        IsPrivate = u.User.Private
                    }).ToList()
                })
                .FirstAsync()
        };

        return View(model);
    }

    [HttpGet("home/users")]
    public IActionResult SearchUsers([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return Ok(new List<SearchUserViewModel>());
        }

        var users = _context.Users
            .Where(u => (u.FirstName + " " + u.LastName).ToLower().Contains(query.ToLower()))
            .Select(u => new SearchUserViewModel
            {
                Id = u.Id,
                Name = $"{u.FirstName} {u.LastName}",
                Avatar = u.AvatarUri
            })
            .ToList();

        return Ok(users);
    }
}