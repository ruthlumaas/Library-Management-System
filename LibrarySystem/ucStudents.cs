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
    public partial class ucStudents : UserControl
    {
        public ucStudents()
        {
            InitializeComponent();
        }

        private void ucStudents_Load(object sender, EventArgs e)
        {
            ConnectDB.DisplayData(@"SELECT 
                student_id AS 'ID',
                student_number AS 'Student ID',
                CONCAT(first_name, ' ', last_name) AS 'Full Name',
                email AS 'Email',
                phone AS 'Phone',
                address AS 'Address',
                year_level AS 'Year Level',
                section AS 'Section',
                status AS 'Status'
            FROM register_students
            ORDER BY student_id DESC
            ", dgvStudents);

            LoadStudentCounts();
        }
        private void LoadStudentsToGrid(string query)
        {
            ConnectDB.DisplayData(query, dgvStudents);

            dgvStudents.Columns["QR Code"].Visible = false;

            dgvStudents.Columns["Image"].Visible = false;

            dgvStudents.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void DisplayStudents(
            string yearLevel = "All Grade Levels",
            string section = "All Sections",
            string status = "All Status")
                {
                    string query =
                    @"SELECT 
                student_id AS 'ID',
                student_number AS 'Student Number',
                first_name AS 'First Name',
                middle_name AS 'Middle Name',
                last_name AS 'Last Name',
                email AS 'Email',
                phone AS 'Phone',
                address AS 'Address',
                year_level AS 'Grade Level',
                section AS 'Section',
                qr_code AS 'QR Code',
                status AS 'Status',
                image_path AS 'Image',
                date_registered AS 'Date Registered'
        
            FROM register_students
            WHERE 1=1";

            // GRADE LEVEL FILTER
            if (yearLevel != "All Grade Levels")
            {
                query +=
                    $" AND year_level = '{yearLevel}'";
            }

            // SECTION FILTER
            if (section != "All Sections")
            {
                query +=
                    $" AND section = '{section}'";
            }

            // STATUS FILTER
            if (status != "All Status")
            {
                query +=
                    $" AND status = '{status}'";
            }

            query += " ORDER BY student_id DESC";

            ConnectDB.DisplayData(query, dgvStudents);

            dgvStudents.Columns["QR Code"].Visible = false;
            dgvStudents.Columns["Image"].Visible = false;
        }
        private void LoadSections(string yearLevel)
        {
            cmbSection.Items.Clear();

            cmbSection.Items.Add("All Sections");

            using (MySqlConnection conn =
                ConnectDB.GetConnection())
            {
                string query =
                    @"SELECT DISTINCT section
            FROM register_students
            WHERE year_level = @yearLevel";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@yearLevel",
                    yearLevel);

                MySqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbSection.Items.Add(
                        dr["section"].ToString());
                }

                conn.Close();
            }

            cmbSection.SelectedIndex = 0;
        }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGradeLevel.Text !=
      "All Grade Levels")
            {
                LoadSections(
                    cmbGradeLevel.Text);
            }
            else
            {
                cmbSection.Items.Clear();

                cmbSection.Items.Add(
                    "All Sections");

                cmbSection.SelectedIndex = 0;
            }

            DisplayStudents(
                cmbGradeLevel.Text,
                cmbSection.Text,
                cmbStudentStatus.Text);
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayStudents(
               cmbGradeLevel.Text,
               cmbSection.Text,
               cmbStudentStatus.Text);
        }

        private void cmbStudentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayStudents(
                cmbGradeLevel.Text,
                cmbSection.Text,
                cmbStudentStatus.Text);
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            cmbGradeLevel.SelectedIndex = 0;

            cmbSection.Items.Clear();

            cmbSection.Items.Add(
                "All Sections");

            cmbSection.SelectedIndex = 0;

            cmbStudentStatus.SelectedIndex = 0;

            DisplayStudents();
        }
        private void LoadStudentCounts()
        {
            using (MySqlConnection conn =
                ConnectDB.GetConnection())
            {
                try
                {
                    // TOTAL STUDENTS
                    string totalStudents =
                        "SELECT COUNT(*) FROM register_students";

                    MySqlCommand cmdTotal =
                        new MySqlCommand(
                            totalStudents,
                            conn);

                    lblTotalStudents.Text =
                        cmdTotal.ExecuteScalar().ToString();

                    // ACTIVE STUDENTS
                    string activeStudents =
                        @"SELECT COUNT(*)
                FROM register_students
                WHERE status = 'Active'";

                    MySqlCommand cmdActive =
                        new MySqlCommand(
                            activeStudents,
                            conn);

                    lblTotalActiveStudents.Text =
                        cmdActive.ExecuteScalar().ToString();

                    // NEW STUDENTS THIS MONTH
                    string newStudents =
                        @"SELECT COUNT(*)
                FROM register_students
                WHERE MONTH(date_registered)
                = MONTH(CURDATE())
                
                AND YEAR(date_registered)
                = YEAR(CURDATE())";

                    MySqlCommand cmdNew =
                        new MySqlCommand(
                            newStudents,
                            conn);

                    lblTotalNewStudents.Text =
                        cmdNew.ExecuteScalar().ToString();

                    // INACTIVE STUDENTS
                    string inactiveStudents =
                        @"SELECT COUNT(*)
                FROM register_students
                WHERE status = 'Inactive'";

                    MySqlCommand cmdInactive =
                        new MySqlCommand(
                            inactiveStudents,
                            conn);

                    lblTotalInactiveStudents.Text =
                        cmdInactive.ExecuteScalar().ToString();
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

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
            dashboard.LoadUserControl(new ucAddStudents());
        }

        private void txtSearchStudent_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchStudent.Text.Trim();

            string baseQuery = @"
            SELECT 
                student_id AS 'ID',
                student_number AS 'Student ID',
                CONCAT(first_name, ' ', last_name) AS 'Full Name',
                email AS 'Email',
                phone AS 'Phone',
                address AS 'Address',
                year_level AS 'Year Level',
                section AS 'Section',
                status AS 'Status'
            FROM register_students";

                        string[] columns =
            {
                    "student_number",
                    "first_name",
                    "last_name",
                    "email",
                    "section"
                };
                        ConnectDB.SearchData(
                baseQuery,
                searchText,
                columns,
                dgvStudents
            );
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string studentId =
                dgvStudents.Rows[e.RowIndex].Cells["ID"].Value.ToString();

            frmMainDashboardForm dashboard =
                (frmMainDashboardForm)this.FindForm();

            ucAddStudents form = new ucAddStudents();

            form.LoadStudentForEdit(studentId);

            dashboard.LoadUserControl(form);
        }
    }
}
