﻿using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Web.Models.Profile;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        var allSkills = await _context.Skills.ToListAsync();

        var unusedSkills = allSkills
            .Where(skill => !user.Skills.Any(userSkill => userSkill.SkillId == skill.Id))
            .Select(skill => new SkillViewModel
            {
                Title = skill.Title
            }).ToList();

        var isProfileOwner = await IsProfileOwner(user.Id);

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


            Skills = user.Skills.Select(y => new SkillViewModel
            {
                Title = y.Skill.Title,
            }).ToList(),

            UnusedSkills = unusedSkills,

            IsProfileOwner = isProfileOwner
        };

        return View(profileViewModel);
    }

    [Authorize]
    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateAvatar(string id, IFormFile avatar)
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

    [Authorize]
    [HttpGet("{id}/edit/details")]
    public async Task<IActionResult> UpdateDetails(string id)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        User? user = await _userManager.FindByIdAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        var model = new UpdateDetailsViewModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            IsPrivate = user.Private
        };
        
        return View(model);
    }

    [Authorize]
    [HttpPost("{id}/edit/details")]
    public async Task<IActionResult> UpdateDetails(string id, UpdateDetailsViewModel model)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        if (!ModelState.IsValid) return View(model);

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
    [HttpGet("{id}/edit/password")]
    public async Task<IActionResult> UpdatePassword(string id)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        User? user = await _userManager.FindByIdAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        return View(new UpdatePasswordViewModel());
    }

    [Authorize]
    [HttpPost("{id}/edit/password")]
    public async Task<IActionResult> UpdatePassword(string id, UpdatePasswordViewModel model)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        if (!ModelState.IsValid) return View(model);

        User? user = await _context.Users.FindAsync(id);
        if (user == null) return Error("Unknown error", "An unexpected error happend!");

        IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("OldPassword", "The old password does not match.");
            return View(model);
        }

        return RedirectToAction("Index", new { id });
    }

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

    [Authorize]
    [HttpGet("{id}/edit/qualifications/{qid}")]
    public async Task<IActionResult> UpdateQualification(string id, int qid)
    {
        if (!await IsProfileOwner(id)) return RedirectToAction("Login", "Auth");

        var qualification = await _context.Qualifications.FirstOrDefaultAsync(q => q.Id == qid);
        if (qualification == null)
        {
            return Error("Unknown qualification", "Qualification not found!");
        }

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

    [Authorize]
    [HttpPost("{id}/edit/qualifications/{qid}")]
    public async Task<IActionResult> UpdateQualification(string id, int qid, UpdateQualificationViewModel model)
    {
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

        return RedirectToAction("Index", new { id });
    }

    [Authorize]
    [HttpGet("{id}/qualifications/add")]
    public async Task<IActionResult> AddQualification(string id)
    {
        if (!await IsProfileOwner(id))
        {
            return RedirectToAction("Login", "Auth");
        }

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

    [Authorize]
    [HttpPost("{id}/qualifications/add")]
    public async Task<IActionResult> AddQualification(string id, AddQualificationViewModel model)
    {
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

        _context.Qualifications.Add(qualification);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", new { id });
    }

    [Authorize]
    [HttpPost("{id}/qualifications/delete/{qid}")]
    public async Task<IActionResult> DeleteQualification(string id, int qid)
    {
        if (!await IsProfileOwner(id))
        {
            return RedirectToAction("Login", "Auth");
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Error("Unknown Error", "An unexpected error happend");
        }

        var qualification = await _context.Qualifications.FirstOrDefaultAsync(q => q.Id == qid);
        if (qualification == null)
        {
            return Error("Unknown qualification", "Qualification not found!");
        }

        _context.Qualifications.Remove(qualification);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", new { id });
    }
}