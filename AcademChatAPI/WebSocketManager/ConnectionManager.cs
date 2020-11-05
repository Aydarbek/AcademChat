using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace WoodChessV1.WebSocketManager
{
    public class ConnectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public ConnectionManager()
        {
        }

        public WebSocket GetSocketById (string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }

        public ConcurrentDictionary<string, WebSocket> GetAll()
        {
            return _sockets;
        }


        public string GetId (WebSocket socket)
        {
            return _sockets.FirstOrDefault(w => w.Value == socket).Key;
        }

        public void AddSocket(WebSocket socket)
        {
            _sockets.TryAdd(CreateConnectionId(), socket);
        }

        private string CreateConnectionId()
        {
            return Guid.NewGuid().ToString();
        }

        public async Task RemoveSocket(string id)
        {
            WebSocket socket;
            if (id == null)
                return;

            _sockets.TryRemove(id, out socket);

            if (socket.State != WebSocketState.Aborted)
                await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                                        statusDescription: "Closed by the ConnectionManager",
                                        cancellationToken: CancellationToken.None);
        }
    }
}
