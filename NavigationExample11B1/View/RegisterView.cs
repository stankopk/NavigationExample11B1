using NavigationExample11B1.Controller;
using NavigationExample11B1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavigationExample11B1.View
{
    public partial class RegisterView : Form
    {
        LoginController controller = new LoginController();

        public RegisterView()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if(username == string.Empty)
            {
                MessageBox.Show("Please enter your username");
            }

            User user = new User();
            user.Username = username;
            user.Password = password;

            controller.AddUser(user);
            LoginView m = new LoginView();
            this.Hide();
            m.Show();
        }
    }
}
