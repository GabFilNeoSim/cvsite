using Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;
using Web.Models.Profile;
using Web.Models.Profile.Skill;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers;

[Route("export")]
public class ExportController : BaseController
{
    private XmlSerializer xmlSerializer;

    public ExportController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager) : base(context, userManager)
    {
        xmlSerializer = new XmlSerializer(typeof(ExportProfileModel));
    }

    [HttpGet("download/{userId}")]
    public async Task<IActionResult> Download(string userId)
    {
        User? user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Error("Internal error", "Unknown user");
        }

        var ownedProjects = await _context.UserProjects.Where(up => up.Project.OwnerId == user.Id).Select(p => new ProfileProjectViewModel
        {
            Id = p.ProjectId,
            Title = p.Project.Title,
            Description = p.Project.Description
        }).ToListAsync();

        var exportData = new ExportProfileModel
        {
            User = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Description = user.Description,
                Private = user.Private,
            },

            WorkExperience = user.Qualifications.Where(x => x.Type.Name == "Work").OrderByDescending(x => x.StartDate).Select(y => new QualificationViewModel
            {
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),

            Education = user.Qualifications.Where(x => x.Type.Name == "Education").OrderByDescending(x => x.StartDate).Select(y => new QualificationViewModel
            {
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),

            Skills = user.Skills.Select(x => new SkillViewModel
            {
                Title = x.Skill.Title,
            }).ToList(),

            CollaboratingProjects = user.Projects.Select(x => new ProfileProjectViewModel
            {
                Title = x.Project.Title,
                Description = x.Project.Description
            }).ToList(),

            OwnedProjects = ownedProjects
        };

        var stream = new MemoryStream();
        try
        {
            xmlSerializer.Serialize(stream, exportData);
            stream.Position = 0;

            string fileName = $"{user.FirstName}-{user.LastName}-export.xml".ToLower();

            return File(stream, "application/xml", fileName);
        }
        catch(Exception ex)
        {
            return Error("Internal error", ex.Message);
        }
    }
}
