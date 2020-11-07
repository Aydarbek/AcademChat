namespace ChatClient
{
    partial class ChatClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatClientForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.UserNameText = new System.Windows.Forms.TextBox();
            this.publicChatButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.chatPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.54479F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.45521F));
            this.tableLayoutPanel1.Controls.Add(this.chatPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.controlPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 568);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chatPanel
            // 
            this.chatPanel.Controls.Add(this.flowLayoutPanel2);
            this.chatPanel.Controls.Add(this.mainTextBox);
            this.chatPanel.Controls.Add(this.inputTextBox);
            this.chatPanel.Controls.Add(this.sendButton);
            this.chatPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatPanel.Location = new System.Drawing.Point(263, 3);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(754, 562);
            this.chatPanel.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // mainTextBox
            // 
            this.mainTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainTextBox.Location = new System.Drawing.Point(3, 17);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.Size = new System.Drawing.Size(756, 459);
            this.mainTextBox.TabIndex = 1;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextBox.Location = new System.Drawing.Point(3, 482);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(751, 30);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextBox_KeyDown);
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendButton.Location = new System.Drawing.Point(3, 518);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(109, 39);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.UserNameText);
            this.controlPanel.Controls.Add(this.publicChatButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(3, 3);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(254, 562);
            this.controlPanel.TabIndex = 1;
            // 
            // UserNameText
            // 
            this.UserNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.UserNameText.Location = new System.Drawing.Point(3, 3);
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.ReadOnly = true;
            this.UserNameText.Size = new System.Drawing.Size(251, 30);
            this.UserNameText.TabIndex = 0;
            this.UserNameText.Text = "UserName";
            // 
            // publicChatButton
            // 
            this.publicChatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publicChatButton.Location = new System.Drawing.Point(3, 39);
            this.publicChatButton.Name = "publicChatButton";
            this.publicChatButton.Size = new System.Drawing.Size(251, 33);
            this.publicChatButton.TabIndex = 1;
            this.publicChatButton.Text = "Public Chat";
            this.publicChatButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.publicChatButton.UseVisualStyleBackColor = true;
            // 
            // ChatClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 568);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChatClientForm";
            this.Text = "ChatClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatClientForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.chatPanel.ResumeLayout(false);
            this.chatPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel chatPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.FlowLayoutPanel controlPanel;
        private System.Windows.Forms.TextBox UserNameText;
        private System.Windows.Forms.Button publicChatButton;
    }
}

