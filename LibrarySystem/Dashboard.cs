using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frmMainDashboardForm : Form
    {
        public frmMainDashboardForm()
        {
            InitializeComponent();
        }

        private void MainDashboardForm_Load(object sender, EventArgs e)
        {
            LoadUserControl(new ucDashboard());
            tmrClock.Start();

            ucDashboard dashboard = new ucDashboard();

            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(dashboard);
        }
        public void LoadUserControl(UserControl uc)
        {
            pnlContainer.Controls.Clear();

            uc.Dock = DockStyle.Fill;

            pnlContainer.Controls.Add(uc);

            uc.BringToFront();
        }
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucDashboard());
        }

        private void btnBorrowBooks_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucBorrowBooks());
        }

        private void btnReturnBooks_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucReturnBooks());
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucBooks());
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucStudents());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucCategories());
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucTransactions());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucReports());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();

            login.Show();

            this.Close();
        }
    }
}
