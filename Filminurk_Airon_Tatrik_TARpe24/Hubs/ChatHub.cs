using Filminurk.Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Filminurk.ApplicationServices.Services;
using System;

namespace Filminurk.Hubs
{
    public class ChatHub : Hub
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatHub(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize] 
        public async Task SendMessage(string message)
        {
            var user = await _userManager.GetUserAsync(Context.User);
            var displayName = user?.DisplayName ?? user?.UserName ?? "Unknown";

            await Clients.All.SendAsync("ReceiveMessage", displayName, message);
        }
    }
}