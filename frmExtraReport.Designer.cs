namespace Lab
{
    partial class frmExtraReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbDoctorDetails = new System.Windows.Forms.RadioButton();
            this.rbPatientDetail = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbRefName = new System.Windows.Forms.ComboBox();
            this.txtRefCode = new System.Windows.Forms.TextBox();
            this.lblDrName = new System.Windows.Forms.Label();
            this.cmbPName = new System.Windows.Forms.ComboBox();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbTestDetails = new System.Windows.Forms.RadioButton();
            this.cmbTestName = new System.Windows.Forms.ComboBox();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.lblTestName = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(952, 28);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 464);
            this.pnlBottom.Size = new System.Drawing.Size(952, 33);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnClose.Location = new System.Drawing.Point(1400, -2);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.panel2);
            this.pnlMiddle.Controls.Add(this.panel1);
            this.pnlMiddle.Size = new System.Drawing.Size(952, 436);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbTestDetails);
            this.panel1.Controls.Add(this.rbDoctorDetails);
            this.panel1.Controls.Add(this.rbPatientDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 434);
            this.panel1.TabIndex = 0;
            // 
            // rbDoctorDetails
            // 
            this.rbDoctorDetails.AutoSize = true;
            this.rbDoctorDetails.Location = new System.Drawing.Point(11, 32);
            this.rbDoctorDetails.Name = "rbDoctorDetails";
            this.rbDoctorDetails.Size = new System.Drawing.Size(126, 21);
            this.rbDoctorDetails.TabIndex = 1;
            this.rbDoctorDetails.TabStop = true;
            this.rbDoctorDetails.Text = "Doctor Details";
            this.rbDoctorDetails.UseVisualStyleBackColor = true;
            // 
            // rbPatientDetail
            // 
            this.rbPatientDetail.AutoSize = true;
            this.rbPatientDetail.Location = new System.Drawing.Point(11, 5);
            this.rbPatientDetail.Name = "rbPatientDetail";
            this.rbPatientDetail.Size = new System.Drawing.Size(126, 21);
            this.rbPatientDetail.TabIndex = 0;
            this.rbPatientDetail.TabStop = true;
            this.rbPatientDetail.Text = "Patient Details";
            this.rbPatientDetail.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbTestName);
            this.panel2.Controls.Add(this.txtTestCode);
            this.panel2.Controls.Add(this.lblTestName);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.cmbRefName);
            this.panel2.Controls.Add(this.txtRefCode);
            this.panel2.Controls.Add(this.lblDrName);
            this.panel2.Controls.Add(this.cmbPName);
            this.panel2.Controls.Add(this.txtPCode);
            this.panel2.Controls.Add(this.lblPatient);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(285, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 434);
            this.panel2.TabIndex = 1;
            // 
            // cmbRefName
            // 
            this.cmbRefName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRefName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbRefName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefName.FormattingEnabled = true;
            this.cmbRefName.Location = new System.Drawing.Point(248, 38);
            this.cmbRefName.Name = "cmbRefName";
            this.cmbRefName.Size = new System.Drawing.Size(326, 26);
            this.cmbRefName.TabIndex = 38;
            this.cmbRefName.TabStop = false;
            // 
            // txtRefCode
            // 
            this.txtRefCode.BackColor = System.Drawing.Color.Pink;
            this.txtRefCode.Enabled = false;
            this.txtRefCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefCode.Location = new System.Drawing.Point(181, 39);
            this.txtRefCode.Name = "txtRefCode";
            this.txtRefCode.ReadOnly = true;
            this.txtRefCode.Size = new System.Drawing.Size(65, 27);
            this.txtRefCode.TabIndex = 42;
            // 
            // lblDrName
            // 
            this.lblDrName.AutoSize = true;
            this.lblDrName.BackColor = System.Drawing.Color.Transparent;
            this.lblDrName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrName.Location = new System.Drawing.Point(26, 43);
            this.lblDrName.Name = "lblDrName";
            this.lblDrName.Size = new System.Drawing.Size(153, 18);
            this.lblDrName.TabIndex = 40;
            this.lblDrName.Text = "Ref. Doctor Name";
            this.lblDrName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPName
            // 
            this.cmbPName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbPName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPName.FormattingEnabled = true;
            this.cmbPName.Location = new System.Drawing.Point(249, 4);
            this.cmbPName.MaxDropDownItems = 30;
            this.cmbPName.Name = "cmbPName";
            this.cmbPName.Size = new System.Drawing.Size(326, 26);
            this.cmbPName.TabIndex = 37;
            this.cmbPName.TabStop = false;
            // 
            // txtPCode
            // 
            this.txtPCode.BackColor = System.Drawing.Color.Pink;
            this.txtPCode.Enabled = false;
            this.txtPCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCode.Location = new System.Drawing.Point(182, 4);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.ReadOnly = true;
            this.txtPCode.Size = new System.Drawing.Size(65, 27);
            this.txtPCode.TabIndex = 41;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.BackColor = System.Drawing.Color.Transparent;
            this.lblPatient.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.Location = new System.Drawing.Point(59, 8);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(120, 18);
            this.lblPatient.TabIndex = 39;
            this.lblPatient.Text = "Patient Name";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtToDate);
            this.panel3.Controls.Add(this.txtFromDate);
            this.panel3.Controls.Add(this.lblToDate);
            this.panel3.Controls.Add(this.lblFromDate);
            this.panel3.Location = new System.Drawing.Point(258, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 67);
            this.panel3.TabIndex = 45;
            
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(9, 10);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(82, 17);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "From Date";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(9, 42);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(64, 17);
            this.lblToDate.TabIndex = 1;
            this.lblToDate.Text = "To Date";
            // 
            // txtFromDate
            // 
            this.txtFromDate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFromDate.Location = new System.Drawing.Point(98, 10);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(100, 24);
            this.txtFromDate.TabIndex = 2;
            // 
            // txtToDate
            // 
            this.txtToDate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtToDate.Location = new System.Drawing.Point(98, 35);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(100, 24);
            this.txtToDate.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rbAll);
            this.panel4.Controls.Add(this.rbDaily);
            this.panel4.Controls.Add(this.rbMonthly);
            this.panel4.Location = new System.Drawing.Point(35, 212);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 50);
            this.panel4.TabIndex = 46;
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(4, 13);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(81, 21);
            this.rbMonthly.TabIndex = 0;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Location = new System.Drawing.Point(83, 13);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(59, 21);
            this.rbDaily.TabIndex = 1;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(148, 13);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(42, 21);
            this.rbAll.TabIndex = 2;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbTestDetails
            // 
            this.rbTestDetails.AutoSize = true;
            this.rbTestDetails.Location = new System.Drawing.Point(11, 59);
            this.rbTestDetails.Name = "rbTestDetails";
            this.rbTestDetails.Size = new System.Drawing.Size(109, 21);
            this.rbTestDetails.TabIndex = 2;
            this.rbTestDetails.TabStop = true;
            this.rbTestDetails.Text = "Test Details";
            this.rbTestDetails.UseVisualStyleBackColor = true;
            // 
            // cmbTestName
            // 
            this.cmbTestName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTestName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTestName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbTestName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTestName.FormattingEnabled = true;
            this.cmbTestName.Location = new System.Drawing.Point(248, 71);
            this.cmbTestName.Name = "cmbTestName";
            this.cmbTestName.Size = new System.Drawing.Size(326, 26);
            this.cmbTestName.TabIndex = 47;
            this.cmbTestName.TabStop = false;
            // 
            // txtTestCode
            // 
            this.txtTestCode.BackColor = System.Drawing.Color.Pink;
            this.txtTestCode.Enabled = false;
            this.txtTestCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestCode.Location = new System.Drawing.Point(181, 72);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.ReadOnly = true;
            this.txtTestCode.Size = new System.Drawing.Size(65, 27);
            this.txtTestCode.TabIndex = 49;
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.BackColor = System.Drawing.Color.Transparent;
            this.lblTestName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestName.Location = new System.Drawing.Point(26, 76);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(97, 18);
            this.lblTestName.TabIndex = 48;
            this.lblTestName.Text = "Test Name";
            this.lblTestName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmExtraReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(952, 497);
            this.Name = "frmExtraReport";
            this.Load += new System.EventHandler(this.frmExtraReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmExtraReport_KeyDown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbPatientDetail;
        private System.Windows.Forms.RadioButton rbDoctorDetails;
        internal System.Windows.Forms.ComboBox cmbRefName;
        internal System.Windows.Forms.TextBox txtRefCode;
        internal System.Windows.Forms.Label lblDrName;
        internal System.Windows.Forms.ComboBox cmbPName;
        internal System.Windows.Forms.TextBox txtPCode;
        internal System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbTestDetails;
        internal System.Windows.Forms.ComboBox cmbTestName;
        internal System.Windows.Forms.TextBox txtTestCode;
        internal System.Windows.Forms.Label lblTestName;
    }
}
