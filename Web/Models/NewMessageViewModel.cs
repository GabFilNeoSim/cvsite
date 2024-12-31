using Models;

namespace Web.Models;

public class NewMessageViewModel
{
    public required string Text { get; set; }
    public string? AnonymousName { get; set; }
    public required User Receiver {  get; set; }
}
