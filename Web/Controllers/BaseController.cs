using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using System.Security.Claims;

public class BaseController : Controller
{
    private readonly AppDbContext _context;

    public BaseController(AppDbContext context)
    {
        _context = context;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (User.Identity.IsAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewData["UserId"] = userId;

            var unreadMessageCount = ViewData["MessageCount"] = _context.Messages
                .Where(m => m.ReceiverId == userId && m.Read == false)
                .Count();

            ViewData["UnreadMessagesCount"] = unreadMessageCount;

        }

        base.OnActionExecuting(context);
    }
}
