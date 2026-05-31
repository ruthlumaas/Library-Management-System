using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class ucAddStudents : UserControl
    {
        private string studentImagePath = "";
        private string studentQR = "";
        private string selectedStudentId = "";
        private bool isEditMode = false;
        public ucAddStudents()
        {
            InitializeComponent();
        }

        private void btnGenerateQR_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentForm())
            {
                return;
            }

            Bitmap qr = QRCodeHelper.GenerateQRCode(txtStudentID.Text);

            picQRCode.Image = qr;

            string path = QRCodeHelper.SaveStudentQRCode(qr, txtStudentID.Text);

            MessageBox.Show("QR Code generated successfully!");
        }

        private void btnGenerateStudentID_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.ToString("yyyy");

            int nextID = ConnectDB.GetMaxID("register_students", "student_id", 1);

            string studentNumber = "STU-" + year + "-" + nextID.ToString("000000");
            txtStudentID.Text = studentNumber;
        }

        private void lblClickToBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.Combine(Application.StartupPath, @"..\..\StudentImages");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = txtStudentID.Text.Trim() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(ofd.FileName);
                studentImagePath = Path.Combine(folderPath, fileName);

                File.Copy(ofd.FileName, studentImagePath, true);

                Image img = Image.FromFile(studentImagePath);

                picUploadIcon.Image = img;
                picUploadIcon.SizeMode = PictureBoxSizeMode.StretchImage;

                picSummaryProfile.Image = img;
                picSummaryProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void UpdateStudentSummary()
        {
            lblSummaryStudentID.Text = txtStudentID.Text;

            lblSummaryFullName.Text =
                txtFirstName.Text + " " +
                txtMiddleName.Text + " " +
                txtLastName.Text;
            lblSummaryEmail.Text = txtEmail.Text;
            lblSummaryPhone.Text = cmbPhoneNumber.Text + txtPhoneNumber.Text;
            lblSummaryYearSection.Text =
                cmbYearLevel.Text + " - " + cmbSection.Text;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            UpdateStudentSummary();
        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {
            UpdateStudentSummary();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            UpdateStudentSummary();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            UpdateStudentSummary();
        }

        private void cmbYearLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSection.Items.Clear();

            string yearLevel = cmbYearLevel.Text.Trim().ToLower();

            if (yearLevel == "7th grade")
            {
                cmbSection.Items.AddRange(new string[] { "Pearl", "Diamond", "Emerald", "Bronze", "Silver", "Gold", "Platinum", "Copper" });
            }
            else if (yearLevel == "8th grade")
            {
                cmbSection.Items.AddRange(new string[] { "Purple", "Orange", "Red", "Peach", "Yellow", "Blue", "Green" });
            }
            else if (yearLevel == "9th grade")
            {
                cmbSection.Items.AddRange(new string[] { "Mabini", "Aquino", "Bonifacio", "Del Pilar", "Balagtas", "Luna", "Rizal" });
            }
            else if (yearLevel == "10th grade")
            {
                cmbSection.Items.AddRange(new string[] { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" });
            }
            else if (yearLevel == "11th grade" || yearLevel == "12th grade")
            {
                cmbSection.Items.AddRange(new string[] { "ABM", "ICT", "STEM", "HUMSS", "HE", "IA" });
            }

            cmbSection.SelectedIndex = -1;
            UpdateStudentSummary();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStudentSummary();
        }

        private void ClearStudentForm()
        {
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();

            txtStudentID.Clear();
            cmbYearLevel.SelectedIndex = -1;
            cmbSection.SelectedIndex = -1;

            picUploadIcon.Image = null;
            picQRCode.Image = null;

            lblSummaryStudentID.Text = "-";
            lblSummaryFullName.Text = "-";
            lblSummaryYearSection.Text = "-";

            picSummaryProfile.Image = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this student entry?", "Confirm Cancel",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ClearStudentForm();
            }
        }

        private void tblMainAddBook_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucAddStudents_Load(object sender, EventArgs e)
        {
            cmbPhoneNumber.Items.Clear();
            cmbPhoneNumber.Items.Add("+639");
            cmbPhoneNumber.SelectedIndex = 0;
            cmbPhoneNumber.Enabled = false;

            txtPhoneNumber.MaxLength = 9;

            txtPhoneNumber.KeyPress += new KeyPressEventHandler(txtPhoneNumber_KeyPress);
            cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSection.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool ValidateStudentForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter first name.");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter last name.");
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter email address.");
                txtEmail.Focus();
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Please enter phone number.");
                txtPhoneNumber.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtPhoneNumber.Text.Trim(), @"^\d{9}$"))
            {
                MessageBox.Show("Phone number must contain 9 digits only.\nExample: 309878122");
                txtPhoneNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show("Please generate student ID first.");
                txtStudentID.Focus();
                return false;
            }

            if (cmbYearLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select year level.");
                cmbYearLevel.Focus();
                return false;
            }

            if (cmbSection.SelectedIndex == -1)
            {
                MessageBox.Show("Please select section.");
                cmbSection.Focus();
                return false;
            }

            return true;
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateStudentForm())
                {
                    return;
                }

                if (picQRCode.Image == null)
                {
                    MessageBox.Show("Please generate student QR code first.");
                    return;
                }

                string phone = cmbPhoneNumber.Text + txtPhoneNumber.Text.Trim();

                string query = @"INSERT INTO register_students  
                        (student_number, first_name, middle_name, last_name, email, phone, address,
                        year_level, section, status, qr_code, image_path, date_registered) 
                        VALUES 
                        (@student_number, @fn, @mn, @ln, @email, @phone, @address,
                        @year, @section, 'Active', @qr, @image, @date)";

                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    { "@student_number", txtStudentID.Text.Trim() },
                    { "@fn", txtFirstName.Text.Trim() },
                    { "@mn", txtMiddleName.Text.Trim() },
                    { "@ln", txtLastName.Text.Trim() },
                    { "@email", txtEmail.Text.Trim() },
                    { "@phone", phone },
                    { "@address", txtAddress.Text.Trim() },
                    { "@year", cmbYearLevel.Text },
                    { "@section", cmbSection.Text },
                    { "@qr", txtStudentID.Text.Trim() },
                    { "@image", studentImagePath },
                    { "@date", DateTime.Now }
                };

                ConnectDB.saveUpdateDeleteData(query, param);

                MessageBox.Show("Student saved successfully!");

                frmMainDashboardForm dashboard = (frmMainDashboardForm)this.FindForm();
                dashboard.LoadUserControl(new ucStudents());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving student:\n" + ex.Message);
            }
        }
        private void SetEditMode()
        {
            isEditMode = true;

            btnSaveStudent.Visible = false;
            btnCancel.Visible = false;

            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            // LOCK STUDENT NUMBER GENERATION
            btnGenerateStudentID.Enabled = false;
            btnGenerateQR.Enabled = false;

            txtStudentID.ReadOnly = true;

            // READ ONLY FIELDS
            txtFirstName.ReadOnly = false;
            txtMiddleName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtPhoneNumber.ReadOnly = false;

            cmbYearLevel.Enabled = false;
            cmbSection.Enabled = false;

            dtRegistered.Enabled = true;
        }
        public void LoadStudentForEdit(string studentId)
        {
            selectedStudentId = studentId;

            using (MySqlConnection conn = ConnectDB.GetConnection())
            {
                string query = @"SELECT * FROM register_students WHERE student_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", studentId);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtStudentID.Text = dr["student_number"]?.ToString();
                    txtFirstName.Text = dr["first_name"]?.ToString();
                    txtMiddleName.Text = dr["middle_name"]?.ToString();
                    txtLastName.Text = dr["last_name"]?.ToString();
                    txtEmail.Text = dr["email"]?.ToString();
                    txtAddress.Text = dr["address"]?.ToString();

                    // PHONE FIX
                    string phone = dr["phone"]?.ToString();

                    if (!string.IsNullOrEmpty(phone) && phone.Length > 3)
                    {
                        cmbPhoneNumber.Text = phone.Substring(0, 4); // +639
                        txtPhoneNumber.Text = phone.Substring(4);
                    }
                    else
                    {
                        txtPhoneNumber.Text = phone;
                    }

                    cmbYearLevel.Text = dr["year_level"]?.ToString();
                    cmbSection.Text = dr["section"]?.ToString();

                    
                }
            }

            SetEditMode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                UPDATE register_students
                SET first_name=@fn,
                    middle_name=@mn,
                    last_name=@ln,
                    email=@email,
                    phone=@phone,
                    address=@address,
                    year_level=@year,
                    section=@section
                WHERE student_id=@id";

                string phone = cmbPhoneNumber.Text + txtPhoneNumber.Text;

                Dictionary<string, object> param = new Dictionary<string, object>
                {
                    {"@fn", txtFirstName.Text},
                    {"@mn", txtMiddleName.Text},
                    {"@ln", txtLastName.Text},
                    {"@email", txtEmail.Text},
                    {"@phone", phone},
                    {"@address", txtAddress.Text},
                    {"@year", cmbYearLevel.Text},
                    {"@section", cmbSection.Text},
                    {"@id", selectedStudentId}
                };

                ConnectDB.saveUpdateDeleteData(query, param);

                MessageBox.Show("Student updated successfully!");

                frmMainDashboardForm dashboard =
                    (frmMainDashboardForm)this.FindForm();

                dashboard.LoadUserControl(new ucStudents());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedStudentId))
                return;

            DialogResult result = MessageBox.Show(
                "Delete this student?",
                "Confirm",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            string query = "DELETE FROM register_students WHERE student_id=@id";

            Dictionary<string, object> param = new Dictionary<string, object>
            {
                {"@id", selectedStudentId}
            };

            ConnectDB.saveUpdateDeleteData(query, param);

            MessageBox.Show("Deleted!");

            frmMainDashboardForm dashboard =
                (frmMainDashboardForm)this.FindForm();

            dashboard.LoadUserControl(new ucStudents());
        }
    }
}
