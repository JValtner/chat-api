using ChatApp.Model;

namespace ChatApp.Service
{
    public interface IChatService
    {
        void AddMessage(Message message);
        IEnumerable<Message> GetMessages();
    }
}
