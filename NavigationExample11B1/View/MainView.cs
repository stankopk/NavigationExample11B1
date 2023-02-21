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
    public partial class MainView : Form
    {
        LoginController controller = new LoginController();

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            dgvUsers.DataSource = controller.GetAll();
        }

        private void RefreshTable()
        {
            dgvUsers.DataSource = controller.GetAll();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            controller.AddUser(user);
            RefreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvUsers.CurrentRow;
            int id = int.Parse(row.Cells[0].Value.ToString());
            controller.DeleteUser(id);
            RefreshTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvUsers.CurrentRow;
            int id = int.Parse(row.Cells[0].Value.ToString());
            User user = new User();
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            controller.UpdateUser(id, user);
            RefreshTable();
        }
    }
}
