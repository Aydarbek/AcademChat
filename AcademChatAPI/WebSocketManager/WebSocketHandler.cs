using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WoodChessV1.WebSocketManager
{
    public abstract class WebSocketHandler
    {
        internal ConnectionManager wsConnectionManager { get; set; }

        public WebSocketHandler(ConnectionManager wsConnectionmanager)
        {
            wsConnectionManager = wsConnectionmanager;
        }

        public virtual async Task OnConnected(WebSocket socket)
        {
            await Task.Run(() => wsConnectionManager.AddSocket(socket));
        }

        public virtual async Task OnDisconnected(WebSocket socket)
        {
            await wsConnectionManager.RemoveSocket(wsConnectionManager.GetId(socket));
        }

        public async Task SendMessageAsync (WebSocket socket, string message)
        {
            if (socket == null || socket.State != WebSocketState.Open)
                return;

            await socket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.ASCII.GetBytes(message),
                                                                  offset: 0,
                                                                  count: message.Length),
                                   messageType: WebSocketMessageType.Text,
                                   endOfMessage: true,
                                   cancellationToken: CancellationToken.None);
        }

        public async Task SendMessageAsync(string socketId, string message)
        {
            await SendMessageAsync(wsConnectionManager.GetSocketById(socketId), message);
        }

        public virtual async Task SendMessageToAllAsync(string message)
        {
            foreach(var pair in wsConnectionManager.GetAll())
            {
                if (pair.Value.State == WebSocketState.Open)
                    await SendMessageAsync(pair.Value, message);
            }
        }

        public abstract Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
    }
}
