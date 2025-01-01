using Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;

namespace Web.Controllers;

public class MessageController : BaseController
{   
    private readonly SignInManager<User> _signInManager;

    public MessageController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager) : base(context, userManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        User? user = await _userManager.GetUserAsync(User);

        return View(user);
    }

    [HttpGet]
    public ActionResult New() => View();
    
    [HttpPost]
    public ActionResult New(NewMessageViewModel model)
    {
        return View();
    }
}
