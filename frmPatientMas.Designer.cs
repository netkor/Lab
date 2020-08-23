namespace Lab
{
    partial class frmPatientMas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPatientMas));
            this.pnlButton = new System.Windows.Forms.Panel();
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
            this.pnlMas = new System.Windows.Forms.Panel();
            this.chkNewSugarPatient = new System.Windows.Forms.CheckBox();
            this.txtSPCode = new System.Windows.Forms.TextBox();
            this.txtDLabNo = new System.Windows.Forms.TextBox();
            this.cmbRefName = new System.Windows.Forms.ComboBox();
            this.txtRefCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEntryDate = new System.Windows.Forms.TextBox();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.txtLabNo = new System.Windows.Forms.TextBox();
            this.lblLabNo = new System.Windows.Forms.Label();
            this.cmbPName = new System.Windows.Forms.ComboBox();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlMas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(828, 34);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 250);
            this.pnlBottom.Size = new System.Drawing.Size(828, 40);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnClose.Location = new System.Drawing.Point(11195, -1);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlButton);
            this.pnlMiddle.Controls.Add(this.pnlMas);
            this.pnlMiddle.Location = new System.Drawing.Point(0, 34);
            this.pnlMiddle.Size = new System.Drawing.Size(828, 216);
            // 
            // pnlButton
            // 
            this.pnlButton.BackColor = System.Drawing.Color.LightSlateGray;
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
            this.pnlButton.Location = new System.Drawing.Point(0, 173);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(826, 41);
            this.pnlButton.TabIndex = 36;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Clear.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Clear.Image = global::Lab.Properties.Resources.btn_Clear;
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(438, 2);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(87, 37);
            this.btn_Clear.TabIndex = 14;
            this.btn_Clear.TabStop = false;
            this.btn_Clear.Text = "Clea&r";
            this.btn_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // btn_Find
            // 
            this.btn_Find.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_Find.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Find.Image = ((System.Drawing.Image)(resources.GetObject("btn_Find.Image")));
            this.btn_Find.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Find.Location = new System.Drawing.Point(697, 2);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(34, 37);
            this.btn_Find.TabIndex = 4;
            this.btn_Find.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Find.UseVisualStyleBackColor = true;
            // 
            // btn_last
            // 
            this.btn_last.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_last.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_last.Image = global::Lab.Properties.Resources.btn_Last;
            this.btn_last.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_last.Location = new System.Drawing.Point(766, 2);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(34, 37);
            this.btn_last.TabIndex = 11;
            this.btn_last.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_last.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_next.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.Image = global::Lab.Properties.Resources.btn_next;
            this.btn_next.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_next.Location = new System.Drawing.Point(731, 2);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(34, 37);
            this.btn_next.TabIndex = 10;
            this.btn_next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // btn_previous
            // 
            this.btn_previous.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_previous.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_previous.Image = global::Lab.Properties.Resources.btn_Prev;
            this.btn_previous.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_previous.Location = new System.Drawing.Point(663, 2);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(34, 37);
            this.btn_previous.TabIndex = 9;
            this.btn_previous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_previous.UseVisualStyleBackColor = true;
            // 
            // btn_First
            // 
            this.btn_First.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_First.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_First.Image = global::Lab.Properties.Resources.btn_first;
            this.btn_First.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_First.Location = new System.Drawing.Point(629, 2);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(34, 37);
            this.btn_First.TabIndex = 8;
            this.btn_First.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_First.UseVisualStyleBackColor = true;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Edit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Edit.Image = global::Lab.Properties.Resources.btn_Edit_Image;
            this.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Edit.Location = new System.Drawing.Point(91, 2);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(87, 37);
            this.btn_Edit.TabIndex = 12;
            this.btn_Edit.Text = "&Edit";
            this.btn_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Edit.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Cancel.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Cancel.Image = global::Lab.Properties.Resources.btn_Cancel_Image;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.Location = new System.Drawing.Point(351, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(87, 37);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "C&ancel";
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
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.Location = new System.Drawing.Point(525, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(87, 37);
            this.btn_Close.TabIndex = 9;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "&Close";
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_New
            // 
            this.btn_New.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_New.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_New.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_New.Image = global::Lab.Properties.Resources.btn_New_Image;
            this.btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_New.Location = new System.Drawing.Point(4, 2);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(87, 37);
            this.btn_New.TabIndex = 0;
            this.btn_New.Text = "&New";
            this.btn_New.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_New.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Save.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Save.Image = global::Lab.Properties.Resources.btn_Save_Image;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(178, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(87, 37);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "&Save";
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_Delete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Delete.Image = global::Lab.Properties.Resources.btn_Delete_Image;
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.Location = new System.Drawing.Point(265, 2);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(87, 37);
            this.btn_Delete.TabIndex = 15;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // pnlMas
            // 
            this.pnlMas.Controls.Add(this.chkNewSugarPatient);
            this.pnlMas.Controls.Add(this.txtSPCode);
            this.pnlMas.Controls.Add(this.txtDLabNo);
            this.pnlMas.Controls.Add(this.cmbRefName);
            this.pnlMas.Controls.Add(this.txtRefCode);
            this.pnlMas.Controls.Add(this.label1);
            this.pnlMas.Controls.Add(this.cmbSex);
            this.pnlMas.Controls.Add(this.lblSex);
            this.pnlMas.Controls.Add(this.txtAge);
            this.pnlMas.Controls.Add(this.lblAge);
            this.pnlMas.Controls.Add(this.txtAddress);
            this.pnlMas.Controls.Add(this.lblAddress);
            this.pnlMas.Controls.Add(this.txtEntryDate);
            this.pnlMas.Controls.Add(this.lblBillDate);
            this.pnlMas.Controls.Add(this.txtLabNo);
            this.pnlMas.Controls.Add(this.lblLabNo);
            this.pnlMas.Controls.Add(this.cmbPName);
            this.pnlMas.Controls.Add(this.txtPCode);
            this.pnlMas.Controls.Add(this.lblPatient);
            this.pnlMas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMas.Location = new System.Drawing.Point(0, 0);
            this.pnlMas.Name = "pnlMas";
            this.pnlMas.Size = new System.Drawing.Size(826, 174);
            this.pnlMas.TabIndex = 0;
            // 
            // chkNewSugarPatient
            // 
            this.chkNewSugarPatient.AutoSize = true;
            this.chkNewSugarPatient.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNewSugarPatient.Location = new System.Drawing.Point(236, 45);
            this.chkNewSugarPatient.Name = "chkNewSugarPatient";
            this.chkNewSugarPatient.Size = new System.Drawing.Size(188, 22);
            this.chkNewSugarPatient.TabIndex = 39;
            this.chkNewSugarPatient.Text = "New Sugar Patient?";
            this.chkNewSugarPatient.UseVisualStyleBackColor = true;
            this.chkNewSugarPatient.CheckedChanged += new System.EventHandler(this.chkNewSugarPatient_CheckedChanged);
            // 
            // txtSPCode
            // 
            this.txtSPCode.BackColor = System.Drawing.Color.Pink;
            this.txtSPCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSPCode.Location = new System.Drawing.Point(159, 40);
            this.txtSPCode.Name = "txtSPCode";
            this.txtSPCode.Size = new System.Drawing.Size(57, 27);
            this.txtSPCode.TabIndex = 38;
            this.txtSPCode.Validated += new System.EventHandler(this.txtSPCode_Validated);
            // 
            // txtDLabNo
            // 
            this.txtDLabNo.BackColor = System.Drawing.Color.Pink;
            this.txtDLabNo.Enabled = false;
            this.txtDLabNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDLabNo.Location = new System.Drawing.Point(312, 14);
            this.txtDLabNo.Name = "txtDLabNo";
            this.txtDLabNo.ReadOnly = true;
            this.txtDLabNo.Size = new System.Drawing.Size(148, 27);
            this.txtDLabNo.TabIndex = 37;
            // 
            // cmbRefName
            // 
            this.cmbRefName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRefName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbRefName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefName.FormattingEnabled = true;
            this.cmbRefName.Location = new System.Drawing.Point(224, 132);
            this.cmbRefName.Name = "cmbRefName";
            this.cmbRefName.Size = new System.Drawing.Size(326, 26);
            this.cmbRefName.TabIndex = 6;
            this.cmbRefName.TabStop = false;
            this.cmbRefName.TextChanged += new System.EventHandler(this.cmbRefName_TextChanged);
            // 
            // txtRefCode
            // 
            this.txtRefCode.BackColor = System.Drawing.Color.Pink;
            this.txtRefCode.Enabled = false;
            this.txtRefCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefCode.Location = new System.Drawing.Point(157, 132);
            this.txtRefCode.Name = "txtRefCode";
            this.txtRefCode.ReadOnly = true;
            this.txtRefCode.Size = new System.Drawing.Size(65, 27);
            this.txtRefCode.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Ref. Doctor Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSex
            // 
            this.cmbSex.AutoCompleteCustomSource.AddRange(new string[] {
            "Male",
            "Female"});
            this.cmbSex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbSex.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbSex.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(688, 68);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(86, 26);
            this.cmbSex.TabIndex = 4;
            this.cmbSex.TabStop = false;
            this.cmbSex.TextChanged += new System.EventHandler(this.cmbSex_TextChanged);
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.BackColor = System.Drawing.Color.Transparent;
            this.lblSex.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.Location = new System.Drawing.Point(649, 72);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(37, 18);
            this.lblSex.TabIndex = 27;
            this.lblSex.Text = "Sex";
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAge.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(599, 68);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(47, 27);
            this.txtAge.TabIndex = 3;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(560, 72);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(39, 18);
            this.lblAge.TabIndex = 26;
            this.lblAge.Text = "Age";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(158, 101);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(392, 27);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            this.txtAddress.Validated += new System.EventHandler(this.txtAddress_Validated);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(69, 107);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(73, 18);
            this.lblAddress.TabIndex = 25;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtEntryDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntryDate.Location = new System.Drawing.Point(688, 14);
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.Size = new System.Drawing.Size(103, 27);
            this.txtEntryDate.TabIndex = 1;
            this.txtEntryDate.TextChanged += new System.EventHandler(this.txtEntryDate_TextChanged);
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBillDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDate.Location = new System.Drawing.Point(644, 17);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(47, 18);
            this.lblBillDate.TabIndex = 24;
            this.lblBillDate.Text = "Date";
            this.lblBillDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLabNo
            // 
            this.txtLabNo.BackColor = System.Drawing.Color.Pink;
            this.txtLabNo.Enabled = false;
            this.txtLabNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabNo.Location = new System.Drawing.Point(158, 14);
            this.txtLabNo.Name = "txtLabNo";
            this.txtLabNo.ReadOnly = true;
            this.txtLabNo.Size = new System.Drawing.Size(148, 27);
            this.txtLabNo.TabIndex = 0;
            // 
            // lblLabNo
            // 
            this.lblLabNo.AutoSize = true;
            this.lblLabNo.BackColor = System.Drawing.Color.Transparent;
            this.lblLabNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabNo.Location = new System.Drawing.Point(78, 18);
            this.lblLabNo.Name = "lblLabNo";
            this.lblLabNo.Size = new System.Drawing.Size(65, 18);
            this.lblLabNo.TabIndex = 22;
            this.lblLabNo.Text = "Lab No";
            this.lblLabNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPName
            // 
            this.cmbPName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbPName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPName.FormattingEnabled = true;
            this.cmbPName.Location = new System.Drawing.Point(225, 68);
            this.cmbPName.MaxDropDownItems = 30;
            this.cmbPName.Name = "cmbPName";
            this.cmbPName.Size = new System.Drawing.Size(326, 26);
            this.cmbPName.TabIndex = 2;
            this.cmbPName.TabStop = false;
            this.cmbPName.TextChanged += new System.EventHandler(this.cmbPName_TextChanged);
            // 
            // txtPCode
            // 
            this.txtPCode.BackColor = System.Drawing.Color.Pink;
            this.txtPCode.Enabled = false;
            this.txtPCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCode.Location = new System.Drawing.Point(158, 68);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.ReadOnly = true;
            this.txtPCode.Size = new System.Drawing.Size(65, 27);
            this.txtPCode.TabIndex = 35;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.BackColor = System.Drawing.Color.Transparent;
            this.lblPatient.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.Location = new System.Drawing.Point(35, 72);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(120, 18);
            this.lblPatient.TabIndex = 18;
            this.lblPatient.Text = "Patient Name";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPatientMas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(828, 290);
            this.Name = "frmPatientMas";
            this.Text = "frmPatientMas";
            this.Load += new System.EventHandler(this.frmPatientMas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPatientMas_KeyDown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlButton.ResumeLayout(false);
            this.pnlMas.ResumeLayout(false);
            this.pnlMas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Panel pnlMas;
        internal System.Windows.Forms.ComboBox cmbSex;
        internal System.Windows.Forms.Label lblSex;
        internal System.Windows.Forms.TextBox txtAge;
        internal System.Windows.Forms.Label lblAge;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label lblAddress;
        internal System.Windows.Forms.ComboBox cmbPName;
        internal System.Windows.Forms.TextBox txtPCode;
        internal System.Windows.Forms.Label lblPatient;
        internal System.Windows.Forms.TextBox txtEntryDate;
        internal System.Windows.Forms.Label lblBillDate;
        internal System.Windows.Forms.TextBox txtLabNo;
        internal System.Windows.Forms.Label lblLabNo;
        internal System.Windows.Forms.ComboBox cmbRefName;
        internal System.Windows.Forms.TextBox txtRefCode;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtSPCode;
        internal System.Windows.Forms.TextBox txtDLabNo;
        private System.Windows.Forms.CheckBox chkNewSugarPatient;
    }
}