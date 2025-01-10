﻿using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Web.Models.Profile;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models.Profile.Skill;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Web.Controllers;

[Route("profile")]
public class ProfileController : BaseController
{
    public ProfileController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager) : base(context, userManager) { }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {   
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error("Unknown profile", "This profile does not exist, please try again.");
        }

        if (user.IsDeactivated)
        {
            TempData["NotifyType"] = "error";
            TempData["NotifyMessage"] = "This user is deactivated";
            return RedirectToAction("Index", "Home");
        }

        bool isProfileOwner = await IsProfileOwner(id);

        if (!isProfileOwner)
        {
            user.VisitCount += 1;
            await _context.SaveChangesAsync();
        }

        var userSkillIds = user.Skills.Select(us => us.SkillId);

        var unusedSkills = await _context.Skills
            .Where(skill => !userSkillIds.Contains(skill.Id))
            .Select(skill => new SkillViewModel
            {
                SkillId = skill.Id,
                Title = skill.Title
            }).ToListAsync();

        var profileViewModel = new ProfileViewModel
        {
            User = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                AvatarUri = user.AvatarUri,
                Description = user.Description,
                Private = user.Private,
                IsDeactivated = user.IsDeactivated
            },

            // Retrieve work and education qualifications
            Work = user.Qualifications.Where(x => x.Type.Name == "Work").OrderByDescending(x => x.StartDate).Select(y => new QualificationViewModel
            {
                Id = y.Id,
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),

            Education = user.Qualifications.Where(x => x.Type.Name == "Education").OrderByDescending(x => x.StartDate).Select(y => new QualificationViewModel
            {
                Id = y.Id,
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),

            // Get user's skills and projects
            Skills = user.Skills.Select(x => new SkillViewModel
            {
                SkillId = x.SkillId,
                Title = x.Skill.Title,
            }).ToList(),

            Projects = user.Projects.Select(x => new ProfileProjectViewModel
            {
                Id = x.ProjectId,
                Title = x.Project.Title,
                Description = x.Project.Description
            }).ToList(),

            UnusedSkills = unusedSkills,

            IsProfileOwner = isProfileOwner,

            ProfileVisits = user.VisitCount
        };

        return View(profileViewModel);
    }

    // Update avatar endpoint
    [Authorize]
    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateAvatar(string id, IFormFile avatar)
    {
        string[] allowedExtensions = [".jpg", ".jpeg", ".png"];

        // Handle no avatar selected
        if (avatar == null || avatar.Length == 0)
        {
            TempData["NotifyType"] = "error";
            TempData["NotifyMessage"] = "No image selected";
            return RedirectToAction("Index", "Profile", new { id });
        }

        // Check for valid file extension
        string extension = Path.GetExtension(avatar.FileName).ToLower();
        if (!allowedExtensions.Contains(extension))
        {
            TempData["NotifyType"] = "error";
            TempData["NotifyMessage"] = "Invalid file type";
            return RedirectToAction("Index", "Profile", new { id });
        }

        // Create upload folder
        string uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets/avatars");
        if (!Directory.Exists(uploadDirectory))
        {
            Directory.CreateDirectory(uploadDirectory);
        }

        // Create a file name
        string fileName = Guid.NewGuid().ToString() + extension;
        string filePath = Path.Combine(uploadDirectory, fileName);

        // Resize
        using var image = await Image.LoadAsync(avatar.OpenReadStream());

        image.Mutate(x => x.Resize(new ResizeOptions
        {
            Size = new Size(400, 400),
            Mode = ResizeMode.Crop
        }));

        // Save image to file
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.SaveAsJpegAsync(fileStream);
        }

        // Update the avatar URI in the database
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return RedirectToAction("Index", "Profile", new { id });

        user.AvatarUri = fileName;
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully updated avatar";

        // Notify success and refresh the page
        return RedirectToAction("Index", "Profile", new { id });
    }

    // view and return details form
    [Authorize]
    [HttpGet("{id}/settings/details")]
    public async Task<IActionResult> UpdateDetails(string id)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        User? user = await _userManager.FindByIdAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        // Populates the view model for editing and returns populated model
        var model = new UpdateDetailsViewModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            Description = user.Description,
            IsPrivate = user.Private
        };

        return View(model);
    }

    // Save updated details to database
    [Authorize]
    [HttpPost("{id}/settings/details")]
    public async Task<IActionResult> UpdateDetails(string id, UpdateDetailsViewModel model)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        if (!ModelState.IsValid) return View(model);

        User? user = await _context.Users.FindAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        // Only updates fields that have changed
        if (user.FirstName != model.FirstName) user.FirstName = model.FirstName;
        if (user.LastName != model.LastName) user.LastName = model.LastName;
        if (user.Address != model.Address) user.Address = model.Address;
        if (user.Description != model.Description) user.Description = model.Description;
        if (user.Private != model.IsPrivate) user.Private = model.IsPrivate;

        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully edited details";

        return RedirectToAction("Index", new { id });
    }

    // view and return password form
    [Authorize]
    [HttpGet("{id}/settings/password")]
    public async Task<IActionResult> UpdatePassword(string id)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        User? user = await _userManager.FindByIdAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        return View(new UpdatePasswordViewModel());
    }

    // Save updated password to database
    [Authorize]
    [HttpPost("{id}/settings/password")]
    public async Task<IActionResult> UpdatePassword(string id, UpdatePasswordViewModel model)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        if (!ModelState.IsValid) return View(model);

        User? user = await _context.Users.FindAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        // Attempts to change the user's password
        IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("OldPassword", "The old password does not match.");
            return View(model);
        }

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully edited password";

        return RedirectToAction("Index", new { id });
    }

    // Retrieves and returns user
    [Authorize]
    [HttpGet("{id}/edit/projects/{pid}")]
    public async Task<IActionResult> Projects(string id, string pid)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return View();
        }

        return View(user);
    }

    // view and return qualifications form
    [Authorize]
    [HttpGet("{id}/edit/qualifications/{qid}")]
    public async Task<IActionResult> UpdateQualification(string id, int qid)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        // Retrieves the qualification to update
        var qualification = await _context.Qualifications.FirstOrDefaultAsync(q => q.Id == qid);
        if (qualification == null)
        {
            return Error("Unknown qualification", "Qualification not found!");
        }

        // Populates qualification details and list selection for editing
        var model = new UpdateQualificationViewModel
        {
            QualId = qualification.Id,
            Title = qualification.Title,
            Description = qualification.Description,
            StartDate = qualification.StartDate,
            EndDate = qualification.EndDate,
            Location = qualification.Location,
            TypeId = qualification.TypeId,
            UserId = id,
            Types = await _context.QualificationTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToListAsync(),
        };

        return View(model);
    }

    // Save updated qualifications to database
    [Authorize]
    [HttpPost("{id}/edit/qualifications/{qid}")]
    public async Task<IActionResult> UpdateQualification(string id, int qid, UpdateQualificationViewModel model)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        if (!ModelState.IsValid)
        {
            model.Types = await _context.QualificationTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToListAsync();

            return View(model);
        }

        // Retrieves the qualification to be updated
        var qualification = await _context.Qualifications.FirstOrDefaultAsync(x => x.Id == qid);
        if (qualification == null)
        {
            return Error(string.Empty, "Qualification was not found!");
        }

        // Updates the qualification fields if changed
        if (qualification.Title != model.Title) qualification.Title = model.Title;
        if (qualification.Description != model.Description) qualification.Description = model.Description;
        if (qualification.StartDate != model.StartDate) qualification.StartDate = model.StartDate;
        if (qualification.EndDate != model.EndDate) qualification.EndDate = model.EndDate;
        if (qualification.Location != model.Location) qualification.Location = model.Location;
        if (qualification.TypeId != model.TypeId) qualification.TypeId = model.TypeId;

        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully edited qualification";

        return RedirectToAction("Index", new { id });
    }

    // view and return qualifications add form
    [Authorize]
    [HttpGet("{id}/qualifications/add")]
    public async Task<IActionResult> AddQualification(string id)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id))
        {
            return RedirectToAction("Login", "Auth");
        }

        // Populates the model with a list of qualification types
        var model = new AddQualificationViewModel
        {
            UserId = id,
            Types = await _context.QualificationTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToListAsync(),
        };

        return View(model);
    }

    // Save updated qualification to profile in database
    [Authorize]
    [HttpPost("{id}/qualifications/add")]
    public async Task<IActionResult> AddQualification(string id, AddQualificationViewModel model)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id))
        {
            return RedirectToAction("Login", "Auth");
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error("Unknown Error", "An unexpected error happend");
        }

        if (!ModelState.IsValid)
        {
            model.Types = await _context.QualificationTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToListAsync();

            return View(model);
        }

        // Creates new qualification based on the submitted model
        var qualification = new Qualification
        {
            Title = model.Title,
            Description = model.Description,
            Location = model.Location,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            TypeId = model.TypeId,
            UserId = user.Id
        };

        // Add to database
        _context.Qualifications.Add(qualification);
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully added qualification";

        return RedirectToAction("Index", new { id });
    }

    // delete qualifications from database
    [Authorize]
    [HttpPost("{id}/qualifications/delete/{qid}")]
    public async Task<IActionResult> DeleteQualification(string id, int qid)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id))
        {
            return RedirectToAction("Login", "Auth");
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error("Unknown Error", "An unexpected error happend");
        }

        // Retrieves and removes qualification from database
        var qualification = await _context.Qualifications.FirstOrDefaultAsync(q => q.Id == qid);
        if (qualification == null)
        {
            return Error("Unknown qualification", "Qualification not found!");
        }

        _context.Qualifications.Remove(qualification);
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully deleted qualification";

        return RedirectToAction("Index", new { id });
    }

    // add skills to profile in database
    [Authorize]
    [HttpPost("{id}/skills/add/{sid}")]
    public async Task<IActionResult> AddSkill(string id, int sid, AddSkillViewModel model)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id))
        {
            return RedirectToAction("Login", "Auth");
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error("Unknown Error", "An unexpected error happened");
        }

        // Retrieves the skill to be added
        var skill = await _context.Skills.SingleOrDefaultAsync(x => x.Id == sid);
        if (skill == null)
        {
            return Error("Unknown Error", "An unexpected error happened");
        }

        var userSkill = new UserSkill
        {
            User = user,
            Skill = skill
        };

        // Adds the skill to the user's profile
        user.Skills.Add(userSkill);
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully added skill";

        return RedirectToAction("Index", new { id });
    }

    // delete skills from database
    [Authorize]
    [HttpPost("{id}/skills/delete/{sid}")]
    public async Task<IActionResult> DeleteSkill(string id, int sid)
    {
        // Redirect if the user is not the profile owner
        if (!await IsProfileOwner(id))
        {
            return RedirectToAction("Login", "Auth");
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error("Unknown Error", "An unexpected error happened");
        }

        // Retrieves skill to delete
        var skill = await _context.UserSkills.SingleOrDefaultAsync(x => x.SkillId == sid && x.UserId == user.Id);
        if (skill == null)
        {
            return Error("Unknown Error", "An unexpected error happened");
        }

        // Removes the skill from the user's profile
        user.Skills.Remove(skill);
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully removed skill";

        return RedirectToAction("Index", new { id });
    }
}