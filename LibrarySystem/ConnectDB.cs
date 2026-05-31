using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    internal class ConnectDB
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=;database=librarydb";
            MySqlConnection conn = new MySqlConnection(sql);
            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static bool VerifyPassword(
            string inputPassword,
            string storedHash)
        {
            string hashedInput = HashPassword(inputPassword).Trim();

            storedHash = storedHash.Trim();

            return hashedInput == storedHash;
        }
        public bool RegisterUser(string username, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
              //  conn.Open();

                // CHECK EXISTING USERNAME
                string check =
                    "SELECT COUNT(*) FROM user WHERE username=@user";

                MySqlCommand checkCmd =
                    new MySqlCommand(check, conn);

                checkCmd.Parameters.AddWithValue("@user", username);

                int count =
                    Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count > 0)
                {
                    return false;
                }

                // HASH PASSWORD
                string hashedPassword =
                    HashPassword(password);

                // INSERT USER
                string insert =
                    "INSERT INTO user(username,password) VALUES(@user,@pass)";

                MySqlCommand cmd =
                    new MySqlCommand(insert, conn);

                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", hashedPassword);

                cmd.ExecuteNonQuery();

                conn.Close();

                return true;
            }
        }
        public bool LoginUser(string username, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
               // conn.Open();

                string query =
                    "SELECT password FROM user WHERE username=@username";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@username", username);

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    return false;
                }

                string storedHash = result.ToString();

                conn.Close();

                return VerifyPassword(password, storedHash);
            }
        }
        public static int GetMaxID(string tableName, string columnName, int defaultStartID)
        {
            int maxID = 0;
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    string query = $"SELECT MAX({columnName}) AS maxID FROM {tableName}";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();

                    maxID = result != DBNull.Value ? Convert.ToInt32(result) + 1 : defaultStartID;
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            return maxID;
        }
        public static void DisplayData(string query, DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static void saveUpdateDeleteData(string query, Dictionary<string, object> parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    try
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static object GetData(string query,Dictionary<string, object> parameters)
        {
            object result = null;

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue( param.Key, param.Value);
                    }

                    result = cmd.ExecuteScalar();

                    conn.Close();
                }
            }
            return result;
        }
        public static void FillComboBox(string query, ComboBox cmb, string displayMember, string valueMember)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmb.DataSource = dt;
                    cmb.DisplayMember = displayMember;
                    cmb.ValueMember = valueMember;
                    cmb.SelectedIndex = -1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error loading combo: " + ex.Message);
            }
        }
        public static void SearchData(string baseQuery,string searchText,string[] searchColumns, DataGridView dgv)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    string query = baseQuery;

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrWhiteSpace(searchText))
                    {
                        query += " WHERE (";

                        for (int i = 0; i < searchColumns.Length; i++)
                        {
                            query += searchColumns[i] + " LIKE @search";

                            if (i < searchColumns.Length - 1)
                                query += " OR ";
                        }

                        query += ")";

                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    }

                    cmd.CommandText = query;

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.ReadOnly = true;
                    dgv.AllowUserToAddRows = false;
                    dgv.DataSource = dt;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Search error:\n" + ex.Message);
            }
        }
    }
}
