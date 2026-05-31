using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    internal class BorrowHelperFunctions
    {
        public static void DisplayReturnBookDetails(MySqlDataReader dr,
            Control lblBookTitle,
            Control lblAuthor,
            Control lblCategory,
            Control lblISBN,
            Control lblAccession)
        {
            lblBookTitle.Text = dr["title"].ToString();

            lblAuthor.Text = dr["author"].ToString();

            lblCategory.Text = dr["category_name"].ToString();

            lblISBN.Text = dr["isbn"].ToString();

            lblAccession.Text = dr["accession_no"].ToString();
        }
        public static void DisplayReturnStudentDetails(
            MySqlDataReader dr,
            Control lblName,
            Control lblID,
            Control lblCourseYear,
            Control lblSection,
            Control lblStatus)
        {
            lblName.Text = dr["first_name"].ToString() + " " + dr["last_name"].ToString();

            lblID.Text = dr["student_number"].ToString();

            lblCourseYear.Text =
                dr["year_level"].ToString();

            lblSection.Text =
                dr["section"].ToString();

            lblStatus.Text =
                dr["student_status"].ToString();
        }
        public static void DisplayReturnSummary(
            MySqlDataReader dr,
            Control lblBorrowDate,
            Control lblDueDate,
            Control lblReturnDate,
            Control lblDaysBorrowed)
        {
            DateTime borrowDate =
                DateTime.Parse(
                    dr["borrow_date"].ToString());

            DateTime dueDate =
                DateTime.Parse(
                    dr["due_date"].ToString());

            DateTime returnDate =
                DateTime.Now;

            lblBorrowDate.Text =
                borrowDate.ToString("MMM dd, yyyy");

            lblDueDate.Text =
                dueDate.ToString("MMM dd, yyyy");

            lblReturnDate.Text =
                returnDate.ToString("MMM dd, yyyy");

            int days =
                (returnDate - borrowDate).Days;

            lblDaysBorrowed.Text =
                days + " day(s)";
        }
    }
}
