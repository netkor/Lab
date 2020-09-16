namespace Lab
{
    partial class frmBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBill));
            this.pnlMas = new System.Windows.Forms.Panel();
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
            this.txtBillDate = new System.Windows.Forms.TextBox();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.cmbPName = new System.Windows.Forms.ComboBox();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.pnlTrn = new System.Windows.Forms.Panel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.txtTotalAmt = new System.Windows.Forms.TextBox();
            this.lblTotalAmt = new System.Windows.Forms.Label();
            this.txtNetAmt = new System.Windows.Forms.TextBox();
            this.lblNetAmt = new System.Windows.Forms.Label();
            this.txtLessAmt = new System.Windows.Forms.TextBox();
            this.lblLess = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvTestDetails = new System.Windows.Forms.DataGridView();
            this.BILL_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DETAILID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PARA_TYPE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pnlTotal.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestDetails)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMainHead
            // 
            this.lblMainHead.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainHead.Size = new System.Drawing.Size(85, 17);
            // 
            // pnlTop
            // 
            this.pnlTop.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Size = new System.Drawing.Size(807, 34);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(0, 455);
            this.pnlBottom.Size = new System.Drawing.Size(807, 40);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(2770, 2);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlTrn);
            this.pnlMiddle.Controls.Add(this.pnlMas);
            this.pnlMiddle.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMiddle.Location = new System.Drawing.Point(0, 34);
            this.pnlMiddle.Size = new System.Drawing.Size(807, 421);
            // 
            // pnlMas
            // 
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
            this.pnlMas.Controls.Add(this.txtBillDate);
            this.pnlMas.Controls.Add(this.lblBillDate);
            this.pnlMas.Controls.Add(this.txtBillNo);
            this.pnlMas.Controls.Add(this.lblBillNo);
            this.pnlMas.Controls.Add(this.cmbPName);
            this.pnlMas.Controls.Add(this.txtPCode);
            this.pnlMas.Controls.Add(this.lblPatient);
            this.pnlMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMas.Location = new System.Drawing.Point(0, 0);
            this.pnlMas.Name = "pnlMas";
            this.pnlMas.Size = new System.Drawing.Size(805, 138);
            this.pnlMas.TabIndex = 1;
            // 
            // cmbRefName
            // 
            this.cmbRefName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRefName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbRefName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefName.FormattingEnabled = true;
            this.cmbRefName.Location = new System.Drawing.Point(210, 108);
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
            this.txtRefCode.Location = new System.Drawing.Point(143, 108);
            this.txtRefCode.Name = "txtRefCode";
            this.txtRefCode.Size = new System.Drawing.Size(65, 24);
            this.txtRefCode.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 108);
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
            this.txtLabNo.Location = new System.Drawing.Point(388, 11);
            this.txtLabNo.Name = "txtLabNo";
            this.txtLabNo.Size = new System.Drawing.Size(148, 24);
            this.txtLabNo.TabIndex = 1;
            this.txtLabNo.TextChanged += new System.EventHandler(this.txtLabNo_TextChanged);
            // 
            // lblLabNo
            // 
            this.lblLabNo.AutoSize = true;
            this.lblLabNo.BackColor = System.Drawing.Color.Transparent;
            this.lblLabNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabNo.Location = new System.Drawing.Point(325, 16);
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
            this.cmbSex.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(673, 46);
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
            this.lblSex.Location = new System.Drawing.Point(634, 50);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(35, 17);
            this.lblSex.TabIndex = 27;
            this.lblSex.Text = "Sex";
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAge.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(584, 46);
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
            this.lblAge.Location = new System.Drawing.Point(545, 50);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(35, 17);
            this.lblAge.TabIndex = 26;
            this.lblAge.Text = "Age";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(143, 79);
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
            this.lblAddress.Location = new System.Drawing.Point(73, 81);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(66, 17);
            this.lblAddress.TabIndex = 25;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBillDate
            // 
            this.txtBillDate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBillDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillDate.Location = new System.Drawing.Point(673, 14);
            this.txtBillDate.Name = "txtBillDate";
            this.txtBillDate.Size = new System.Drawing.Size(103, 24);
            this.txtBillDate.TabIndex = 2;
            this.txtBillDate.TextChanged += new System.EventHandler(this.txtBillDate_TextChanged);
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBillDate.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDate.Location = new System.Drawing.Point(629, 17);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(41, 17);
            this.lblBillDate.TabIndex = 24;
            this.lblBillDate.Text = "Date";
            this.lblBillDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBillNo
            // 
            this.txtBillNo.BackColor = System.Drawing.Color.Pink;
            this.txtBillNo.Enabled = false;
            this.txtBillNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(143, 14);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.ReadOnly = true;
            this.txtBillNo.Size = new System.Drawing.Size(148, 24);
            this.txtBillNo.TabIndex = 0;
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.BackColor = System.Drawing.Color.Transparent;
            this.lblBillNo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.Location = new System.Drawing.Point(88, 14);
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
            this.cmbPName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPName.FormattingEnabled = true;
            this.cmbPName.Location = new System.Drawing.Point(210, 46);
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
            this.txtPCode.Location = new System.Drawing.Point(143, 46);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Size = new System.Drawing.Size(65, 24);
            this.txtPCode.TabIndex = 3;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.BackColor = System.Drawing.Color.Transparent;
            this.lblPatient.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.Location = new System.Drawing.Point(39, 46);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(100, 17);
            this.lblPatient.TabIndex = 18;
            this.lblPatient.Text = "Patient Name";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTrn
            // 
            this.pnlTrn.Controls.Add(this.pnlTotal);
            this.pnlTrn.Controls.Add(this.pnlGrid);
            this.pnlTrn.Controls.Add(this.pnlButton);
            this.pnlTrn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrn.Location = new System.Drawing.Point(0, 138);
            this.pnlTrn.Name = "pnlTrn";
            this.pnlTrn.Size = new System.Drawing.Size(805, 281);
            this.pnlTrn.TabIndex = 16;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.txtTotalAmt);
            this.pnlTotal.Controls.Add(this.lblTotalAmt);
            this.pnlTotal.Controls.Add(this.txtNetAmt);
            this.pnlTotal.Controls.Add(this.lblNetAmt);
            this.pnlTotal.Controls.Add(this.txtLessAmt);
            this.pnlTotal.Controls.Add(this.lblLess);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotal.Location = new System.Drawing.Point(0, 209);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(805, 31);
            this.pnlTotal.TabIndex = 36;
            // 
            // txtTotalAmt
            // 
            this.txtTotalAmt.BackColor = System.Drawing.Color.Pink;
            this.txtTotalAmt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmt.Location = new System.Drawing.Point(343, 4);
            this.txtTotalAmt.Name = "txtTotalAmt";
            this.txtTotalAmt.ReadOnly = true;
            this.txtTotalAmt.Size = new System.Drawing.Size(78, 24);
            this.txtTotalAmt.TabIndex = 34;
            this.txtTotalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmt
            // 
            this.lblTotalAmt.AutoSize = true;
            this.lblTotalAmt.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmt.Location = new System.Drawing.Point(236, 7);
            this.lblTotalAmt.Name = "lblTotalAmt";
            this.lblTotalAmt.Size = new System.Drawing.Size(104, 17);
            this.lblTotalAmt.TabIndex = 35;
            this.lblTotalAmt.Text = "Total Amount";
            this.lblTotalAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNetAmt
            // 
            this.txtNetAmt.BackColor = System.Drawing.Color.Pink;
            this.txtNetAmt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetAmt.Location = new System.Drawing.Point(724, 3);
            this.txtNetAmt.Name = "txtNetAmt";
            this.txtNetAmt.ReadOnly = true;
            this.txtNetAmt.Size = new System.Drawing.Size(78, 24);
            this.txtNetAmt.TabIndex = 32;
            this.txtNetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNetAmt
            // 
            this.lblNetAmt.AutoSize = true;
            this.lblNetAmt.BackColor = System.Drawing.Color.Transparent;
            this.lblNetAmt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmt.Location = new System.Drawing.Point(617, 6);
            this.lblNetAmt.Name = "lblNetAmt";
            this.lblNetAmt.Size = new System.Drawing.Size(93, 17);
            this.lblNetAmt.TabIndex = 33;
            this.lblNetAmt.Text = "Net Amount";
            this.lblNetAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLessAmt
            // 
            this.txtLessAmt.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLessAmt.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLessAmt.Location = new System.Drawing.Point(534, 3);
            this.txtLessAmt.Name = "txtLessAmt";
            this.txtLessAmt.Size = new System.Drawing.Size(78, 24);
            this.txtLessAmt.TabIndex = 0;
            this.txtLessAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLessAmt.TextChanged += new System.EventHandler(this.txtLessAmt_TextChanged);
            this.txtLessAmt.Validated += new System.EventHandler(this.txtLessAmt_Validated);
            // 
            // lblLess
            // 
            this.lblLess.AutoSize = true;
            this.lblLess.BackColor = System.Drawing.Color.Transparent;
            this.lblLess.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLess.Location = new System.Drawing.Point(427, 6);
            this.lblLess.Name = "lblLess";
            this.lblLess.Size = new System.Drawing.Size(101, 17);
            this.lblLess.TabIndex = 31;
            this.lblLess.Text = "Less Amount";
            this.lblLess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvTestDetails);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(805, 240);
            this.pnlGrid.TabIndex = 35;
            // 
            // dgvTestDetails
            // 
            this.dgvTestDetails.AllowUserToResizeColumns = false;
            this.dgvTestDetails.AllowUserToResizeRows = false;
            this.dgvTestDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTestDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvTestDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BILL_NO,
            this.DETAILID,
            this.PARA_TYPE_CODE});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTestDetails.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvTestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTestDetails.GridColor = System.Drawing.Color.Black;
            this.dgvTestDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvTestDetails.Name = "dgvTestDetails";
            this.dgvTestDetails.RowHeadersWidth = 25;
            this.dgvTestDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTestDetails.Size = new System.Drawing.Size(805, 240);
            this.dgvTestDetails.TabIndex = 0;
            this.dgvTestDetails.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTestDetails_CellValidated);
            this.dgvTestDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvTestDetails_CellValidating);
            // 
            // BILL_NO
            // 
            this.BILL_NO.DataPropertyName = "BILL_NO";
            this.BILL_NO.HeaderText = "Ref.No";
            this.BILL_NO.Name = "BILL_NO";
            this.BILL_NO.ReadOnly = true;
            this.BILL_NO.Width = 60;
            // 
            // DETAILID
            // 
            this.DETAILID.DataPropertyName = "DETAILID";
            this.DETAILID.HeaderText = "No.";
            this.DETAILID.Name = "DETAILID";
            this.DETAILID.ReadOnly = true;
            this.DETAILID.Width = 40;
            // 
            // PARA_TYPE_CODE
            // 
            this.PARA_TYPE_CODE.DataPropertyName = "PARA_TYPE_CODE";
            this.PARA_TYPE_CODE.HeaderText = "Code";
            this.PARA_TYPE_CODE.Name = "PARA_TYPE_CODE";
            this.PARA_TYPE_CODE.ReadOnly = true;
            this.PARA_TYPE_CODE.Width = 50;
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
            this.pnlButton.Location = new System.Drawing.Point(0, 240);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(805, 41);
            this.pnlButton.TabIndex = 34;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Image = global::Lab.Properties.Resources.Print_small;
            this.btnPrint.Location = new System.Drawing.Point(577, 2);
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
            this.btn_Clear.Location = new System.Drawing.Point(414, 2);
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
            this.btn_Find.Location = new System.Drawing.Point(729, 2);
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
            this.btn_last.Location = new System.Drawing.Point(779, 2);
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
            this.btn_next.Location = new System.Drawing.Point(754, 2);
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
            this.btn_previous.Location = new System.Drawing.Point(704, 2);
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
            this.btn_First.Location = new System.Drawing.Point(679, 2);
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
            this.btn_Edit.Location = new System.Drawing.Point(86, 2);
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
            this.btn_Cancel.Location = new System.Drawing.Point(332, 2);
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
            this.btn_Close.Location = new System.Drawing.Point(496, 2);
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
            this.btn_New.Location = new System.Drawing.Point(4, 2);
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
            this.btn_Save.Location = new System.Drawing.Point(168, 2);
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
            this.btn_Delete.Location = new System.Drawing.Point(250, 2);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(82, 37);
            this.btn_Delete.TabIndex = 10;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(807, 495);
            this.Name = "frmBill";
            this.Load += new System.EventHandler(this.frmBill_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBill_KeyDown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMas.ResumeLayout(false);
            this.pnlMas.PerformLayout();
            this.pnlTrn.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestDetails)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMas;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label lblAddress;
        internal System.Windows.Forms.TextBox txtBillDate;
        internal System.Windows.Forms.Label lblBillDate;
        internal System.Windows.Forms.TextBox txtBillNo;
        internal System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.Panel pnlTrn;
        internal System.Windows.Forms.Panel pnlButton;
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
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvTestDetails;
        internal System.Windows.Forms.ComboBox cmbSex;
        internal System.Windows.Forms.Label lblSex;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.Label lblAge;
        internal System.Windows.Forms.ComboBox cmbPName;
        internal System.Windows.Forms.TextBox txtPCode;
        internal System.Windows.Forms.Label lblPatient;
        internal System.Windows.Forms.TextBox txtLabNo;
        internal System.Windows.Forms.Label lblLabNo;
        internal System.Windows.Forms.ComboBox cmbRefName;
        internal System.Windows.Forms.TextBox txtRefCode;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILL_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DETAILID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PARA_TYPE_CODE;
        private System.Windows.Forms.Panel pnlTotal;
        internal System.Windows.Forms.TextBox txtLessAmt;
        internal System.Windows.Forms.Label lblLess;
        internal System.Windows.Forms.TextBox txtNetAmt;
        internal System.Windows.Forms.Label lblNetAmt;
        internal System.Windows.Forms.TextBox txtTotalAmt;
        internal System.Windows.Forms.Label lblTotalAmt;
        internal System.Windows.Forms.Button btnPrint;
        
        

    }
}
