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
    public partial class ucReturnBooks : UserControl
    {
        private int selectedTransactionID = 0;
        private int selectedBookID = 0;
        private string returnBookQRValue = "";

        public ucReturnBooks()
        {
            InitializeComponent();
        }


        private void ucReturnBooks_Load(object sender, EventArgs e)
        {
            LoadTransactions();
            ClearReturnDetails();

            txtReturnTransactionID.TextChanged += txtReturnTransactionID_TextChanged;
            dgvReturnBooks.CellClick += dgvReturnBooks_CellClick;

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, ev) =>
            {
                lblReturnTime.Text = DateTime.Now.ToString("hh:mm tt");
            };
            timer.Start();
        }

        private void LoadTransactions()
        {
            string query = @"
    SELECT 
        bt.transaction_id AS 'Transaction ID',
        CONCAT(rs.first_name, ' ', rs.last_name) AS 'Student Name',
        b.title AS 'Book Title',
        DATE_FORMAT(bt.borrow_date, '%b %d, %Y') AS 'Borrow Date',
        DATE_FORMAT(bt.due_date, '%b %d, %Y') AS 'Due Date',
        DATEDIFF(bt.due_date, CURDATE()) AS 'Days Left',
        CASE
            WHEN bt.status = 'RETURNED' 
                 AND bt.return_date > bt.due_date 
            THEN 'Returned, Overdue'

            WHEN bt.status = 'RETURNED' 
            THEN 'Returned'

            WHEN bt.status = 'BORROWED' 
                 AND bt.due_date < CURDATE() 
            THEN 'Borrowed, Overdue'

            WHEN bt.status = 'BORROWED' 
            THEN 'Borrowed'

            ELSE bt.status
        END AS 'Status'

    FROM borrow_transactions bt

    INNER JOIN register_students rs
        ON bt.student_id = rs.student_id

    INNER JOIN books b
        ON bt.book_id = b.book_id

    ORDER BY bt.transaction_id DESC";

            ConnectDB.DisplayData(query, dgvReturnBooks);
            dgvReturnBooks.AllowUserToAddRows = false;
        }


        private void btnConfirmReturn_Click(object sender, EventArgs e)
        {
            if (selectedTransactionID == 0 || selectedBookID == 0)
            {
                MessageBox.Show("Please select a transaction first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Confirm return?",
                "Return Book",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                string updateTransaction = @"
                UPDATE borrow_transactions
                SET status = 'RETURNED',
                    return_date = @returnDate,
                    return_time = @returnTime
                WHERE transaction_id = @transactionID";

                MySqlCommand cmd = new MySqlCommand(updateTransaction, conn);
                cmd.Parameters.AddWithValue("@returnDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@returnTime", DateTime.Now.ToString("HH:mm:ss"));
                cmd.Parameters.AddWithValue("@transactionID", selectedTransactionID);
                cmd.ExecuteNonQuery();

                string updateBook = @"
                UPDATE books 
                SET available_copies = available_copies + 1
                WHERE book_id = @bookID";

                MySqlCommand cmdBook = new MySqlCommand(updateBook, conn);
                cmdBook.Parameters.AddWithValue("@bookID", selectedBookID);
                cmdBook.ExecuteNonQuery();
            }

            MessageBox.Show("Book returned successfully.");

            LoadTransactions();
            ClearReturnDetails();
        }

        private void ClearReturnDetails()
        {
            selectedTransactionID = 0;
            selectedBookID = 0;

            lblReturnBookTitle.Text = "-";
            lblReturnAuthor.Text = "-";
            lblReturnCategory.Text = "-";
            lblReturnISBN.Text = "-";
            lblReturnAccession.Text = "-";

            lblReturnStudentName.Text = "-";
            lblReturnStudentID.Text = "-";
            lblReturnCourseYear.Text = "-";
            lblReturnSection.Text = "-";
            lblReturnStudentStatus.Text = "-";

            lblBorrowDate.Text = "-";
            lblDueDate.Text = "-";
            lblReturnDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
            lblReturnTime.Text = DateTime.Now.ToString("hh:mm tt");
            lblDaysBorrowed.Text = "-";
        }
        private void txtReturnTransactionID_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtReturnTransactionID.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadTransactions();
                return;
            }

            string baseQuery = @"
    SELECT 
        bt.transaction_id AS 'Transaction ID',
        CONCAT(rs.first_name, ' ', rs.last_name) AS 'Student Name',
        b.title AS 'Book Title',
        DATE_FORMAT(bt.borrow_date, '%b %d, %Y') AS 'Borrow Date',
        DATE_FORMAT(bt.due_date, '%b %d, %Y') AS 'Due Date',
        DATEDIFF(bt.due_date, CURDATE()) AS 'Days Left',
        CASE
            WHEN bt.status = 'RETURNED' AND bt.return_date > bt.due_date THEN 'Returned, Overdue'
            WHEN bt.status = 'RETURNED' THEN 'Returned'
            WHEN bt.status = 'BORROWED' AND bt.due_date < CURDATE() THEN 'Borrowed, Overdue'
            WHEN bt.status = 'BORROWED' THEN 'Borrowed'
            ELSE bt.status
        END AS 'Status'
    FROM borrow_transactions bt
    INNER JOIN register_students rs ON bt.student_id = rs.student_id
    INNER JOIN books b ON bt.book_id = b.book_id";

            string[] columns =
            {
        "bt.transaction_id",
        "CONCAT(rs.first_name, ' ', rs.last_name)",
        "b.title"
    };

            ConnectDB.SearchData(
                baseQuery,
                searchText,
                columns,
                dgvReturnBooks
            );
        }

        private void LoadReturnDetails(int transactionID)
        {
            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                string query = @"
                SELECT 
                    bt.transaction_id,
                    bt.borrow_date,
                    bt.due_date,
                    bt.status,

                    b.book_id,
                    b.title,
                    b.author,
                    b.isbn,
                    b.accession_no,

                    IFNULL(c.category_name, 'No Category') AS category_name,

                    rs.first_name,
                    rs.last_name,
                    rs.student_number,
                    rs.year_level,
                    rs.section,
                    rs.status AS student_status

                FROM borrow_transactions bt
                INNER JOIN books b ON bt.book_id = b.book_id
                LEFT JOIN category c ON b.category_id = c.category_id
                INNER JOIN register_students rs ON bt.student_id = rs.student_id
                WHERE bt.transaction_id = @transactionID";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@transactionID", transactionID);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    selectedBookID = Convert.ToInt32(dr["book_id"]);

                    lblReturnBookTitle.Text = dr["title"].ToString();
                    lblReturnAuthor.Text = dr["author"].ToString();
                    lblReturnCategory.Text = dr["category_name"].ToString();
                    lblReturnISBN.Text = dr["isbn"].ToString();
                    lblReturnAccession.Text = dr["accession_no"].ToString();

                    lblReturnStudentName.Text =
                        dr["first_name"].ToString() + " " +
                        dr["last_name"].ToString();

                    lblReturnStudentID.Text = dr["student_number"].ToString();
                    lblReturnCourseYear.Text = dr["year_level"].ToString();
                    lblReturnSection.Text = dr["section"].ToString();
                    lblReturnStudentStatus.Text = dr["student_status"].ToString();

                    DateTime borrowDate = Convert.ToDateTime(dr["borrow_date"]);
                    DateTime dueDate = Convert.ToDateTime(dr["due_date"]);
                    DateTime returnDate = DateTime.Now;

                    lblBorrowDate.Text = borrowDate.ToString("MMM dd, yyyy");
                    lblDueDate.Text = dueDate.ToString("MMM dd, yyyy");
                    lblReturnDate.Text = returnDate.ToString("MMM dd, yyyy");
                    lblReturnTime.Text = returnDate.ToString("hh:mm tt");

                    int daysBorrowed = (returnDate.Date - borrowDate.Date).Days;
                    if (daysBorrowed < 0)
                        daysBorrowed = 0;

                    lblDaysBorrowed.Text = daysBorrowed + " day(s)";
                }
            }
        }

        private void dgvReturnBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            try
            {
                DataGridViewRow row = dgvReturnBooks.Rows[e.RowIndex];

                if (row.IsNewRow || row.Cells[0].Value == null || row.Cells[0].Value == DBNull.Value)
                    return;

                selectedTransactionID = Convert.ToInt32(row.Cells[0].Value);

                txtReturnTransactionID.Text = selectedTransactionID.ToString();

                LoadReturnDetails(selectedTransactionID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading transaction details:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        

        private void dgvReturnBooks_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            StudentCellRenderer.RenderStatusColor(dgvReturnBooks, e, "Status");
        }
    }
}

