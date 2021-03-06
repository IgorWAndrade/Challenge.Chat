﻿using IWA.Challenge.Chat.Service.Manager;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Service.Handler
{
    public class ChatMessageHandler : WebSocketHandler
    {
        public ChatMessageHandler(ConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var socketId = WebSocketConnectionManager.GetId(socket);
            var message = $"{Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            await SendMessageToAllAsync(JsonConvert.SerializeObject(message));
        }
    }
}
