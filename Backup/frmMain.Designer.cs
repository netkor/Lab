namespace Lab
{
    partial class frmMain
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
            this.pnlTestDetail = new System.Windows.Forms.Panel();
            this.btnTestDetail = new System.Windows.Forms.Button();
            this.pnlPatientBill = new System.Windows.Forms.Panel();
            this.btnPatientBill = new System.Windows.Forms.Button();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlTestDetail.SuspendLayout();
            this.pnlPatientBill.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlReport);
            this.pnlMiddle.Controls.Add(this.pnlPatientBill);
            this.pnlMiddle.Controls.Add(this.pnlTestDetail);
            // 
            // pnlTestDetail
            // 
            this.pnlTestDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTestDetail.Controls.Add(this.btnTestDetail);
            this.pnlTestDetail.Location = new System.Drawing.Point(92, 38);
            this.pnlTestDetail.Name = "pnlTestDetail";
            this.pnlTestDetail.Size = new System.Drawing.Size(86, 100);
            this.pnlTestDetail.TabIndex = 0;
            // 
            // btnTestDetail
            // 
            this.btnTestDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTestDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestDetail.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestDetail.Location = new System.Drawing.Point(0, 0);
            this.btnTestDetail.Name = "btnTestDetail";
            this.btnTestDetail.Size = new System.Drawing.Size(84, 98);
            this.btnTestDetail.TabIndex = 0;
            this.btnTestDetail.Text = "Test Settings";
            this.btnTestDetail.UseVisualStyleBackColor = true;
            this.btnTestDetail.Click += new System.EventHandler(this.btnTestDetail_Click);
            // 
            // pnlPatientBill
            // 
            this.pnlPatientBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPatientBill.Controls.Add(this.btnPatientBill);
            this.pnlPatientBill.Location = new System.Drawing.Point(194, 38);
            this.pnlPatientBill.Name = "pnlPatientBill";
            this.pnlPatientBill.Size = new System.Drawing.Size(86, 100);
            this.pnlPatientBill.TabIndex = 1;
            // 
            // btnPatientBill
            // 
            this.btnPatientBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPatientBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientBill.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientBill.Location = new System.Drawing.Point(0, 0);
            this.btnPatientBill.Name = "btnPatientBill";
            this.btnPatientBill.Size = new System.Drawing.Size(84, 98);
            this.btnPatientBill.TabIndex = 0;
            this.btnPatientBill.Text = "Bill Payment";
            this.btnPatientBill.UseVisualStyleBackColor = true;
            this.btnPatientBill.Click += new System.EventHandler(this.btnPatientBill_Click);
            // 
            // pnlReport
            // 
            this.pnlReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReport.Controls.Add(this.btnReport);
            this.pnlReport.Location = new System.Drawing.Point(296, 38);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(86, 100);
            this.pnlReport.TabIndex = 2;
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(0, 0);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(84, 98);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Create Report";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(475, 349);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlTestDetail.ResumeLayout(false);
            this.pnlPatientBill.ResumeLayout(false);
            this.pnlReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTestDetail;
        private System.Windows.Forms.Button btnTestDetail;
        private System.Windows.Forms.Panel pnlPatientBill;
        private System.Windows.Forms.Button btnPatientBill;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Button btnReport;
    }
}
