namespace ChatApp.Model
{
    public class Message
    {
        public string User { get; set; } = "";
        public string Text { get; set; } = "";
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
