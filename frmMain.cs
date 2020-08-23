using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab
{
    public partial class frmMain : Lab.BaseForm
    {
        

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnTestDetail_Click(object sender, EventArgs e)
        {
            frmParameter objpara = new frmParameter();
            objpara.ShowDialog();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPatientBill_Click(object sender, EventArgs e)
        {
            frmBill objBill = new frmBill();
            objBill.ShowDialog();
        }
    }
}
