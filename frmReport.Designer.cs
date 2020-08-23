namespace Lab
{
    partial class frmReport
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.pnlMas = new System.Windows.Forms.Panel();
            this.txtReportNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRefName = new System.Windows.Forms.ComboBox();
            this.txtRefCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLabNo = new System.Windows.Forms.TextBox();
            this.lblLabNo = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtReportDate = new System.Windows.Forms.TextBox();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.cmbPName = new System.Windows.Forms.ComboBox();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.pnlTrn = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvTestDetails = new System.Windows.Forms.DataGridView();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_last = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_First = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlMas.SuspendLayout();
            this.pnlTrn.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestDetails)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(1317, 28);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 639);
            this.pnlBottom.Size = new System.Drawing.Size(1317, 33);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnClose.Location = new System.Drawing.Point(15003, -2);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlTrn);
            this.pnlMiddle.Controls.Add(this.pnlMas);
            this.pnlMiddle.Size = new System.Drawing.Size(1317, 611);
            // 
            // pnlMas
            // 
            this.pnlMas.Controls.Add(this.txtReportNo);
            this.pnlMas.Controls.Add(this.label2);
            this.pnlMas.Controls.Add(this.cmbRefName);
            this.pnlMas.Controls.Add(this.txtRefCode);
            this.pnlMas.Controls.Add(this.label1);
            this.pnlMas.Controls.Add(this.txtLabNo);
            this.pnlMas.Controls.Add(this.lblLabNo);
            this.pnlMas.Controls.Add(this.cmbSex);
            this.pnlMas.Controls.Add(this.lblSex);
            this.pnlMas.Controls.Add(this.txtAge);
            this.pnlMas.Controls.Add(this.lblAge);
            this.pnlMas.Controls.Add(this.txtAddress);
            this.pnlMas.Controls.Add(this.lblAddress);
            this.pnlMas.Controls.Add(this.txtReportDate);
            this.pnlMas.Controls.Add(this.lblBillDate);
            this.pnlMas.Controls.Add(this.txtBillNo);
            this.pnlMas.Controls.Add(this.lblBillNo);
            this.pnlMas.Controls.Add(this.cmbPName);
            this.pnlMas.Controls.Add(this.txtPCode);
            this.pnlMas.Controls.Add(this.lblPatient);
            this.pnlMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMas.Location = new System.Drawing.Point(0, 0);
            this.pnlMas.Name = "pnlMas";
            this.pnlMas.Size = new System.Drawing.Size(1315, 138);
            this.pnlMas.TabIndex = 2;
            // 
            // txtReportNo
            // 
            this.txtReportNo.BackColor = System.Drawing.Color.Pink;
            this.txtReportNo.Enabled = false;
            this.txtReportNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportNo.Location = new System.Drawing.Point(383, 10);
            this.txtReportNo.Name = "txtReportNo";
            this.txtReportNo.ReadOnly = true;
            this.txtReportNo.Size = new System.Drawing.Size(67, 24);
            this.txtReportNo.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Report No";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbRefName
            // 
            this.cmbRefName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRefName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbRefName.Enabled = false;
            this.cmbRefName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefName.FormattingEnabled = true;
            this.cmbRefName.Location = new System.Drawing.Point(451, 104);
            this.cmbRefName.Name = "cmbRefName";
            this.cmbRefName.Size = new System.Drawing.Size(326, 24);
            this.cmbRefName.TabIndex = 7;
            this.cmbRefName.TabStop = false;
            this.cmbRefName.TextChanged += new System.EventHandler(this.cmbRefName_TextChanged);
            // 
            // txtRefCode
            // 
            this.txtRefCode.BackColor = System.Drawing.Color.Pink;
            this.txtRefCode.Enabled = false;
            this.txtRefCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefCode.Location = new System.Drawing.Point(384, 104);
            this.txtRefCode.Name = "txtRefCode";
            this.txtRefCode.Size = new System.Drawing.Size(65, 24);
            this.txtRefCode.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Ref. Doctor Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLabNo
            // 
            this.txtLabNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLabNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabNo.Location = new System.Drawing.Point(707, 10);
            this.txtLabNo.Name = "txtLabNo";
            this.txtLabNo.Size = new System.Drawing.Size(67, 24);
            this.txtLabNo.TabIndex = 1;
            this.txtLabNo.TextChanged += new System.EventHandler(this.txtLabNo_TextChanged);
            // 
            // lblLabNo
            // 
            this.lblLabNo.AutoSize = true;
            this.lblLabNo.BackColor = System.Drawing.Color.Transparent;
            this.lblLabNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabNo.Location = new System.Drawing.Point(644, 14);
            this.lblLabNo.Name = "lblLabNo";
            this.lblLabNo.Size = new System.Drawing.Size(57, 17);
            this.lblLabNo.TabIndex = 29;
            this.lblLabNo.Text = "Lab No";
            this.lblLabNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSex
            // 
            this.cmbSex.AutoCompleteCustomSource.AddRange(new string[] {
            "Male",
            "Female"});
            this.cmbSex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbSex.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbSex.Enabled = false;
            this.cmbSex.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(914, 42);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(103, 24);
            this.cmbSex.TabIndex = 5;
            this.cmbSex.TabStop = false;
            this.cmbSex.TextChanged += new System.EventHandler(this.cmbSex_TextChanged);
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.BackColor = System.Drawing.Color.Transparent;
            this.lblSex.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.Location = new System.Drawing.Point(875, 46);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(35, 17);
            this.lblSex.TabIndex = 27;
            this.lblSex.Text = "Sex";
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAge.Enabled = false;
            this.txtAge.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(825, 42);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(47, 24);
            this.txtAge.TabIndex = 4;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(786, 46);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(35, 17);
            this.lblAge.TabIndex = 26;
            this.lblAge.Text = "Age";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAddress.Enabled = false;
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(384, 75);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(393, 24);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(314, 77);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(66, 17);
            this.lblAddress.TabIndex = 25;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReportDate
            // 
            this.txtReportDate.AcceptsTab = true;
            this.txtReportDate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtReportDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportDate.Location = new System.Drawing.Point(914, 10);
            this.txtReportDate.Name = "txtReportDate";
            this.txtReportDate.Size = new System.Drawing.Size(103, 24);
            this.txtReportDate.TabIndex = 2;
            this.txtReportDate.TextChanged += new System.EventHandler(this.txtReportDate_TextChanged);
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBillDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDate.Location = new System.Drawing.Point(870, 13);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(41, 17);
            this.lblBillDate.TabIndex = 24;
            this.lblBillDate.Text = "Date";
            this.lblBillDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBillNo
            // 
            this.txtBillNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBillNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(539, 10);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.ReadOnly = true;
            this.txtBillNo.Size = new System.Drawing.Size(67, 24);
            this.txtBillNo.TabIndex = 0;
            this.txtBillNo.TextChanged += new System.EventHandler(this.txtBillNo_TextChanged);
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.BackColor = System.Drawing.Color.Transparent;
            this.lblBillNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.Location = new System.Drawing.Point(484, 14);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(51, 17);
            this.lblBillNo.TabIndex = 22;
            this.lblBillNo.Text = "Bill No";
            this.lblBillNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPName
            // 
            this.cmbPName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbPName.Enabled = false;
            this.cmbPName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPName.FormattingEnabled = true;
            this.cmbPName.Location = new System.Drawing.Point(451, 42);
            this.cmbPName.Name = "cmbPName";
            this.cmbPName.Size = new System.Drawing.Size(326, 24);
            this.cmbPName.TabIndex = 3;
            this.cmbPName.TabStop = false;
            this.cmbPName.TextChanged += new System.EventHandler(this.cmbPName_TextChanged);
            // 
            // txtPCode
            // 
            this.txtPCode.BackColor = System.Drawing.Color.Pink;
            this.txtPCode.Enabled = false;
            this.txtPCode.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCode.Location = new System.Drawing.Point(384, 42);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Size = new System.Drawing.Size(65, 24);
            this.txtPCode.TabIndex = 3;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.BackColor = System.Drawing.Color.Transparent;
            this.lblPatient.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.Location = new System.Drawing.Point(280, 42);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(100, 17);
            this.lblPatient.TabIndex = 18;
            this.lblPatient.Text = "Patient Name";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTrn
            // 
            this.pnlTrn.Controls.Add(this.pnlGrid);
            this.pnlTrn.Controls.Add(this.pnlButton);
            this.pnlTrn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrn.Location = new System.Drawing.Point(0, 138);
            this.pnlTrn.Name = "pnlTrn";
            this.pnlTrn.Size = new System.Drawing.Size(1315, 471);
            this.pnlTrn.TabIndex = 17;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvTestDetails);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1315, 430);
            this.pnlGrid.TabIndex = 35;
            // 
            // dgvTestDetails
            // 
            this.dgvTestDetails.AllowUserToAddRows = false;
            this.dgvTestDetails.AllowUserToDeleteRows = false;
            this.dgvTestDetails.AllowUserToResizeColumns = false;
            this.dgvTestDetails.AllowUserToResizeRows = false;
            this.dgvTestDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTestDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTestDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTestDetails.GridColor = System.Drawing.Color.Black;
            this.dgvTestDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvTestDetails.Name = "dgvTestDetails";
            this.dgvTestDetails.RowHeadersWidth = 25;
            this.dgvTestDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestDetails.Size = new System.Drawing.Size(1315, 430);
            this.dgvTestDetails.TabIndex = 0;
            this.dgvTestDetails.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestDetails_CellValidated);
            this.dgvTestDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTestDetails_DataError);
            this.dgvTestDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestDetails_CellEnter);
            // 
            // pnlButton
            // 
            this.pnlButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.pnlButton.Controls.Add(this.btnPrint);
            this.pnlButton.Controls.Add(this.btn_Clear);
            this.pnlButton.Controls.Add(this.btn_Find);
            this.pnlButton.Controls.Add(this.btn_last);
            this.pnlButton.Controls.Add(this.btn_next);
            this.pnlButton.Controls.Add(this.btn_previous);
            this.pnlButton.Controls.Add(this.btn_First);
            this.pnlButton.Controls.Add(this.btn_Edit);
            this.pnlButton.Controls.Add(this.btn_Cancel);
            this.pnlButton.Controls.Add(this.btn_Close);
            this.pnlButton.Controls.Add(this.btn_New);
            this.pnlButton.Controls.Add(this.btn_Save);
            this.pnlButton.Controls.Add(this.btn_Delete);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 430);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1315, 41);
            this.pnlButton.TabIndex = 34;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Image = global::Lab.Properties.Resources.Print_small;
            this.btnPrint.Location = new System.Drawing.Point(830, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 37);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Clear.Enabled = false;
            this.btn_Clear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Clear.Image = global::Lab.Properties.Resources.btn_Clear;
            this.btn_Clear.Location = new System.Drawing.Point(667, 2);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(82, 37);
            this.btn_Clear.TabIndex = 8;
            this.btn_Clear.TabStop = false;
            this.btn_Clear.Text = "Clea&r";
            this.btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // btn_Find
            // 
            this.btn_Find.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_Find.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Find.Image = ((System.Drawing.Image)(resources.GetObject("btn_Find.Image")));
            this.btn_Find.Location = new System.Drawing.Point(982, 2);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(25, 37);
            this.btn_Find.TabIndex = 5;
            this.btn_Find.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Find.UseVisualStyleBackColor = true;
            // 
            // btn_last
            // 
            this.btn_last.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_last.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_last.Image = global::Lab.Properties.Resources.btn_next;
            this.btn_last.Location = new System.Drawing.Point(1032, 2);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(25, 37);
            this.btn_last.TabIndex = 4;
            this.btn_last.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_last.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_next.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.Image = global::Lab.Properties.Resources.btn_Last;
            this.btn_next.Location = new System.Drawing.Point(1007, 2);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(25, 37);
            this.btn_next.TabIndex = 25;
            this.btn_next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // btn_previous
            // 
            this.btn_previous.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_previous.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_previous.Image = global::Lab.Properties.Resources.btn_first;
            this.btn_previous.Location = new System.Drawing.Point(957, 2);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(25, 37);
            this.btn_previous.TabIndex = 2;
            this.btn_previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_previous.UseVisualStyleBackColor = true;
            // 
            // btn_First
            // 
            this.btn_First.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_First.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_First.Image = global::Lab.Properties.Resources.btn_Prev;
            this.btn_First.Location = new System.Drawing.Point(932, 2);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(25, 37);
            this.btn_First.TabIndex = 1;
            this.btn_First.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_First.UseVisualStyleBackColor = true;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Edit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Edit.Image = global::Lab.Properties.Resources.btn_Edit_Image;
            this.btn_Edit.Location = new System.Drawing.Point(339, 2);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(82, 37);
            this.btn_Edit.TabIndex = 6;
            this.btn_Edit.Text = "&Edit";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Edit.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Cancel.Enabled = false;
            this.btn_Cancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Cancel.Image = global::Lab.Properties.Resources.btn_Cancel_Image;
            this.btn_Cancel.Location = new System.Drawing.Point(585, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(82, 37);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "C&ancel";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Close.Image = global::Lab.Properties.Resources.btn_Close_Image;
            this.btn_Close.Location = new System.Drawing.Point(749, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(82, 37);
            this.btn_Close.TabIndex = 9;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "&Close";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_New
            // 
            this.btn_New.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_New.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_New.Image = global::Lab.Properties.Resources.btn_New_Image;
            this.btn_New.Location = new System.Drawing.Point(257, 2);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(82, 37);
            this.btn_New.TabIndex = 14;
            this.btn_New.Text = "&New";
            this.btn_New.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_New.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_New.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Save.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Save.Image = global::Lab.Properties.Resources.btn_Save_Image;
            this.btn_Save.Location = new System.Drawing.Point(421, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(82, 37);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "&Save";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Delete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Delete.Image = global::Lab.Properties.Resources.btn_Delete_Image;
            this.btn_Delete.Location = new System.Drawing.Point(503, 2);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(82, 37);
            this.btn_Delete.TabIndex = 10;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1317, 672);
            this.Name = "frmReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMas.ResumeLayout(false);
            this.pnlMas.PerformLayout();
            this.pnlTrn.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestDetails)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMas;
        internal System.Windows.Forms.ComboBox cmbRefName;
        internal System.Windows.Forms.TextBox txtRefCode;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtLabNo;
        internal System.Windows.Forms.Label lblLabNo;
        internal System.Windows.Forms.ComboBox cmbSex;
        internal System.Windows.Forms.Label lblSex;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.Label lblAge;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label lblAddress;
        internal System.Windows.Forms.TextBox txtReportDate;
        internal System.Windows.Forms.Label lblBillDate;
        internal System.Windows.Forms.TextBox txtBillNo;
        internal System.Windows.Forms.Label lblBillNo;
        internal System.Windows.Forms.ComboBox cmbPName;
        internal System.Windows.Forms.TextBox txtPCode;
        internal System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Panel pnlTrn;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvTestDetails;
        internal System.Windows.Forms.Panel pnlButton;
        internal System.Windows.Forms.Button btnPrint;
        internal System.Windows.Forms.Button btn_Clear;
        internal System.Windows.Forms.Button btn_Find;
        internal System.Windows.Forms.Button btn_last;
        internal System.Windows.Forms.Button btn_next;
        internal System.Windows.Forms.Button btn_previous;
        internal System.Windows.Forms.Button btn_First;
        internal System.Windows.Forms.Button btn_Edit;
        internal System.Windows.Forms.Button btn_Cancel;
        internal System.Windows.Forms.Button btn_Close;
        internal System.Windows.Forms.Button btn_New;
        internal System.Windows.Forms.Button btn_Save;
        internal System.Windows.Forms.Button btn_Delete;
        internal System.Windows.Forms.TextBox txtReportNo;
        internal System.Windows.Forms.Label label2;
    }
}
