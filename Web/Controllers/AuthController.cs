using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Models;
using Web.Models.Auth;

namespace Web.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthController
    (
        UserManager<User> userManager,
        SignInManager<User> signInManager
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet("auth/register")]
    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost("auth/register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
         
        if (model.Password == null) model.Password = string.Empty;
        if (model.ConfirmPassword == null) model.ConfirmPassword = string.Empty;

        if (await _userManager.FindByEmailAsync(model.Email) != null)
        {
            ModelState.AddModelError("User already exists", "This user already exists.");
            return View(model);
        }

        User newUser = new User
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Address = model.Address
        };

        var result = await _userManager.CreateAsync(newUser, model.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        await _signInManager.SignInAsync(newUser, isPersistent: false);

        return RedirectToAction("Index", "Profile", new { id = newUser.Id });
    }

    [HttpGet("auth/login")]
    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        
        if (model.Password == null)
        {
            model.Password = string.Empty;
        }

        User? user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            ModelState.AddModelError("Email", "Wrong email or password");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(
            user,
            model.Password,
            isPersistent: model.RememberMe,
            lockoutOnFailure: false
        );

        if (!result.Succeeded)
        {
            ModelState.AddModelError("Password", "Wrong email or password");
            return View(model);
        }

        return RedirectToAction("Index", "Profile", new { id = user.Id });
    }

    [HttpPost("auth/logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}