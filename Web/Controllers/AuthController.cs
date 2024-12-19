using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Models;

namespace Web.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    // private readonly UserManager<IdentityUser> _userManager;
    // private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
        // _userManager = userManager;
        // _signInManager = signInManager;
    }
    
    [HttpGet] // GET /auth/register
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost] // POST /auth/register
    public async Task<IActionResult> Register2() // ViewModel
    {
        return View();
    }

    [HttpGet] // GET /auth/login
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost] // POST /auth/login
    public async Task<IActionResult> Login2() // ViewModel
    {
        return View();
    }

    [HttpGet] // GET /auth/logout
    public async Task<IActionResult> Logout()
    {
        return View();
    }

    [HttpPost] // POST /auth/logout
    public async Task<IActionResult> Logout2() // ViewModel
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}