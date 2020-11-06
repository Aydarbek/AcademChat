using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WebSocketSharp;

namespace ChatClient
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

            webSocket.OnOpen += (sender, e) => Debug.WriteLine("Connected!");
            webSocket.OnError += (sender, e) => Debug.WriteLine(e.Message);
            webSocket.OnClose += (sender, e) => Debug.WriteLine("WebSocket Closed.");
        }
    }
}
