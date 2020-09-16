using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab
{
    public partial class frmDatabase : BaseForm
    {
        public frmDatabase()
        {
            InitializeComponent();
        }

        private void dgvParaValueMethod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDatabase_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < GLOBAL.ds.Tables.Count; i++)
			{
                cmbTableName.Items.Add(GLOBAL.ds.Tables[i].TableName);
			} 
        }

        private void cmbTableName_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvTableDetails.DataSource = null;
            dgvTableDetails.DataSource = GLOBAL.ds.Tables[cmbTableName.Text.ToString()];

            //dgvTableDetails.Columns["PARA_TYPE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            GLOBAL.ds.Tables[cmbTableName.Text.ToString()].Rows.Clear();
        }
    }
}
