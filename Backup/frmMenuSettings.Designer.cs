namespace Lab
{
    partial class frmMenuSettings
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
            this.dgvMenuDetails = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.dgvMenuDetails);
            // 
            // dgvMenuDetails
            // 
            this.dgvMenuDetails.AccessibleName = "";
            this.dgvMenuDetails.AllowUserToOrderColumns = true;
            this.dgvMenuDetails.AllowUserToResizeColumns = false;
            this.dgvMenuDetails.AllowUserToResizeRows = false;
            this.dgvMenuDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvMenuDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMenuDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenuDetails.EnableHeadersVisualStyles = false;
            this.dgvMenuDetails.GridColor = System.Drawing.Color.Navy;
            this.dgvMenuDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvMenuDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMenuDetails.Name = "dgvMenuDetails";
            this.dgvMenuDetails.RowHeadersWidth = 25;
            this.dgvMenuDetails.Size = new System.Drawing.Size(473, 286);
            this.dgvMenuDetails.TabIndex = 7;
            this.dgvMenuDetails.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuDetails_CellValidated);
            
            this.dgvMenuDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvMenuDetails_CellValidating);
            this.dgvMenuDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMenuDetails_KeyDown);
            
            // 
            // frmMenuSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(475, 349);
            this.Name = "frmMenuSettings";
            this.Load += new System.EventHandler(this.frmMenuSettings_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMenuDetails;
    }
}
