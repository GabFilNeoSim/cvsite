namespace Web.Models.Message
{
    public class AnonymousMessageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime MessageTime { get; set; }
        public bool Read { get; set; }
    }
}
