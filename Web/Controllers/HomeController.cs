using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models;
using Microsoft.AspNetCore.Identity;
using Models;

namespace Web.Controllers;

public class HomeController : BaseController
{
    public HomeController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }

    public IActionResult Index() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });    
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