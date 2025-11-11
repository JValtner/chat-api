using ChatApp.Model;
using ChatApp.Service;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string user, string message)
        {
            var msg = new Message { User = user, Text = message, SentAt = DateTime.UtcNow };
            _chatService.AddMessage(msg);

            await Clients.All.SendAsync("ReceiveMessage", msg);
        }
    }
}
