namespace Web.Models.Message
{
    public class ChatViewModel
    {
        public UserViewModel ChatUser { get; set; }
        public IEnumerable<ChatMessageViewModel> Messages { get; set; }
    }
}
