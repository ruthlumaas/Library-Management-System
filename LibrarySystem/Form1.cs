using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Please enter username and password to continue.",
                    "Input Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            ConnectDB db = new ConnectDB();

            bool isValid = db.LoginUser(username, password);

            if (isValid)
            {
                frmMainDashboardForm dashboard = new frmMainDashboardForm();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                // 🔥 CLEAN SECURITY MESSAGE (NO DETAIL LEAK)
                MessageBox.Show(
                    "Invalid username or password.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
        

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
         
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false; // SHOW PASSWORD
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;  // HIDE PASSWORD
            }
        }

    }
    
}
