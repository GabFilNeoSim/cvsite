using Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Web.Models.Discover;

namespace Web.Controllers;

[Route("profile")]
public class DiscoverController : BaseController
{
    public DiscoverController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }

    /// <summary>
    /// Endpoint for discover simmilar profiles page
    /// </summary>
    [Authorize]
    [HttpGet("{userId}/discover")]
    public async Task<IActionResult> Index(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Error404();
        }

        if (user.IsDeactivated)
        {
            TempData["NotifyType"] = "error";
            TempData["NotifyMessage"] = "This user is deactivated";
            return RedirectToAction("Index", "Home");
        }

        var userSkillIds = user.Skills.Select(us => us.SkillId).ToList();

        // Get top 5 users with similar skills
        var topUsers = await _context.Users
            .Where(u => u.Id != userId && !u.IsDeactivated)
            .Select(u => new
            {
                User = u,
                CommonSkillCount = u.Skills.Count(us => userSkillIds.Contains(us.SkillId))
            })
            .Where(x => x.CommonSkillCount > 0)
            .OrderByDescending(x => x.CommonSkillCount)
            .Take(5)
            .Select(x => new DiscoverUserViewModel
            {
                UserId = x.User.Id,
                Fullname = $"{x.User.FirstName} {x.User.LastName}",
                Avatar = x.User.AvatarUri,
                CommonSkillCount = x.CommonSkillCount
            })
            .ToListAsync();

        var model = new DiscoverViewModel
        {   
            UserId = user.Id,
            UserFullname = $"{user.FirstName} {user.LastName}",
            SimilarUsers = topUsers
        };

        return View(model);
    }
}
