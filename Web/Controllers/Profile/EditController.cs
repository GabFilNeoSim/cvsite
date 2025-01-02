using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models.ProfileSettings;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers.Profile;

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

        return RedirectToAction("Index", "Profile", new { id });
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

        return RedirectToAction("Index", "Profile", new { id });
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
    public async Task<IActionResult> EditQualification(string id, int qid)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        var qualification = await _context.Qualifications.FirstOrDefaultAsync(q => q.Id == qid);
        if (qualification == null)
        {
            return Error("Unknown qualification", "Qualification not found!");
        }

        var model = new EditQualificationViewModel
        {
            QualId = qualification.Id,
            Title = qualification.Title,
            Description = qualification.Description,
            StartDate = qualification.StartDate,
            EndDate = qualification.EndDate,
            Location = qualification.Location,
            TypeId = qualification.TypeId
        };

        List<SelectListItem> qualificationTypes = await _context.QualificationTypes.Select(x => new SelectListItem
        {
            Text = x.Name,
            Value = x.Id.ToString()
        }).ToListAsync();

        ViewBag.options = qualificationTypes;

        return View(model);
    }

    [Authorize]
    [HttpPost("qualification/{qid}")]
    public async Task<IActionResult> EditQualification(string id, int qid, EditQualificationViewModel model)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        if (!ModelState.IsValid)
        {
            ViewBag.QualificationTypes = await _context.QualificationTypes
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .ToListAsync();

            return View("EditQualification", model);
        }
        
        var qualification = await _context.Qualifications.FirstOrDefaultAsync(x => x.Id == qid);
        if (qualification == null)
        {
            return Error(string.Empty, "Qualification was not found!");
        }

        if (qualification.Title != model.Title) qualification.Title = model.Title;
        if (qualification.Description != model.Description) qualification.Description = model.Description;
        if (qualification.StartDate != model.StartDate) qualification.StartDate = model.StartDate;
        if (qualification.EndDate != model.EndDate) qualification.EndDate = model.EndDate;
        if (qualification.Location != model.Location) qualification.Location = model.Location;
        if (qualification.TypeId != model.TypeId) qualification.TypeId = model.TypeId;

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Profile", new { id });
    }

    [Authorize]
    [HttpGet("qualification/add")]
    public async Task<IActionResult> AddQualification(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return View();
        }

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddQualification(string id, User model)
    {
        return View();
    }
}