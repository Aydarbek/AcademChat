using System;
using System.Windows.Forms;
using System.Diagnostics;
using WebSocketSharp;
using WsChatModels;
using Newtonsoft.Json;
using Message = WsChatModels.Message;
using System.Collections.Generic;
using System.Linq;

namespace ChatClient
{
    public partial class chatClientForm : Form
    {
        private delegate void SafeCallDelegate(string text);

        Action threadSafeActionEmpty;
        Action<string> threadSafeAction;

        private delegate void SafeCallDelegateEmpty();
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
                Message authRequest = new Message
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
                WsChatModels.Message chatMessage = new WsChatModels.Message
                {
                    user_id = CurrentUser.id,
                    type = WsMessageType.Chat,
                    data = message,
                    time_stamp = DateTime.Now
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
            WsChatModels.Message statusUpdate = new WsChatModels.Message
            {
                user_id = CurrentUser.id,
                type = WsMessageType.Status,
                data = newStatus
            };

            webSocket.Send(JsonConvert.SerializeObject(statusUpdate));
        }


        private void ReceveWsMessage(object sender, WebSocketSharp.MessageEventArgs e)
        {
            try
            {
                WsChatModels.Message wsMessage = JsonConvert.DeserializeObject<WsChatModels.Message>(e.Data);
                if (wsMessage == null)
                    return;

                switch (wsMessage.type)
                {
                    case WsMessageType.Chat:
                        PrintWsMessage($"{wsMessage.User.name} {wsMessage.time_stamp.ToString("HH:mm")}:  {wsMessage.data.Trim('\"')}");
                        break;
                    case WsMessageType.System:
                        PrintWsMessage($"System {wsMessage.time_stamp.ToString("HH:mm")}:  {wsMessage.data.Trim('\"')}");
                        break;
                    case WsMessageType.AuthGrant:                        
                        EnterProgram(wsMessage);
                        break;
                    case WsMessageType.AuthRequest:
                        loginForm.ShowDialog();
                        break;
                    case WsMessageType.Users:
                        ShowOnlineUsers(wsMessage.data);
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ShowOnlineUsers(string usersJson)
        {
            ClearOnlineUsersPanel();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(usersJson).Where(u => !u.name.Equals(CurrentUser.name)).ToList();
            
            if (users != null)
                foreach (User user in users)
                    AddOnlineUserButton(user.name);

        }

        private void ClearOnlineUsersPanel()
        {
            if (this.onlineUsersPanel.InvokeRequired)
            {
                var d = new SafeCallDelegateEmpty(ClearOnlineUsersPanel);
                onlineUsersPanel.Invoke(d);
            }
            else
                onlineUsersPanel.Controls.Clear();
        }

        private void AddOnlineUserButton(string user)
        {
            if (this.onlineUsersPanel.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddOnlineUserButton);
                onlineUsersPanel.Invoke(d, new object[] { user });
            }
            else
            {
                Button button = new Button();
                button.Text = user;
                button.Width = 180;
                button.Height = 30;
                onlineUsersPanel.Controls.Add(button);
            }
        }

        private void EnterProgram(Message wsMessage)
        {
            User user = JsonConvert.DeserializeObject<User>(wsMessage.data);
            if (user != null)
                CurrentUser = user;
            CloseLoginForm();
            SetUserInfo();
        }

        private void SetUserInfo()
        {
            SetUserNameTextSafely();
            SetUserStatusTextSafely();
        }

        private void SetUserNameTextSafely()
        {
            if (userNameText.InvokeRequired)
            {
                threadSafeActionEmpty = SetUserNameTextSafely;
                userNameText.Invoke(threadSafeActionEmpty);
            }
            else
                userNameText.Text = CurrentUser.name;
        }


        private void SetUserStatusTextSafely()
        {
            if (statusTextBox.InvokeRequired)
            {
                threadSafeActionEmpty = SetUserStatusTextSafely;
                userNameText.Invoke(threadSafeActionEmpty);
            }
            else
                statusTextBox.Text = CurrentUser.status;
        }

        private void CloseLoginForm()
        {
            if (loginForm.InvokeRequired)
            {
                var d = new SafeCallDelegateEmpty(CloseLoginForm);
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
            MakeButtonsVisible(true);
            statusText = statusTextBox.Text;
        }

        private void acceptStatusButton_Click(object sender, EventArgs e)
        {
            if (statusTextBox.Text.Length <= 30)
            {
                statusTextBox.ReadOnly = true;
                MakeButtonsVisible(false);
                WsSendStatusUpdate(statusTextBox.Text);
            }
        }

        private void cancelStatusButton_Click(object sender, EventArgs e)
        {
            statusTextBox.Text = statusText;
            statusTextBox.ReadOnly = true;
            MakeButtonsVisible(false);
        }

        private void MakeButtonsVisible(bool isVisible)
        {
            acceptStatusButton.Visible = isVisible;
            cancelStatusButton.Visible = isVisible;
        }
    }
}
