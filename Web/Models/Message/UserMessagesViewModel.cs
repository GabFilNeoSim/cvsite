namespace Web.Models.Message
{
    public class UserMessagesViewModel
    {
        public UserViewModel? User { get; set; }
        public string? LastMessage { get; set; }
        public DateTime LastMessageTime { get; set; }
        public int? UnreadCount { get; set; }
    }
}
