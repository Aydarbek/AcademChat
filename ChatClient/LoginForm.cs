using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        ChatClientForm MainForm;

        public LoginForm()
        {
            InitializeComponent();
            MainForm = (ChatClientForm)Application.OpenForms["ChatClientForm"];
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (userNameBox.Text != "" && passwordBox.Text != "")
                MainForm.WsSendAuthenticationRequest(userNameBox.Text, passwordBox.Text);
        }


    }
}
