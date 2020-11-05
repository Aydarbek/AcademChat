using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WoodChessV1.WebSocketManager;

namespace AcademChatAPI.WebSocketManager
{
    public class ChatMessageHandler : WebSocketHandler
    {
        private ILogger<ChatMessageHandler> _logger;

        public ChatMessageHandler(ConnectionManager webSocketConnectionManager, ILogger<ChatMessageHandler> logger) 
            : base(webSocketConnectionManager)
        {
            _logger = logger;
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);

            var socketId = wsConnectionManager.GetId(socket);
            await SendMessageToAllAsync($"{socketId} is now connected");
            _logger.LogInformation($"{socketId} is now connected");
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var socketId = wsConnectionManager.GetId(socket);
            var message = $"{socketId} said: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";

            await SendMessageToAllAsync(message);
            _logger.LogInformation($"Received message {message}");
        }
    }
}
