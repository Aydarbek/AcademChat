using System;
using System.Windows.Forms;
using System.Diagnostics;
using WebSocketSharp;
using WsChatModels;
using WsChatModels.Entities;
using Newtonsoft.Json;

namespace ChatClient
{
    public partial class chatClientForm : Form
    {
        private delegate void SafeCallDelegate(string text);
        private delegate void SafeCallDelegateClose();
        public User CurrentUser { get; private set; }

        internal WebSocket webSocket;
        loginForm loginForm;
        string statusText;

        public chatClientForm()
        {
            InitializeComponent();            
        }


        private void ChatClientForm_Load(object sender, EventArgs e)
        {
            InitWebSocket();
            this.ActiveControl = inputTextBox;
            loginForm = new loginForm();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.Cancel)
                this.Close();
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

        public void WsSendAuthenticationRequest(string userName, string password)
        {
            try
            {
                WsMessage authRequest = new WsMessage
                {
                    type = WsMessageType.AuthRequest
                };
                authRequest.parameters.Add("userName", userName);
                authRequest.parameters.Add("password", password);

                webSocket.Send(JsonConvert.SerializeObject(authRequest));
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal void WsSendChatMessage(string message, string toUserId = "")
        {
            try
            {
                WsMessage chatMessage = new WsMessage
                {
                    fromUserId = CurrentUser.id,
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


        private void WsSendStatusUpdate(string newStatus)
        {
            WsMessage statusUpdate = new WsMessage
            {
                fromUserId = CurrentUser.id,
                type = WsMessageType.Status,
                data = newStatus
            };

            webSocket.Send(JsonConvert.SerializeObject(statusUpdate));
        }


        private void ReceveWsMessage(object sender, WebSocketSharp.MessageEventArgs e)
        {
            try
            {
                WsMessage wsMessage = JsonConvert.DeserializeObject<WsMessage>(e.Data);
                if (wsMessage == null)
                    return;

                if (wsMessage.type == WsMessageType.Chat ||
                   wsMessage.type == WsMessageType.System)
                    PrintWsMessage(wsMessage.data.Trim('"'));

                else if (wsMessage.type == WsMessageType.AuthGrant)
                {
                    User user = JsonConvert.DeserializeObject<User>(wsMessage.data);
                    if (user != null)
                        CurrentUser = user;
                    EnterProgram();
                }

                else if (wsMessage.type == WsMessageType.AuthRequest)
                    loginForm.ShowDialog();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void EnterProgram()
        {
            CloseLoginForm();
            SetUserInfo();
        }

        private void SetUserInfo()
        {
            userNameText.Text = CurrentUser.name;
            statusTextBox.Text = CurrentUser.status;
        }

        private void CloseLoginForm()
        {
            if (loginForm.InvokeRequired)
            {
                var d = new SafeCallDelegateClose(EnterProgram);
                loginForm.Invoke(d);
            }
            else
            {
                loginForm.Close();
                loginForm.DialogResult = DialogResult.OK;
            }
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
            if (CurrentUser == null)
                loginForm.ShowDialog();
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


        private void statusTextBox_MouseUp_1(object sender, MouseEventArgs e)
        {
            statusTextBox.ReadOnly = false;
            acceptStatusButton.Visible = true;
            cancelStatusButton.Visible = true;
            statusText = statusTextBox.Text;
        }

        private void acceptStatusButton_Click(object sender, EventArgs e)
        {
            if (statusTextBox.Text.Length <= 30)
            {
                statusTextBox.ReadOnly = true;
                acceptStatusButton.Visible = false;
                cancelStatusButton.Visible = false;
                WsSendStatusUpdate(statusTextBox.Text);
            }
        }

        private void cancelStatusButton_Click(object sender, EventArgs e)
        {
            statusTextBox.Text = statusText;
            statusTextBox.ReadOnly = true;
            acceptStatusButton.Visible = false;
            cancelStatusButton.Visible = false;
        }
    }
}
