using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
namespace Filminurk.Hubs
{
    public class ChatHub : Hub
    {
        [Authorize] //only logged in users
        public async Task SendMessage(string message)
        {
            var userName = Context.User?.Identity?.Name ?? "Unknown";
            await Clients.All.SendAsync("ReceiveMessage", userName, message);
        }
    }
}