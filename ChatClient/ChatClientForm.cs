using System;
using System.Net.WebSockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ChatClient
{
    public partial class ChatClientForm : Form
    {
        private delegate void SafeCallDelegate(string text);
        private Action SafeCallDelegateWithoutParams;

        WSClient wsClient;
        object locker = new object();

        public ChatClientForm()
        {
            InitializeComponent();
            wsClient = new WSClient();
            wsClient.InitWebSocket();
        }


        private void ChatClientForm_Load(object sender, EventArgs e)
        {
            mainTextBox.Text = "ChatClient connected!";
            wsClient.webSocket.OnMessage += ReceveWsMessage;
        }


        private void ReceveWsMessage(object sender, WebSocketSharp.MessageEventArgs e)
        {
            Debug.WriteLine($"Message received: {e.Data}");
            PrintWsMessage(e.Data);
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
                mainTextBox.AppendText(":" + "\n" + text + "\n" + ":");
            }
        }


        private void ChatClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            wsClient.webSocket.CloseAsync();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = inputTextBox.Text;
            wsClient.webSocket.Send(message);
            inputTextBox.Text = "";
        }

    }
}
