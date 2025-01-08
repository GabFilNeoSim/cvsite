using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Models;
using Data.Contexts;
using Web.Models;

public class BaseController : Controller
{
    protected readonly AppDbContext _context;
    protected readonly UserManager<User> _userManager;

	// Constructor for injecting the database context and UserManager.
	public BaseController(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

	// Action method for displaying a custom 404 error page.
	public IActionResult Error404() => Error("404 - Page not found", "The specified page was not found.");

    public override void OnActionExecuting(ActionExecutingContext context)
    {
		// Check if the user is authenticated and store the authenticated user's ID in ViewData.
		if (User.Identity.IsAuthenticated)
        {
            ViewData["UserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier); ;
        }

        base.OnActionExecuting(context);
    }
	// Determines if the currently signed-in user owns the profile.
	protected async Task<bool> IsProfileOwner(string endpointUserId)
    {
		// Retrieve the currently signed-in user and compare it with the specified endpoint user ID.
		User? signedInUser = await _userManager.GetUserAsync(User);
        return signedInUser?.Id == endpointUserId;
    }

	// Retrieves the authenticated user's ID from their claims.
	protected string? GetUserIdFromClaim() => User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

	// Displays a custom error page with a given title and message.
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // Prevents caching of the error page.
	protected IActionResult Error(string title, string message) => View("Error", new ErrorViewModel { Title = title, Message = message });
}
