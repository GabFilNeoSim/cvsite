using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("profile")]
public class ProfileController : BaseController
{
    public ProfileController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }

    public IActionResult Index() => RedirectToAction("Index", "Home");
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
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
                Id = y.Id,
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),

            Education = user.Qualifications.Where(x => x.Type.Name == "Education").Select(y => new QualificationViewModel
            {
                Id = y.Id,
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
    [HttpPost("{id}")]
    public async Task<IActionResult> ChangeAvatar(string id, IFormFile avatar)
    {
        string[] allowedExtensions = [".jpg", ".jpeg", ".png"];

        if (avatar == null || avatar.Length == 0) return RedirectToAction("Index", "Profile", new { id });

        string extension = Path.GetExtension(avatar.FileName).ToLower();
        if (!allowedExtensions.Contains(extension))
        {
            ModelState.AddModelError(string.Empty, "Invalid file type.");
            return RedirectToAction("Index", "Profile", new { id });
        }

        // Create upload folder
        string uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "avatars");
        if (!Directory.Exists(uploadDirectory))
        {
            Directory.CreateDirectory(uploadDirectory);
        }

        // Create a file name
        string fileName = Guid.NewGuid().ToString() + extension;
        string filePath = Path.Combine(uploadDirectory, fileName);

        // Save file
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await avatar.CopyToAsync(fileStream);
        }

        // Update the avatar of the user in the database
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return RedirectToAction("Index", "Profile", new { id });

        user.AvatarUri = fileName;
        await _context.SaveChangesAsync();

        // If the upload succeed, refresh the website
        return RedirectToAction("Index", "Profile", new { id });
    }
}