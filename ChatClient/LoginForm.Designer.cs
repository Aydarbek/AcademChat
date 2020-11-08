namespace ChatClient
{
    partial class loginForm
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
            this.loginLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.loginLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginLayoutPanel
            // 
            this.loginLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginLayoutPanel.Controls.Add(this.userNameLabel);
            this.loginLayoutPanel.Controls.Add(this.userNameBox);
            this.loginLayoutPanel.Controls.Add(this.passwordLabel);
            this.loginLayoutPanel.Controls.Add(this.passwordBox);
            this.loginLayoutPanel.Controls.Add(this.loginButton);
            this.loginLayoutPanel.Controls.Add(this.statusBox);
            this.loginLayoutPanel.Location = new System.Drawing.Point(13, 10);
            this.loginLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.loginLayoutPanel.Name = "loginLayoutPanel";
            this.loginLayoutPanel.Size = new System.Drawing.Size(133, 196);
            this.loginLayoutPanel.TabIndex = 0;
            // 
            // userNameLabel
            // 
            this.userNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userNameLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameLabel.Location = new System.Drawing.Point(2, 0);
            this.userNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(123, 20);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "UserName";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userNameBox
            // 
            this.userNameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userNameBox.Location = new System.Drawing.Point(2, 22);
            this.userNameBox.Margin = new System.Windows.Forms.Padding(2);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(121, 20);
            this.userNameBox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordLabel.Location = new System.Drawing.Point(2, 44);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(123, 20);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "Password";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordBox
            // 
            this.passwordBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordBox.Location = new System.Drawing.Point(2, 66);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(2);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(121, 20);
            this.passwordBox.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginButton.Location = new System.Drawing.Point(2, 90);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(120, 25);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.Login_Click);
            // 
            // statusBox
            // 
            this.statusBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusBox.Location = new System.Drawing.Point(2, 119);
            this.statusBox.Margin = new System.Windows.Forms.Padding(2);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(123, 24);
            this.statusBox.TabIndex = 3;
            // 
            // loginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 154);
            this.Controls.Add(this.loginLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatClient";
            this.loginLayoutPanel.ResumeLayout(false);
            this.loginLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel loginLayoutPanel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox userNameBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox statusBox;
    }
}