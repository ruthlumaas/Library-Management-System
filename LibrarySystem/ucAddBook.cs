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
using System.IO;
using System.Text.RegularExpressions;
using ZXing;

namespace LibrarySystem
{
    public partial class ucAddBook : UserControl
    {
        public ucAddBook()
        {
            InitializeComponent();
        }
        private List<string> authorList = new List<string>();
        private string accessionNumber = "";
        private string bookCoverPath = "";
        private string selectedBookId = "";
        private bool isEditMode = false;
        private void btnGenerateAccession_Click(object sender, EventArgs e)
        {
            accessionNumber = "ACC-" + DateTime.Now.ToString("yyyy") + "-" +
            ConnectDB.GetMaxID("books", "book_id", 1).ToString("00000");

            txtAccession.Text = accessionNumber;
        }

        private void ucAddBook_Load(object sender, EventArgs e)
        {
            LoadCategories();
            txtPublicationYear.KeyPress += new KeyPressEventHandler(txtPublicationYear_KeyPress);

            txtTotalCopies.KeyPress += new KeyPressEventHandler(txtTotalCopies_KeyPress);

            txtAvailableCopies.KeyPress += new KeyPressEventHandler(txtAvailableCopies_KeyPress);
            txtISBN.MaxLength = 13;
            txtISBN.KeyPress += new KeyPressEventHandler(txtISBN_KeyPress);
        }
        private void LoadCategories()
        {
            string query = "SELECT category_id, category_name FROM category";

            ConnectDB.FillComboBox(query, cmbCategory, "category_name", "category_id");
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAuthor.Text))
                {
                    MessageBox.Show("Please enter author name.");
                    return;
                }

                authorList.Add(txtAuthor.Text.Trim());
                lblAuthorName.Text = string.Join(", ", authorList);
                UpdateBookSummary();
                txtAuthor.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding author:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                if (authorList == null || authorList.Count == 0)
                {
                    MessageBox.Show("No author to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                authorList.RemoveAt(authorList.Count - 1);
                lblAuthorName.Text = string.Join(", ", authorList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing author:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTotalCopies_TextChanged(object sender, EventArgs e)
        {
            txtAvailableCopies.Text = txtTotalCopies.Text;
            UpdateBookSummary();
        }

        private void pnlBookInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtISBN.Text))
                {
                    MessageBox.Show("Please enter ISBN.");
                    txtISBN.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
                {
                    MessageBox.Show("Please enter book title.");
                    txtBookTitle.Focus();
                    return;
                }

                if (authorList == null || authorList.Count == 0)
                {
                    MessageBox.Show("Please add at least one author.");
                    txtAuthor.Focus();
                    return;
                }

                if (cmbCategory.SelectedIndex == -1 || cmbCategory.SelectedValue == null)
                {
                    MessageBox.Show("Please select category.");
                    cmbCategory.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbLanguage.Text))
                {
                    MessageBox.Show("Please select language.");
                    cmbLanguage.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPublisher.Text))
                {
                    MessageBox.Show("Please enter publisher.");
                    txtPublisher.Focus();
                    return;
                }

                int year;
                if (!int.TryParse(txtPublicationYear.Text, out year))
                {
                    MessageBox.Show("Publication year must be numbers only.");
                    txtPublicationYear.Focus();
                    return;
                }

                int total;
                if (!int.TryParse(txtTotalCopies.Text, out total) || total <= 0)
                {
                    MessageBox.Show("Total copies must be a valid number greater than 0.");
                    txtTotalCopies.Focus();
                    return;
                }

                int avail;
                if (!int.TryParse(txtAvailableCopies.Text, out avail) || avail < 0)
                {
                    MessageBox.Show("Available copies must be a valid number.");
                    txtAvailableCopies.Focus();
                    return;
                }

                if (avail > total)
                {
                    MessageBox.Show("Available copies cannot be greater than total copies.");
                    txtAvailableCopies.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtAccession.Text))
                {
                    MessageBox.Show("Please generate accession number first.");
                    txtAccession.Focus();
                    return;
                }

                string authors = string.Join(", ", authorList);

                Bitmap qrImage = QRCodeHelper.GenerateQRCode(txtAccession.Text);
                string qrPath = QRCodeHelper.SaveQRCode(qrImage, txtAccession.Text);

                string query = @"INSERT INTO books
                            (isbn, accession_no, title, author, category_id, language, publisher, publication_year, description,
                            total_copies, available_copies, qr_code, status, cover_image)
                            VALUES
                            (@isbn, @acc, @title, @author, @cat, @lang, @pub, @year, @desc,
                            @total, @avail, @qr, 'Active', @cover)";

                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "@isbn", txtISBN.Text.Trim() },
                    { "@acc", txtAccession.Text.Trim() },
                    { "@title", txtBookTitle.Text.Trim() },
                    { "@author", authors },
                    { "@cat", cmbCategory.SelectedValue },
                    { "@lang", cmbLanguage.Text.Trim() },
                    { "@pub", txtPublisher.Text.Trim() },
                    { "@year", year },
                    { "@desc", txtDescription.Text.Trim() },
                    { "@total", total },
                    { "@avail", avail },
                    { "@qr", txtAccession.Text.Trim() },
                    { "@cover", bookCoverPath }
                };

                ConnectDB.saveUpdateDeleteData(query, param);

                MessageBox.Show("Book saved successfully!");

                frmMainDashboardForm dashboard =
                    (frmMainDashboardForm)this.FindForm();

                dashboard.LoadUserControl(new ucBooks());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving book:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateBookSummary()
        {
            lblSummaryTitleValue.Text = txtBookTitle.Text;

            lblSummaryAuthorsValue.Text = lblAuthorName.Text;

            lblSummaryCategoryValue.Text = cmbCategory.Text;

            lblSummaryISBNValue.Text = txtISBN.Text;

            lblSummaryAccNumValue.Text = txtAccession.Text;

            lblSummaryPublisherValue.Text = txtPublisher.Text;

            lblSummaryPublishYearValue.Text = txtPublicationYear.Text;

            lblSummaryTotalCopiesValue.Text = txtTotalCopies.Text;

            lblSummaryStatus.Text = "Active";
        }
        private void lblClickToBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.Combine(Application.StartupPath, @"..\..\BookCovers");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = txtAccession.Text.Trim() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(ofd.FileName);
                bookCoverPath = Path.Combine(folderPath, fileName);

                File.Copy(ofd.FileName, bookCoverPath, true);

                Image img = Image.FromFile(bookCoverPath);

                picBookCover.Image = img;
                picBookCover.SizeMode = PictureBoxSizeMode.StretchImage;

                picSummaryBookCover.Image = img;
                picSummaryBookCover.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this book entry?\nAll unsaved data will be lost.", "Confirm Cancel",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ClearBookForm();
            }
        }
        private void ClearBookForm()
        {
            txtISBN.Clear();
            txtBookTitle.Clear();
            txtAuthor.Clear();
            lblAuthorName.Text = "";

            cmbCategory.SelectedIndex = -1;
            cmbLanguage.SelectedIndex = -1;

            txtPublisher.Clear();
            txtPublicationYear.Clear();
            txtDescription.Clear();

            txtTotalCopies.Clear();
            txtAvailableCopies.Clear();

            txtAccession.Clear();

            picQRCode.Image = null;
            picBookCover.Image = null;
            picSummaryBookCover.Image = null;

            // reset summary
            lblSummaryTitleValue.Text = "-";
            lblSummaryAuthorsValue.Text = "-";
            lblSummaryCategoryValue.Text = "-";
            lblSummaryISBNValue.Text = "-";
            lblSummaryAccNumValue.Text = "-";
            lblSummaryPublisherValue.Text = "-";
            lblSummaryPublishYearValue.Text = "-";
            lblSummaryTotalCopiesValue.Text = "-";
            lblSummaryStatus.Text = "-";
        }

        private void txtISBN_TextChanged(object sender, EventArgs e)
        {
            UpdateBookSummary();
        }

        private void txtBookTitle_TextChanged(object sender, EventArgs e)
        {
            UpdateBookSummary();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBookSummary();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBookSummary();
        }

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {
            UpdateBookSummary();
        }

        private void txtPublicationYear_TextChanged(object sender, EventArgs e)
        {
            UpdateBookSummary();
        }

        private void txtAvailableCopies_TextChanged(object sender, EventArgs e)
        {
            UpdateBookSummary();
        }

        private void btnGenerateQRCode_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Please enter ISBN.");
                txtISBN.Focus();
                return;
            }

            if (!Regex.IsMatch(txtISBN.Text.Trim(), @"^\d{13}$"))
            {
                MessageBox.Show("ISBN must contain 13 digits only.\nExample: 9780134685991");
                txtISBN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBookTitle.Text))
            {
                MessageBox.Show("Please enter book title first.");
                txtBookTitle.Focus();
                return;
            }

            if (authorList == null || authorList.Count == 0)
            {
                MessageBox.Show("Please add at least one author.");
                txtAuthor.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == -1 || cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select category.");
                cmbCategory.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbLanguage.Text))
            {
                MessageBox.Show("Please select language.");
                cmbLanguage.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPublisher.Text))
            {
                MessageBox.Show("Please enter publisher.");
                txtPublisher.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPublicationYear.Text))
            {
                MessageBox.Show("Please enter publication year.");
                txtPublicationYear.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter description.");
                txtDescription.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTotalCopies.Text))
            {
                MessageBox.Show("Please enter total copies.");
                txtTotalCopies.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAvailableCopies.Text))
            {
                MessageBox.Show("Please enter available copies.");
                txtAvailableCopies.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAccession.Text))
            {
                MessageBox.Show("Please generate accession number first.");
                txtAccession.Focus();
                return;
            }

            // VALIDATE NUMBERS

            int year;
            if (!int.TryParse(txtPublicationYear.Text, out year))
            {
                MessageBox.Show("Publication year must be numbers only.");
                txtPublicationYear.Focus();
                return;
            }

            int total;
            if (!int.TryParse(txtTotalCopies.Text, out total))
            {
                MessageBox.Show("Total copies must be numbers only.");
                txtTotalCopies.Focus();
                return;
            }

            int avail;
            if (!int.TryParse(txtAvailableCopies.Text, out avail))
            {
                MessageBox.Show("Available copies must be numbers only.");
                txtAvailableCopies.Focus();
                return;
            }

            if (avail > total)
            {
                MessageBox.Show("Available copies cannot be greater than total copies.");
                txtAvailableCopies.Focus();
                return;
            }

            // GENERATE QR

            Bitmap qrImage =
                QRCodeHelper.GenerateQRCode(txtAccession.Text);

            // DISPLAY
            picQRCode.Image = qrImage;

            // SAVE QR IMAGE
            string savedPath =
                QRCodeHelper.SaveQRCode(qrImage, txtAccession.Text);

            MessageBox.Show("QR Code generated successfully!\n\nSaved at:\n" + savedPath);
        }

        private void lblSummaryISBNValue_Click(object sender, EventArgs e)
        {

        }

        private void txtAccession_TextChanged(object sender, EventArgs e)
        {
            UpdateBookSummary();
        }

        private void txtPublicationYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTotalCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAvailableCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void LoadBookForEdit(string bookId)
        {
            selectedBookId = bookId;
            isEditMode = true;

            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                string query = @"SELECT * FROM books WHERE book_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", bookId);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtISBN.Text = dr["isbn"].ToString();
                    txtAccession.Text = dr["accession_no"].ToString();
                    txtBookTitle.Text = dr["title"].ToString();
                    txtPublisher.Text = dr["publisher"].ToString();
                    txtPublicationYear.Text = dr["publication_year"].ToString();
                    txtDescription.Text = dr["description"].ToString();

                    txtTotalCopies.Text = dr["total_copies"].ToString();
                    txtAvailableCopies.Text = dr["available_copies"].ToString();

                    // numTotalCopies.Value = Convert.ToDecimal(dr["total_copies"]);

                    lblAuthorName.Text = dr["author"].ToString();
                }
            }
            SetEditMode();
            LockFields(); // READ ONLY MODE
        }
        private void LockFields()
        {
            txtISBN.ReadOnly = true;
            txtAccession.ReadOnly = true;
            txtBookTitle.ReadOnly = true;
            txtAvailableCopies.ReadOnly = true;
            txtPublisher.ReadOnly = true;
            txtPublicationYear.ReadOnly = true;
            txtDescription.ReadOnly = true;

            cmbCategory.Enabled = false;
            cmbLanguage.Enabled = false;

            // ONLY ALLOW EDIT:
            //numTotalCopies.Enabled = true;
        }
        private void SetEditMode()
        {
            isEditMode = true;

            btnSaveBook.Visible = false;
            btnCancel.Visible = false;

            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedBookId))
                {
                    MessageBox.Show("Please select a book first.");
                    return;
                }

                if (!int.TryParse(txtTotalCopies.Text, out int newTotal))
                {
                    MessageBox.Show("Invalid total copies value.");
                    return;
                }

                using (MySqlConnection conn = ConnectDB.GetConnection())
                {
                    // 1. GET BORROWED COUNT
                    string borrowQuery = @"
                SELECT COUNT(*) 
                FROM borrow_transactions 
                WHERE book_id = @id AND status = 'BORROWED'";

                    MySqlCommand cmdBorrow = new MySqlCommand(borrowQuery, conn);
                    cmdBorrow.Parameters.AddWithValue("@id", selectedBookId);

                    int borrowed = Convert.ToInt32(cmdBorrow.ExecuteScalar());

                    // 2. COMPUTE AVAILABLE
                    int newAvailable = newTotal - borrowed;

                    if (newAvailable < 0)
                    {
                        MessageBox.Show(
                            "Cannot reduce total copies below borrowed books!",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    // 3. UPDATE DATABASE
                    string updateQuery = @"
                UPDATE books 
                SET total_copies = @total,
                    available_copies = @avail
                WHERE book_id = @id";

                    Dictionary<string, object> param = new Dictionary<string, object>
            {
                {"@total", newTotal},
                {"@avail", newAvailable},
                {"@id", selectedBookId}
            };

                    ConnectDB.saveUpdateDeleteData(updateQuery, param);
                }

                MessageBox.Show("Book updated successfully!");

                frmMainDashboardForm dashboard =
                    (frmMainDashboardForm)this.FindForm();

                dashboard.LoadUserControl(new ucBooks());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(selectedBookId))
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this book?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            try
            {
                string query = @"DELETE FROM books WHERE book_id = @id";

                Dictionary<string, object> param = new Dictionary<string, object>
        {
            { "@id", selectedBookId }
        };

                ConnectDB.saveUpdateDeleteData(query, param);

                MessageBox.Show("Book deleted successfully!");

                // refresh grid
                frmMainDashboardForm dashboard =
                    (frmMainDashboardForm)this.FindForm();

                dashboard.LoadUserControl(new ucBooks());


                // clear selection
                selectedBookId = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message);
            }
        }
    }
}
