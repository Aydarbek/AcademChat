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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chatPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.cancelStatusButton = new System.Windows.Forms.Button();
            this.acceptStatusButton = new System.Windows.Forms.Button();
            this.publicChatButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.chatPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 602F));
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
            this.controlPanel.Controls.Add(this.userNameText);
            this.controlPanel.Controls.Add(this.flowLayoutPanel1);
            this.controlPanel.Controls.Add(this.publicChatButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(3, 3);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(254, 562);
            this.controlPanel.TabIndex = 1;
            // 
            // userNameText
            // 
            this.userNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.userNameText.Location = new System.Drawing.Point(3, 3);
            this.userNameText.Name = "userNameText";
            this.userNameText.ReadOnly = true;
            this.userNameText.Size = new System.Drawing.Size(251, 30);
            this.userNameText.TabIndex = 0;
            this.userNameText.Text = "UserName";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.statusTextBox);
            this.flowLayoutPanel1.Controls.Add(this.cancelStatusButton);
            this.flowLayoutPanel1.Controls.Add(this.acceptStatusButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(251, 73);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusTextBox.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusTextBox.Location = new System.Drawing.Point(0, 3);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(248, 27);
            this.statusTextBox.TabIndex = 2;
            this.statusTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.statusTextBox_MouseUp_1);
            // 
            // cancelStatusButton
            // 
            this.cancelStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelStatusButton.Location = new System.Drawing.Point(223, 36);
            this.cancelStatusButton.Name = "cancelStatusButton";
            this.cancelStatusButton.Size = new System.Drawing.Size(25, 25);
            this.cancelStatusButton.TabIndex = 5;
            this.cancelStatusButton.Text = "X";
            this.cancelStatusButton.UseVisualStyleBackColor = true;
            this.cancelStatusButton.Visible = false;
            this.cancelStatusButton.Click += new System.EventHandler(this.cancelStatusButton_Click);
            // 
            // acceptStatusButton
            // 
            this.acceptStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptStatusButton.Location = new System.Drawing.Point(192, 36);
            this.acceptStatusButton.Name = "acceptStatusButton";
            this.acceptStatusButton.Size = new System.Drawing.Size(25, 25);
            this.acceptStatusButton.TabIndex = 6;
            this.acceptStatusButton.Text = "V";
            this.acceptStatusButton.UseVisualStyleBackColor = true;
            this.acceptStatusButton.Visible = false;
            this.acceptStatusButton.Click += new System.EventHandler(this.acceptStatusButton_Click);
            // 
            // publicChatButton
            // 
            this.publicChatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publicChatButton.Location = new System.Drawing.Point(3, 118);
            this.publicChatButton.Name = "publicChatButton";
            this.publicChatButton.Size = new System.Drawing.Size(251, 33);
            this.publicChatButton.TabIndex = 8;
            this.publicChatButton.Text = "Public Chat";
            this.publicChatButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.publicChatButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // chatClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 568);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "chatClientForm";
            this.Text = "ChatClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatClientForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.chatPanel.ResumeLayout(false);
            this.chatPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel chatPanel;
        private System.Windows.Forms.TextBox mainTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.FlowLayoutPanel controlPanel;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button cancelStatusButton;
        private System.Windows.Forms.Button acceptStatusButton;
        private System.Windows.Forms.Button publicChatButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

