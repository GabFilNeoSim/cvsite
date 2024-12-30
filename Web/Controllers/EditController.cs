using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Data.Contexts;
using Web.Models;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

[Route("profile/{id}/edit")]
public class EditController : BaseController
{
    public EditController(AppDbContext context, UserManager<User> userManager) : base(context, userManager) { }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Index(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return View();
        }

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Index(string id, User model)
    {
        return View();
    }

    [Authorize]
    [HttpGet("projects/{pid}")]
    public async Task<IActionResult> Projects(string id, string pid)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return View();
        }

        return View(user);
    }

    [Authorize]
    [HttpGet("qualification/{qid}")]
    public async Task<IActionResult> Qualifications(string id, string qid)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return View();
        }

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Qualifications(string id, User model)
    {
        return View();
    }
}