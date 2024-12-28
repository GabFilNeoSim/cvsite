using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

public class ProfileController : BaseController
{
    public ProfileController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }


    [HttpGet("profile/{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error();
        }

        var profileViewModel = new ProfileViewModel
        {
            User = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                AvatarUri = user.AvatarUri,
                Description = user.Description,
                Private = user.Private,
            },

            Work = user.Qualifications.Where(x => x.Type.Name == "Work").Select(y => new QualificationViewModel
            {
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),

            Education = user.Qualifications.Where(x => x.Type.Name == "Education").Select(y => new QualificationViewModel
            {
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),


            Skill = user.Skills.Select(y => new SkillViewModel
            {
                Title = y.Skill.Title,
            }).ToList()
        };

        return View(profileViewModel);
    }

    [Authorize]
    [HttpGet("profile/{id}/edit")]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error();
        }

        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}