using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;

namespace AcademChatClient
{
    class WSClient
    {
        internal WebSocket webSocket;

        internal void InitWebSocket()
        {
            if (webSocket != null && webSocket.ReadyState == WebSocketState.Open)
                return;

            webSocket = new WebSocketSharp.WebSocket("ws://localhost:5000/ws");
            webSocket.Connect();

            webSocket.OnOpen += (sender, e) => Console.WriteLine("Connected!");
            webSocket.OnError += (sender, e) => Console.WriteLine(e.Message);
            webSocket.OnClose += (sender, e) => Console.WriteLine("WebSocket Closed.");
        }
    }
}
