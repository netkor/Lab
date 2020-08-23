namespace Lab
{
    partial class frmDatabase
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
            this.cmbTableName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTableDetails = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(927, 28);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 523);
            this.pnlBottom.Size = new System.Drawing.Size(927, 33);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnClose.Location = new System.Drawing.Point(1350, -2);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.panel2);
            this.pnlMiddle.Controls.Add(this.panel1);
            this.pnlMiddle.Size = new System.Drawing.Size(927, 495);
            // 
            // cmbTableName
            // 
            this.cmbTableName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTableName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTableName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbTableName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTableName.FormattingEnabled = true;
            this.cmbTableName.Location = new System.Drawing.Point(298, 3);
            this.cmbTableName.Name = "cmbTableName";
            this.cmbTableName.Size = new System.Drawing.Size(417, 24);
            this.cmbTableName.TabIndex = 4;
            this.cmbTableName.TabStop = false;
            this.cmbTableName.SelectedValueChanged += new System.EventHandler(this.cmbTableName_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Table Name";
            // 
            // dgvTableDetails
            // 
            this.dgvTableDetails.AccessibleName = "";
            this.dgvTableDetails.AllowUserToOrderColumns = true;
            this.dgvTableDetails.AllowUserToResizeColumns = false;
            this.dgvTableDetails.AllowUserToResizeRows = false;
            this.dgvTableDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvTableDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTableDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableDetails.GridColor = System.Drawing.Color.Navy;
            this.dgvTableDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvTableDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTableDetails.Name = "dgvTableDetails";
            this.dgvTableDetails.RowHeadersWidth = 25;
            this.dgvTableDetails.Size = new System.Drawing.Size(925, 458);
            this.dgvTableDetails.TabIndex = 6;
            this.dgvTableDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParaValueMethod_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteAll);
            this.panel1.Controls.Add(this.cmbTableName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 35);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvTableDetails);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(925, 458);
            this.panel2.TabIndex = 8;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(737, 6);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(93, 23);
            this.btnDeleteAll.TabIndex = 6;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // frmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(927, 556);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDatabase";
            this.Text = "frmDatabase";
            this.Load += new System.EventHandler(this.frmDatabase_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbTableName;
        private System.Windows.Forms.DataGridView dgvTableDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteAll;
    }
}