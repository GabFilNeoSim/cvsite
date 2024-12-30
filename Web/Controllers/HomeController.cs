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

    [HttpGet]
    public IActionResult SearchUsers(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return Json(Enumerable.Empty<object>());
        }

        // Perform the query
        var users = _context.Users
            .Where(u => u.FirstName.Contains(query) || u.LastName.Contains(query))
            .Select(u => new
            {
                u.Id,
                Name = $"{u.FirstName} {u.LastName}"
            })
            .ToList();

        // Return the results as JSON
        Debug.WriteLine(Json(users));
        return Json(users);
    }
}