using Data.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Web.Models;
using Web.Models.Message;

namespace Web.Controllers;

public class MessageController : BaseController
{   
    private readonly SignInManager<User> _signInManager;

    public MessageController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager) : base(context, userManager)
    {
        _signInManager = signInManager;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        User? loggedInUser = await _userManager.GetUserAsync(User);

        var messages = _context.Messages
                .Where(x => x.SenderId == loggedInUser.Id || x.ReceiverId == loggedInUser.Id);

        var userMessages = await messages
        .GroupBy(m => m.SenderId == loggedInUser.Id ? m.ReceiverId : m.SenderId)
        .Select(g => new UserMessagesViewModel
        {
            User = _context.Users
                .Where(u => u.Id == g.Key)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName ?? "Unknown",
                    LastName = u.LastName ?? "User",
                    AvatarUri = u.AvatarUri ?? "default.png"
                })
                .FirstOrDefault() ?? new UserViewModel
                {
                    Id = g.Key ?? "Unknown",
                    FirstName = "Unknown",
                    LastName = "User",
                    AvatarUri = "default.png"
                },
            LastMessage = g.OrderByDescending(m => m.CreatedAt).FirstOrDefault().Text
        })
        .ToListAsync();


        return View(userMessages);
    }

    [HttpGet("chat/{id}")]
    public async Task<ActionResult> Chat(string id)
    {
        User? loggedInUser = await _userManager.GetUserAsync(User);
        if (loggedInUser == null) return RedirectToAction("Login", "Auth");

        var chatUser = await _context.Users
           .Where(u => u.Id == id)
           .Select(u => new UserViewModel
           {
               Id = u.Id,
               FirstName = u.FirstName,
               LastName = u.LastName,
               AvatarUri = u.AvatarUri ?? "default.png"
           })
           .FirstOrDefaultAsync();

        if (chatUser == null) return NotFound("User not found.");

        var messages = await _context.Messages
       .Where(m => (m.SenderId == loggedInUser.Id && m.ReceiverId == id) ||
                   (m.SenderId == id && m.ReceiverId == loggedInUser.Id))
           .OrderBy(m => m.CreatedAt)
           .Select(m => new ChatMessageViewModel
           {
               Text = m.Text,
               IsSentByCurrentUser = m.SenderId == loggedInUser.Id,
               Avatar = m.SenderId == loggedInUser.Id
                    ? loggedInUser.AvatarUri ?? "default.png"
                    : _context.Users
                              .Where(u => u.Id == m.SenderId)
                              .Select(u => u.AvatarUri)
                              .FirstOrDefault() ?? "default.png",
               CreatedAt = m.CreatedAt
           })
           .ToListAsync();

        var chatViewModel = new ChatViewModel
        {
            ChatUser = chatUser,
            Messages = messages
        };

        return View(chatViewModel);
    }

    [HttpPost]
    public async Task<ActionResult> Send(SendMessageViewModel model)
    {

        if (!ModelState.IsValid)
        {
            return RedirectToAction("Chat", new { id = model.ChatUserId });
        }

        User? loggedInUser = await _userManager.GetUserAsync(User);
        if (loggedInUser == null) return RedirectToAction("Login", "Auth");

        User? receivingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.ChatUserId);
        if (receivingUser == null) return Content("Bad");


        var message = new Message
        {
            Sender = loggedInUser,
            Receiver = receivingUser,
            Text = model.Text,
        };

        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();

        return RedirectToAction("Chat", new { id = model.ChatUserId });

    }
}
