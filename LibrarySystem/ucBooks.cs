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
    public partial class ucBooks : UserControl
    {
        private string selectedBookId = "";
        private int originalTotalCopies = 0;
        public ucBooks()
        {
            InitializeComponent();
        }

        private void ucBooks_Load(object sender, EventArgs e)
        {
            //DisplayBooks();
            LoadBookCounts();
            LoadBookCategories();

            cmbBookStatus.Items.Clear();

            cmbBookStatus.Items.Add("All Status");
            cmbBookStatus.Items.Add("Available");
            cmbBookStatus.Items.Add("Not Available");

            cmbBookStatus.SelectedIndex = 0;

            LoadBooks();
        }
        private void LoadBookCounts()
        {
            using (MySqlConnection conn =
                ConnectDB.GetConnection())
            {
                try
                {
                    // TOTAL BOOKS
                    string totalBooks =
                        "SELECT COUNT(*) FROM books";

                    MySqlCommand cmdBooks =
                        new MySqlCommand(totalBooks, conn);

                    lblTotalBooks.Text =
                        cmdBooks.ExecuteScalar().ToString();

                    // AVAILABLE COPIES
                    string availableCopies =
                        @"SELECT SUM(available_copies)
                FROM books";

                    MySqlCommand cmdAvailable =
                        new MySqlCommand(availableCopies, conn);

                    object availableResult =
                        cmdAvailable.ExecuteScalar();


                    // TOTAL CATEGORIES
                    string totalCategories =
                        "SELECT COUNT(*) FROM category";

                    MySqlCommand cmdCategories =
                        new MySqlCommand(totalCategories, conn);

                    lblCategories.Text =
                        cmdCategories.ExecuteScalar().ToString();

                    // OUT OF STOCK
                    string outOfStock =
                        @"SELECT COUNT(*)
                FROM books
                WHERE available_copies <= 0";

                    MySqlCommand cmdOutOfStock =
                        new MySqlCommand(outOfStock, conn);

                    lblOutOfStock.Text =
                        cmdOutOfStock.ExecuteScalar().ToString();
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
        private void DisplayBooks()
        {
            string query =
            @"SELECT 
        b.book_id AS 'ID',
        b.isbn AS 'ISBN',
        b.accession_no AS 'Accession No',
        b.title AS 'Title',
        b.author AS 'Author',
        c.category_name AS 'Category',
        b.language AS 'Language',
        b.publisher AS 'Publisher',
        b.publication_year AS 'Year',
        b.description AS 'Description',
        b.total_copies AS 'Total Copies',
        b.available_copies AS 'Available Copies',
        b.qr_code AS 'QR Code',
        b.status AS 'Status',
        b.date_added AS 'Date Added',
        b.cover_image AS 'Cover Image'
        
    FROM books b
    
    LEFT JOIN category c
    ON b.category_id = c.category_id
    WHERE 1=1";

            ConnectDB.DisplayData(query, dgvBooks);
        }
        private void btnGoAddBook_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucAddBook());
        }
        private void LoadBooks(string category = "All Categories", string status = "All Status")
        {
            string query = @"SELECT 
                    b.book_id AS 'ID',
                    b.isbn AS 'ISBN',
                    b.accession_no AS 'Accession No',
                    b.title AS 'Title',
                    b.author AS 'Author',
                    IFNULL(c.category_name, 'No Category') AS 'Category',
                    b.language AS 'Language',
                    b.publisher AS 'Publisher',
                    b.publication_year AS 'Year',
                    b.description AS 'Description',
                    b.total_copies AS 'Total Copies',
                    b.available_copies AS 'Available Copies',
                    b.status AS 'Status',
                    b.date_added AS 'Date Added'
                FROM books b
                LEFT JOIN category c
                ON b.category_id = c.category_id
                WHERE 1=1";

                        if (category != "All Categories")
                        {
                            query += $" AND c.category_name = '{category}'";
                        }

                        if (status != "All Status")
                        {
                            if (status == "Available")
                            {
                                query += " AND b.available_copies > 0";
                            }
                            else if (status == "Not Available")
                            {
                                query += " AND b.available_copies <= 0";
                            }
                        }

                        query += " ORDER BY b.book_id DESC";

                        ConnectDB.DisplayData(query, dgvBooks);
        }

        private void LoadBookCategories()
        {
            cmbBookCategory.Items.Clear();

            cmbBookCategory.Items.Add("All Categories");

            string query =
                "SELECT category_name FROM category";

            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                MySqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbBookCategory.Items.Add( dr["category_name"].ToString());
                }

                conn.Close();
            }

            cmbBookCategory.SelectedIndex = 0;
        }

        private void cmbBookCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBooks(cmbBookCategory.Text,cmbBookStatus.Text);
        }

        private void cmbBookStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBooks(cmbBookCategory.Text, cmbBookStatus.Text);
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            cmbBookCategory.SelectedIndex = 0;

            cmbBookStatus.SelectedIndex = 0;

            LoadBooks();
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchBooks_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBooks.Text.Trim();

            string baseQuery = @"
                SELECT 
                    b.book_id,
                    b.isbn,
                    b.accession_no,
                    b.title,
                    b.author,
                    IFNULL(c.category_name, 'No Category') AS category_name,
                    b.language,
                    b.publisher,
                    b.publication_year,
                    b.description,
                    b.total_copies,
                    b.available_copies,
                    b.status,
                    b.date_added
                FROM books b
                LEFT JOIN category c 
                    ON b.category_id = c.category_id";

            string[] columns =
                    {
                "b.title",
                "b.author",
                
            };

            ConnectDB.SearchData(
                baseQuery,
                searchText,
                columns,
                dgvBooks
            );
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

            string bookId = row.Cells["ID"].Value.ToString();

            frmMainDashboardForm dashboard =
                (frmMainDashboardForm)this.FindForm();

            ucAddBook addBook = new ucAddBook();

            addBook.LoadBookForEdit(bookId); // IMPORTANT

            dashboard.LoadUserControl(addBook);
        }

        private void pnlBooksTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
