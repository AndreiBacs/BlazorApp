using Microsoft.AspNetCore.SignalR;
using MudBlazor;

namespace BlazorApp.Hubs
{
    public class ChatHub : Hub
    {
        public const string HubUrl = "/chat";
        public override async Task OnConnectedAsync()
        {
            //await Broadcast("", "User Connected!");
            await base.OnConnectedAsync();
        }

        public async Task Broadcast(string user, string message)
        {
            await Clients.All.SendAsync("Broadcast", user, message);
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            await Broadcast(e?.Message ?? "User", "Disconnected!");
            await base.OnDisconnectedAsync(e);
        }
    }
    public class Message
    {
        public Message(string username, string body, bool mine)
        {
            Username = username;
            Body = body;
            Mine = mine;
            TimeSent = DateTime.Now.ToString("G");
        }

        public string Username { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }
        public string TimeSent { get; set; }

        public bool IsNotice => Body.StartsWith("[Notice]");

        public string CSS => Mine ? Colors.Red.Default : Colors.Teal.Default;
    }
}
