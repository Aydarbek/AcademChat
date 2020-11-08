﻿using Microsoft.Extensions.Logging;
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
            WsMessage wsMessage = new WsMessage
            {
                type = WsMessageType.System,
                data = ex.Message
            };
            await SendMessageAsync(socketId, JsonConvert.SerializeObject(wsMessage));
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
                    SendAuthRequest(currWebsocket);
                    await SendMessageToAllAsync($"{fromUser.name} is now connected");
                }
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
            WsMessage authRequest = new WsMessage { type = WsMessageType.AuthRequest };
            await SendMessageAsync(currWebsocket, JsonConvert.SerializeObject(authRequest));

        }

        private async Task HandleAuthenticationRequest(WsMessage wsMessage)
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

            WsMessage authGrant = new WsMessage
            {
                type = WsMessageType.AuthGrant,
                data = JsonConvert.SerializeObject(user)
            };

            if (user.password.Equals(password))
            {
                UserWebsockets[userName]= currWebsocket; 
                await SendMessageAsync(currWebsocket, JsonConvert.SerializeObject(authGrant));
            }
            else
                throw new ChatException("Password is incorrect");
        }

        private async Task HandleChatMessage(WsMessage wsMessage, User fromUser)
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

            WsMessage chatMessage = new WsMessage
            {
                type = WsMessageType.Chat,
                data = message
            };

            await SendMessageToAllAsync(JsonConvert.SerializeObject(chatMessage));
        }

        private async Task HandleStatusMessage(WsMessage wsMessage)
        {
            User user = _context.Users.Find(wsMessage.fromUserId);
            if (user != null)
                user.status = wsMessage.data;

            await _context.SaveChangesAsync();
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