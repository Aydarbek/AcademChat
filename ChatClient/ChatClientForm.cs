using System;
using System.Windows.Forms;
using System.Diagnostics;
using WebSocketSharp;
using WsChatModels;
using Newtonsoft.Json;
using Message = WsChatModels.Message;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using System.Drawing;

namespace ChatClient
{
    public partial class chatClientForm : Form
    {
        private delegate void SafeCallDelegate(string text);
        Action threadSafeAction;
        Action<User> setUserDataSafe;

        int connectionCounter;

        private delegate void SafeCallDelegateEmpty();
        public User CurrentUser { get; private set; }
        long? selectedUserId = null;

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

                while (webSocket.ReadyState != WebSocketState.Open)
                {
                    InitWebSocket();
                    connectionCounter++;
                    if (connectionCounter >= 5)
                        throw new Exception("Server not available");
                    Thread.Sleep(100);
                }
                connectionCounter = 0;
                webSocket.Send(JsonConvert.SerializeObject(authRequest));
            }
            catch (Exception ex)
            {
                if (loginForm.Modal)
                {
                    loginForm.PrintMessage(ex.Message);
                }

                Debug.WriteLine(ex.Message);
            }
        }


        internal void WsSendChatMessage(string message, long? toUserId)
        {
            try
            {
                WsChatModels.Message chatMessage = new WsChatModels.Message
                {
                    user_id = CurrentUser.id,
                    type = WsMessageType.Chat,
                    data = message,
                    to_user_id = toUserId,
                    time_stamp = DateTime.Now
                };


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
                        if (selectedUserId != null && 
                            (selectedUserId == wsMessage.user_id || selectedUserId == wsMessage.to_user_id) &&
                            (CurrentUser.id == wsMessage.user_id || CurrentUser.id == wsMessage.to_user_id))
                            PrintWsMessage($"{wsMessage.User.name} {wsMessage.time_stamp.ToString("HH:mm")}:  {wsMessage.data.Trim('\"')}");
                        else if (selectedUserId == null)
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
            List<User> users = JsonConvert.DeserializeObject<List<User>>(usersJson).Where(u => !u.name.Equals(CurrentUser.name)).ToList();
            ClearOnlineUsersPanel();

            if (users != null)
                foreach (User user in users)
                    AddOnlineUserButton(user);
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

        private void AddOnlineUserButton(User user)
        {
            if (this.onlineUsersPanel.InvokeRequired)
            {
                setUserDataSafe = AddOnlineUserButton;
                onlineUsersPanel.Invoke(setUserDataSafe, new object[] { user });
            }
            else
            {
                Button button = new Button();
                button.Text = user.name;
                button.Tag = user.id;                
                button.Width = 180;
                button.Height = 30;
                onlineUsersPanel.Controls.Add(button);
                button.Click += new EventHandler(UserButtonClick);

                if (button.Tag.ToString() == selectedUserId.ToString())
                    button.BackColor = Color.DarkGray;
                else if (selectedUserId == null)
                    publicChatButton.BackColor = Color.DarkGray;
            }
        }

        private void UserButtonClick(object sender, EventArgs e)
        {
            Button userButton = (Button)sender;
            
            var buttons = GetAll(onlineUsersPanel, typeof(Button));
            foreach (Button button in buttons)
            {
                if (button != userButton)
                    button.BackColor = Color.LightGray;
                else
                    button.BackColor = Color.DarkGray;
            }

            publicChatButton.BackColor = Color.LightGray;

            selectedUserId = Int64.Parse(userButton.Tag.ToString());            
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
                threadSafeAction = SetUserNameTextSafely;
                userNameText.Invoke(threadSafeAction);
            }
            else
                userNameText.Text = CurrentUser.name;
        }


        private void SetUserStatusTextSafely()
        {
            if (statusTextBox.InvokeRequired)
            {
                threadSafeAction = SetUserStatusTextSafely;
                userNameText.Invoke(threadSafeAction);
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
            WsSendChatMessage(message, selectedUserId);
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

        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void publicChatButton_Click(object sender, EventArgs e)
        {
            SwitchToPublicChat();
        }

        private void SwitchToPublicChat()
        {
            publicChatButton.BackColor = Color.DarkGray;
            selectedUserId = null;
            var onlineButtons = GetAll(onlineUsersPanel, typeof(Button));
            foreach (Button button in onlineButtons)
                button.BackColor = Color.LightGray;
        }
    }
}
