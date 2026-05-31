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
    public partial class ucCategories : UserControl
    {
        public ucCategories()
        {
            InitializeComponent();
        }

        private void pnlCategoryTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadCategories()
        {
            ConnectDB.DisplayData(@"
            SELECT 
                category_id AS 'ID',
                category_name AS 'Category Name',
                description AS 'Description',
                status AS 'Status',
                DATE_FORMAT(date_added, '%M %d, %Y') AS 'Date Added'
            FROM category
            ORDER BY category_id DESC
            ", dgvCategory);
        }

        private void ucCategories_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadStudentCounts();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucAddCategory());
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCategory.Rows[e.RowIndex];

            string id = row.Cells["ID"].Value.ToString();

            frmMainDashboardForm dashboard =
                (frmMainDashboardForm)this.FindForm();

            ucAddCategory uc = new ucAddCategory();

            uc.LoadCategoryForEdit(id);

            dashboard.LoadUserControl(uc);
        }
        private void LoadStudentCounts()
        {
            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    // TOTAL STUDENTS
                    string totalQuery =
                        "SELECT COUNT(*) FROM register_students";

                    MySqlCommand cmdTotal =
                        new MySqlCommand(totalQuery, conn);

                    lblTotalCategory.Text =
                        cmdTotal.ExecuteScalar().ToString();

                    // ACTIVE STUDENTS
                    string activeQuery =
                        "SELECT COUNT(*) FROM register_students WHERE status = 'Active'";

                    MySqlCommand cmdActive =
                        new MySqlCommand(activeQuery, conn);

                    lblTotalActiveStudents.Text =
                        cmdActive.ExecuteScalar().ToString();

                    // NEW STUDENTS THIS MONTH
                    string newQuery = @"
                SELECT COUNT(*) 
                FROM register_students
                WHERE MONTH(date_registered) = MONTH(CURDATE())
                AND YEAR(date_registered) = YEAR(CURDATE())";

                    MySqlCommand cmdNew =
                        new MySqlCommand(newQuery, conn);

                    lblTotalNewStudents.Text =
                        cmdNew.ExecuteScalar().ToString();

                    // INACTIVE STUDENTS
                    string inactiveQuery =
                        "SELECT COUNT(*) FROM register_students WHERE status = 'Inactive'";

                    MySqlCommand cmdInactive =
                        new MySqlCommand(inactiveQuery, conn);

                    lblTotalInactiveStudents.Text =
                        cmdInactive.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error loading student counts:\n" + ex.Message
                    );
                }
            }
        }

        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchCategory.Text.Trim();

            string baseQuery = @"
            SELECT 
                category_id AS 'ID',
                category_name AS 'Category Name',
                description AS 'Description',
   
                status AS 'Status',
                date_added AS 'Date Added'
            FROM category";

            string[] columns =
            {
                    "category_name",
                    "description",
                    "status"
            };
             ConnectDB.SearchData(
                baseQuery,
                searchText,
                columns,
                dgvCategory
            );
        }
    }
}
