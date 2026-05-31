using MySql.Data.MySqlClient;
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
    public partial class ucDashboard : UserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
        }

        private void ucDashboard_Load(object sender, EventArgs e)
        {
            LoadRecentTransactions();
            LoadOverdueBooks();
            LoadDashboardCounts();
        }
        public void LoadRecentTransactions()
        {
            string query = @"SELECT CONCAT(rs.first_name,' ', rs.last_name) AS 'colStudent',b.title AS 'colBook',bt.borrow_date AS 'colDate',
                            TIME_FORMAT(bt.borrow_time, '%h:%i %p') AS 'colTime',bt.status AS 'colStatus' FROM borrow_transactions bt
                            INNER JOIN register_students rs ON bt.student_id = rs.student_id INNER JOIN books b ON bt.book_id = b.book_id
                            ORDER BY bt.transaction_id DESC LIMIT 8";

            ConnectDB.DisplayData( query, dgvRecentTransactions);
        }
        public void LoadOverdueBooks()
        {
            string query = @"SELECT CONCAT(rs.first_name,' ', rs.last_name) AS colStudent,b.title AS colBook,
                            CONCAT(DATEDIFF(CURDATE(), bt.due_date),' days') AS colDays FROM borrow_transactions bt
                            INNER JOIN register_students rs ON bt.student_id = rs.student_id INNER JOIN books b ON bt.book_id = b.book_id
                            WHERE bt.status = 'OVERDUE' ORDER BY bt.due_date ASC LIMIT 8";

            ConnectDB.DisplayData( query, dgvOverdueBooks);
        }

        private void dgvRecentTransactions_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StudentCellRenderer.RenderStudentCell( dgvRecentTransactions, e, "colStudent");
        }

        private void dgvRecentTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            StudentCellRenderer.RenderStatusColor( dgvRecentTransactions, e, "colStatus");
        }

        private void dgvOverdueBooks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StudentCellRenderer.RenderStudentCell( dgvOverdueBooks, e, "colStudent");
        }

        private void dgvOverdueBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            StudentCellRenderer.RenderOverdueColor( dgvOverdueBooks, e, "colDays");
        }
        private void LoadDashboardCounts()
        {
            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    // TOTAL BOOKS
                    string totalBooks ="SELECT COUNT(*) FROM books";
                    MySqlCommand cmdBooks = new MySqlCommand(totalBooks, conn);
                    lblTotalBooks.Text = cmdBooks.ExecuteScalar().ToString();

                    // TOTAL STUDENTS
                    string totalStudents = "SELECT COUNT(*) FROM register_students";
                    MySqlCommand cmdStudents = new MySqlCommand(totalStudents, conn);
                    lblTotalStudents.Text = cmdStudents.ExecuteScalar().ToString();

                    // TOTAL BORROWED BOOKS
                    string totalBorrowed = @"SELECT COUNT(*) FROM borrow_transactions WHERE status = 'BORROWED'";
                    MySqlCommand cmdBorrowed = new MySqlCommand(totalBorrowed, conn);
                    lblTotalBorrowedBooks.Text = cmdBorrowed.ExecuteScalar().ToString();

                    // TOTAL OVERDUE BOOKS
                    string totalOverdue = @"SELECT COUNT(*) FROM borrow_transactions WHERE status = 'OVERDUE'";
                    MySqlCommand cmdOverdue = new MySqlCommand(totalOverdue, conn);
                    lblOverdueBooks.Text = cmdOverdue.ExecuteScalar().ToString();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnGoScanStudent_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucBorrowBooks());
        }

        private void btnGoScanBook_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucBorrowBooks());
        }

        private void btnGoAddBook_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucBooks());
        }

        private void btnGoScanStudents_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucStudents());
        }

        private void btnGoGenerateReports_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucReports());
        }
    }
}
