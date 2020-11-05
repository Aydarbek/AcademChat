using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademChatClient
{
    public partial class ChatClient : Form
    {
        WSClient wsClient;

        public ChatClient()
        {
            InitializeComponent();
            wsClient = new WSClient();
            wsClient.InitWebSocket();
        }

        private void ChatClient_Load(object sender, EventArgs e)
        {

        }
    }
}
