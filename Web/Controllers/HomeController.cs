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
}