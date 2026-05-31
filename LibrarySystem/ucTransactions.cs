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
using MySql.Data.MySqlClient;
namespace LibrarySystem
{
    public partial class ucTransactions : UserControl
    {
        public ucTransactions()
        {
            InitializeComponent();
        }
        private void LoadTransactionHistory()
        {
            string query = @"
    SELECT
        bt.transaction_id AS 'Transaction ID',
        CONCAT(rs.first_name, ' ', rs.last_name) AS 'Student Name',
        rs.student_number AS 'Student ID',
        b.title AS 'Book Title',
        b.accession_no AS 'Accession No',
        DATE_FORMAT(bt.borrow_date, '%b %d, %Y') AS 'Borrow Date',
        TIME_FORMAT(bt.borrow_time, '%h:%i %p') AS 'Borrow Time',
        DATE_FORMAT(bt.due_date, '%b %d, %Y') AS 'Due Date',
        DATE_FORMAT(bt.return_date, '%b %d, %Y') AS 'Return Date',
        TIME_FORMAT(bt.return_time, '%h:%i %p') AS 'Return Time',
        CASE
            WHEN bt.status = 'RETURNED' AND bt.return_date > bt.due_date THEN 'Returned, Overdue'
            WHEN bt.status = 'RETURNED' THEN 'Returned'
            WHEN bt.status = 'BORROWED' AND bt.due_date < CURDATE() THEN 'Borrowed, Overdue'
            WHEN bt.status = 'BORROWED' THEN 'Borrowed'
            ELSE bt.status
        END AS 'Status'
    FROM borrow_transactions bt
    INNER JOIN register_students rs ON bt.student_id = rs.student_id
    INNER JOIN books b ON bt.book_id = b.book_id
    ORDER BY bt.transaction_id DESC";

            ConnectDB.DisplayData(query, dgvTransactions);
        }

        private void ucTransactions_Load(object sender, EventArgs e)
        {
            LoadTransactionHistory();
            LoadTransactionCounts();
        }
        private void LoadTransactionCounts()
        {
            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    string totalQuery = "SELECT COUNT(*) FROM borrow_transactions";
                    MySqlCommand cmdTotal = new MySqlCommand(totalQuery, conn);
                    lblTotalTransactions.Text = cmdTotal.ExecuteScalar().ToString();

                    string borrowedQuery = @"
                SELECT COUNT(*) 
                FROM borrow_transactions 
                WHERE status = 'BORROWED'";
                    MySqlCommand cmdBorrowed = new MySqlCommand(borrowedQuery, conn);
                    lblTotalBorrowed.Text = cmdBorrowed.ExecuteScalar().ToString();

                    string returnedQuery = @"
                SELECT COUNT(*) 
                FROM borrow_transactions 
                WHERE status = 'RETURNED'";
                    MySqlCommand cmdReturned = new MySqlCommand(returnedQuery, conn);
                    lblTotalReturned.Text = cmdReturned.ExecuteScalar().ToString();

                    string overdueQuery = @"
                SELECT COUNT(*) 
                FROM borrow_transactions
                WHERE 
                    (status = 'BORROWED' AND due_date < CURDATE())
                    OR
                    (status = 'RETURNED' AND return_date > due_date)";
                    MySqlCommand cmdOverdue = new MySqlCommand(overdueQuery, conn);
                    lblTotalOverdue.Text = cmdOverdue.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading transaction counts:\n" + ex.Message);
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucReports());
        }
    }
}
