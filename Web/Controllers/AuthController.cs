﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Models;
using Web.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Data.Contexts;
using Microsoft.AspNetCore.Hosting.Server;

namespace Web.Controllers;

public class AuthController : BaseController
{
    private readonly SignInManager<User> _signInManager;

    public AuthController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager) : base(context, userManager)
    {
        _signInManager = signInManager;
    }

    // Endpoint for the registration page.
    [HttpGet("auth/register")]
    public IActionResult Register() => View(new RegisterViewModel());

	// Endpoint for account registration post request
	[HttpPost("auth/register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {   
        if (!ModelState.IsValid) return View(model);

		// Ensure password fields are not null.
		if (model.Password == null) model.Password = string.Empty;
        if (model.ConfirmPassword == null) model.ConfirmPassword = string.Empty;

		// Check if the email already exists.
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

		// Handle any errors during user creation.
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

	// Endpoint for the login page.
	[HttpGet("auth/login")]
    public IActionResult Login() => View(new LoginViewModel());

	// Endpoint for account login post request
	[HttpPost("auth/login")]
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

        if (user.IsDeactivated)
        {
            TempData["NotifyType"] = "error";
            TempData["NotifyMessage"] = "You're account is deactivated.";
            return View(model);
        }

        // Attempt to sign the user.
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

        // Display notification for new unread messages
        var unreadMessages = user.ReceivedMessages.Where(x => !x.Read).Count();

        if (unreadMessages > 0)
        {
            TempData["NotifyType"] = "success";
            TempData["NotifyMessage"] =  $"You've got {unreadMessages} new messages";
        }

        // Redirect to the profile page of the logged-in user.
        return RedirectToAction("Index", "Profile", new { id = user.Id });
    }

	// Endpoint for account logout post request
	[HttpPost("auth/logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // Endpoint for account deactivation post request
    [Authorize]
    [HttpPost("auth/deactivate")]
    public async Task<IActionResult> Deactivate()
    {
		string? userId = GetUserIdFromClaim();
        if (userId == null)
        {
            return Error("User not logged in", "The user is not logged in");
        }

		User? user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Error("Internal error", "The user was not found");
        }

        user.IsDeactivated = true;

        _context.Update(user);

        await _context.SaveChangesAsync();
        await _signInManager.SignOutAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Successfully deactivated account";

        return RedirectToAction("Index", "Home");
    }
}