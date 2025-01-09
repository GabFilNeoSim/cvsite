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

    /// <summary>
    /// Message page endpoint
    /// </summary>
    [Authorize]
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        User? loggedInUser = await _userManager.GetUserAsync(User);

        if (loggedInUser == null)
            return RedirectToAction("Login", "Account");

        // Get users all messages, grouped by user.
        var userMessages = await _context.Messages
            .Where(m => m.SenderId != null && m.SenderId == loggedInUser.Id || m.SenderId != null && m.ReceiverId == loggedInUser.Id)
            .Where(m => !m.Sender.IsDeactivated && !m.Receiver.IsDeactivated)
            .OrderByDescending(m => m.CreatedAt)
            .GroupBy(m => m.SenderId == loggedInUser.Id ? m.ReceiverId : m.SenderId)
            .Select(g => new UserMessagesViewModel
            {
                User = _context.Users
                    .Where(u => u.Id == g.Key)
                    .Select(u => new UserViewModel
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        AvatarUri = u.AvatarUri
                    })
                    .FirstOrDefault(),
                LastMessage = g.OrderByDescending(m => m.CreatedAt).First().Text,
                LastMessageTime = g.OrderByDescending(m => m.CreatedAt).First().CreatedAt,
                UnreadCount = g.Count(m => !m.Read && m.ReceiverId == loggedInUser.Id)
            })
            .OrderByDescending(um => um.LastMessageTime)
            .ToListAsync();

        // Get anonymous messages
        var anonymousMessages = await _context.Messages
            .Where(m => m.SenderId == null && m.ReceiverId == loggedInUser.Id)
            .OrderByDescending(m => m.CreatedAt)
            .Select(g => new AnonymousMessageViewModel {
                Id = g.Id,
                Name = g.AnonymousName,
                Text = g.Text,
                MessageTime = g.CreatedAt,
                Read = g.Read
            })
            .OrderByDescending(u => u.MessageTime)
            .ToListAsync();

        // Create messages view model
        var messages = new MessagesViewModel
        {
            UserMessages = userMessages,
            AnonymousMessages = anonymousMessages
        };

        return View(messages);
    }


    /// <summary>
    /// Chat view endpoint.
    /// </summary>
    [HttpGet("chat/{id}")]
    public async Task<ActionResult> Chat(string id)
    {
        User? loggedInUser = await _userManager.GetUserAsync(User);
        if (loggedInUser == null) return RedirectToAction("Login", "Auth");

        // Get the chat user, as a userviewmodel
        var chatUser = await _context.Users
           .Where(u => u.Id == id)
           .Select(u => new UserViewModel
           {
               Id = u.Id,
               FirstName = u.FirstName,
               LastName = u.LastName,
               AvatarUri = u.AvatarUri
           })
           .FirstOrDefaultAsync();

        if (chatUser == null) return NotFound("User not found.");

        // Get all unread messages.
        var unreadMessages = await _context.Messages
            .Where(m => m.SenderId == id && m.ReceiverId == loggedInUser.Id && !m.Read)
            .ToListAsync();

        // Set read state to true.
        foreach (var message in unreadMessages)
        {
            message.Read = true;
        }

        await _context.SaveChangesAsync();

        // Get all the message history for those two individs, related to each other.
        var messages = await _context.Messages
           .Where(m => (m.SenderId == loggedInUser.Id && m.ReceiverId == id) ||
                       (m.SenderId == id && m.ReceiverId == loggedInUser.Id))
               .OrderBy(m => m.CreatedAt)
               .Select(m => new ChatMessageViewModel
               {
                   Id = m.Id,
                   Text = m.Text,
                   Read = m.Read,
                   IsSentByCurrentUser = m.SenderId == loggedInUser.Id,
                   Avatar = m.SenderId == loggedInUser.Id ? loggedInUser.AvatarUri : m.Sender.AvatarUri,
                   CreatedAt = m.CreatedAt
               })
               .ToListAsync();

        // Declare chatviewmodel
        var chatViewModel = new ChatViewModel
        {
            ChatUser = chatUser,
            Messages = messages
        };

        return View(chatViewModel);
    }

    /// <summary>
    /// Send message endpoint
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Send(SendMessageViewModel model)
    {
        // Return if validation fails.
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Chat", new { id = model.ChatUserId });
        }

        // Get users involved.
        User? loggedInUser = await _userManager.GetUserAsync(User);
        if (loggedInUser == null) return RedirectToAction("Login", "Auth");

        User? receivingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.ChatUserId);
        if (receivingUser == null) Error("Unknown Error", "An unexpected error happend");

        // Create message object.
        var message = new Message
        {
            Sender = loggedInUser,
            Receiver = receivingUser,
            Text = model.Text,
        };

        // Add and save message to database
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();

        return RedirectToAction("Chat", new { id = model.ChatUserId });
    }

    /// <summary>
    /// Send anonymously messages endpoint
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> SendAnonymous(AnonymousSendMessageViewModel model)
    {
        // Return if validation fails.
        if (!ModelState.IsValid)
        {
            TempData["NotifyType"] = "error";
            TempData["NotifyMessage"] = "Failed to send message";
            return RedirectToAction("Index", "Profile", new { id = model.ReceiverId });
        }

        User? receivingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.ReceiverId);
        if (receivingUser == null) Error("Unknown Error", "An unexpected error happend");

        // Create message object.
        var message = new Message
        {
            AnonymousName = model.Name,
            Sender = null,
            Receiver = receivingUser,
            Text = model.Text,
        };

        // Add and save message to database
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();

        TempData["NotifyType"] = "success";
        TempData["NotifyMessage"] = "Message sent successfully!";
        return RedirectToAction("Index", "Profile", new { id = model.ReceiverId });
    }

    /// <summary>
    /// Mark messages as read
    /// </summary>
    [HttpPost("{mid}")]
    public async Task<IActionResult> MarkRead(int mid)
    {
        var message = await _context.Messages.SingleOrDefaultAsync(x => x.Id == mid);

        if (message == null)
        {
            return Error("Internal error", "Message not found.");
        }

        message.Read = true;

        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpPost("{mid}/delete")]
    public async Task<IActionResult> DeleteMessage(int mid)
    {
        var message = await _context.Messages.SingleOrDefaultAsync(x => x.Id == mid);
        if (message == null)
        {
            return Error("Internal error", "Message not found.");
        }

        _context.Messages.Remove(message);

        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
