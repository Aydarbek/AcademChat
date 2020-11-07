namespace ChatClient
{
    partial class LoginForm
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
            this.Login = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.loginLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginLayoutPanel
            // 
            this.loginLayoutPanel.Controls.Add(this.userNameLabel);
            this.loginLayoutPanel.Controls.Add(this.userNameBox);
            this.loginLayoutPanel.Controls.Add(this.passwordLabel);
            this.loginLayoutPanel.Controls.Add(this.passwordBox);
            this.loginLayoutPanel.Controls.Add(this.Login);
            this.loginLayoutPanel.Controls.Add(this.statusBox);
            this.loginLayoutPanel.Location = new System.Drawing.Point(60, 12);
            this.loginLayoutPanel.Name = "loginLayoutPanel";
            this.loginLayoutPanel.Size = new System.Drawing.Size(173, 188);
            this.loginLayoutPanel.TabIndex = 0;
            // 
            // userNameLabel
            // 
            this.userNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameLabel.Location = new System.Drawing.Point(3, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(89, 24);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "UserName";
            // 
            // userNameBox
            // 
            this.userNameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userNameBox.Location = new System.Drawing.Point(3, 27);
            this.userNameBox.Name = "userNameBox";
            this.userNameBox.Size = new System.Drawing.Size(164, 22);
            this.userNameBox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordLabel.Location = new System.Drawing.Point(3, 52);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(82, 24);
            this.passwordLabel.TabIndex = 0;
            this.passwordLabel.Text = "Password";
            // 
            // passwordBox
            // 
            this.passwordBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordBox.Location = new System.Drawing.Point(3, 79);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(164, 22);
            this.passwordBox.TabIndex = 1;
            // 
            // Login
            // 
            this.Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Login.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login.Location = new System.Drawing.Point(3, 107);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(120, 31);
            this.Login.TabIndex = 2;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(3, 144);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(164, 44);
            this.statusBox.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 229);
            this.ControlBox = false;
            this.Controls.Add(this.loginLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.Text = "LoginForm";
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
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox statusBox;
    }
}