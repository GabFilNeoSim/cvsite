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

	// Constructor for dependency injection of UserManager and SignInManager.
	public AuthController
    (
        UserManager<User> userManager,
        SignInManager<User> signInManager
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

	// Displays the registration view.
	[HttpGet("auth/register")]
    public IActionResult Register() => View(new RegisterViewModel());

	// Handles user registration.
	[HttpPost("auth/register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

		// Ensure password fields are not null.
		if (model.Password == null) model.Password = string.Empty;
        if (model.ConfirmPassword == null) model.ConfirmPassword = string.Empty;

		// Check if a user with the same email already exists.
		if (await _userManager.FindByEmailAsync(model.Email) != null)
        {
            ModelState.AddModelError("User already exists", "This user already exists.");
            return View(model);
        }

		// Create a new user object.
		User newUser = new User
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Address = model.Address
        };

		// Attempt to create the user in the database.
		var result = await _userManager.CreateAsync(newUser, model.Password);

		// Handle any errors during user creation.
		if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

		// Sign the user in after successful registration.
		await _signInManager.SignInAsync(newUser, isPersistent: false);

		// Redirect to the profile page of the new user.
		return RedirectToAction("Index", "Profile", new { id = newUser.Id });
    }

	// Displays the login view.
	[HttpGet("auth/login")]
    public IActionResult Login() => View(new LoginViewModel());

	// Handles user login.
	[HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

		// Ensure the password field is not null.
		if (model.Password == null)
        {
            model.Password = string.Empty;
        }

		// Check if a user with the provided email exists.
		User? user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            ModelState.AddModelError("Email", "Wrong email or password");
            return View(model);
        }

		// Attempt to sign the user in with the provided credentials.
		var result = await _signInManager.PasswordSignInAsync(
            user,
            model.Password,
            isPersistent: model.RememberMe,
            lockoutOnFailure: false
        );

		// Handle unsuccessful sign-in attempts.
		if (!result.Succeeded)
        {
            ModelState.AddModelError("Password", "Wrong email or password");
            return View(model);
        }

		// Redirect to the profile page of the logged-in user.
		return RedirectToAction("Index", "Profile", new { id = user.Id });
    }

	// Handles user logout and sign the user out.
	[HttpPost("auth/logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}