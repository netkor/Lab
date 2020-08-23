using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab
{
    public partial class frmPriceList : Lab.BaseForm
    {
        delegate void SetComboBoxCellType(int iRowIndex);
        bool bIsComboBox = false;  
        public frmPriceList()
        {
            InitializeComponent();
        }
        #region Form Events
        private void frmPriceList_Load(object sender, EventArgs e)
        {
            try
            {

                dgvPriceDetails.DataSource = null;
                dgvPriceDetails.DataSource = GLOBAL.ds.Tables["PRICE_LIST"];

                dgvPriceDetails.Columns["PRICE_CODE"].HeaderText = "No.";
                dgvPriceDetails.Columns["PRICE_CODE"].Width = 30;
                dgvPriceDetails.Columns["PRICE_CODE"].ReadOnly = true;
                dgvPriceDetails.Columns["PRICE_CODE"].ValueType = typeof(System.Int32);
                //dgvPriceDetails.Columns["PRICE_CODE"].Visible = false;

                dgvPriceDetails.Columns["PARA_TYPE_CODE"].HeaderText = "Code";
                dgvPriceDetails.Columns["PARA_TYPE_CODE"].Width = 30;
                dgvPriceDetails.Columns["PARA_TYPE_CODE"].ReadOnly = true;
                dgvPriceDetails.Columns["PARA_TYPE_CODE"].ValueType = typeof(System.Int32);

                dgvPriceDetails.Columns["PARA_TYPE"].HeaderText = "Test Name";
                dgvPriceDetails.Columns["PARA_TYPE"].Width = 150;
                dgvPriceDetails.Columns["PARA_TYPE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvPriceDetails.Columns["PRICE"].HeaderText = "Price";
                dgvPriceDetails.Columns["PRICE"].Width = 80;
                dgvPriceDetails.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPriceDetails.Columns["PRICE"].ValueType = typeof(System.Decimal);
                dgvPriceDetails.Columns["PRICE"].DefaultCellStyle.Format = "#.##";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }
        #endregion

        #region Grid Events
        private void dgvPriceDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvPriceDetails.Rows[e.RowIndex].ErrorText = "";

        }

        private void dgvPriceDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvPriceDetails.Rows[e.RowIndex].ErrorText = null;
                string strParaType = Convert.ToString(dgvPriceDetails.Rows[e.RowIndex].Cells["PARA_TYPE"].Value).ToUpper();
                DataRow[] rw = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("PARA_TYPE='" + strParaType + "'");

                dgvPriceDetails.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value = 0;
                if (rw.Length != 0)
                {
                    int code = Convert.ToInt32(rw[0]["PARA_TYPE_CODE"]);
                    dgvPriceDetails.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value = code;
                }
                
                if (Convert.IsDBNull(dgvPriceDetails.Rows[e.RowIndex].Cells["PRICE_CODE"].Value))
                {
                    int nextId = 0;
                    if (GLOBAL.ds.Tables["PRICE_LIST"].Rows.Count == 0)
                    {
                        nextId = 1;
                        dgvPriceDetails.Rows[e.RowIndex].Cells["PRICE_CODE"].Value = nextId;
                        
                    }
                    else if (e.RowIndex == dgvPriceDetails.Rows.Count - 2)
                    {

                        DataRow row = GLOBAL.ds.Tables["PRICE_LIST"].Select("PRICE_CODE=MAX(PRICE_CODE)")[0];
                        nextId = Convert.ToInt32(row["PRICE_CODE"]) + 1;
                        dgvPriceDetails.Rows[e.RowIndex].Cells["PRICE_CODE"].Value = nextId;
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void dgvPriceDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = dgvPriceDetails.CurrentCell.ColumnIndex;
                    int iRow = dgvPriceDetails.CurrentCell.RowIndex;

                    if (iColumn == dgvPriceDetails.Columns.Count - 1)
                    {
                        if (iRow + 1 < dgvPriceDetails.Rows.Count)
                            dgvPriceDetails.CurrentCell = dgvPriceDetails[0, iRow + 1];
                    }
                    else
                    {
                        dgvPriceDetails.CurrentCell = dgvPriceDetails[iColumn + 1, iRow];
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        
        private void dgvPriceDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);

                //if (e.ColumnIndex == this.dgvPriceDetails.Columns["PARA_TYPE"].Index)
                //{
                //    this.dgvPriceDetails.BeginInvoke(objChangeCellType, e.RowIndex);
                //    bIsComboBox = false;
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
            }
        }
        private void ChangeCellToComboBox(int iRowIndex)
        {
            try
            {

                if (bIsComboBox == false && dgvPriceDetails.Rows.Count > iRowIndex)
                {
                    DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                    dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    dgComboCell.FlatStyle = FlatStyle.Flat;
                    dgComboCell.DropDownWidth = 200;

                    DataTable dt = new DataTable();
                    dt = GLOBAL.ds.Tables["PARA_TYPE_MAS"];
                    dgComboCell.DataSource = dt.DefaultView;
                    dgComboCell.ValueMember = "PARA_TYPE";
                    dgComboCell.DisplayMember = "PARA_TYPE";

                    dgvPriceDetails.Rows[iRowIndex].Cells[dgvPriceDetails.CurrentCell.ColumnIndex] = dgComboCell;
                    bIsComboBox = true;

                    //Int32 ParaValueCode = Convert.ToInt32(dgvPriceDetails.Rows[iRowIndex].Cells["PARA_VALUE_CODE"].Value);
                    //if (ParaValueCode != 0)
                    //{
                    //    DataRow[] rw = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Select("PARA_VALUE_CODE=" + ParaValueCode);

                    //    if (rw.Length != 0)
                    //    {
                    //        string Result = rw[0]["RESULT_VALUE"].ToString();
                    //        if (Result.ToUpper() != "VALUE" && Result.ToUpper() != "MIN_SEC")
                    //        {
                    //            DataTable dt = new DataTable();

                    //            dt = GLOBAL.ds.Tables["PARA_TYPE_MAS"];
                    //            dt.Rows.Add(ParaValueCode);
                    //            dt.DefaultView.RowFilter = "";
                    //            dt.DefaultView.RowFilter = "PARA_VALUE_CODE=" + ParaValueCode;

                    //            dgComboCell.DataSource = dt.DefaultView;
                    //            dgComboCell.ValueMember = "RESULT_VALUE";
                    //            dgComboCell.DisplayMember = "RESULT_VALUE";

                    //            dgvPriceDetails.Rows[iRowIndex].Cells[dgvPriceDetails.CurrentCell.ColumnIndex] = dgComboCell;
                    //            bIsComboBox = true;
                    //        }

                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message.ToString());
            }
        }
        #endregion
    }
}
