namespace LibrarySystem
{
    partial class ucBooks
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flpBooksContent = new System.Windows.Forms.FlowLayoutPanel();
            this.tblBookCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBookCategories = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCategories = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CirclePictureBox4 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlOutOfStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblOutOfStock = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlTotalBooks = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalBooks = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlBooksTable = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvBooks = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblBookCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpPagination = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrevPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnPage1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnPage2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnPage3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnDots = new Guna.UI2.WinForms.Guna2Button();
            this.btnLastPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnGoAddBook = new Guna.UI2.WinForms.Guna2Button();
            this.lblFooterBooks = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnScanStudentCamera = new Guna.UI2.WinForms.Guna2Button();
            this.btnResetFilters = new Guna.UI2.WinForms.Guna2Button();
            this.cmbBookStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbBookCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnFilterBooks = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearchBooks = new Guna.UI2.WinForms.Guna2TextBox();
            this.flpBooksContent.SuspendLayout();
            this.tblBookCards.SuspendLayout();
            this.pnlBookCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).BeginInit();
            this.pnlOutOfStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            this.pnlTotalBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            this.pnlBooksTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.flpPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpBooksContent
            // 
            this.flpBooksContent.AutoScroll = true;
            this.flpBooksContent.BackColor = System.Drawing.Color.White;
            this.flpBooksContent.Controls.Add(this.tblBookCards);
            this.flpBooksContent.Controls.Add(this.pnlBooksTable);
            this.flpBooksContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBooksContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBooksContent.Location = new System.Drawing.Point(0, 0);
            this.flpBooksContent.Name = "flpBooksContent";
            this.flpBooksContent.Padding = new System.Windows.Forms.Padding(20);
            this.flpBooksContent.Size = new System.Drawing.Size(1281, 780);
            this.flpBooksContent.TabIndex = 0;
            this.flpBooksContent.WrapContents = false;
            // 
            // tblBookCards
            // 
            this.tblBookCards.ColumnCount = 3;
            this.tblBookCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblBookCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblBookCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblBookCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblBookCards.Controls.Add(this.pnlBookCategories, 1, 0);
            this.tblBookCards.Controls.Add(this.pnlOutOfStock, 2, 0);
            this.tblBookCards.Controls.Add(this.pnlTotalBooks, 0, 0);
            this.tblBookCards.Location = new System.Drawing.Point(20, 20);
            this.tblBookCards.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.tblBookCards.Name = "tblBookCards";
            this.tblBookCards.RowCount = 1;
            this.tblBookCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblBookCards.Size = new System.Drawing.Size(1233, 120);
            this.tblBookCards.TabIndex = 0;
            // 
            // pnlBookCategories
            // 
            this.pnlBookCategories.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.pnlBookCategories.BorderRadius = 15;
            this.pnlBookCategories.BorderThickness = 1;
            this.pnlBookCategories.Controls.Add(this.lblCategories);
            this.pnlBookCategories.Controls.Add(this.guna2HtmlLabel4);
            this.pnlBookCategories.Controls.Add(this.guna2CirclePictureBox4);
            this.pnlBookCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBookCategories.FillColor = System.Drawing.Color.White;
            this.pnlBookCategories.Location = new System.Drawing.Point(413, 3);
            this.pnlBookCategories.Name = "pnlBookCategories";
            this.pnlBookCategories.Size = new System.Drawing.Size(404, 114);
            this.pnlBookCategories.TabIndex = 6;
            // 
            // lblCategories
            // 
            this.lblCategories.BackColor = System.Drawing.Color.Transparent;
            this.lblCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblCategories.Location = new System.Drawing.Point(90, 43);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(18, 33);
            this.lblCategories.TabIndex = 5;
            this.lblCategories.Text = "0";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(90, 18);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(88, 22);
            this.guna2HtmlLabel4.TabIndex = 7;
            this.guna2HtmlLabel4.Text = "CATEGORIES";
            // 
            // guna2CirclePictureBox4
            // 
            this.guna2CirclePictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.guna2CirclePictureBox4.Image = global::LibrarySystem.Properties.Resources.icons8_four_squares_40;
            this.guna2CirclePictureBox4.ImageRotate = 0F;
            this.guna2CirclePictureBox4.Location = new System.Drawing.Point(20, 13);
            this.guna2CirclePictureBox4.Name = "guna2CirclePictureBox4";
            this.guna2CirclePictureBox4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox4.Size = new System.Drawing.Size(50, 50);
            this.guna2CirclePictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.guna2CirclePictureBox4.TabIndex = 6;
            this.guna2CirclePictureBox4.TabStop = false;
            this.guna2CirclePictureBox4.UseTransparentBackground = true;
            // 
            // pnlOutOfStock
            // 
            this.pnlOutOfStock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pnlOutOfStock.BorderRadius = 15;
            this.pnlOutOfStock.BorderThickness = 1;
            this.pnlOutOfStock.Controls.Add(this.lblOutOfStock);
            this.pnlOutOfStock.Controls.Add(this.guna2HtmlLabel5);
            this.pnlOutOfStock.Controls.Add(this.guna2CirclePictureBox3);
            this.pnlOutOfStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOutOfStock.FillColor = System.Drawing.Color.White;
            this.pnlOutOfStock.Location = new System.Drawing.Point(823, 3);
            this.pnlOutOfStock.Name = "pnlOutOfStock";
            this.pnlOutOfStock.Size = new System.Drawing.Size(407, 114);
            this.pnlOutOfStock.TabIndex = 5;
            // 
            // lblOutOfStock
            // 
            this.lblOutOfStock.BackColor = System.Drawing.Color.Transparent;
            this.lblOutOfStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblOutOfStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblOutOfStock.Location = new System.Drawing.Point(90, 43);
            this.lblOutOfStock.Name = "lblOutOfStock";
            this.lblOutOfStock.Size = new System.Drawing.Size(18, 33);
            this.lblOutOfStock.TabIndex = 5;
            this.lblOutOfStock.Text = "0";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(90, 18);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(105, 22);
            this.guna2HtmlLabel5.TabIndex = 7;
            this.guna2HtmlLabel5.Text = "OUT OF STOCK";
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.guna2CirclePictureBox3.Image = global::LibrarySystem.Properties.Resources.icons8_out_of_stock_40;
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(20, 13);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(50, 50);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.guna2CirclePictureBox3.TabIndex = 6;
            this.guna2CirclePictureBox3.TabStop = false;
            this.guna2CirclePictureBox3.UseTransparentBackground = true;
            // 
            // pnlTotalBooks
            // 
            this.pnlTotalBooks.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.pnlTotalBooks.BorderRadius = 15;
            this.pnlTotalBooks.BorderThickness = 1;
            this.pnlTotalBooks.Controls.Add(this.lblTotalBooks);
            this.pnlTotalBooks.Controls.Add(this.guna2HtmlLabel3);
            this.pnlTotalBooks.Controls.Add(this.guna2CirclePictureBox2);
            this.pnlTotalBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotalBooks.FillColor = System.Drawing.Color.White;
            this.pnlTotalBooks.Location = new System.Drawing.Point(3, 3);
            this.pnlTotalBooks.Name = "pnlTotalBooks";
            this.pnlTotalBooks.Size = new System.Drawing.Size(404, 114);
            this.pnlTotalBooks.TabIndex = 0;
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblTotalBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTotalBooks.Location = new System.Drawing.Point(86, 43);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(18, 33);
            this.lblTotalBooks.TabIndex = 5;
            this.lblTotalBooks.Text = "0";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(86, 18);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(99, 22);
            this.guna2HtmlLabel3.TabIndex = 7;
            this.guna2HtmlLabel3.Text = "TOTAL BOOKS";
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.guna2CirclePictureBox2.Image = global::LibrarySystem.Properties.Resources.book__1_;
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(16, 13);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(55, 55);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.guna2CirclePictureBox2.TabIndex = 6;
            this.guna2CirclePictureBox2.TabStop = false;
            // 
            // pnlBooksTable
            // 
            this.pnlBooksTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlBooksTable.BorderRadius = 15;
            this.pnlBooksTable.BorderThickness = 1;
            this.pnlBooksTable.Controls.Add(this.dgvBooks);
            this.pnlBooksTable.Controls.Add(this.lblBookCount);
            this.pnlBooksTable.Controls.Add(this.flpPagination);
            this.pnlBooksTable.Controls.Add(this.btnGoAddBook);
            this.pnlBooksTable.Controls.Add(this.lblFooterBooks);
            this.pnlBooksTable.Controls.Add(this.btnScanStudentCamera);
            this.pnlBooksTable.Controls.Add(this.btnResetFilters);
            this.pnlBooksTable.Controls.Add(this.cmbBookStatus);
            this.pnlBooksTable.Controls.Add(this.cmbBookCategory);
            this.pnlBooksTable.Controls.Add(this.btnFilterBooks);
            this.pnlBooksTable.Controls.Add(this.txtSearchBooks);
            this.pnlBooksTable.FillColor = System.Drawing.Color.White;
            this.pnlBooksTable.Location = new System.Drawing.Point(23, 158);
            this.pnlBooksTable.Name = "pnlBooksTable";
            this.pnlBooksTable.Size = new System.Drawing.Size(1230, 606);
            this.pnlBooksTable.TabIndex = 1;
            this.pnlBooksTable.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBooksTable_Paint);
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBooks.ColumnHeadersHeight = 40;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBooks.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvBooks.Location = new System.Drawing.Point(42, 124);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.RowHeadersWidth = 51;
            this.dgvBooks.RowTemplate.Height = 35;
            this.dgvBooks.Size = new System.Drawing.Size(1164, 321);
            this.dgvBooks.TabIndex = 11;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBooks.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.dgvBooks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.dgvBooks.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBooks.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.dgvBooks.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.dgvBooks.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBooks.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvBooks.ThemeStyle.ReadOnly = true;
            this.dgvBooks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBooks.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBooks.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBooks.ThemeStyle.RowsStyle.Height = 35;
            this.dgvBooks.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBooks.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellClick);
            this.dgvBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellContentClick);
            // 
            // lblBookCount
            // 
            this.lblBookCount.BackColor = System.Drawing.Color.Transparent;
            this.lblBookCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBookCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBookCount.Location = new System.Drawing.Point(20, 525);
            this.lblBookCount.Name = "lblBookCount";
            this.lblBookCount.Size = new System.Drawing.Size(145, 17);
            this.lblBookCount.TabIndex = 10;
            this.lblBookCount.Text = "Showing 1 to 7 of 50 books";
            // 
            // flpPagination
            // 
            this.flpPagination.Controls.Add(this.btnPrevPage);
            this.flpPagination.Controls.Add(this.btnPage1);
            this.flpPagination.Controls.Add(this.btnPage2);
            this.flpPagination.Controls.Add(this.btnPage3);
            this.flpPagination.Controls.Add(this.btnDots);
            this.flpPagination.Controls.Add(this.btnLastPage);
            this.flpPagination.Controls.Add(this.btnNextPage);
            this.flpPagination.Location = new System.Drawing.Point(868, 503);
            this.flpPagination.Name = "flpPagination";
            this.flpPagination.Size = new System.Drawing.Size(324, 40);
            this.flpPagination.TabIndex = 9;
            this.flpPagination.WrapContents = false;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnPrevPage.BorderRadius = 6;
            this.btnPrevPage.BorderThickness = 1;
            this.btnPrevPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrevPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrevPage.FillColor = System.Drawing.Color.White;
            this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnPrevPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnPrevPage.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPrevPage.Location = new System.Drawing.Point(3, 3);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(35, 35);
            this.btnPrevPage.TabIndex = 10;
            this.btnPrevPage.Text = "<";
            // 
            // btnPage1
            // 
            this.btnPage1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnPage1.BorderRadius = 6;
            this.btnPage1.BorderThickness = 1;
            this.btnPage1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPage1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPage1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPage1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPage1.FillColor = System.Drawing.Color.White;
            this.btnPage1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnPage1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPage1.Location = new System.Drawing.Point(44, 3);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(35, 35);
            this.btnPage1.TabIndex = 11;
            this.btnPage1.Text = "1";
            // 
            // btnPage2
            // 
            this.btnPage2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnPage2.BorderRadius = 6;
            this.btnPage2.BorderThickness = 1;
            this.btnPage2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPage2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPage2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPage2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPage2.FillColor = System.Drawing.Color.White;
            this.btnPage2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnPage2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPage2.Location = new System.Drawing.Point(85, 3);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(35, 35);
            this.btnPage2.TabIndex = 12;
            this.btnPage2.Text = "2";
            // 
            // btnPage3
            // 
            this.btnPage3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnPage3.BorderRadius = 6;
            this.btnPage3.BorderThickness = 1;
            this.btnPage3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPage3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPage3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPage3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPage3.FillColor = System.Drawing.Color.White;
            this.btnPage3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnPage3.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnPage3.Location = new System.Drawing.Point(126, 3);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(35, 35);
            this.btnPage3.TabIndex = 13;
            this.btnPage3.Text = "3";
            // 
            // btnDots
            // 
            this.btnDots.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnDots.BorderRadius = 6;
            this.btnDots.BorderThickness = 1;
            this.btnDots.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDots.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDots.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDots.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDots.Enabled = false;
            this.btnDots.FillColor = System.Drawing.Color.White;
            this.btnDots.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnDots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnDots.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDots.Location = new System.Drawing.Point(167, 3);
            this.btnDots.Name = "btnDots";
            this.btnDots.Size = new System.Drawing.Size(50, 35);
            this.btnDots.TabIndex = 14;
            this.btnDots.Text = "...";
            // 
            // btnLastPage
            // 
            this.btnLastPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnLastPage.BorderRadius = 6;
            this.btnLastPage.BorderThickness = 1;
            this.btnLastPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLastPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLastPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLastPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLastPage.FillColor = System.Drawing.Color.White;
            this.btnLastPage.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnLastPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnLastPage.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLastPage.Location = new System.Drawing.Point(223, 3);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(52, 35);
            this.btnLastPage.TabIndex = 15;
            this.btnLastPage.Text = "50";
            // 
            // btnNextPage
            // 
            this.btnNextPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnNextPage.BorderRadius = 6;
            this.btnNextPage.BorderThickness = 1;
            this.btnNextPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextPage.FillColor = System.Drawing.Color.White;
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnNextPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNextPage.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnNextPage.Location = new System.Drawing.Point(281, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(35, 35);
            this.btnNextPage.TabIndex = 16;
            this.btnNextPage.Text = ">";
            // 
            // btnGoAddBook
            // 
            this.btnGoAddBook.BorderRadius = 8;
            this.btnGoAddBook.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGoAddBook.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGoAddBook.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGoAddBook.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGoAddBook.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnGoAddBook.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnGoAddBook.ForeColor = System.Drawing.Color.White;
            this.btnGoAddBook.Image = global::LibrarySystem.Properties.Resources.icons8_add_30;
            this.btnGoAddBook.ImageSize = new System.Drawing.Size(25, 20);
            this.btnGoAddBook.Location = new System.Drawing.Point(1015, 20);
            this.btnGoAddBook.Name = "btnGoAddBook";
            this.btnGoAddBook.Size = new System.Drawing.Size(178, 40);
            this.btnGoAddBook.TabIndex = 7;
            this.btnGoAddBook.Text = "Add New Book";
            this.btnGoAddBook.Click += new System.EventHandler(this.btnGoAddBook_Click);
            // 
            // lblFooterBooks
            // 
            this.lblFooterBooks.BackColor = System.Drawing.Color.Transparent;
            this.lblFooterBooks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFooterBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblFooterBooks.Location = new System.Drawing.Point(459, 574);
            this.lblFooterBooks.Name = "lblFooterBooks";
            this.lblFooterBooks.Size = new System.Drawing.Size(332, 17);
            this.lblFooterBooks.TabIndex = 2;
            this.lblFooterBooks.Text = "© 2025 Smart Library Management System. All rights reserved.";
            this.lblFooterBooks.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnScanStudentCamera
            // 
            this.btnScanStudentCamera.BackColor = System.Drawing.Color.Transparent;
            this.btnScanStudentCamera.BorderRadius = 8;
            this.btnScanStudentCamera.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnScanStudentCamera.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnScanStudentCamera.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnScanStudentCamera.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnScanStudentCamera.FillColor = System.Drawing.Color.White;
            this.btnScanStudentCamera.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnScanStudentCamera.ForeColor = System.Drawing.Color.White;
            this.btnScanStudentCamera.Image = global::LibrarySystem.Properties.Resources.icons8_reset_30__1_;
            this.btnScanStudentCamera.ImageSize = new System.Drawing.Size(30, 30);
            this.btnScanStudentCamera.Location = new System.Drawing.Point(459, 79);
            this.btnScanStudentCamera.Name = "btnScanStudentCamera";
            this.btnScanStudentCamera.Size = new System.Drawing.Size(33, 29);
            this.btnScanStudentCamera.TabIndex = 5;
            this.btnScanStudentCamera.UseTransparentBackground = true;
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnResetFilters.BorderRadius = 8;
            this.btnResetFilters.BorderThickness = 1;
            this.btnResetFilters.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetFilters.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetFilters.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetFilters.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetFilters.FillColor = System.Drawing.Color.White;
            this.btnResetFilters.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnResetFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnResetFilters.Location = new System.Drawing.Point(454, 75);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(97, 40);
            this.btnResetFilters.TabIndex = 4;
            this.btnResetFilters.Text = "Reset";
            this.btnResetFilters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // cmbBookStatus
            // 
            this.cmbBookStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbBookStatus.BorderRadius = 8;
            this.cmbBookStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBookStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBookStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBookStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBookStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBookStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBookStatus.ItemHeight = 30;
            this.cmbBookStatus.Items.AddRange(new object[] {
            "All Status",
            "Available",
            "Borrowed",
            "Out of Stock"});
            this.cmbBookStatus.Location = new System.Drawing.Point(267, 75);
            this.cmbBookStatus.Name = "cmbBookStatus";
            this.cmbBookStatus.Size = new System.Drawing.Size(170, 36);
            this.cmbBookStatus.TabIndex = 3;
            this.cmbBookStatus.SelectedIndexChanged += new System.EventHandler(this.cmbBookStatus_SelectedIndexChanged);
            // 
            // cmbBookCategory
            // 
            this.cmbBookCategory.BackColor = System.Drawing.Color.Transparent;
            this.cmbBookCategory.BorderRadius = 8;
            this.cmbBookCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBookCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBookCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBookCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBookCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBookCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBookCategory.ItemHeight = 30;
            this.cmbBookCategory.Location = new System.Drawing.Point(70, 75);
            this.cmbBookCategory.Name = "cmbBookCategory";
            this.cmbBookCategory.Size = new System.Drawing.Size(170, 36);
            this.cmbBookCategory.TabIndex = 2;
            this.cmbBookCategory.SelectedIndexChanged += new System.EventHandler(this.cmbBookCategory_SelectedIndexChanged);
            // 
            // btnFilterBooks
            // 
            this.btnFilterBooks.BorderRadius = 8;
            this.btnFilterBooks.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterBooks.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilterBooks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilterBooks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilterBooks.FillColor = System.Drawing.Color.White;
            this.btnFilterBooks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilterBooks.ForeColor = System.Drawing.Color.White;
            this.btnFilterBooks.Image = global::LibrarySystem.Properties.Resources.icons8_filter_40;
            this.btnFilterBooks.Location = new System.Drawing.Point(16, 66);
            this.btnFilterBooks.Name = "btnFilterBooks";
            this.btnFilterBooks.Size = new System.Drawing.Size(48, 47);
            this.btnFilterBooks.TabIndex = 1;
            // 
            // txtSearchBooks
            // 
            this.txtSearchBooks.BorderRadius = 8;
            this.txtSearchBooks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBooks.DefaultText = "";
            this.txtSearchBooks.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchBooks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchBooks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBooks.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBooks.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.txtSearchBooks.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBooks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchBooks.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBooks.Location = new System.Drawing.Point(20, 20);
            this.txtSearchBooks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBooks.Name = "txtSearchBooks";
            this.txtSearchBooks.PlaceholderText = "Search by title, author, ISBN, or accession no...";
            this.txtSearchBooks.SelectedText = "";
            this.txtSearchBooks.Size = new System.Drawing.Size(720, 40);
            this.txtSearchBooks.TabIndex = 0;
            this.txtSearchBooks.TextChanged += new System.EventHandler(this.txtSearchBooks_TextChanged);
            // 
            // ucBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.flpBooksContent);
            this.Name = "ucBooks";
            this.Size = new System.Drawing.Size(1281, 780);
            this.Load += new System.EventHandler(this.ucBooks_Load);
            this.flpBooksContent.ResumeLayout(false);
            this.tblBookCards.ResumeLayout(false);
            this.pnlBookCategories.ResumeLayout(false);
            this.pnlBookCategories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).EndInit();
            this.pnlOutOfStock.ResumeLayout(false);
            this.pnlOutOfStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            this.pnlTotalBooks.ResumeLayout(false);
            this.pnlTotalBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            this.pnlBooksTable.ResumeLayout(false);
            this.pnlBooksTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.flpPagination.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBooksContent;
        private Guna.UI2.WinForms.Guna2Panel pnlBooksTable;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBooks;
        private Guna.UI2.WinForms.Guna2Button btnResetFilters;
        private Guna.UI2.WinForms.Guna2ComboBox cmbBookStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbBookCategory;
        private Guna.UI2.WinForms.Guna2Button btnFilterBooks;
        private Guna.UI2.WinForms.Guna2Button btnScanStudentCamera;
        private Guna.UI2.WinForms.Guna2Button btnGoAddBook;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFooterBooks;
        private System.Windows.Forms.FlowLayoutPanel flpPagination;
        private Guna.UI2.WinForms.Guna2Button btnPrevPage;
        private Guna.UI2.WinForms.Guna2Button btnPage1;
        private Guna.UI2.WinForms.Guna2Button btnPage2;
        private Guna.UI2.WinForms.Guna2Button btnPage3;
        private Guna.UI2.WinForms.Guna2Button btnDots;
        private Guna.UI2.WinForms.Guna2Button btnLastPage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBookCount;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBooks;
        private System.Windows.Forms.TableLayoutPanel tblBookCards;
        private Guna.UI2.WinForms.Guna2Panel pnlBookCategories;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCategories;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox4;
        private Guna.UI2.WinForms.Guna2Panel pnlOutOfStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblOutOfStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private Guna.UI2.WinForms.Guna2Panel pnlTotalBooks;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalBooks;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
    }
}
