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
    public partial class ucAddCategory : UserControl
    {
        public ucAddCategory()
        {
            InitializeComponent();
        }
        private string selectedCategoryId = "";
        private bool isEditMode = false;
        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter category name.");
                return;
            }

            string query = @"INSERT INTO category
                            (category_name, description, status, date_added)
                            VALUES
                            (@name, @desc, @status, @date)";

            Dictionary<string, object> param = new Dictionary<string, object>
            {
                { "@name", txtCategoryName.Text.Trim() },
                { "@desc", txtDescription.Text.Trim() },
                { "@status", "Active" },
                { "@date", DateTime.Now }
            };

            ConnectDB.saveUpdateDeleteData(query, param);

            MessageBox.Show("Category saved successfully!");

            frmMainDashboardForm dashboard =
                (frmMainDashboardForm)this.FindForm();

            dashboard.LoadUserControl(new ucCategories());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard =
            (frmMainDashboardForm)this.FindForm();

            dashboard.LoadUserControl(new ucCategories());
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            lblSummaryCategoryName.Text = txtCategoryName.Text;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            lblSummaryDescription.Text = txtDescription.Text;
        }
       

        private void ucAddCategory_Load(object sender, EventArgs e)
        {
            dtpDateAdded.Value = DateTime.Now;
            txtStatus.Text = "Active";
        }
        private void SetEditMode()
        {
            btnSaveBook.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = true;

            txtStatus.ReadOnly = true;
            dtpDateAdded.Enabled = false;

            txtCategoryName.ReadOnly = false;
            txtDescription.ReadOnly = false;
        }
        public void LoadCategoryForEdit(string id)
        {
            selectedCategoryId = id;
            isEditMode = true;

            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                string query = "SELECT * FROM category WHERE category_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtCategoryName.Text = dr["category_name"].ToString();
                    txtDescription.Text = dr["description"].ToString();

                    txtStatus.Text = dr["status"].ToString();

                    if (dr["date_added"] != DBNull.Value)
                        dtpDateAdded.Value = Convert.ToDateTime(dr["date_added"]);
                }
            }

            SetEditMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCategoryId))
            {
                MessageBox.Show("Select category first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Delete this category?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            string query = "DELETE FROM category WHERE category_id=@id";

            Dictionary<string, object> param = new Dictionary<string, object>
            {
                {"@id", selectedCategoryId}
            };

            ConnectDB.saveUpdateDeleteData(query, param);

            MessageBox.Show("Category deleted!");

            frmMainDashboardForm dashboard =
                (frmMainDashboardForm)this.FindForm();

            dashboard.LoadUserControl(new ucCategories());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCategoryId))
            {
                MessageBox.Show("Select category first.");
                return;
            }

            string query = @"
                UPDATE category
                SET category_name=@name,
                    description=@desc
                WHERE category_id=@id";

            Dictionary<string, object> param = new Dictionary<string, object>
            {
                {"@name", txtCategoryName.Text.Trim()},
                {"@desc", txtDescription.Text.Trim()},
                {"@id", selectedCategoryId}
            };

            ConnectDB.saveUpdateDeleteData(query, param);

            MessageBox.Show("Category updated successfully!");

            frmMainDashboardForm dashboard =
                (frmMainDashboardForm)this.FindForm();

            dashboard.LoadUserControl(new ucCategories());
        }
    }
}
