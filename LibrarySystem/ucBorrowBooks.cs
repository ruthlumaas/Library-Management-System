using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibrarySystem
{
    public partial class ucBorrowBooks : UserControl
    {

        private string studentQRValue = "";
        private string bookQRValue = "";

        public ucBorrowBooks()
        {
            InitializeComponent();
        }

        private void ucBorrowBooks_Load(object sender, EventArgs e)
        {
            dgvRecentBorrow.AutoGenerateColumns = true;

            LoadRecentBorrow();

            SetBorrowDetails();

            // REAL TIME BORROW TIME
            Timer borrowTimer = new Timer();

            borrowTimer.Interval = 1000;

            borrowTimer.Tick += (s, ev) =>
            {
                lblBorrowTime.Text =
                    DateTime.Now.ToString("hh:mm tt");
            };

            borrowTimer.Start();

            // AUTO UPDATE DUE DATE
            dtBorrowDate.ValueChanged += dtBorrowDate_ValueChanged;
        }
        private void LoadRecentBorrow()
        {
            string query =
            @"SELECT bt.transaction_id AS 'Transaction ID',
            CONCAT(rs.first_name, ' ', rs.last_name) AS 'Student Name', b.title AS 'Book Title',
            DATE_FORMAT( bt.borrow_date, '%b %d, %Y') AS 'Borrow Date',
            TIME_FORMAT(bt.borrow_time, '%h:%i %p') AS 'Borrow Time',
            DATE_FORMAT(bt.due_date, '%b %d, %Y') AS 'Due Date', bt.status AS 'Status'
            FROM borrow_transactions bt INNER JOIN register_students rs ON bt.student_id = rs.student_id
            INNER JOIN books b ON bt.book_id = b.book_id ORDER BY bt.transaction_id ASC LIMIT 7";

            ConnectDB.DisplayData(query, dgvRecentBorrow);
        }
        private void SaveBorrowTransaction()
        {
            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                // GET STUDENT ID
                string getStudentQuery =
                    @"SELECT student_id 
              FROM register_students
              WHERE student_number = @studentNumber";

                MySqlCommand cmdStudent =
                    new MySqlCommand(getStudentQuery, conn);

                cmdStudent.Parameters.AddWithValue(
                    "@studentNumber",
                    lblStudentID.Text.Trim());

                object studentResult =
                    cmdStudent.ExecuteScalar();

                if (studentResult == null)
                {
                    MessageBox.Show("Student not found.");
                    return;
                }

                int studentID =
                    Convert.ToInt32(studentResult);

                // GET BOOK ID
                string getBookQuery =
                    @"SELECT book_id
              FROM books
              WHERE qr_code = @qrCode";

                MySqlCommand cmdBook =
                    new MySqlCommand(getBookQuery, conn);

                cmdBook.Parameters.AddWithValue(
                    "@qrCode",
                    bookQRValue.Trim());

                object bookResult =
                    cmdBook.ExecuteScalar();

                if (bookResult == null)
                {
                    MessageBox.Show("Book not found.");
                    return;
                }

                int bookID =
                    Convert.ToInt32(bookResult);

                // BORROW DATE
                DateTime borrowDate =
                    dtBorrowDate.Value.Date;

                // DUE DATE = +3 DAYS
                DateTime dueDate =
                    borrowDate.AddDays(3);

                // INSERT TRANSACTION
                string insertQuery =
                    @"INSERT INTO borrow_transactions
            (
                student_id,
                book_id,
                borrow_date,
                borrow_time,
                due_date,
                status
            )
            VALUES
            (
                @studentID,
                @bookID,
                @borrowDate,
                @borrowTime,
                @dueDate,
                @status
            )";

                MySqlCommand cmdInsert =
                    new MySqlCommand(insertQuery, conn);

                cmdInsert.Parameters.AddWithValue(
                    "@studentID",
                    studentID);

                cmdInsert.Parameters.AddWithValue(
                    "@bookID",
                    bookID);

                cmdInsert.Parameters.AddWithValue(
                    "@borrowDate",
                    borrowDate);

                cmdInsert.Parameters.AddWithValue(
                    "@borrowTime",
                    DateTime.Now.ToString("HH:mm:ss"));

                cmdInsert.Parameters.AddWithValue(
                    "@dueDate",
                    dueDate);

                cmdInsert.Parameters.AddWithValue(
                    "@status",
                    "BORROWED");

                cmdInsert.ExecuteNonQuery();

                // UPDATE AVAILABLE COPIES
                string updateBookQuery =
                    @"UPDATE books
              SET available_copies =
              available_copies - 1
              WHERE book_id = @bookID";

                MySqlCommand cmdUpdate =
                    new MySqlCommand(updateBookQuery, conn);

                cmdUpdate.Parameters.AddWithValue(
                    "@bookID",
                    bookID);

                cmdUpdate.ExecuteNonQuery();

                // UPDATE UI
                dtDueDate.Value = dueDate;
            }
        }

        private void SetBorrowDetails()
        {
            DateTime today = DateTime.Today;

            dtBorrowDate.Value = today;

            dtDueDate.Value =
                today.AddDays(3);

            lblBorrowTime.Text =
                DateTime.Now.ToString("hh:mm tt");
        }
        private void btnScanStudentQR_Click(object sender, EventArgs e)
        {
            studentQRValue = StudentCellRenderer.ScanQRCode(picStudentQR);

            if (!string.IsNullOrEmpty(studentQRValue))
            {
                LoadStudentInfo(studentQRValue);
            }
        }

        private void btnScanStudent_Click(object sender, EventArgs e)
        {
            btnScanStudentQR_Click(sender, e);
        }
        private void ClearStudentInfo()
        {
            lblStudentName.Text = "-";
            lblStudentID.Text = "-";
            lblCourseYear.Text = "-";
            lblSection.Text = "-";
            lblStudentStatus.Text = "-";
            picStudentProfile.Image = null;
        }

        private void btnScanBookQR_Click(object sender, EventArgs e)
        {
            bookQRValue = StudentCellRenderer.ScanQRCode(picBookQR);

            if (!string.IsNullOrEmpty(bookQRValue))
            {
                LoadBookInfo(bookQRValue);
            }
        }

        private void btnScanBook_Click(object sender, EventArgs e)
        {
            btnScanBookQR_Click(sender, e);
        }
        private void ClearBookInfo()
        {
            lblBookTitle.Text = "-";
            lblAuthor.Text = "-";
            lblCategory.Text = "-";
            lblISBN.Text = "-";
            lblCopies.Text = "-";
            lblBookAvailability.Text = "-";
            picScannedBookQR.Image = null;
        }

        private void btnConfirmBorrow_Click(object sender, EventArgs e)
        {
            if (lblStudentID.Text == "-" || lblBookTitle.Text == "-")
            {
                MessageBox.Show("Please scan student and book first.");
                return;
            }

            SaveBorrowTransaction();

            LoadRecentBorrow(); // FORCE REFRESH

            MessageBox.Show("Borrow transaction saved.");

            ClearStudentInfo();
            ClearBookInfo();

            picStudentQR.Image = null;
            picBookQR.Image = null;

            studentQRValue = "";
            bookQRValue = "";

            SetBorrowDetails();
        }

        private string UploadAndReadQR(PictureBox pictureBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(ofd.FileName);

                pictureBox.Image = bitmap;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                BarcodeReader reader = new BarcodeReader();
                var result = reader.Decode(bitmap);

                if (result != null)
                {
                    return result.Text;
                }

                MessageBox.Show("No QR code detected in the image.");
                return "";
            }

            return "";
        }

        private void LoadStudentInfo(string studentNumber)
        {
            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                string query = @"SELECT * FROM register_students 
                         WHERE TRIM(student_number) = @studentNumber";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentNumber", studentNumber.Trim());

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblStudentName.Text =
                        dr["first_name"].ToString() + " " +
                        dr["last_name"].ToString();

                    lblStudentID.Text = dr["student_number"].ToString();
                    lblCourseYear.Text = dr["year_level"].ToString();
                    lblSection.Text = dr["section"].ToString();
                    lblStudentStatus.Text = dr["status"].ToString();

                    if (dr["image_path"] != DBNull.Value)
                    {
                        string imagePath = dr["image_path"].ToString();

                        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                        {
                            picStudentProfile.Image = Image.FromFile(imagePath);
                            picStudentProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            picStudentProfile.Image = null;
                        }
                    }

                    if (lblStudentStatus.Text == "Active")
                    {
                        lblStudentStatus.ForeColor = Color.Green;
                        pnlStudentStatus.FillColor = Color.FromArgb(220, 252, 231);
                    }
                    else
                    {
                        lblStudentStatus.ForeColor = Color.Red;
                        pnlStudentStatus.FillColor = Color.FromArgb(255, 230, 230);

                        MessageBox.Show("Student account is inactive.");
                        ClearStudentInfo();
                    }
                }
                else
                {
                    MessageBox.Show("Student not found.");
                    ClearStudentInfo();
                }
            }
        }

        private void LoadBookInfo(string qrCode)
        {
            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                string query = @"SELECT 
                            b.*, 
                            IFNULL(c.category_name, 'No Category') AS category_name
                         FROM books b
                         LEFT JOIN category c 
                         ON b.category_id = c.category_id
                         WHERE TRIM(b.qr_code) = @qrCode";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@qrCode", qrCode.Trim());

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblBookTitle.Text = dr["title"].ToString();
                    lblAuthor.Text = dr["author"].ToString();
                    lblCategory.Text = dr["category_name"].ToString();
                    lblISBN.Text = dr["isbn"].ToString();

                    if (dr["cover_image"] != DBNull.Value)
                    {
                        string coverPath = dr["cover_image"].ToString();

                        if (!string.IsNullOrEmpty(coverPath) && File.Exists(coverPath))
                        {
                            picScannedBookQR.Image = Image.FromFile(coverPath);
                            picScannedBookQR.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            picScannedBookQR.Image = null;
                        }
                    }

                    int copies = Convert.ToInt32(dr["available_copies"]);
                    lblCopies.Text = copies.ToString();

                    if (copies > 0)
                    {
                        lblBookAvailability.Text = "AVAILABLE";
                        lblBookAvailability.ForeColor = Color.Green;
                        pnlBookAvailability.FillColor = Color.FromArgb(220, 252, 231);
                    }
                    else
                    {
                        lblBookAvailability.Text = "OUT OF STOCK";
                        lblBookAvailability.ForeColor = Color.Red;
                        pnlBookAvailability.FillColor = Color.FromArgb(255, 230, 230);

                        MessageBox.Show("Book is out of stock.");
                        ClearBookInfo();
                    }
                }
                else
                {
                    MessageBox.Show("Book not found.");
                    ClearBookInfo();
                }
            }
        }

        private void btnUploadStudentQR_Click(object sender, EventArgs e)
        {
            studentQRValue = UploadAndReadQR(picStudentQR);

            MessageBox.Show("Scanned QR value: " + studentQRValue);

            if (!string.IsNullOrEmpty(studentQRValue))
            {
                LoadStudentInfo(studentQRValue.Trim());
            }
        }

        private void btnUploadBookQR_Click(object sender, EventArgs e)
        {
            bookQRValue = UploadAndReadQR(picBookQR);

            if (!string.IsNullOrEmpty(bookQRValue))
            {
                LoadBookInfo(bookQRValue);
            }
        }

        private void dgvRecentBorrow_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            StudentCellRenderer.RenderStatusColor(dgvRecentBorrow,e, "colStatus");
        }

        private void dtBorrowDate_ValueChanged(object sender, EventArgs e)
        {
            dtDueDate.Value =
            dtBorrowDate.Value.Date.AddDays(3);
        }
    }
}