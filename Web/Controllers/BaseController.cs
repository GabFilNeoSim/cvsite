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

    public BaseController(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Error404() => Error("404 - Page not found", "The specified page was not found.");

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (User.Identity.IsAuthenticated)
        {
            ViewData["UserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier); ;
        }

        base.OnActionExecuting(context);
    }

    protected async Task<bool> IsProfileOwner(string endpointUserId)
    {
        User? signedInUser = await _userManager.GetUserAsync(User);
        return signedInUser?.Id == endpointUserId;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    protected IActionResult Error(string title, string message) => View("Error", new ErrorViewModel { Title = title, Message = message });
}
