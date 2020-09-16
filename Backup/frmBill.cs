using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
namespace Lab
{
    public partial class frmBill : BaseForm
    {
        int BillNo = 0;
        #region Form Events
        public frmBill()
        {
            InitializeComponent();
        }
        private void frmBill_Load(object sender, EventArgs e)
        {
            #region Declare Events
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);

            this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            this.btn_last.Click += new System.EventHandler(this.btn_last_Click);
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);

            this.txtAge.Validated += new System.EventHandler(this.txtAge_Validated);
            this.cmbPName.Validated += new System.EventHandler(this.cmbPName_Validated);
            this.cmbRefName.Validated += new System.EventHandler(this.cmbRefName_Validated);
            this.txtLabNo.Validated += new System.EventHandler(this.txtLabNo_Validated);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);

            #endregion

            #region Fill Controls
            AutoCompleteLabNo();
            FillPName();
            FillRefName();
            #endregion

            #region Set Grid
            //SetGrid_BillTrans();
            DisplayRecordOfBillTrans();
            #endregion

            FirstRecord();
            ENABLE_DISABLE_CONTROLS(false);
        }
        private void frmBill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Main Function

        #region Trans Functions
        private void ClearAll()
        {
            txtBillNo.Text = "";
            txtBillDate.Text = "";
            txtAddress.Text = "";
            txtAge.Text = "";
            txtLabNo.Text = "";
            txtPCode.Text = "";
            cmbPName.Text = "";
            cmbSex.Text = "";
            txtRefCode.Text = "";
            cmbRefName.Text = "";
            txtTotalAmt.Text = "";
            txtLessAmt.Text = "";
            txtNetAmt.Text = "";

            dgvTestDetails.DataSource = null;
            dgvTestDetails.Columns.Remove("PARA_TYPE");
            dgvTestDetails.Columns.Remove("PRICE");
            
        }
        private void NewRecord()
        {
            ClearAll();
            txtBillNo.Text = GetNewID("BILL_NO", "BILL_MAS").ToString();
            txtBillDate.Text = System.DateTime.Today.ToShortDateString();
            BillNo = Convert.ToInt32(txtBillNo.Text);
            txtTotalAmt.Text = "0";
            txtLessAmt.Text = "0";
            txtNetAmt.Text = "0";
            ENABLE_DISABLE_CONTROLS(true);
            DisplayRecordOfBillTrans();
            txtLabNo.Focus();
        }
        private void SaveRecord()
        {
            #region Save BILL_MAS
            if (GLOBAL.ds.Tables["BILL_MAS"].Rows.Count == 0 && txtPCode.Text != "")
            {
                GLOBAL.ds.Tables["BILL_MAS"].Rows.Add(Convert.ToInt32(txtBillNo.Text), txtBillDate.Text, System.DateTime.Today.ToShortTimeString(), Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtTotalAmt.Text), Convert.ToInt32(txtLessAmt.Text), Convert.ToInt32(txtNetAmt.Text));
            }
            else if (GLOBAL.ds.Tables["BILL_MAS"].Rows.Count > 0 && txtBillNo.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["BILL_MAS"].Select("BILL_NO=" + Convert.ToInt32(txtBillNo.Text));
                if (row.Length != 0)
                {
                    if (row[0].IsNull("BILL_NO"))
                    {
                        GLOBAL.ds.Tables["BILL_MAS"].Rows.Add(Convert.ToInt32(txtBillNo.Text), txtBillDate.Text, System.DateTime.Today.ToShortTimeString(), Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtTotalAmt.Text), Convert.ToInt32(txtLessAmt.Text), Convert.ToInt32(txtNetAmt.Text));
                    }
                    else
                    {
                        int rowIndex = GLOBAL.ds.Tables["BILL_MAS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["BILL_DATE"] = txtBillDate.Text;
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["BILL_TIME"] = System.DateTime.Today.ToShortTimeString();
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["LAB_CODE"] = txtLabNo.Text;
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["TOTAL_AMT"] = txtTotalAmt.Text;
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["LESS_AMT"] = txtLessAmt.Text;
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["NET_AMT"] = txtNetAmt.Text;
                    }
                }
                else
                    GLOBAL.ds.Tables["BILL_MAS"].Rows.Add(Convert.ToInt32(txtBillNo.Text), txtBillDate.Text, System.DateTime.Today.ToShortTimeString(), Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtTotalAmt.Text), Convert.ToInt32(txtLessAmt.Text), Convert.ToInt32(txtNetAmt.Text));
            }
            #endregion

            #region Save BILL_TRANS

            #endregion
        }
        private void DeleteRecord()
        {
            if (GLOBAL.ds.Tables["BILL_MAS"].Rows.Count > 0 && txtPCode.Text != "")
            {
                if (GLOBAL.ds.Tables["BILL_TRANS"].Rows.Count > 0 && txtPCode.Text != "")
                {
                    DataRow[] row = GLOBAL.ds.Tables["BILL_TRANS"].Select("BILL_NO=" + Convert.ToInt32(txtBillNo.Text));
                    if (row.Length != 0)
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (!row[i].IsNull("BILL_NO"))
                            {
                                int rowIndex = GLOBAL.ds.Tables["BILL_TRANS"].Rows.IndexOf(row[i]);
                                GLOBAL.ds.Tables["BILL_TRANS"].Rows.RemoveAt(rowIndex);
                            }
                        }
                    }
                }

                DataRow[] rw = GLOBAL.ds.Tables["BILL_MAS"].Select("BILL_NO=" + Convert.ToInt32(txtBillNo.Text));
                if (rw.Length != 0)
                {
                    if (!rw[0].IsNull("BILL_NO"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["BILL_MAS"].Rows.IndexOf(rw[0]);
                        GLOBAL.ds.Tables["BILL_MAS"].Rows.RemoveAt(rowIndex);
                        ClearAll();
                        FillRecord(rowIndex - 1);
                    }
                }

            }
        }
        private void CancelRecord()
        {
            ClearAll();
            LasRecord();
            ENABLE_DISABLE_CONTROLS(false);

        }
        private void FillRecord(int Index)
        {
            if (GLOBAL.ds.Tables["BILL_MAS"].Rows.Count > 0 && Index < GLOBAL.ds.Tables["BILL_MAS"].Rows.Count)
            {
                #region Master
                #region Fill Bill Mas
                txtBillNo.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["BILL_NO"].ToString();
                txtBillDate.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["BILL_DATE"].ToString();
                txtLabNo.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["LAB_CODE"].ToString();
                txtTotalAmt.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["TOTAL_AMT"].ToString();
                txtLessAmt.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["LESS_AMT"].ToString();
                txtNetAmt.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["NET_AMT"].ToString();
                BillNo = Convert.ToInt32(txtBillNo.Text);
                #endregion

                #region Fill Lab Details
                DataRow[] rowp = GLOBAL.ds.Tables["LAB_MAS"].Select("LAB_CODE=" + Convert.ToInt32(txtLabNo.Text));
                if (rowp.Length != 0)
                {
                    if (!rowp[0].IsNull("LAB_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["LAB_MAS"].Rows.IndexOf(rowp[0]);
                        txtPCode.Text = GLOBAL.ds.Tables["LAB_MAS"].Rows[rowIndex]["P_CODE"].ToString();
                        txtRefCode.Text = GLOBAL.ds.Tables["LAB_MAS"].Rows[rowIndex]["R_CODE"].ToString();
                        //txtBillDate.Text = GLOBAL.ds.Tables["LAB_MAS"].Rows[rowIndex]["LAB_DATE"].ToString();
                    }
                }

                
                #endregion

                #region Fill Patient Details
                if (txtPCode.Text != "")
                {
                    DataRow[] rw = GLOBAL.ds.Tables["PATIENT_MAS"].Select("P_CODE=" + Convert.ToInt32(txtPCode.Text));
                    if (rw.Length != 0)
                    {
                        if (!rw[0].IsNull("P_CODE"))
                        {
                            int rowIndex = GLOBAL.ds.Tables["PATIENT_MAS"].Rows.IndexOf(rw[0]);
                            cmbPName.Text = GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["P_NAME"].ToString();
                            txtAge.Text = GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["P_AGE"].ToString();
                            cmbSex.Text = GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["P_SEX"].ToString();
                            txtAddress.Text = GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["P_AREA"].ToString();
                        }
                    }
                }
                #endregion

                #region Fill Ref. Dr Details
                if (txtRefCode.Text != "")
                {
                    DataRow[] dr = GLOBAL.ds.Tables["REF_DR_MAS"].Select("R_CODE=" + Convert.ToInt32(txtRefCode.Text));
                    if (dr.Length != 0)
                    {
                        if (!dr[0].IsNull("R_CODE"))
                        {
                            int rowIndex = GLOBAL.ds.Tables["REF_DR_MAS"].Rows.IndexOf(dr[0]);
                            cmbRefName.Text = GLOBAL.ds.Tables["REF_DR_MAS"].Rows[rowIndex]["R_NAME"].ToString();
                        }
                    }
                }
                #endregion
                #endregion

                #region Grid Details

                DisplayRecordOfBillTrans();
                //for (int i = 0; i < dgvTestDetails.Rows.Count-1; i++)
                //{
                //    dgvTestDetails.Rows.RemoveAt(i);
                //}

                //if (GLOBAL.ds.Tables["BILL_TRANS"].Rows.Count > 0)
                //{
                //    DataRow[] drow = GLOBAL.ds.Tables["BILL_TRANS"].Select("BILL_NO=" + BillNo);
                //    if (drow.Length != 0)
                //    {
                //        for (int i = 0; i < drow.Length; i++)
                //        {
                //            if (!drow[i].IsNull("BILL_NO"))
                //            {
                //                int Code = Convert.ToInt32(GLOBAL.ds.Tables["BILL_TRANS"].Rows[i]["PARA_TYPE_CODE"]);
                //                string ParaType = "";
                //                double Price = 0;
                //                DataRow drtest = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("PARA_TYPE_CODE=" + Code)[0];
                //                if (!drtest.IsNull("PARA_TYPE_CODE"))
                //                {
                //                    int idx = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows.IndexOf(drtest);
                //                    ParaType = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[idx]["PARA_TYPE"].ToString();
                //                    Price = Convert.ToDouble(GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[idx]["PRICE"]);
                //                }

                //                dgvTestDetails.Rows[i].Cells["PARA_TYPE"].Value = ParaType;
                //                dgvTestDetails.Rows[i].Cells["PRICE"].Value = Price;
                //            }
                //        }

                //    }
                //}
                #endregion

                //dgvTestDetails.Focus();
            }
        }
        private void CalculateTotal()
        {
            int TAmt = 0, LessAmt = 0, NetAmt = 0;
            for (int i = 0; i < dgvTestDetails.Rows.Count - 1; i++)
            {
                if (dgvTestDetails.Columns.Contains("PRICE"))
                {
                    TAmt += Convert.ToInt32(dgvTestDetails.Rows[i].Cells["PRICE"].Value);    
                }
            }
            txtTotalAmt.Text = TAmt.ToString();
            NetAmt = TAmt;
            if (Convert.ToString(txtLessAmt.Text) !="" && Convert.ToInt32(txtLessAmt.Text)!=0)
            {
                LessAmt = Convert.ToInt32(txtLessAmt.Text);
                NetAmt = TAmt - LessAmt;
            }
            txtLessAmt.Text = LessAmt.ToString();
            txtNetAmt.Text = NetAmt.ToString();
        }
        #endregion

        #region Navigation Functions
        private void FirstRecord()
        {
            FillRecord(0);
        }
        private void NextRecord()
        {
            if (txtBillNo.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["BILL_MAS"].Select("BILL_NO=" + Convert.ToInt32(txtBillNo.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("BILL_NO"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["BILL_MAS"].Rows.IndexOf(row[0]);
                        if (rowIndex >= 0 && rowIndex != GLOBAL.ds.Tables["BILL_MAS"].Rows.Count - 1)
                        {
                            FillRecord(rowIndex + 1);
                        }
                        else
                        {
                            FillRecord(GLOBAL.ds.Tables["BILL_MAS"].Rows.Count - 1);
                        }
                    }
                }
            }
            else
            {
                FillRecord(0);
            }
        }
        private void PreviousRecord()
        {
            if (txtBillNo.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["BILL_MAS"].Select("BILL_NO=" + Convert.ToInt32(txtBillNo.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("BILL_NO"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["BILL_MAS"].Rows.IndexOf(row[0]);
                        if (rowIndex > 0 && rowIndex != GLOBAL.ds.Tables["BILL_MAS"].Rows.Count)
                        {
                            FillRecord(rowIndex - 1);
                        }
                        else
                        {
                            FillRecord(0);
                        }
                    }
                }
            }
            else
            {
                FillRecord(0);
            }
        }
        private void LasRecord()
        {
            FillRecord(GLOBAL.ds.Tables["BILL_MAS"].Rows.Count - 1);
        }
        #endregion

        #region Common Functions
        private int GetNewID(string FieldName, string TableName)
        {
            int nextId = 0;
            if (GLOBAL.ds.Tables[TableName].Rows.Count == 0)
            {
                nextId = 1;
            }
            else
            {
                DataRow row = GLOBAL.ds.Tables[TableName].Select("" + FieldName + "=MAX(" + FieldName + ")")[0];
                nextId = Convert.ToInt32(row[FieldName]) + 1;
            }

            return nextId;
        }
        private void FillLabDetail(string Code)
        {
            if (GLOBAL.ds.Tables["LAB_MAS"].Rows.Count > 0)
            {
                DataRow[] row = GLOBAL.ds.Tables["LAB_MAS"].Select("LAB_CODE=" + Code);
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("P_CODE") || !row[0].IsNull("R_CODE"))
                    {
                        txtPCode.Text = row[0]["P_CODE"].ToString();
                        txtRefCode.Text = row[0]["R_CODE"].ToString();
                    }
                }

                if (GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Count > 0 && txtPCode.Text!="")
                {
                    DataRow[] dr = GLOBAL.ds.Tables["PATIENT_MAS"].Select("P_CODE=" + Convert.ToInt32(txtPCode.Text));
                    if (dr.Length != 0)
                    {
                        if (!dr[0].IsNull("P_AGE") || !dr[0].IsNull("P_SEX") || !dr[0].IsNull("P_AREA"))
                        {
                            cmbPName.Text = dr[0]["P_NAME"].ToString();
                            txtAge.Text = dr[0]["P_AGE"].ToString();
                            cmbSex.Text = dr[0]["P_SEX"].ToString();
                            txtAddress.Text = dr[0]["P_AREA"].ToString();
                        }
                    }
                }

                if (GLOBAL.ds.Tables["REF_DR_MAS"].Rows.Count > 0 && txtRefCode.Text != "")
                {
                    DataRow[] dr1 = GLOBAL.ds.Tables["REF_DR_MAS"].Select("R_CODE=" + Convert.ToInt32(txtRefCode.Text));
                    if (dr1.Length != 0)
                    {
                        if (!dr1[0].IsNull("R_NAME"))
                        {
                            cmbRefName.Text = dr1[0]["R_NAME"].ToString();
                        }
                    }
                }
            }

        }
        private void FillPateintDetail(string Code)
        {
            if (GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Count > 0)
            {
                DataRow[] row = GLOBAL.ds.Tables["PATIENT_MAS"].Select("P_CODE=" + Code);
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("P_AGE") || !row[0].IsNull("P_SEX") || !row[0].IsNull("P_AREA"))
                    {
                        cmbPName.Text = row[0]["P_NAME"].ToString();
                        txtAge.Text = row[0]["P_AGE"].ToString();
                        cmbSex.Text = row[0]["P_SEX"].ToString();
                        txtAddress.Text = row[0]["P_AREA"].ToString();
                    }
                }
            }
        }
        private void FillReferenceDetail(string Code)
        {
            if (GLOBAL.ds.Tables["REF_DR_MAS"].Rows.Count > 0)
            {
                DataRow[] row = GLOBAL.ds.Tables["REF_DR_MAS"].Select("R_CODE=" + Code);
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("R_NAME"))
                    {
                        cmbRefName.Text = row[0]["R_NAME"].ToString();
                    }
                }
            }
        }
        private void FillPName()
        {
            cmbPName.DataSource = GLOBAL.ds.Tables["PATIENT_MAS"];
            cmbPName.DisplayMember = "P_NAME";
            cmbPName.ValueMember = "P_CODE";
        }
        private void FillRefName()
        {
            cmbRefName.DataSource = GLOBAL.ds.Tables["REF_DR_MAS"];
            cmbRefName.DisplayMember = "R_NAME";
            cmbRefName.ValueMember = "R_CODE";
        }
        private void AutoCompleteLabNo()
        {
            AutoCompleteStringCollection strLabNo = new AutoCompleteStringCollection();
            for (int i = 0; i < GLOBAL.ds.Tables["LAB_MAS"].Rows.Count; i++)
            {
                strLabNo.Add(GLOBAL.ds.Tables["LAB_MAS"].Rows[i]["LAB_CODE"].ToString());
            }

            txtLabNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtLabNo.AutoCompleteCustomSource = strLabNo;
            txtLabNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ENABLE_DISABLE_CONTROLS(bool Val)
        {
            btn_Cancel.Enabled = Val;
            btn_Clear.Enabled = Val;
            btn_Save.Enabled = Val;
            btn_Edit.Enabled = !Val;
            btn_New.Enabled = !Val;
            btn_Delete.Enabled = !Val;
            btnPrint.Enabled = !Val;
        }
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

        #region Bill Trans
        private void SetGrid_BillTrans()
        {
            try
            {
                if (dgvTestDetails.Columns.Contains("PARA_TYPE"))
                    dgvTestDetails.Columns.Remove("PARA_TYPE");
                
                if (dgvTestDetails.Columns.Contains("PRICE"))
                    dgvTestDetails.Columns.Remove("PRICE");


                GLOBAL.ds.Tables["BILL_TRANS"].DefaultView.RowFilter = "";
                if (BillNo != 0)
                {
                    GLOBAL.ds.Tables["BILL_TRANS"].DefaultView.RowFilter = "BILL_NO=" + BillNo;

                    //dgvTestDetails.DataSource = null;
                    dgvTestDetails.DataSource = GLOBAL.ds.Tables["BILL_TRANS"].DefaultView;
                }
                else
                {
                    dgvTestDetails.DataSource = GLOBAL.ds.Tables["BILL_TRANS"];
                }

                //dgvTestDetails.AutoGenerateColumns = false;

                dgvTestDetails.Columns["BILL_NO"].HeaderText = "Ref. No";
                dgvTestDetails.Columns["BILL_NO"].Width = 30;
                dgvTestDetails.Columns["BILL_NO"].ReadOnly = true;
                dgvTestDetails.Columns["BILL_NO"].ValueType = typeof(System.Int32);

                dgvTestDetails.Columns["DETAILID"].HeaderText = "No.";
                dgvTestDetails.Columns["DETAILID"].Width = 30;
                dgvTestDetails.Columns["DETAILID"].ReadOnly = true;
                dgvTestDetails.Columns["DETAILID"].ValueType = typeof(System.Int32);

                dgvTestDetails.Columns["PARA_TYPE_CODE"].HeaderText = "No.";
                dgvTestDetails.Columns["PARA_TYPE_CODE"].Width = 30;
                dgvTestDetails.Columns["PARA_TYPE_CODE"].ReadOnly = true;
                dgvTestDetails.Columns["PARA_TYPE_CODE"].ValueType = typeof(System.Int32);

                DataTable DtPara=new DataTable();
                DtPara=GLOBAL.ds.Tables["PARA_TYPE_MAS"].Copy();
                DataGridViewComboBoxColumn cmbTestName = new DataGridViewComboBoxColumn();
                cmbTestName.HeaderText = "Test Name";
                cmbTestName.Name = "PARA_TYPE";
                cmbTestName.DataSource = DtPara;
                cmbTestName.DisplayMember = "PARA_TYPE";
                cmbTestName.ValueMember = "PARA_TYPE";
                cmbTestName.Width = 150;
                cmbTestName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTestDetails.Columns.Add(cmbTestName);

                DataGridViewTextBoxColumn txtprice = new DataGridViewTextBoxColumn();
                txtprice.HeaderText = "Price";
                txtprice.Name = "PRICE";
                txtprice.ValueType = typeof(System.Decimal);
                txtprice.Width = 80;
                txtprice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                txtprice.DefaultCellStyle.Format = "#.##";
                dgvTestDetails.Columns.Add(txtprice);

                //DisplayRecordOfBillTrans();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void DisplayRecordOfBillTrans()
        {
            try
            {
                //GLOBAL.ds.Tables["BILL_TRANS"].DefaultView.RowFilter = "";
                //GLOBAL.ds.Tables["BILL_TRANS"].DefaultView.RowFilter = "BILL_NO=" + BillNo;

                //dgvTestDetails.DataSource = null;
                //dgvTestDetails.DataSource = GLOBAL.ds.Tables["BILL_TRANS"].DefaultView;


                //GLOBAL.ds.Tables["BILL_TRANS"].Columns["PARA_TYPE_CODE"].DefaultValue = BillNo;

                //for (int i = 0; i < GLOBAL.ds.Tables["BILL_TRANS"].DefaultView.Count; i++)
                //{

                SetGrid_BillTrans();

                int TAmt = 0,LessAmt=0,NetAmt=0;
                for (int i = 0; i < dgvTestDetails.Rows.Count-1; i++)
                {
                     //GLOBAL.ds.Tables["BILL_TRANS"].DefaultView.
                    //int Code = Convert.ToInt32(GLOBAL.ds.Tables["BILL_TRANS"].Rows[i]["PARA_TYPE_CODE"]);
                    int Code = Convert.ToInt32(dgvTestDetails.Rows[i].Cells["PARA_TYPE_CODE"].Value);
                    string ParaType = "";
                    int Price = 0;
                    DataRow[] drtest = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("PARA_TYPE_CODE=" + Code);
                    
                    if (!drtest[0].IsNull("PARA_TYPE_CODE"))
                    {
                        int idx = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows.IndexOf(drtest[0]);
                        ParaType = Convert.ToString(GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[idx]["PARA_TYPE"]);
                        Price = Convert.ToInt32(GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[idx]["PRICE"]);
                        TAmt += Price;
                    }

                    //int rowIndex = GLOBAL.ds.Tables["BILL_TRANS"].Rows.IndexOf(drtest[0]);
                    dgvTestDetails.Rows[i].Cells["PARA_TYPE"].Value = ParaType;
                    dgvTestDetails.Rows[i].Cells["PRICE"].Value = Price;

                }

                txtTotalAmt.Text = TAmt.ToString();
                NetAmt = TAmt;
                if (Convert.ToString(txtLessAmt.Text) != "" && Convert.ToInt32(txtLessAmt.Text) != 0)
                {
                    LessAmt = Convert.ToInt32(txtLessAmt.Text);
                    NetAmt = TAmt - LessAmt;
                }
                txtLessAmt.Text = LessAmt.ToString();
                txtNetAmt.Text = NetAmt.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #endregion

        #region Trans Control Events
        private void btn_New_Click(object sender, EventArgs e)
        {
            NewRecord();
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtLabNo.Text == "")
            {
                ShowMessagePrompt("First Generate Lab No", "");
                return;
            }
            if (txtPCode.Text == "")
            {
                ShowMessagePrompt("Enter Patient Name", "");
                return;
            }
            ShowMessagePrompt("", "");
            SaveRecord();
            GLOBAL.SaveDB();
            //NextRecord();
            ShowMessagePrompt("Record save successfully", "S");
            ENABLE_DISABLE_CONTROLS(false);
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            CancelRecord();
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
            ENABLE_DISABLE_CONTROLS(false);
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ClearAll();
            ENABLE_DISABLE_CONTROLS(false);
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Find_Click(object sender, EventArgs e)
        {
            //frmDatabase objpara = new frmDatabase();
            //objpara.MdiParent = this;
            //objpara.Show();

            
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            BillInExcel();
            //printBill();
            //frmReportViewer obj = new frmReportViewer();
            //obj.Build_Report("");
        }
        #endregion

        #region Navigation Control Events
        private void btn_First_Click(object sender, EventArgs e)
        {
            FirstRecord();
        }
        private void btn_previous_Click(object sender, EventArgs e)
        {
            PreviousRecord();
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            NextRecord();
        }
        private void btn_last_Click(object sender, EventArgs e)
        {
            LasRecord();
        }
        #endregion

        #region Combo And Text Events
        private void txtLabNo_Validated(object sender, EventArgs e)
        {
            if (txtLabNo.Text != "")
            {
                FillLabDetail(txtLabNo.Text);
            }
        }
        private void cmbPName_Validated(object sender, EventArgs e)
        {
            if (cmbPName.SelectedValue != null)
            {
                txtPCode.Text = cmbPName.SelectedValue.ToString();
            }
            if (txtPCode.Text == "" && cmbPName.Text != "")
            {
                txtPCode.Text = GetNewID("P_CODE", "PATIENT_MAS").ToString();
            }
            else if (txtPCode.Text != "" && cmbPName.Text != "")
            {
                FillPateintDetail(txtPCode.Text);
            }
        }
        private void txtAge_Validated(object sender, EventArgs e)
        {
            char[] chars = txtAge.Text.ToString().ToCharArray();
            bool IsNumeric = true;
            foreach (char c in chars)
            {
                if (char.IsDigit(c) == false)
                {
                    ShowMessagePrompt("You have to enter Age only", "");
                    IsNumeric = false;
                    txtAge.Focus();
                    break;
                }
            }
            if (IsNumeric)
            {
                ShowMessagePrompt("", "S");
            }
            cmbSex.Focus();
        }
        private void cmbRefName_Validated(object sender, EventArgs e)
        {
            if (cmbRefName.SelectedValue != null)
            {
                txtRefCode.Text = cmbRefName.SelectedValue.ToString();
            }
            if (txtRefCode.Text == "" && cmbRefName.Text != "")
            {
                txtRefCode.Text = GetNewID("R_CODE", "REF_DR_MAS").ToString();
            }
            else if (txtRefCode.Text != "" && cmbRefName.Text != "")
            {
                FillReferenceDetail(txtRefCode.Text);
            }
        }
        private void txtAddress_Validated(object sender, EventArgs e)
        {
            cmbRefName.Focus();

        }
        private void txtLessAmt_Validated(object sender, EventArgs e)
        {
            int LessAmt = Convert.ToInt32(txtLessAmt.Text);
            int TAmt = Convert.ToInt32(txtTotalAmt.Text);
            if (TAmt >= LessAmt)
            {
                txtNetAmt.Text = Convert.ToString(TAmt - LessAmt);
            }
            else
            {
                txtLessAmt.Text = "0";
                txtNetAmt.Text = txtTotalAmt.Text;
            }
        }
        private void txtLabNo_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtBillDate_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void cmbPName_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void cmbSex_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void cmbRefName_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtLessAmt_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        #endregion

        #region Grid Events
        private void dgvTestDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvTestDetails.Rows[e.RowIndex].ErrorText = null;
                if (dgvTestDetails.Rows[e.RowIndex].IsNewRow) return;
                if (dgvTestDetails.Rows[e.RowIndex].Cells["DETAILID"].Value.ToString() == "")
                {
                    int nextId = 0;
                    if (GLOBAL.ds.Tables["BILL_TRANS"].Rows.Count == 0)
                    {
                        nextId = 1;
                        dgvTestDetails.Rows[e.RowIndex].Cells["DETAILID"].Value = nextId;
                        dgvTestDetails.Rows[e.RowIndex].Cells["BILL_NO"].Value = BillNo;
                    }
                    else if (e.RowIndex == dgvTestDetails.Rows.Count - 2)
                    {
                        //if (ParaValueCode != 0)
                        //{
                            DataRow row = GLOBAL.ds.Tables["BILL_TRANS"].Select("DETAILID=MAX(DETAILID)")[0];
                            nextId = Convert.ToInt32(row["DETAILID"]) + 1;
                            dgvTestDetails.Rows[e.RowIndex].Cells["DETAILID"].Value = nextId;
                            dgvTestDetails.Rows[e.RowIndex].Cells["BILL_NO"].Value = BillNo;
                        //}
                    }
                }
                CalculateTotal();
                //int iColumn = dgvTestDetails.CurrentCell.ColumnIndex;
                //int iRow = dgvTestDetails.CurrentCell.RowIndex;

                //if (iColumn == dgvTestDetails.Columns.Count - 1)
                //{
                //    if (iRow + 1 < dgvTestDetails.Rows.Count)
                //    {
                //        //   dgvTestDetails.CurrentCell = dgvTestDetails[0, iRow + 1];
                //        dgvTestDetails.Rows[iRow + 1].Cells[0].Selected = true;
                //    }
                //}
                //else
                //{
                //    //   dgvTestDetails.CurrentCell = dgvTestDetails[iColumn + 1, iRow];
                //    dgvTestDetails.Rows[iRow].Cells[iColumn + 1].Selected = true;
                //}

                //SendKeys.Send("{Tab}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void dgvTestDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                dgvTestDetails.Rows[e.RowIndex].ErrorText = "";
                if (dgvTestDetails.Rows[e.RowIndex].IsNewRow) return;
                //DataGridViewComboBoxCell cell = dgvTestDetails["PARA_TYPE", e.RowIndex] as DataGridViewComboBoxCell;

                //if (cell != null)
                {
                    if (dgvTestDetails.Columns[e.ColumnIndex].Name == "PARA_TYPE" && e.FormattedValue.ToString()!="")
                    {
                        string TEMP = e.FormattedValue.ToString();
                        DataRow DR = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("PARA_TYPE='" + TEMP + "'")[0];
                        if (DR!=null)
                        {
                            int INDEX = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows.IndexOf(DR);
                            dgvTestDetails.Rows[e.RowIndex].Cells["PARA_TYPE_CODE"].Value =Convert.ToInt32(GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[INDEX]["PARA_TYPE_CODE"]);
                            dgvTestDetails.Rows[e.RowIndex].Cells["PRICE"].Value = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[INDEX]["PRICE"];

                            //int TAmt = Convert.ToInt32(txtTotalAmt.Text);
                            //TAmt += Convert.ToInt32(GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[INDEX]["PRICE"]);

                            //int NetAmt = TAmt;
                            //int LessAmt = 0;
                            //txtTotalAmt.Text = TAmt.ToString();
                            //if (txtLessAmt.Text != null && Convert.ToInt32(txtLessAmt.Text) > 0)
                            //{
                            //    LessAmt = Convert.ToInt32(txtLessAmt.Text);
                            //    txtNetAmt.Text = (TAmt - LessAmt).ToString();
                            //}
                            //else
                            //{
                            //    txtLessAmt.Text = "0";
                            //    txtNetAmt.Text = NetAmt.ToString();
                            //}
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #region  Report
        private void printBill()
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "CASH MEMO";
            oPara1.Range.Font.Bold = 1;
            oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //oPara1.Range.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineDashLongHeavy;
            oPara1.Format.SpaceAfter = 5;    //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();

            //Insert a paragraph at the end of the document.
            //Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            //oPara2.Range.Text = "Heading 2";
            ////oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            //oPara2.Format.SpaceAfter = 6;
            //oPara2.Range.InsertParagraphAfter();

            ////Insert another paragraph.
            //Word.Paragraph oPara3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            //oPara3.Range.Text = "Patient Name:" + cmbPName.Text ;
            //oPara3.Range.Font.Bold = 0;
            //oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            //oPara3.Format.SpaceAfter = 24;
            //oPara3.Range.InsertParagraphAfter();

            

            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 3, 4, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            oTable.Range.Font.Bold = 0;
            oTable.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(1, 1).Range.Text = "Patient Name";
            oTable.Cell(1, 1).Range.Font.Bold = 1;
            oTable.Cell(1, 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(1, 2).Range.Text =  cmbPName.Text;
            oTable.Cell(1, 2).Range.Font.Bold = 0;
            oTable.Cell(1, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(1, 3).Range.Text = "Bill No";
            oTable.Cell(1, 3).Range.Font.Bold = 1;
            oTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Cell(1, 4).Range.Text = txtBillNo.Text;
            oTable.Cell(1, 4).Range.Font.Bold = 0;
            oTable.Cell(1, 4).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(2, 1).Range.Text = "Address";
            oTable.Cell(2, 1).Range.Font.Bold = 1;
            oTable.Cell(2, 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(2, 2).Range.Text = txtAddress.Text;
            oTable.Cell(2, 2).Range.Font.Bold = 0;
            oTable.Cell(2, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(3, 1).Range.Text = "Prescribed By";
            oTable.Cell(3, 1).Range.Font.Bold = 1;
            oTable.Cell(3, 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(3, 2).Range.Text = cmbRefName.Text;
            oTable.Cell(3, 2).Range.Font.Bold = 0;
            oTable.Cell(3, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(3, 3).Range.Text = "Date";
            oTable.Cell(3, 3).Range.Font.Bold = 1;
            oTable.Cell(3, 3).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Cell(3, 4).Range.Text = txtBillDate.Text;
            oTable.Cell(3, 4).Range.Font.Bold = 0;
            oTable.Cell(3, 4).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Range.Font.Size = 9;

            oTable.Rows[1].Height = 1;
            oTable.Rows[2].Height = 1;
            oTable.Rows[3].Height = 1;

            oTable.Columns[1].Width = 70;
            oTable.Columns[2].Width = 110;
            oTable.Columns[3].Width = 50;
            oTable.Columns[4].Width = 60;

            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            Word.InlineShape ilShp = oDoc.InlineShapes.AddHorizontalLineStandard(ref oRng);
            ilShp.HorizontalLineFormat.Alignment = Word.WdHorizontalLineAlignment.wdHorizontalLineAlignLeft;
            //Similar for Width, which is "length"
            ilShp.Height = 1;
            ilShp.Width = 290;
            
            //Insert a 1 x 3 table, fill it with data, and change the column widths.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 1, 3, ref oMissing, ref oMissing);

            //oTable.Range.ParagraphFormat.SpaceAfter = 6;

            oTable.Cell(1, 1).Range.Text = "Sr.";
            oTable.Cell(1, 1).Range.Font.Bold = 1;
            oTable.Cell(1, 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(1, 2).Range.Text = "Test Details";
            oTable.Cell(1, 2).Range.Font.Bold = 1;
            oTable.Cell(1, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            oTable.Cell(1, 3).Range.Text = "Price";
            oTable.Cell(1, 3).Range.Font.Bold = 1;
            oTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Range.Font.Size = 9;
            oTable.Rows[1].Height = 1;
            oTable.Columns[1].Width = 60;
            oTable.Columns[2].Width = 150;
            oTable.Columns[3].Width = 80;

            //oTable.Columns[1].Width = oWord.InchesToPoints(2); //Change width of columns 1 & 2
            //oTable.Columns[2].Width = oWord.InchesToPoints(3);
                        
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            ilShp = oDoc.InlineShapes.AddHorizontalLineStandard(ref oRng);
            ilShp.HorizontalLineFormat.Alignment = Word.WdHorizontalLineAlignment.wdHorizontalLineAlignLeft;
            //Similar for Width, which is "length"
            ilShp.Height = 1;
            ilShp.Width = 290;

            //Insert a n x 3 table, fill it with data, and change the column widths.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, dgvTestDetails.RowCount-1, 3, ref oMissing, ref oMissing);
            int SrNo=0;
            int Row = 1;

            oTable.Columns[1].Width = 60;
            oTable.Columns[2].Width = 150;
            oTable.Columns[3].Width = 80;

            for (int i = 0; i < dgvTestDetails.RowCount-1; i++)
            {
                SrNo+=1;
                string Test=Convert.ToString(dgvTestDetails.Rows[i].Cells["PARA_TYPE"].Value);
                string Price = Convert.ToString(dgvTestDetails.Rows[i].Cells["PRICE"].Value);

                oTable.Cell(Row, 1).Range.Text = SrNo.ToString();
                oTable.Cell(Row, 1).Range.Font.Bold = 0;
                oTable.Cell(Row, 1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                oTable.Cell(Row, 2).Range.Text = Test;
                oTable.Cell(Row, 2).Range.Font.Bold = 0;
                oTable.Cell(Row, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                oTable.Cell(Row, 3).Range.Text = Price;
                oTable.Cell(Row, 3).Range.Font.Bold = 0;
                oTable.Cell(Row, 3).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

                oTable.Range.Font.Size = 9;
                if (Row <= dgvTestDetails.Rows.Count - 2)
                {
                     oTable.Rows[Row].Height = 1;
                }
                Row++;

            }

            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            ilShp = oDoc.InlineShapes.AddHorizontalLineStandard(ref oRng);
            ilShp.HorizontalLineFormat.Alignment = Word.WdHorizontalLineAlignment.wdHorizontalLineAlignLeft;
            //Similar for Width, which is "length"
            ilShp.Height = 1;
            ilShp.Width = 290;

            //Insert a 3 x 3 table, fill it with data, and change the column widths.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 3, 3, ref oMissing, ref oMissing);

            oTable.Cell(1, 2).Range.Text = "Total Amount :";
            oTable.Cell(1, 2).Range.Font.Bold = 1;
            oTable.Cell(1, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Cell(1, 3).Range.Text = txtTotalAmt.Text;
            oTable.Cell(1, 3).Range.Font.Bold = 1;
            oTable.Cell(1, 3).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Cell(2, 2).Range.Text = "Less Amount :";
            oTable.Cell(2, 2).Range.Font.Bold = 1;
            oTable.Cell(2, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Cell(2, 3).Range.Text = txtLessAmt.Text;
            oTable.Cell(2, 3).Range.Font.Bold = 1;
            oTable.Cell(2, 3).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Cell(3, 2).Range.Text = "Net Amount :";
            oTable.Cell(3, 2).Range.Font.Bold = 1;
            oTable.Cell(3, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

            oTable.Cell(3, 3).Range.Text = txtNetAmt.Text;
            oTable.Cell(3, 3).Range.Font.Bold = 1;
            oTable.Cell(3, 3).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
            oTable.AllowAutoFit = true;
            oTable.Range.Font.Size = 9;
            oTable.Rows[1].Height = 1;
            oTable.Rows[2].Height = 1;
            oTable.Rows[3].Height = 1;
            oTable.Columns[1].Width = 60;
            oTable.Columns[2].Width = 150;
            oTable.Columns[3].Width = 80;

            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            ilShp = oDoc.InlineShapes.AddHorizontalLineStandard(ref oRng);
            ilShp.HorizontalLineFormat.Alignment = Word.WdHorizontalLineAlignment.wdHorizontalLineAlignLeft;
            //Similar for Width, which is "length"
            ilShp.Height = 1;
            ilShp.Width = 290;

            //object oPos;
            //double dPos = oWord.InchesToPoints(7);
            //oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
            //do
            //{
            //    wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //    wrdRng.ParagraphFormat.SpaceAfter = 6;
            //    wrdRng.InsertAfter("A line of text");
            //    wrdRng.InsertParagraphAfter();
            //    oPos = wrdRng.get_Information
            //                   (Word.WdInformation.wdVerticalPositionRelativeToPage);
            //}
            //while (dPos >= Convert.ToDouble(oPos));
            //object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
            //object oPageBreak = Word.WdBreakType.wdPageBreak;
            //wrdRng.Collapse(ref oCollapseEnd);
            //wrdRng.InsertBreak(ref oPageBreak);
            //wrdRng.Collapse(ref oCollapseEnd);
            //wrdRng.InsertAfter("We're now on page 2. Here's my chart:");
            //wrdRng.InsertParagraphAfter();

            ////Insert a chart.
            //Word.InlineShape oShape;
            //object oClassType = "MSGraph.Chart.8";
            //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            //oShape = wrdRng.InlineShapes.AddOLEObject(ref oClassType, ref oMissing,
            //    ref oMissing, ref oMissing, ref oMissing,
            //    ref oMissing, ref oMissing, ref oMissing);

            ////Demonstrate use of late bound oChart and oChartApp objects to
            ////manipulate the chart object with MSGraph.
            //object oChart;
            //object oChartApp;
            //oChart = oShape.OLEFormat.Object;
            //oChartApp = oChart.GetType().InvokeMember("Application",
            //    BindingFlags.GetProperty, null, oChart, null);

            ////Change the chart type to Line.
            //object[] Parameters = new Object[1];
            //Parameters[0] = 4; //xlLine = 4
            //oChart.GetType().InvokeMember("ChartType", BindingFlags.SetProperty,
            //    null, oChart, Parameters);

            ////Update the chart image and quit MSGraph.
            //oChartApp.GetType().InvokeMember("Update",
            //    BindingFlags.InvokeMethod, null, oChartApp, null);
            //oChartApp.GetType().InvokeMember("Quit",
            //    BindingFlags.InvokeMethod, null, oChartApp, null);
            ////... If desired, you can proceed from here using the Microsoft Graph 
            ////Object model on the oChart and oChartApp objects to make additional
            ////changes to the chart.

            ////Set the width of the chart.
            //oShape.Width = oWord.InchesToPoints(6.25f);
            //oShape.Height = oWord.InchesToPoints(3.57f);

            //Add text after the chart.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("THE END.");
            //oDoc.Reload();
        }
        private void BillInExcel()
        {
            Excel.Application oXL = new Excel.Application();
            Excel.Workbook theWorkbook;
            Excel.Worksheet worksheet;

            if (File.Exists(Application.StartupPath + @"\BillReport.xls"))
	        {
                File.Delete(Application.StartupPath + @"\BillReport.xls");
	        } 

            theWorkbook = oXL.Workbooks.Open(Application.StartupPath+ @"\Bill.xlt", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true,Type.Missing,Type.Missing);

            worksheet = (Excel.Worksheet)theWorkbook.Sheets[1];

            
            Excel.Range RngBillNo = worksheet.get_Range("Bill_No", "Bill_No"); Excel.Range RngBillDate = worksheet.get_Range("Bill_Date", "Bill_Date");
            Excel.Range RngPName = worksheet.get_Range("P_NAME", "P_NAME");Excel.Range RngPAdd = worksheet.get_Range("P_ADD", "P_ADD");
            Excel.Range RngRName = worksheet.get_Range("R_NAME", "R_NAME");Excel.Range RngSrNo = worksheet.get_Range("SRNO", "SRNO");
            Excel.Range RngTestName = worksheet.get_Range("TEST_NAME", "TEST_NAME"); Excel.Range RngAmount = worksheet.get_Range("Amount", "Amount");
            Excel.Range RngTotal = worksheet.get_Range("Total", "Total"); Excel.Range RngRelief = worksheet.get_Range("Relief", "Relief");
            Excel.Range RngAddLess = worksheet.get_Range("Add_Less", "Add_Less"); Excel.Range RngNetAmount = worksheet.get_Range("Net_Amount", "Net_Amount");
            Excel.Range RngRemarks = worksheet.get_Range("Remarks", "Remarks"); Excel.Range RngRsInWords = worksheet.get_Range("Rs_In_Words", "Rs_In_Words");

            Excel.Range RngCompName = worksheet.get_Range("COMP_NAME", "COMP_NAME");
            Excel.Range RngCompAdd = worksheet.get_Range("COMP_ADD", "COMP_ADD");
            Excel.Range RngCompCity = worksheet.get_Range("COMP_CITY_PIN", "COMP_CITY_PIN");
            Excel.Range RngCompPhone = worksheet.get_Range("COMP_PHONE", "COMP_PHONE");
            Excel.Range RngCompTime = worksheet.get_Range("COMP_TIME", "COMP_TIME");

            if (GLOBAL.ds.Tables["COMP_MAS"].Rows.Count > 0)
            {
                RngCompName.Value2 = GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_NAME"];
                RngCompAdd.Value2 = GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_ADD"];
                RngCompCity.Value2 = GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_CITY"] + "-" + GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_PINCODE"];
                RngCompPhone.Value2 = "Phone No " + GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_PHONE"] + ", (M)" + GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_MOBILE"];
                RngCompTime.Value2 = GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_TIMING"];
            }

            RngBillNo.Value2 = txtBillNo.Text;
            RngBillDate.Value2 = txtBillDate.Text;
            RngPName.Value2 = cmbPName.Text;
            RngPAdd.Value2 = txtAddress.Text;
            RngRName.Value2 = cmbRefName.Text;

            for (int i = 0; i < dgvTestDetails.Rows.Count-1; i++)
            {
                RngSrNo.set_Item(i+1, 1, i+1);
                RngTestName.set_Item(i + 1, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["PARA_TYPE"].Value));
                RngAmount.set_Item(i + 1, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["PRICE"].Value));
            }

            RngTotal.Value2 = txtTotalAmt.Text;
            RngRelief.Value2 = txtLessAmt.Text;
            RngAddLess.Value2 = 0;
            RngNetAmount.Value2 = txtNetAmt.Text;
            RngRemarks.Value2 = "";
            RngRsInWords.Value2 = NumbersToWords(Convert.ToInt32(txtNetAmt.Text));

            oXL.ActiveWorkbook.SaveAs(Application.StartupPath + @"\BillReport", Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,Type.Missing, Type.Missing, Type.Missing, Type.Missing,Type.Missing);

            
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.FinalReleaseComObject(worksheet);
            oXL.Workbooks.Close();
            Marshal.FinalReleaseComObject(theWorkbook);
            oXL.Application.Quit();
            Marshal.FinalReleaseComObject(oXL);
            oXL = null;

            Excel.Application xlApp = new Excel.Application();  // create new Excel application
            xlApp.Visible = true;                               // application becomes visible
            xlApp.Workbooks.Open(Application.StartupPath + @"\BillReport.xls", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, Type.Missing, Type.Missing);

            MessageBox.Show("Press Enter To Continue.......", "", MessageBoxButtons.OK);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            xlApp.Workbooks.Close();
            xlApp.Application.Quit();
            Marshal.FinalReleaseComObject(xlApp);
            xlApp = null;
            
        }
        public static string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 1) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }
        
        #endregion

        
       

        

        
    }
}
