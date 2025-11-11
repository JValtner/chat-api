
using ChatApp.Model;
using ChatApp.Service;

namespace ChatApp.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly List<Message> _messages = new();

        public void AddMessage(Message message)
        {
            _messages.Add(message);
        }

        public IEnumerable<Message> GetMessages() => _messages;
    }
}
