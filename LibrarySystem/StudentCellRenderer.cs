using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace LibrarySystem
{
    internal class StudentCellRenderer
    {
        public static void RenderStudentCell(DataGridView dgv, DataGridViewCellPaintingEventArgs e, string columnName)
        {
            if (e.RowIndex < 0)
                return;

            if (dgv.Columns[e.ColumnIndex].Name == columnName)
            {
                e.PaintBackground(e.CellBounds, true);

                string studentName = dgv.Rows[e.RowIndex].Cells[columnName].Value?.ToString();

                Image img = Properties.Resources.default_icon;
                int imgSize = 28;

                Rectangle imgRect = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 8, imgSize, imgSize);

                e.Graphics.DrawImage(img, imgRect);

                using (Brush brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(studentName, e.CellStyle.Font, brush, e.CellBounds.X + 40, e.CellBounds.Y + 14);
                }
                e.Handled = true;
            }
        }
        public static void RenderStatusColor(DataGridView dgv, DataGridViewCellFormattingEventArgs e, string columnName)
        {
            if (dgv.Columns[e.ColumnIndex].Name
                == columnName)
            {
                string status = e.Value?.ToString();

                if (status == "BORROWED")
                {
                    e.CellStyle.ForeColor = Color.Green;

                    e.CellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                }
                else if (status == "RETURNED")
                {
                    e.CellStyle.ForeColor = Color.RoyalBlue;

                    e.CellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                }

                else if (status == "OVERDUE")
                {
                    e.CellStyle.ForeColor = Color.Red;

                    e.CellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                }
            }
        }
        public static void RenderOverdueColor(DataGridView dgv,DataGridViewCellFormattingEventArgs e,string columnName)
        {
            if (dgv.Columns[e.ColumnIndex].Name == columnName)
            {
                e.CellStyle.ForeColor = Color.Red;

                e.CellStyle.Font = new Font( dgv.Font, FontStyle.Bold);
            }
        }
        public static string ScanQRCode(PictureBox pictureBox)
        {
            frmScanQR scanForm = new frmScanQR();

            if (scanForm.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = scanForm.QRImage;

                MessageBox.Show("QR Code scanned successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return scanForm.QRCodeValue;
            }

            return "";
        }
        public static string UploadQRCode(PictureBox pictureBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(ofd.FileName);

                pictureBox.Image = bitmap;

                BarcodeReader reader = new BarcodeReader();
                Result result =reader.Decode(bitmap);

                if (result != null)
                {
                    MessageBox.Show("QR Code uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return result.Text;
                }
                else
                {
                    MessageBox.Show("No QR code detected!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            return "";
        }
    }
}
