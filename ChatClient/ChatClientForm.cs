using System;
using System.Windows.Forms;
using System.Diagnostics;
using WebSocketSharp;
using WsChatModels;
using WsChatModels.Entities;
using Newtonsoft.Json;

namespace ChatClient
{
    public partial class ChatClientForm : Form
    {
        private delegate void SafeCallDelegate(string text);
        public User CurrentUser { get; private set; }

        internal WebSocket webSocket;

        public ChatClientForm()
        {
            InitializeComponent();            
        }


        private void ChatClientForm_Load(object sender, EventArgs e)
        {
            InitWebSocket();
        }

        private void InitWebSocket()
        {
            if (webSocket != null && webSocket.ReadyState == WebSocketState.Open)
                return;

            webSocket = new WebSocketSharp.WebSocket("ws://localhost:5000/ws");
            webSocket.Connect();

            webSocket.OnOpen += (sender, e) => PrintWsMessage("WebSocket Connected!");
            webSocket.OnError += (sender, e) => PrintWsMessage(e.Message);
            webSocket.OnClose += (sender, e) => PrintWsMessage("WebSocket Closed.");
            webSocket.OnMessage += ReceveWsMessage;
        }


        internal void WsSendChatMessage(string message, string toUserId = "")
        {
            try
            {
                WsMessage chatMessage = new WsMessage
                {
                    fromUserId = 2,
                    type = WsMessageType.Chat,
                    data = message
                };

                if (toUserId != "")
                    chatMessage.parameters.Add("toUserId", toUserId);

                webSocket.Send(JsonConvert.SerializeObject(chatMessage));
                ResetTextInput();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        private void ReceveWsMessage(object sender, WebSocketSharp.MessageEventArgs e)
        {
            Debug.WriteLine($"Message received: {e.Data}");
            PrintWsMessage(e.Data.Trim('"'));
        }

        private void PrintWsMessage(string text)
        {
            if (this.mainTextBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(PrintWsMessage);
                mainTextBox.Invoke(d, new object[] { text });
            }
            else
            {
                mainTextBox.AppendText(text + "\r\n");
            }
        }


        private void ChatClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            webSocket.Close();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text != "")
                SendMessage(inputTextBox.Text);
        }

        private void SendMessage(string message)
        {
            WsSendChatMessage(message);
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (inputTextBox.Text != "")
                    SendMessage(inputTextBox.Text);
                ResetTextInput();
            }
        }

        private void ResetTextInput(string text = "")
        {
            if (this.inputTextBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(ResetTextInput);
                inputTextBox.Invoke(d, new object[] { string.Empty });
            }
            else
            {
                inputTextBox.Text = string.Empty;
            }
        }
    }
}
