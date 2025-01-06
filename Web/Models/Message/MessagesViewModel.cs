namespace Web.Models.Message
{
    public class MessagesViewModel
    {
        public List<AnonymousMessageViewModel>? AnonymousMessages { get; set; }
        public List<UserMessagesViewModel>? UserMessages { get; set; }
    }
}
