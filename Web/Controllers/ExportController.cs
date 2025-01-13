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

// Controller to handle data export functionalities.
[Route("export")]
public class ExportController : BaseController
{
    private XmlSerializer xmlSerializer;

    public ExportController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager) : base(context, userManager)
    {
        xmlSerializer = new XmlSerializer(typeof(ExportProfileModel));
    }

	// Endpoint to serialize and download a user's profile data.
	[HttpGet("download/{userId}")]
    public async Task<IActionResult> Download(string userId)
    {
		// Fetch the user by ID.
		User? user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Error("Internal error", "Unknown user");
        }

        // Prepare the data for export by populating the ExportProfileModel.
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

            // Get user work experience
            WorkExperience = user.Qualifications.Where(x => x.Type.Name == "Work").OrderByDescending(x => x.StartDate).Select(y => new QualificationViewModel
            {
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),

            // Get user education experience
            Education = user.Qualifications.Where(x => x.Type.Name == "Education").OrderByDescending(x => x.StartDate).Select(y => new QualificationViewModel
            {
                Title = y.Title,
                Description = y.Description,
                Location = y.Location,
                StartDate = y.StartDate.ToString("MMM yyyy"),
                EndDate = y.EndDate?.ToString("MMM yyyy")
            }).ToList(),

			// Get user skills
			Skills = user.Skills.Select(x => new SkillViewModel
            {
                Title = x.Skill.Title,
            }).ToList(),

			// Get the users collaborating projects.
			CollaboratingProjects = user.Projects.Select(x => new ProfileProjectViewModel
            {
                Title = x.Project.Title,
                Description = x.Project.Description
            }).ToList(),

			// Get the users owned projects.
			OwnedProjects = await _context.Projects.Where(x => x.OwnerId == user.Id).Select(p => new ProfileProjectViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description
            }).ToListAsync(),
        };

        // Serialize the export data into an XML format and return as a downloadable file.
        var stream = new MemoryStream();
        try
        {
            xmlSerializer.Serialize(stream, exportData);
            stream.Position = 0;

            string fileName = $"{user.FirstName}-{user.LastName}-export.xml".ToLower();

            return File(stream, "application/xml", fileName);
        }
        catch(Exception)
        {
            return Error("Internal error", "Profile export failed");
        }
    }
}
