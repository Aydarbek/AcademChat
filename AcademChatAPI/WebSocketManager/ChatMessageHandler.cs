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
using System.Collections.Concurrent;
using User = AcademChatAPI.Entities.User;
using Message = AcademChatAPI.Entities.Message;

namespace AcademChatAPI.WebSocketManager
{
    public class ChatMessageHandler : WebSocketHandler
    {
        ChatContext _context;
        ILogger<ChatMessageHandler> _logger;
        ConcurrentDictionary<string, WebSocket> UserWebsockets = new ConcurrentDictionary<string, WebSocket>();
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

        public override async Task OnDisconnected(WebSocket socket)
        {
            string userName = UserWebsockets.Keys.FirstOrDefault(k => UserWebsockets[k] == socket);
            if (userName != null)
            {
                UserWebsockets.TryRemove(userName, out socket);
                await SendMessageToAllAsync(new Message
                {
                    type = WsMessageType.System,
                    data = $"User {userName} disconnected.",
                    time_stamp = DateTime.Now                    
                });
                _logger.LogInformation($"Socket is disconnected: \r\n{wsConnectionManager.GetId(socket)}");

                UpdateOnlineUsersInfo();
            }

            await base.OnDisconnected(socket);
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            string socketId = wsConnectionManager.GetId(socket);
            try
            {
                currWebsocket = socket;
                string wsMessageJson = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Message wsMessage = JsonConvert.DeserializeObject<Entities.Message>(wsMessageJson);
                
                await HandleWsMessage(wsMessage);
            }
            catch(ChatException ex)
            {
                await SendSystemMessage(socketId, ex);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        private async Task SendSystemMessage(string socketId, ChatException ex)
        {
            Message wsMessage = new Entities.Message
            {
                type = WsMessageType.System,
                data = ex.Message,
                time_stamp = DateTime.Now
            };
            await SendMessageAsync(socketId, JsonConvert.SerializeObject(wsMessage));
        }

        private async Task HandleWsMessage(Entities.Message wsMessage)
        {
            User fromUser = _context.Users.Find(wsMessage.user_id);
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
                    SendAuthRequest(currWebsocket);
            }

            switch (wsMessage.type)
            {
                case (WsMessageType.Chat):
                    await HandleChatMessage(wsMessage, fromUser);
                    break;
                case (WsMessageType.AuthRequest):
                    await HandleAuthenticationRequest(wsMessage);
                    break;
                case (WsMessageType.Status):
                    await HandleStatusMessage(wsMessage);
                    break;
            }
        }

        private async void SendAuthRequest(WebSocket currWebsocket)
        {
            Entities.Message authRequest = new Entities.Message { type = WsMessageType.AuthRequest };
            await SendMessageAsync(currWebsocket, JsonConvert.SerializeObject(authRequest));

        }

        private async Task HandleAuthenticationRequest(Entities.Message wsMessage)
        {
            string userName;
            string password;

            if (wsMessage.parameters.ContainsKey("userName") &&
               wsMessage.parameters.ContainsKey("password"))
            {
                userName = wsMessage.parameters["userName"];
                password = wsMessage.parameters["password"];
            }
            else
                throw new ChatException("userName or password is empty");

            User user = _context.Users.FirstOrDefault(u => u.name.Equals(userName));
            if (user == null)
                throw new ChatException("User not found");

            Message authGrant = new Message
            {
                type = WsMessageType.AuthGrant,
                data = JsonConvert.SerializeObject(user)
            };

            if (user.password.Equals(password))
            {
                UserWebsockets[userName] = currWebsocket; 
                await SendMessageAsync(currWebsocket, JsonConvert.SerializeObject(authGrant));
                await SendMessageToAllAsync(new Message
                {
                    type = WsMessageType.System,
                    data = $"User {userName} connected",
                    time_stamp = DateTime.Now
                });

                UpdateOnlineUsersInfo();
            }
            else
                throw new ChatException("Password is incorrect");
        }

        private async void UpdateOnlineUsersInfo()
        {
            List<User> onlineUsers = new List<User>();

            foreach (string userName in UserWebsockets.Keys)
            {
                User user = _context.Users.FirstOrDefault(u => u.name.Equals(userName));
                onlineUsers.Add(user);
            }

            Message usersMessage = new Message
            {
                type = WsMessageType.Users,
                data = JsonConvert.SerializeObject(onlineUsers)
            };

            await SendMessageToAllAsync(usersMessage);

        }

        private async Task HandleChatMessage(Message wsMessage, User fromUser)
        {
            long toUserId = -1;

            if (wsMessage.parameters.ContainsKey("toUserId"))
                Int64.TryParse(wsMessage.parameters["toUserId"], out toUserId);


            _context.Add(wsMessage);
            await _context.SaveChangesAsync();

            await SendMessageToAllAsync(wsMessage);
        }

        private async Task HandleStatusMessage(Entities.Message wsMessage)
        {
            User user = _context.Users.Find(wsMessage.user_id);
            if (user != null)
                user.status = wsMessage.data;

            await _context.SaveChangesAsync();
        }

        private async Task SendMessageAsync (long userId, Entities.Message message)
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

        public async Task SendMessageToAllAsync(Message message)
        {
            foreach(WebSocket socket in UserWebsockets.Values)
            {
                await SendMessageAsync(socket, JsonConvert.SerializeObject(message));
            }
        }

    }
}