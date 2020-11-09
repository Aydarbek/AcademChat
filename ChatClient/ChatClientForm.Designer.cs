namespace ChatClient
{
    partial class chatClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chatClientForm));
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.chatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.statusLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.cancelStatusButton = new System.Windows.Forms.Button();
            this.acceptStatusButton = new System.Windows.Forms.Button();
            this.publicChatButton = new System.Windows.Forms.Button();
            this.onlineUsersLabel = new System.Windows.Forms.TextBox();
            this.onlineUsersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayoutPanel.SuspendLayout();
            this.chatPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.54479F));
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.45521F));
            this.mainLayoutPanel.Controls.Add(this.chatPanel, 1, 0);
            this.mainLayoutPanel.Controls.Add(this.controlPanel, 0, 0);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 1;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 489F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(765, 462);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // chatPanel
            // 
            this.chatPanel.Controls.Add(this.mainTextBox);
            this.chatPanel.Controls.Add(this.inputTextBox);
            this.chatPanel.Controls.Add(this.sendButton);
            this.chatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatPanel.Location = new System.Drawing.Point(197, 2);
            this.chatPanel.Margin = new System.Windows.Forms.Padding(2);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(566, 458);
            this.chatPanel.TabIndex = 0;
            // 
            // mainTextBox
            // 
            this.mainTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainTextBox.Location = new System.Drawing.Point(2, 2);
            this.mainTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.Size = new System.Drawing.Size(568, 374);
            this.mainTextBox.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextBox.Location = new System.Drawing.Point(2, 380);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(564, 26);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextBox_KeyDown);
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendButton.Location = new System.Drawing.Point(2, 410);
            this.sendButton.Margin = new System.Windows.Forms.Padding(2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(82, 32);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.menuStrip1);
            this.controlPanel.Controls.Add(this.userNameText);
            this.controlPanel.Controls.Add(this.statusLayoutPanel);
            this.controlPanel.Controls.Add(this.publicChatButton);
            this.controlPanel.Controls.Add(this.onlineUsersLabel);
            this.controlPanel.Controls.Add(this.onlineUsersPanel);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(2, 2);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(2);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(191, 458);
            this.controlPanel.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(178, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "Logout";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.logoutToolStripMenuItem1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logoutToolStripMenuItem.Text = "Reconnect";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // userNameText
            // 
            this.userNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.userNameText.Location = new System.Drawing.Point(2, 26);
            this.userNameText.Margin = new System.Windows.Forms.Padding(2);
            this.userNameText.Name = "userNameText";
            this.userNameText.ReadOnly = true;
            this.userNameText.Size = new System.Drawing.Size(189, 26);
            this.userNameText.TabIndex = 0;
            this.userNameText.Text = "UserName";
            // 
            // statusLayoutPanel
            // 
            this.statusLayoutPanel.Controls.Add(this.statusTextBox);
            this.statusLayoutPanel.Controls.Add(this.cancelStatusButton);
            this.statusLayoutPanel.Controls.Add(this.acceptStatusButton);
            this.statusLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.statusLayoutPanel.Location = new System.Drawing.Point(2, 56);
            this.statusLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.statusLayoutPanel.Name = "statusLayoutPanel";
            this.statusLayoutPanel.Size = new System.Drawing.Size(188, 59);
            this.statusLayoutPanel.TabIndex = 8;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusTextBox.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusTextBox.Location = new System.Drawing.Point(-1, 2);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(187, 23);
            this.statusTextBox.TabIndex = 2;
            this.statusTextBox.Text = "UserStatus";
            this.statusTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.statusTextBox_MouseUp_1);
            // 
            // cancelStatusButton
            // 
            this.cancelStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelStatusButton.Location = new System.Drawing.Point(167, 29);
            this.cancelStatusButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelStatusButton.Name = "cancelStatusButton";
            this.cancelStatusButton.Size = new System.Drawing.Size(19, 20);
            this.cancelStatusButton.TabIndex = 5;
            this.cancelStatusButton.Text = "X";
            this.cancelStatusButton.UseVisualStyleBackColor = true;
            this.cancelStatusButton.Visible = false;
            this.cancelStatusButton.Click += new System.EventHandler(this.cancelStatusButton_Click);
            // 
            // acceptStatusButton
            // 
            this.acceptStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptStatusButton.Location = new System.Drawing.Point(144, 29);
            this.acceptStatusButton.Margin = new System.Windows.Forms.Padding(2);
            this.acceptStatusButton.Name = "acceptStatusButton";
            this.acceptStatusButton.Size = new System.Drawing.Size(19, 20);
            this.acceptStatusButton.TabIndex = 6;
            this.acceptStatusButton.Text = "V";
            this.acceptStatusButton.UseVisualStyleBackColor = true;
            this.acceptStatusButton.Visible = false;
            this.acceptStatusButton.Click += new System.EventHandler(this.acceptStatusButton_Click);
            // 
            // publicChatButton
            // 
            this.publicChatButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.publicChatButton.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publicChatButton.Location = new System.Drawing.Point(2, 119);
            this.publicChatButton.Margin = new System.Windows.Forms.Padding(2);
            this.publicChatButton.Name = "publicChatButton";
            this.publicChatButton.Size = new System.Drawing.Size(185, 30);
            this.publicChatButton.TabIndex = 8;
            this.publicChatButton.Text = "Public Chat";
            this.publicChatButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.publicChatButton.UseVisualStyleBackColor = false;
            this.publicChatButton.Click += new System.EventHandler(this.publicChatButton_Click);
            // 
            // onlineUsersLabel
            // 
            this.onlineUsersLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.onlineUsersLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.onlineUsersLabel.Location = new System.Drawing.Point(3, 154);
            this.onlineUsersLabel.Name = "onlineUsersLabel";
            this.onlineUsersLabel.ReadOnly = true;
            this.onlineUsersLabel.Size = new System.Drawing.Size(184, 19);
            this.onlineUsersLabel.TabIndex = 9;
            this.onlineUsersLabel.Text = "Online Users";
            // 
            // onlineUsersPanel
            // 
            this.onlineUsersPanel.Location = new System.Drawing.Point(3, 179);
            this.onlineUsersPanel.Name = "onlineUsersPanel";
            this.onlineUsersPanel.Size = new System.Drawing.Size(184, 251);
            this.onlineUsersPanel.TabIndex = 11;
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.logoutToolStripMenuItem1.Text = "Logout";
            this.logoutToolStripMenuItem1.Click += new System.EventHandler(this.logoutToolStripMenuItem1_Click);
            // 
            // chatClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 462);
            this.Controls.Add(this.mainLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "chatClientForm";
            this.Text = "ChatClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatClientForm_Load);
            this.mainLayoutPanel.ResumeLayout(false);
            this.chatPanel.ResumeLayout(false);
            this.chatPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusLayoutPanel.ResumeLayout(false);
            this.statusLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel chatPanel;
        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.FlowLayoutPanel controlPanel;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.FlowLayoutPanel statusLayoutPanel;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button cancelStatusButton;
        private System.Windows.Forms.Button acceptStatusButton;
        private System.Windows.Forms.Button publicChatButton;
        private System.Windows.Forms.TextBox onlineUsersLabel;
        private System.Windows.Forms.FlowLayoutPanel onlineUsersPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
    }
}

