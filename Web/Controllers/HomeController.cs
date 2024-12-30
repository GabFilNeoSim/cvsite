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
}