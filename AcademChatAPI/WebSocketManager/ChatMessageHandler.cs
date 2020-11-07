using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WsChatModels;
using Newtonsoft.Json.Serialization;
using AcademChatAPI.Exceptions;
using AcademChatAPI.Repository;
using AcademChatAPI.Entities;

namespace AcademChatAPI.WebSocketManager
{
    public class ChatMessageHandler : WebSocketHandler
    {
        ChatContext _context;
        ILogger<ChatMessageHandler> _logger;        
        Dictionary<string, WebSocket> UserWebsockets = new Dictionary<string, WebSocket>();
        WebSocket currWebsocket;

        public ChatMessageHandler(ConnectionManager webSocketConnectionManager, ChatContext context,
            ILogger<ChatMessageHandler> logger) : base(webSocketConnectionManager)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);

            var socketId = wsConnectionManager.GetId(socket);
            _logger.LogInformation($"{socketId} is now connected");
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            string socketId = wsConnectionManager.GetId(socket);
            try
            {
                currWebsocket = socket;
                string wsMessageJson = Encoding.UTF8.GetString(buffer, 0, result.Count);
                WsMessage wsMessage = JsonConvert.DeserializeObject<WsMessage>(wsMessageJson);
                
                await HandleWsMessage(wsMessage);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }


        private async Task HandleWsMessage(WsMessage wsMessage)
        {
            User fromUser = _context.Users.Find(wsMessage.fromUserId);
            if (currWebsocket != null && fromUser != null)
            {                
                if (UserWebsockets.ContainsKey(fromUser.name))
                {
                    if(UserWebsockets[fromUser.name] != currWebsocket)
                    {
                        UserWebsockets[fromUser.name] = currWebsocket;
                        await SendMessageToAllAsync($"{fromUser.name} is now reconnected");
                    }
                }
                else
                {
                    UserWebsockets.Add(fromUser.name, currWebsocket);
                    await SendMessageToAllAsync($"{fromUser.name} is now connected");
                }
            }

            if (wsMessage.type == WsMessageType.Chat)
            {
                string message = $"{fromUser.name} ({DateTime.Now.ToString("HH:mm")}): {wsMessage.data} ";
                long toUserId = -1;

                if (wsMessage.parameters.ContainsKey("toUserId"))
                    Int64.TryParse(wsMessage.parameters["toUserId"], out toUserId);

               
                Message newMessage = new Message
                {
                    User = fromUser,
                    text = wsMessage.data,
                    time_stamp = DateTime.Now
                };

                if (toUserId != -1)
                    newMessage.To_User = _context.Users.Find(toUserId);

                _context.Add(newMessage);
                await _context.SaveChangesAsync();
                
                await SendMessageToAllAsync(JsonConvert.SerializeObject(message));
            }
        }

        private async Task SendMessageAsync (long userId, WsMessage message)
        {
            try
            {
                User user = _context.Users.Find(userId);
                if (user != null && !UserWebsockets.ContainsKey(user.name))
                    throw new ChatException($"User {user.name} is offline.");

                await SendMessageAsync(UserWebsockets[user.name], JsonConvert.SerializeObject(message));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SendMessageToAllAsync(WsMessage message)
        {
            foreach(WebSocket socket in UserWebsockets.Values)
            {
                await SendMessageAsync(socket, JsonConvert.SerializeObject(message));
            }
        }

        private WsMessage MakeWsMessage(WsMessageType type, string data, string[] parameters = null)
        {
            return new WsMessage(0, type, JsonConvert.SerializeObject(data));
        }
    }
}