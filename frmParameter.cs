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
    public partial class frmParameter : BaseForm
    {
        #region Declaration
        int ParaTypeCode = 0;
        int ParaValueCode = 0;
        #endregion

        #region Common Methods
        public void ShowMessagePrompt(string Msg, string PromptMsg)
        {
            switch (PromptMsg)
            {
                case "S":
                    lblMessage.ForeColor = Color.Lime;
                    break;
                default:
                    lblMessage.ForeColor = Color.Red;
                    break;
            }
            lblMessage.Text = Msg;
        }
        #endregion

        #region Form Events
        public frmParameter()
        {
            InitializeComponent();
        }
        private void frmParameter_Load(object sender, EventArgs e)
        {
            dgvParaTypeMas.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(dgvParaTypeMas_CellValidated);
            dgvParaTypeMas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvParaTypeMas_CellContentDoubleClick);
            dgvParaTypeMas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(dgvParaTypeMas_CellValidating);
            dgvParaTypeMas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgvParaTypeMas_RowHeaderMouseDoubleClick);
            dgvParaTypeMas.KeyDown += new System.Windows.Forms.KeyEventHandler(dgvParaTypeMas_KeyDown);
            dgvParaTypeMas.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(dgvParaTypeMas_RowStateChanged);
            dgvParaTypeMas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgvParaTypeMas_CellContentClick);

            dgvParaValueMas.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(dgvParaValueMas_CellValidated);
            dgvParaValueMas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(dgvParaValueMas_CellValidating);
            dgvParaValueMas.KeyDown += new System.Windows.Forms.KeyEventHandler(dgvParaValueMas_KeyDown);
            dgvParaValueMas.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(dgvParaValueMas_RowStateChanged);

            dgvParaValueResult.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(dgvParameterResult_CellValidated);
            dgvParaValueResult.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(dgvParameterResult_CellValidating);
            dgvParaValueResult.KeyDown += new System.Windows.Forms.KeyEventHandler(dgvParameterResult_KeyDown);

            dgvParaValueRange.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(dgvParaValueRange_CellValidated);
            dgvParaValueRange.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(dgvParaValueRange_CellValidating);
            dgvParaValueRange.KeyDown += new System.Windows.Forms.KeyEventHandler(dgvParaValueRange_KeyDown);

            dgvParaValueMethod.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(dgvParaValueMethod_CellValidated);
            dgvParaValueMethod.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(dgvParaValueMethod_CellValidating);
            dgvParaValueMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(dgvParaValueMethod_KeyDown);

            //LoadDB();
            SetGrid_ParaTypeMas();
            dgvParaTypeMas.Focus();
            SetGrid_ParaValueResult();
            SetGrid_ParaValueRange();
            SetGrid_ParaValueMethod();
            //SetGrid_ParaValueMas();
            //btnClose.Location.X = 1240;
            //btnClose.Location.Y = 3;
        }
        private void frmParameter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Control events
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GLOBAL.ds.WriteXmlSchema(Application.StartupPath + @"\QUICK_LAB.xsd");
                GLOBAL.ds.WriteXml(Application.StartupPath + @"\QUICK_LAB.xml");
                ShowMessagePrompt("Record save successfully!", "S");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #region Para Type Master
        private void SetGrid_ParaTypeMas()
        {
            try
            {
            dgvParaTypeMas.DataSource =  GLOBAL.ds.Tables["PARA_TYPE_MAS"];

            dgvParaTypeMas.Columns["PARA_TYPE_CODE"].HeaderText = "No.";
            dgvParaTypeMas.Columns["PARA_TYPE_CODE"].Width = 30;
            dgvParaTypeMas.Columns["PARA_TYPE_CODE"].ReadOnly = true;
            dgvParaTypeMas.Columns["PARA_TYPE_CODE"].ValueType = typeof(System.Int32);

            dgvParaTypeMas.Columns["PARA_TYPE"].HeaderText = "Test Name";
            dgvParaTypeMas.Columns["PARA_TYPE"].Width = 150;
            dgvParaTypeMas.Columns["PARA_TYPE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvParaTypeMas.Columns["PRICE"].HeaderText = "Price";
            dgvParaTypeMas.Columns["PRICE"].Width = 80;
            dgvParaTypeMas.Columns["PRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvParaTypeMas.Columns["PRICE"].ValueType = typeof(System.Decimal);
            dgvParaTypeMas.Columns["PRICE"].DefaultCellStyle.Format = "#.##";
            dgvParaTypeMas.Columns["PRICE"].Visible = false;

            dgvParaTypeMas.Columns["ORD"].HeaderText = "Order";
            dgvParaTypeMas.Columns["ORD"].Width = 50;
            dgvParaTypeMas.Columns["ORD"].ValueType = typeof(System.Int32);
            dgvParaTypeMas.Columns["ORD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvParaTypeMas.Sort(dgvParaTypeMas.Columns["ORD"], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaTypeMas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
            dgvParaTypeMas.Rows[e.RowIndex].ErrorText = "";
            DataGridViewTextBoxCell cell = dgvParaTypeMas["PRICE", e.RowIndex] as DataGridViewTextBoxCell;

            if (cell != null)
            {
                if (dgvParaTypeMas.Columns[e.ColumnIndex].Name == "PRICE")
                {
                    char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (char.IsDigit(c) == false)
                        {
                            //dataGridView1.Rows[e.RowIndex].ErrorText = "";
                            ShowMessagePrompt("You have to enter price only", "");
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaTypeMas_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            dgvParaTypeMas.Rows[e.RowIndex].ErrorText = null;
            if (Convert.IsDBNull(dgvParaTypeMas.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value))
            {

                int nextId = 0;
                if (GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows.Count == 0)
                {
                    nextId = 1;
                    dgvParaTypeMas.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value = nextId;
                    
                }
                else if (e.RowIndex == dgvParaTypeMas.Rows.Count - 2)
                {
                    DataRow row = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("PARA_TYPE_CODE=MAX(PARA_TYPE_CODE)")[0];
                    nextId = Convert.ToInt32(row["PARA_TYPE_CODE"]) + 1;
                    dgvParaTypeMas.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value = nextId;

                    DataRow Ordrow = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("ORD=MAX(ORD)")[0];
                    if (Ordrow.ToString() != "")
                    {
                        int ord = Convert.ToInt32(row["ORD"]) + 1;
                        dgvParaTypeMas.Rows[e.RowIndex].Cells["ORD"].Value = ord;
                    }
                    else
                    
                        dgvParaTypeMas.Rows[e.RowIndex].Cells["ORD"].Value = 1;
                        
                    }
                }

            int iColumn = dgvParaTypeMas.CurrentCell.ColumnIndex;
            int iRow = dgvParaTypeMas.CurrentCell.RowIndex;

            if (iColumn == dgvParaTypeMas.Columns.Count - 1)
            {
                if (iRow + 1 < dgvParaTypeMas.Rows.Count)
                {
                    //   dgvParaTypeMas.CurrentCell = dgvParaTypeMas[0, iRow + 1];
                    dgvParaTypeMas.Rows[iRow + 1].Cells[0].Selected = true;
                }
            }
            else
            {
             //   dgvParaTypeMas.CurrentCell = dgvParaTypeMas[iColumn + 1, iRow];
                dgvParaTypeMas.Rows[iRow].Cells[iColumn+1].Selected = true;
            }

            //SendKeys.Send("{Tab}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaTypeMas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dgvParaTypeMas.CurrentCell.ColumnIndex;
                int iRow = dgvParaTypeMas.CurrentCell.RowIndex;

                if (iColumn == dgvParaTypeMas.Columns.Count - 1)
                {
                    if (iRow + 1 < dgvParaTypeMas.Rows.Count)
                        dgvParaTypeMas.CurrentCell = dgvParaTypeMas[0, iRow + 1];
                }
                else{
                    dgvParaTypeMas.CurrentCell = dgvParaTypeMas[iColumn + 1, iRow];}

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaTypeMas_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (dgvParaTypeMas.Rows[e.RowIndex].IsNewRow) return;
            //ParaTypeCode = Convert.ToInt32(dgvParaTypeMas.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value);
            //DisplayRecordOfParaValueMas();

        }
        private void dgvParaTypeMas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (e.Row.Index == -1) return;
                //ParaTypeCode = Convert.ToInt32(ds.Tables["PARA_TYPE_MAS"].Rows[e.Row.Index]["PARA_TYPE_CODE"]);
                if (dgvParaTypeMas.Columns.Contains("PARA_TYPE_CODE"))
                {
                    ParaTypeCode = Convert.ToInt32(dgvParaTypeMas.Rows[e.Row.Index].Cells["PARA_TYPE_CODE"].Value);
                    DisplayRecordOfParaValueMas();
                    DisplayRecordOfParaValueResult();
                    DisplayRecordOfParaValueRange();
                    DisplayRecordOfParaValueMethod();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaTypeMas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            //ParaTypeCode = Convert.ToInt32(ds.Tables["PARA_TYPE_MAS"].Rows[e.Row.Index]["PARA_TYPE_CODE"]);
            //ParaTypeCode = Convert.ToInt32(dgvParaTypeMas.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value);
            //DisplayRecordOfParaValueMas();
        }
        private void dgvParaTypeMas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            //ParaTypeCode = Convert.ToInt32(ds.Tables["PARA_TYPE_MAS"].Rows[e.Row.Index]["PARA_TYPE_CODE"]);
            //ParaValueCode = Convert.ToInt32(dgvParaValueMas.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value);
            //DisplayRecordOfParaValueResult();
        }
        #endregion

        #region Para Value Master
        private void DisplayRecordOfParaValueMas()
        {
            try
            {
            GLOBAL.ds.Tables["PARA_VALUE_MAS"].DefaultView.RowFilter = "";
            GLOBAL.ds.Tables["PARA_VALUE_MAS"].DefaultView.RowFilter = "PARA_TYPE_CODE=" + ParaTypeCode;
            dgvParaValueMas.DataSource = GLOBAL.ds.Tables["PARA_VALUE_MAS"].DefaultView;

            if (dgvParaValueMas.RowCount > 0 && dgvParaValueMas.Rows[0].Cells["PARA_VALUE_CODE"].Value != DBNull.Value)
                ParaValueCode = Convert.ToInt32(dgvParaValueMas.Rows[0].Cells["PARA_VALUE_CODE"].Value);          

            GLOBAL.ds.Tables["PARA_VALUE_MAS"].Columns["PARA_TYPE_CODE"].DefaultValue = ParaTypeCode;
            //SetGrid_ParaValueMas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void SetGrid_ParaValueMas()
        {
            try
            {
            dgvParaValueMas.DataSource = GLOBAL.ds.Tables["PARA_VALUE_MAS"];

            dgvParaValueMas.AutoGenerateColumns = false;
            dgvParaValueMas.Columns["PARA_TYPE_CODE"].HeaderText = "Ref. No";
            dgvParaValueMas.Columns["PARA_TYPE_CODE"].Width = 30;
            dgvParaValueMas.Columns["PARA_TYPE_CODE"].ReadOnly = true;
            dgvParaValueMas.Columns["PARA_TYPE_CODE"].ValueType = typeof(System.Int32);

            dgvParaValueMas.Columns["PARA_VALUE_CODE"].HeaderText = "No.";
            dgvParaValueMas.Columns["PARA_VALUE_CODE"].Width = 30;
            dgvParaValueMas.Columns["PARA_VALUE_CODE"].ReadOnly = true;
            dgvParaValueMas.Columns["PARA_VALUE_CODE"].ValueType = typeof(System.Int32);

            dgvParaValueMas.Columns["PARA_VALUE"].HeaderText = "Parameter";
            dgvParaValueMas.Columns["PARA_VALUE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvParaValueMas.Columns["TYPE"].HeaderText = "Sub Type";
            dgvParaValueMas.Columns["TYPE"].Width = 100;

            dgvParaValueMas.Columns["ORD"].HeaderText = "Order";
            dgvParaValueMas.Columns["ORD"].Width = 50;
            dgvParaValueMas.Columns["ORD"].ValueType = typeof(System.Int32);
            dgvParaValueMas.Columns["ORD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvParaValueMas.Columns["TYPE_CODE"].HeaderText = "Type Ord";
            dgvParaValueMas.Columns["TYPE_CODE"].Width = 50;
            dgvParaValueMas.Columns["TYPE_CODE"].ValueType = typeof(System.Int32);
            dgvParaValueMas.Columns["TYPE_CODE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvParaValueMas.Columns[1].ValueType = DataGridViewComboBoxColumn();
            //dgvParaValueMas.Columns[1].HeaderText = "Sub Type";
            //dgvParaValueMas.Columns[1].Items.Add("");
            //dgvParaValueMas.Columns[1].Items.Add("Heading");
            //dgvParaValueMas.Columns[1].Items.Add("Detail");
            //dgvParaValueMas.Columns[1].Name = "TYPE";

            //DataGridViewComboBoxColumn cmbType = new DataGridViewComboBoxColumn();
            //cmbType.Name = "TYPE";
            //cmbType.HeaderText = "Sub Type";
            //cmbType.Items.Add("");
            //cmbType.Items.Add("Heading");
            //cmbType.Items.Add("Detail");
            //cmbType.Name = "TYPE";
            //dgvParaValueMas.Columns.Insert(3, cmbType);

            //dgvParaValueMas.Columns["TYPE"].DisplayIndex = 3;
            //dgvParaValueMas.Sort(dgvParaValueMas.Columns["ORD"], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaValueMas_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            dgvParaValueMas.Rows[e.RowIndex].ErrorText = null;
            if (Convert.IsDBNull(dgvParaValueMas.Rows[e.RowIndex].Cells["PARA_VALUE_CODE"].Value))
            {
                int nextId = 0;
                if (GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows.Count == 0)
                {
                    nextId = 1;
                    dgvParaValueMas.Rows[e.RowIndex].Cells["PARA_VALUE_CODE"].Value = nextId;
                    dgvParaValueMas.Rows[e.RowIndex].Cells["ORD"].Value = 1;
                    dgvParaValueMas.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value = ParaTypeCode;
                    ParaValueCode = nextId;
                }
                else if (e.RowIndex == dgvParaValueMas.Rows.Count - 2)
                {
                    if (ParaTypeCode != 0)
                    {
                            DataRow row = GLOBAL.ds.Tables["PARA_VALUE_MAS"].Select("PARA_VALUE_CODE=MAX(PARA_VALUE_CODE)")[0];
                            nextId = Convert.ToInt32(row["PARA_VALUE_CODE"]) + 1;
                            dgvParaValueMas.Rows[e.RowIndex].Cells["PARA_VALUE_CODE"].Value = nextId;
                            ParaValueCode = nextId;       

                            object Ordrow = GLOBAL.ds.Tables["PARA_VALUE_MAS"].Compute("MAX(ORD)","PARA_TYPE_CODE=" + ParaTypeCode + "");
                            if (Ordrow.ToString()!="")
                            {
                                int ord = Convert.ToInt32(Ordrow) + 1;
                                dgvParaValueMas.Rows[e.RowIndex].Cells["ORD"].Value = ord;
                            }
                            else
                            {
                                dgvParaValueMas.Rows[e.RowIndex].Cells["ORD"].Value = 1;
                                dgvParaValueMas.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value = ParaTypeCode;
                            }
                        }
                    }
                }

            int TypeId = 0;
            if (Convert.ToString(dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE"].Value) != "")
            {
                if (GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows.Count == 0)
                {
                    if (Convert.ToString(dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE"].Value).ToUpper() == "HEADING")
                    {
                        TypeId = 1;
                        dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE_CODE"].Value = TypeId;
                    }
                    else if (Convert.ToString(dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE"].Value).ToUpper() == "DETAIL")
                    {
                        TypeId = 1;
                        dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE_CODE"].Value = TypeId;
                    }
                }
                else if (e.RowIndex == dgvParaValueMas.Rows.Count - 2)
                {
                    if (Convert.ToString(dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE"].Value).ToUpper() == "HEADING")
                    {
                        DataRow row = GLOBAL.ds.Tables["PARA_VALUE_MAS"].Select("TYPE_CODE=MAX(TYPE_CODE)")[0];
                        TypeId = Convert.ToInt32(row["TYPE_CODE"]) + 1;
                        dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE_CODE"].Value = TypeId;
                    }
                    else if (Convert.ToString(dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE"].Value).ToUpper() == "DETAIL")
                    {
                        DataRow row = GLOBAL.ds.Tables["PARA_VALUE_MAS"].Select("TYPE_CODE=MAX(TYPE_CODE)")[0];
                        TypeId = Convert.ToInt32(row["TYPE_CODE"]);
                        dgvParaValueMas.Rows[e.RowIndex].Cells["TYPE_CODE"].Value = TypeId;
                    }
                }
            }
            int iColumn = dgvParaValueMas.CurrentCell.ColumnIndex;
            int iRow = dgvParaValueMas.CurrentCell.RowIndex;

            if (iColumn == dgvParaValueMas.Columns.Count - 1)
            {
                if (iRow + 1 < dgvParaValueMas.Rows.Count)
                {
                    //   dgvParaValueMas.CurrentCell = dgvParaValueMas[0, iRow + 1];
                    dgvParaValueMas.Rows[iRow + 1].Cells[0].Selected = true;
                }
            }
            else
            {
                //   dgvParaValueMas.CurrentCell = dgvParaValueMas[iColumn + 1, iRow];
                dgvParaValueMas.Rows[iRow].Cells[iColumn + 1].Selected = true;
            }

            //SendKeys.Send("{Tab}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaValueMas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvParaValueMas.Rows[e.RowIndex].ErrorText = "";
        }
        private void dgvParaValueMas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dgvParaValueMas.CurrentCell.ColumnIndex;
                int iRow = dgvParaValueMas.CurrentCell.RowIndex;

                if (iColumn == dgvParaValueMas.Columns.Count - 1)
                {
                    if (iRow + 1 < dgvParaValueMas.Rows.Count)
                        dgvParaValueMas.CurrentCell = dgvParaValueMas[0, iRow + 1];
                }
                else
                {
                    dgvParaValueMas.CurrentCell = dgvParaValueMas[iColumn + 1, iRow];
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaValueMas_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
            if (e.Row.Index == -1 ) return;
            if (dgvParaValueMas.Rows[e.Row.Index].IsNewRow) return;
            if (dgvParaValueResult.Columns.Contains("PARA_VALUE_CODE_RESULT"))
            {
                if (dgvParaValueMas.Rows[e.Row.Index].Cells["PARA_VALUE_CODE"].Value!=null && dgvParaValueMas.Rows[e.Row.Index].Cells["PARA_VALUE_CODE"].Value.ToString()!="")
                {
                    ParaValueCode = Convert.ToInt32(dgvParaValueMas.Rows[e.Row.Index].Cells["PARA_VALUE_CODE"].Value);
                    DisplayRecordOfParaValueResult();
                    DisplayRecordOfParaValueRange();
                    DisplayRecordOfParaValueMethod();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured" + ex.Message);
            }
        }
        #endregion
        
        #region Para Value Result
        private void DisplayRecordOfParaValueResult()
        {
            try
            {
            if (GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Columns.Contains("PARA_VALUE_CODE") && ParaValueCode > 0)
            {
                GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].DefaultView.RowFilter = "";
                GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].DefaultView.RowFilter = "PARA_VALUE_CODE=" + ParaValueCode;
                if (GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].DefaultView.Count > 0)
                {
                    dgvParaValueResult.DataSource = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].DefaultView;
                }
                GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Columns["PARA_VALUE_CODE"].DefaultValue = ParaValueCode;
            }
            //SetGrid_ParaValueResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void SetGrid_ParaValueResult()
        {
            try
            {
            if (GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Columns.Count > 0)
            {
                dgvParaValueResult.DataSource = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"];

                dgvParaValueResult.AutoGenerateColumns = false;
                dgvParaValueResult.Columns["PARA_VALUE_CODE_RESULT"].HeaderText = "Ref. No";
                dgvParaValueResult.Columns["PARA_VALUE_CODE_RESULT"].Width = 30;
                dgvParaValueResult.Columns["PARA_VALUE_CODE_RESULT"].ReadOnly = true;
                dgvParaValueResult.Columns["PARA_VALUE_CODE_RESULT"].ValueType = typeof(System.Int32);

                dgvParaValueResult.Columns["RESULT_CODE"].HeaderText = "No.";
                dgvParaValueResult.Columns["RESULT_CODE"].Width = 30;
                dgvParaValueResult.Columns["RESULT_CODE"].ReadOnly = true;
                dgvParaValueResult.Columns["RESULT_CODE"].ValueType = typeof(System.Int32);

                dgvParaValueResult.Columns["RESULT_VALUE"].HeaderText = "Result";
                dgvParaValueResult.Columns["RESULT_VALUE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvParaValueResult.Columns["MESUREMENT"].HeaderText = "Mesurement";
                dgvParaValueResult.Columns["MESUREMENT"].Width = 100;
                dgvParaValueResult.Columns["MESUREMENT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvParaValueResult.Columns["ORD_RESULT"].HeaderText = "Order";
                dgvParaValueResult.Columns["ORD_RESULT"].Width = 80;
                dgvParaValueResult.Columns["ORD_RESULT"].ValueType = typeof(System.Int32);
                dgvParaValueResult.Columns["ORD_RESULT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvParaValueResult.Sort(dgvParaValueResult.Columns["ORD_RESULT"], ListSortDirection.Ascending);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParameterResult_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            dgvParaValueResult.Rows[e.RowIndex].ErrorText = null;
            if (dgvParaValueResult.Rows[e.RowIndex].Cells["RESULT_CODE"].Value.ToString()=="")
            {
                int nextId = 0;
                if (GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Rows.Count == 0)
                {
                    nextId = 1;
                    dgvParaValueResult.Rows[e.RowIndex].Cells["RESULT_CODE"].Value = nextId;
                    dgvParaValueResult.Rows[e.RowIndex].Cells["ORD_RESULT"].Value = 1;
                    dgvParaValueResult.Rows[e.RowIndex].Cells["PARA_VALUE_CODE_RESULT"].Value = ParaValueCode;
                }
                else if (e.RowIndex == dgvParaValueResult.Rows.Count - 2)
                {
                    if (ParaValueCode != 0)
                    {
                        DataRow row = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Select("RESULT_CODE=MAX(RESULT_CODE)")[0];
                        nextId = Convert.ToInt32(row["RESULT_CODE"]) + 1;
                        dgvParaValueResult.Rows[e.RowIndex].Cells["RESULT_CODE"].Value = nextId;

                        object Ordrow = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Compute("MAX(ORD)", "PARA_VALUE_CODE=" + ParaValueCode + "");
                        if (Ordrow.ToString() != "")
                        {
                            int ord = Convert.ToInt32(Ordrow) + 1;
                            dgvParaValueResult.Rows[e.RowIndex].Cells["ORD_RESULT"].Value = ord;
                        }
                        else
                        {
                            dgvParaValueResult.Rows[e.RowIndex].Cells["ORD_RESULT"].Value = 1;
                            dgvParaValueResult.Rows[e.RowIndex].Cells["PARA_VALUE_CODE_RESULT"].Value = ParaValueCode;
                        }
                    }
                }
            }
            
            int iColumn = dgvParaValueResult.CurrentCell.ColumnIndex;
            int iRow = dgvParaValueResult.CurrentCell.RowIndex;

            if (iColumn == dgvParaValueResult.Columns.Count - 1)
            {
                if (iRow + 1 < dgvParaValueResult.Rows.Count)
                {
                    //   dgvParaValueResult.CurrentCell = dgvParaValueResult[0, iRow + 1];
                    dgvParaValueResult.Rows[iRow + 1].Cells[0].Selected = true;
                }
            }
            else
            {
                //   dgvParaValueResult.CurrentCell = dgvParaValueResult[iColumn + 1, iRow];
                dgvParaValueResult.Rows[iRow].Cells[iColumn + 1].Selected = true;
            }

            //SendKeys.Send("{Tab}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParameterResult_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvParaValueResult.Rows[e.RowIndex].ErrorText = "";
           // DataGridViewTextBoxCell cell = dgvParaValueResult[2, e.RowIndex] as DataGridViewTextBoxCell;
        }
        private void dgvParameterResult_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dgvParaValueResult.CurrentCell.ColumnIndex;
                int iRow = dgvParaValueResult.CurrentCell.RowIndex;

                if (iColumn == dgvParaValueResult.Columns.Count - 1)
                {
                    if (iRow + 1 < dgvParaValueResult.Rows.Count)
                        dgvParaValueResult.CurrentCell = dgvParaValueResult[0, iRow + 1];
                }
                else
                {
                    dgvParaValueResult.CurrentCell = dgvParaValueResult[iColumn + 1, iRow];
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #region PARA_VALUE_RANGES
        private void DisplayRecordOfParaValueRange()
        {
            try
            {
            if (GLOBAL.ds.Tables["PARA_VALUE_RANGES"].Columns.Contains("PARA_VALUE_CODE") && ParaValueCode>0)
            {
                GLOBAL.ds.Tables["PARA_VALUE_RANGES"].DefaultView.RowFilter = "";
                GLOBAL.ds.Tables["PARA_VALUE_RANGES"].DefaultView.RowFilter = "PARA_VALUE_CODE=" + ParaValueCode;
                if (GLOBAL.ds.Tables["PARA_VALUE_RANGES"].DefaultView.Count > 0)
                {
                    dgvParaValueRange.DataSource = GLOBAL.ds.Tables["PARA_VALUE_RANGES"].DefaultView;
                }
                GLOBAL.ds.Tables["PARA_VALUE_RANGES"].Columns["PARA_VALUE_CODE"].DefaultValue = ParaValueCode;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void SetGrid_ParaValueRange()
        {
            try
            {
            if (GLOBAL.ds.Tables["PARA_VALUE_RANGES"].Columns.Count > 0)
            {
                dgvParaValueRange.DataSource = GLOBAL.ds.Tables["PARA_VALUE_RANGES"];

                dgvParaValueRange.AutoGenerateColumns = false;
                dgvParaValueRange.Columns["PARA_VALUE_CODE_RANGE"].HeaderText = "Ref. No";
                dgvParaValueRange.Columns["PARA_VALUE_CODE_RANGE"].Width = 30;
                dgvParaValueRange.Columns["PARA_VALUE_CODE_RANGE"].ReadOnly = true;
                dgvParaValueRange.Columns["PARA_VALUE_CODE_RANGE"].ValueType = typeof(System.Int32);

                dgvParaValueRange.Columns["RANGE_CODE"].HeaderText = "No.";
                dgvParaValueRange.Columns["RANGE_CODE"].Width = 30;
                dgvParaValueRange.Columns["RANGE_CODE"].ReadOnly = true;
                dgvParaValueRange.Columns["RANGE_CODE"].ValueType = typeof(System.Int32);

                dgvParaValueRange.Columns["RANGE_VALUE"].HeaderText = "Range";
                dgvParaValueRange.Columns["RANGE_VALUE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvParaValueRange.Columns["AGE_LIMIT"].HeaderText = "Age Limit";
                dgvParaValueRange.Columns["AGE_LIMIT"].Width = 100;
                dgvParaValueRange.Columns["AGE_LIMIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dgvParaValueRange.Columns["ORD_RANGE"].HeaderText = "Order";
                dgvParaValueRange.Columns["ORD_RANGE"].Width = 80;
                dgvParaValueRange.Columns["ORD_RANGE"].ValueType = typeof(System.Int32);
                dgvParaValueRange.Columns["ORD_RANGE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvParaValueRange.Sort(dgvParaValueRange.Columns["ORD_RANGE"], ListSortDirection.Ascending);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaValueRange_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            dgvParaValueRange.Rows[e.RowIndex].ErrorText = null;
            if (dgvParaValueRange.Rows[e.RowIndex].Cells["RANGE_CODE"].Value.ToString() == "")
            {
                int nextId = 0;
                if (GLOBAL.ds.Tables["PARA_VALUE_RANGES"].Rows.Count == 0)
                {
                    nextId = 1;
                    dgvParaValueRange.Rows[e.RowIndex].Cells["RANGE_CODE"].Value = nextId;
                    dgvParaValueRange.Rows[e.RowIndex].Cells["ORD_RANGE"].Value = 1;
                    dgvParaValueRange.Rows[e.RowIndex].Cells["PARA_VALUE_CODE_RANGE"].Value = ParaValueCode;
                }
                else if (e.RowIndex == dgvParaValueRange.Rows.Count - 2)
                {
                    if (ParaValueCode != 0)
                    {
                        DataRow row = GLOBAL.ds.Tables["PARA_VALUE_RANGES"].Select("RANGE_CODE=MAX(RANGE_CODE)")[0];
                        nextId = Convert.ToInt32(row["RANGE_CODE"]) + 1;
                        dgvParaValueRange.Rows[e.RowIndex].Cells["RANGE_CODE"].Value = nextId;

                        object Ordrow = GLOBAL.ds.Tables["PARA_VALUE_RANGES"].Compute("MAX(ORD)", "PARA_VALUE_CODE=" + ParaValueCode + "");
                        if (Ordrow.ToString() != "")
                        {
                            int ord = Convert.ToInt32(Ordrow) + 1;
                            dgvParaValueRange.Rows[e.RowIndex].Cells["ORD_RANGE"].Value = ord;
                        }
                        else
                        {
                            dgvParaValueRange.Rows[e.RowIndex].Cells["ORD_RANGE"].Value = 1;
                            dgvParaValueRange.Rows[e.RowIndex].Cells["PARA_VALUE_CODE_RANGE"].Value = ParaValueCode;
                        }
                    }
                }
            }


            int iColumn = dgvParaValueRange.CurrentCell.ColumnIndex;
            int iRow = dgvParaValueRange.CurrentCell.RowIndex;

            if (iColumn == dgvParaValueRange.Columns.Count - 1)
            {
                if (iRow + 1 < dgvParaValueRange.Rows.Count)
                {
                    //   dgvParaValueRange.CurrentCell = dgvParaValueRange[0, iRow + 1];
                    dgvParaValueRange.Rows[iRow + 1].Cells[0].Selected = true;
                }
            }
            else
            {
                //   dgvParaValueRange.CurrentCell = dgvParaValueRange[iColumn + 1, iRow];
                dgvParaValueRange.Rows[iRow].Cells[iColumn + 1].Selected = true;
            }

            //SendKeys.Send("{Tab}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaValueRange_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvParaValueRange.Rows[e.RowIndex].ErrorText = "";
            //DataGridViewTextBoxCell cell = dgvParaValueRange[2, e.RowIndex] as DataGridViewTextBoxCell;
        }
        private void dgvParaValueRange_KeyDown(object sender, KeyEventArgs e)
        {
            try{

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dgvParaValueRange.CurrentCell.ColumnIndex;
                int iRow = dgvParaValueRange.CurrentCell.RowIndex;

                if (iColumn == dgvParaValueRange.Columns.Count - 1)
                {
                    if (iRow + 1 < dgvParaValueRange.Rows.Count)
                        dgvParaValueRange.CurrentCell = dgvParaValueRange[0, iRow + 1];
                }
                else
                {
                    dgvParaValueRange.CurrentCell = dgvParaValueRange[iColumn + 1, iRow];
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #region Para Value Method
        private void DisplayRecordOfParaValueMethod()
        {
            try
            {
            if (GLOBAL.ds.Tables["PARA_VALUE_METHOD"].Columns.Contains("PARA_VALUE_CODE") && ParaValueCode > 0)
            {
                GLOBAL.ds.Tables["PARA_VALUE_METHOD"].DefaultView.RowFilter = "";
                GLOBAL.ds.Tables["PARA_VALUE_METHOD"].DefaultView.RowFilter = "PARA_VALUE_CODE=" + ParaValueCode;
                if (GLOBAL.ds.Tables["PARA_VALUE_METHOD"].DefaultView.Count > 0)
                {
                    dgvParaValueMethod.DataSource = GLOBAL.ds.Tables["PARA_VALUE_METHOD"].DefaultView;
                }
                GLOBAL.ds.Tables["PARA_VALUE_METHOD"].Columns["PARA_VALUE_CODE"].DefaultValue = ParaValueCode;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void SetGrid_ParaValueMethod()
        {
            try
            {
            dgvParaValueMethod.DataSource = GLOBAL.ds.Tables["PARA_VALUE_METHOD"];

            //dgvParaValueMethod.AutoGenerateColumns = false;
            dgvParaValueMethod.Columns["PARA_VALUE_CODE"].HeaderText = "Ref. No";
            dgvParaValueMethod.Columns["PARA_VALUE_CODE"].Width = 30;
            dgvParaValueMethod.Columns["PARA_VALUE_CODE"].ReadOnly = true;
            dgvParaValueMethod.Columns["PARA_VALUE_CODE"].ValueType = typeof(System.Int32);

            dgvParaValueMethod.Columns["METHOD_CODE"].HeaderText = "No.";
            dgvParaValueMethod.Columns["METHOD_CODE"].Width = 30;
            dgvParaValueMethod.Columns["METHOD_CODE"].ReadOnly = true;
            dgvParaValueMethod.Columns["METHOD_CODE"].ValueType = typeof(System.Int32);

            dgvParaValueMethod.Columns["METHOD_NAME"].HeaderText = "Method Name";
            dgvParaValueMethod.Columns["METHOD_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvParaValueMethod.Columns["ORD"].HeaderText = "Order";
            dgvParaValueMethod.Columns["ORD"].Width = 50;
            dgvParaValueMethod.Columns["ORD"].ValueType = typeof(System.Int32);
            dgvParaValueMethod.Columns["ORD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaValueMethod_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            dgvParaValueMethod.Rows[e.RowIndex].ErrorText = null;
            if (Convert.IsDBNull(dgvParaValueMethod.Rows[e.RowIndex].Cells["METHOD_CODE"].Value))
            {
                int nextId = 0;
                if (GLOBAL.ds.Tables["PARA_VALUE_METHOD"].Rows.Count == 0)
                {
                    nextId = 1;
                    dgvParaValueMethod.Rows[e.RowIndex].Cells["METHOD_CODE"].Value = nextId;
                    dgvParaValueMethod.Rows[e.RowIndex].Cells["ORD"].Value = 1;
                    dgvParaValueMethod.Rows[e.RowIndex].Cells["PARA_VALUE_CODE"].Value = ParaValueCode;
                }
                else if (e.RowIndex == dgvParaValueMethod.Rows.Count - 2)
                {
                    if (ParaValueCode != 0)
                    {
                        DataRow row = GLOBAL.ds.Tables["PARA_VALUE_METHOD"].Select("METHOD_CODE=MAX(METHOD_CODE)")[0];
                        nextId = Convert.ToInt32(row["METHOD_CODE"]) + 1;
                        dgvParaValueMethod.Rows[e.RowIndex].Cells["METHOD_CODE"].Value = nextId;

                        object Ordrow = GLOBAL.ds.Tables["PARA_VALUE_METHOD"].Compute("MAX(ORD)", "PARA_VALUE_CODE=" + ParaValueCode + "");
                        if (Ordrow.ToString() != "")
                        {
                            int ord = Convert.ToInt32(Ordrow) + 1;
                            dgvParaValueMethod.Rows[e.RowIndex].Cells["ORD"].Value = ord;
                        }
                        else
                        {
                            dgvParaValueMethod.Rows[e.RowIndex].Cells["ORD"].Value = 1;
                            dgvParaValueMethod.Rows[e.RowIndex].Cells["PARA_VALUE_CODE"].Value = ParaValueCode;
                        }
                    }
                }
            }

            int iColumn = dgvParaValueMethod.CurrentCell.ColumnIndex;
            int iRow = dgvParaValueMethod.CurrentCell.RowIndex;

            if (iColumn == dgvParaValueMethod.Columns.Count - 1)
            {
                if (iRow + 1 < dgvParaValueMethod.Rows.Count)
                {
                    //   dgvParaValueMethod.CurrentCell = dgvParaValueMethod[0, iRow + 1];
                    dgvParaValueMethod.Rows[iRow + 1].Cells[0].Selected = true;
                }
            }
            else
            {
                //   dgvParaValueMethod.CurrentCell = dgvParaValueMethod[iColumn + 1, iRow];
                dgvParaValueMethod.Rows[iRow].Cells[iColumn + 1].Selected = true;
            }

            //SendKeys.Send("{Tab}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvParaValueMethod_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvParaValueMethod.Rows[e.RowIndex].ErrorText = "";
        }
        private void dgvParaValueMethod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dgvParaValueMethod.CurrentCell.ColumnIndex;
                int iRow = dgvParaValueMethod.CurrentCell.RowIndex;

                if (iColumn == dgvParaValueMethod.Columns.Count - 1)
                {
                    if (iRow + 1 < dgvParaValueMethod.Rows.Count)
                        dgvParaValueMethod.CurrentCell = dgvParaValueMethod[0, iRow + 1];
                }
                else
                {
                    dgvParaValueMethod.CurrentCell = dgvParaValueMethod[iColumn + 1, iRow];
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #region Error handling Events
        private void dgvParaTypeMas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("PARA TYPE MAS");
        }
        private void dgvParaValueMethod_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("PARA TYPE METHOD");
        }
        private void dgvParaValueMas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("PARA VALUE MAS");
        }
        private void dgvParaValueResult_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("PARA VALUE RESULT");
        }
        private void dgvParaValueRange_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("PARA VALUE RANGE");
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void dgvParaValueRange_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
