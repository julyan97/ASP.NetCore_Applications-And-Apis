using Microsoft.AspNetCore.SignalR;
using MovieNight.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.ChatHub
{
    public class ChatHub : Hub
    {

        public HashSet<string> Users { get; set; } 
        public async Task SendVideoInfiToAllMessage(string room, string message)
        {

            await Clients.Groups(room).SendAsync("ReceiveMessage",  new { Text = message, Button = "yes" });

        }

        public async Task PlayPause(string room)
        {

            await Clients.Groups(room).SendAsync("PlayPauseJs");

        }
        public async Task LoadVideo(string room,string name)
        {

            await Clients.Groups(room).SendAsync("LoadVideoJs",name);

        }

        public async Task ChangeTime(string room, double time)
        {

            await Clients.Groups(room).SendAsync("ChangeTimeJs", time);

        }


        public async Task SendMessage(string room , string message)
        {
            
            await Clients.All.SendAsync("ReceiveMessage", new { User = Context.User.Identity.Name, Text = message});
            
        }

        public async Task AddToGroup(string room )
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            await Clients.Group(room).SendAsync("ReceiveMessage", new { User = Context.User.Identity.Name/*, Text = $"{Context.User.Identity.Name} has joined the group ."*/ });
        }

        public async Task SendMessageToGroup(string room, string message)
        {

            await Clients.Groups(room).SendAsync("ReceiveMessage", new { User = Context.User.Identity.Name, Text = message });
        }


        public async Task SendMessageToUser(string user, string message)
        {

            await Clients.User(user).SendAsync("ReceiveMessage", new { User = Context.User.Identity.Name, Text = message });
        }

    }
}
