using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab
{
    public partial class frmMenuSettings : Lab.BaseForm
    {
        public frmMenuSettings()
        {
            InitializeComponent();
        }

        private void frmMenuSettings_Load(object sender, EventArgs e)
        {

            try
            {

                string strMenu_Group = "REPORT";
                GLOBAL.ds.Tables["MENU_MAS"].DefaultView.RowFilter = "";
                GLOBAL.ds.Tables["MENU_MAS"].DefaultView.RowFilter = "MENU_GROUP='" + strMenu_Group + "'";

                dgvMenuDetails.DataSource = GLOBAL.ds.Tables["MENU_MAS"].DefaultView;

                //dgvMenuDetails.DataSource = null;
                //dgvMenuDetails.DataSource = GLOBAL.ds.Tables["MENU_MAS"];

                dgvMenuDetails.Columns["MENU_CODE"].HeaderText = "No.";
                dgvMenuDetails.Columns["MENU_CODE"].Width = 30;
                dgvMenuDetails.Columns["MENU_CODE"].ReadOnly = true;
                dgvMenuDetails.Columns["MENU_CODE"].ValueType = typeof(System.Int32);
                dgvMenuDetails.Columns["MENU_CODE"].Visible = false;

                dgvMenuDetails.Columns["MENU_NAME"].HeaderText = "Menu Name";
                dgvMenuDetails.Columns["MENU_NAME"].Width = 150;
                dgvMenuDetails.Columns["MENU_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvMenuDetails.Columns["MENU_GROUP"].HeaderText = "Group";
                dgvMenuDetails.Columns["MENU_GROUP"].Width = 100;
                dgvMenuDetails.Columns["MENU_GROUP"].ReadOnly = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }

        #region Grid Events
        private void dgvMenuDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvMenuDetails.Rows[e.RowIndex].ErrorText = "";
        }
        private void dgvMenuDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvMenuDetails.Rows[e.RowIndex].ErrorText = null;
                if (Convert.IsDBNull(dgvMenuDetails.Rows[e.RowIndex].Cells["MENU_CODE"].Value))
                {
                    int nextId = 0;
                    if (GLOBAL.ds.Tables["MENU_MAS"].Rows.Count == 0)
                    {
                        nextId = 1;
                        dgvMenuDetails.Rows[e.RowIndex].Cells["MENU_CODE"].Value = nextId;
                        //dgvMenuDetails.Rows[e.RowIndex].Cells["MENU_GROUP"].Value = "REPORT";
                    }
                    else if (e.RowIndex == dgvMenuDetails.Rows.Count - 2)
                    {

                        DataRow row = GLOBAL.ds.Tables["MENU_MAS"].Select("MENU_CODE=MAX(MENU_CODE)")[0];
                        nextId = Convert.ToInt32(row["MENU_CODE"]) + 1;
                        dgvMenuDetails.Rows[e.RowIndex].Cells["MENU_CODE"].Value = nextId;
                        //dgvMenuDetails.Rows[e.RowIndex].Cells["MENU_GROUP"].Value = "REPORT";

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvMenuDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = dgvMenuDetails.CurrentCell.ColumnIndex;
                    int iRow = dgvMenuDetails.CurrentCell.RowIndex;

                    if (iColumn == dgvMenuDetails.Columns.Count - 1)
                    {
                        if (iRow + 1 < dgvMenuDetails.Rows.Count)
                            dgvMenuDetails.CurrentCell = dgvMenuDetails[0, iRow + 1];
                    }
                    else
                    {
                        dgvMenuDetails.CurrentCell = dgvMenuDetails[iColumn + 1, iRow];
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

       
    }
}
