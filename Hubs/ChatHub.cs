using Microsoft.AspNetCore.SignalR;
using SingnalRDemo.Models;

namespace SingnalRDemo.Hubs;


public class ChatHub : Hub
{
    public async Task JoinChat(UserConnection conn)
    {
        await Clients.All.SendAsync(method: "ReceiveMessage", arg1: "admin", arg2: $"{conn.UserName}has joined"); //task 
    }

    public async Task JoinSpecificChatRoom(UserConnection conn)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName: conn.ChatRoom);
        await Clients.Group(conn.ChatRoom).SendAsync(method: "ReceiveMessage", arg1: "admin", arg2: $"{conn.UserName} has joined {conn.ChatRoom}");
    }
}