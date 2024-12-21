using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using Models;
using Data.Contexts;

public class BaseController : Controller
{
    protected readonly AppDbContext _context;
    protected readonly UserManager<User> _userManager;

    public BaseController(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (User.Identity.IsAuthenticated)
        {
            ViewData["UserId"] = User.FindFirstValue(ClaimTypes.NameIdentifier); ;
        }

        base.OnActionExecuting(context);
    }
}
