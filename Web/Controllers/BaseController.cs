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

	// Constructor with dependency injecting.
	public BaseController(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

	// Endpoint for the 404 error page (page not found).
	public IActionResult Error404() => Error("404 - Page not found", "The specified page was not found.");

    public override void OnActionExecuting(ActionExecutingContext context)
    {
		// Check if the user is authenticated and store the authenticated user's ID in ViewData.
		if (User.Identity.IsAuthenticated)
        {
            ViewData["UserId"] = GetUserIdFromClaim();
        }

        base.OnActionExecuting(context);
    }

	// Retrieves the authenticated user ID from their claims.
	protected string? GetUserIdFromClaim() => User.FindFirstValue(ClaimTypes.NameIdentifier);
	
    // Determines if the currently signed-in user owns the profile.
	protected async Task<bool> IsProfileOwner(string endpointUserId)
    {
		User? signedInUser = await _userManager.GetUserAsync(User);
        return signedInUser?.Id == endpointUserId;
    }


	// Displays a custom error page with a given title and message.
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // Prevents caching of the error page.
	protected IActionResult Error(string title, string message) => View("Error", new ErrorViewModel { Title = title, Message = message });
}
