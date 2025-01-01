using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models.ProfileSettings;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("profile/{id}/edit")]
public class EditController : BaseController
{
    public EditController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Index(string id)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        User? user = await _userManager.FindByIdAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        var model = new ProfileSettingsViewModel
        {   
            ChangeDetails = new ChangeDetailsViewModel
            {       
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                IsPrivate = user.Private
            },
            ChangePassword = new ChangePasswordViewModel()
        };

        return View(model);
    }

    [Authorize]
    [HttpPost("details")]
    public async Task<IActionResult> ChangeDetails(string id, ChangeDetailsViewModel model)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        if (!ModelState.IsValid)
        {
            return View("Index", new ProfileSettingsViewModel
            {
                ChangeDetails = model,
                ChangePassword = new ChangePasswordViewModel()
            });
        }

        User? user = await _context.Users.FindAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        if (user.FirstName != model.FirstName) user.FirstName = model.FirstName;
        if (user.LastName != model.LastName) user.LastName = model.LastName;
        if (user.Address != model.Address) user.Address = model.Address;
        if (user.Private != model.IsPrivate) user.Private = model.IsPrivate;

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", new { id });
    }

    [Authorize]
    [HttpPost("password")]
    public async Task<IActionResult> ChangePassword(string id, ChangePasswordViewModel model)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        if (!ModelState.IsValid)
        {
            return View("Index", new ProfileSettingsViewModel
            {
                ChangeDetails = new ChangeDetailsViewModel(),
                ChangePassword = model
            });
        }

        User? user = await _context.Users.FindAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("OldPassword", "The old password does not match.");
            return View("Index", new ProfileSettingsViewModel
            {
                ChangeDetails = new ChangeDetailsViewModel(),
                ChangePassword = model
            });
        }

        return RedirectToAction("Index", new { id });
    }

    [Authorize]
    [HttpGet("projects/{pid}")]
    public async Task<IActionResult> Projects(string id, string pid)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return View();
        }

        return View(user);
    }

    [Authorize]
    [HttpGet("qualification/{qid}")]
    public async Task<IActionResult> Qualifications(string id, string qid)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return View();
        }

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Qualifications(string id, User model)
    {
        return View();
    }
}