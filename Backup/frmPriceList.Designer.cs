namespace Lab
{
    partial class frmPriceList
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
            this.dgvPriceDetails = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.dgvPriceDetails);
            // 
            // dgvPriceDetails
            // 
            this.dgvPriceDetails.AccessibleName = "";
            this.dgvPriceDetails.AllowUserToOrderColumns = true;
            this.dgvPriceDetails.AllowUserToResizeColumns = false;
            this.dgvPriceDetails.AllowUserToResizeRows = false;
            this.dgvPriceDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvPriceDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPriceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPriceDetails.EnableHeadersVisualStyles = false;
            this.dgvPriceDetails.GridColor = System.Drawing.Color.Navy;
            this.dgvPriceDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvPriceDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPriceDetails.Name = "dgvPriceDetails";
            this.dgvPriceDetails.RowHeadersWidth = 25;
            this.dgvPriceDetails.Size = new System.Drawing.Size(473, 286);
            this.dgvPriceDetails.TabIndex = 8;
            this.dgvPriceDetails.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPriceDetails_CellValidated);
            this.dgvPriceDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPriceDetails_CellValidating);
            this.dgvPriceDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPriceDetails_KeyDown);
            this.dgvPriceDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPriceDetails_CellEnter);
            // 
            // frmPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(475, 349);
            this.Name = "frmPriceList";
            this.Load += new System.EventHandler(this.frmPriceList_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPriceDetails;
    }
}
