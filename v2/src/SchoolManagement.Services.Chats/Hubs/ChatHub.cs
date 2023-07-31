using Microsoft.AspNetCore.SignalR;

namespace SchoolManagement.Services.Chats.Hubs;

public class ChatHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
}
