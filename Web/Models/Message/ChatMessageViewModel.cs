﻿namespace Web.Models.Message
{
    public class ChatMessageViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Read { get; set; }
        public bool IsSentByCurrentUser { get; set; }
        public string? Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
