using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademChatClient
{
    public partial class ChatClient : Form
    {
        WSClient wsClient;
        string inputMessage;
        object locker = new object();

        public ChatClient()
        {
            InitializeComponent();
            wsClient = new WSClient();
            wsClient.InitWebSocket();
        }

        private void ChatClient_Load(object sender, EventArgs e)
        {
            MainTextBox.Text = "New text box message.";
            wsClient.webSocket.OnMessage += ReceveWsMessage;
            Task.Run(() => CheckWsMessage());
        }

        private void ReceveWsMessage(object sender, WebSocketSharp.MessageEventArgs e)
        {
            lock (locker) 
            {
                inputMessage = e.Data;                
            }
        }

        private void CheckWsMessage()
        {
            while (true)
            {
                lock (locker)
                {
                    if (inputMessage != null)
                    {
                        MainTextBox.Text = inputMessage;
                        inputMessage = "";
                    } 
                }
                Thread.Sleep(200);
            }
        }

        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            wsClient.webSocket.Close();
        }
    }
}
