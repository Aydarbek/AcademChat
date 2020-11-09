using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WsChatModels;

namespace ChatClient
{
    public partial class loginForm : Form
    {
        chatClientForm MainForm;
        delegate void SafeCallDelegate(string data);

        public loginForm()
        {
            InitializeComponent();
            MainForm = (chatClientForm)Application.OpenForms["ChatClientForm"];
            MainForm.webSocket.OnMessage += LoginForm_OnMessage;
        }

        private void LoginForm_OnMessage(object sender, WebSocketSharp.MessageEventArgs e)
        {
            WsChatModels.Message wsMessage = JsonConvert.DeserializeObject<WsChatModels.Message>(e.Data);
            if (wsMessage != null && wsMessage.type == WsMessageType.System)
                PrintMessage(wsMessage.data);
        }

        internal void PrintMessage(string data)
        {
            if (this.statusBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(PrintMessage);
                statusBox.Invoke(d, new object[] { data });
            }
            else
                statusBox.Text = data;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (userNameBox.Text != "" && passwordBox.Text != "")
                    MainForm.WsSendAuthenticationRequest(userNameBox.Text, passwordBox.Text);
            }
            catch (WebSocketException ex)
            {
                PrintMessage(ex.Message);
            }
        }
    }
}
