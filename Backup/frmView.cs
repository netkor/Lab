using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab
{
    public partial class frmView : Lab.BaseForm
    {
        int BillNo;
        #region Form Event
        public frmView()
        {
            InitializeComponent();
        }
        private void frmView_Load(object sender, EventArgs e)
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
        }
        private void frmView_KeyDown(object sender, KeyEventArgs e)
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


            dgvTestDetails.DataSource = null;
            //dgvTestDetails.Columns.Remove("PARA_TYPE");
            //dgvTestDetails.Columns.Remove("PRICE");

        }
        private void NewRecord()
        {
            ClearAll();
            txtBillNo.Text = GetNewID("BILL_NO", "BILL_MAS").ToString();
            txtBillDate.Text = System.DateTime.Today.ToShortDateString();
            BillNo = Convert.ToInt32(txtBillNo.Text);
            ENABLE_DISABLE_CONTROLS(true);
            //DisplayRecordOfBillTrans();
            txtLabNo.Focus();
        }
        private void SaveRecord()
        {
            #region Save BILL_MAS
            if (GLOBAL.ds.Tables["BILL_MAS"].Rows.Count == 0 && txtPCode.Text != "")
            {
                //GLOBAL.ds.Tables["BILL_MAS"].Rows.Add(Convert.ToInt32(txtBillNo.Text), txtBillDate.Text, System.DateTime.Today.ToShortTimeString(), Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtTotalAmt.Text), Convert.ToInt32(txtLessAmt.Text), Convert.ToInt32(txtNetAmt.Text));
            }
            else if (GLOBAL.ds.Tables["BILL_MAS"].Rows.Count > 0 && txtBillNo.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["BILL_MAS"].Select("BILL_NO=" + Convert.ToInt32(txtBillNo.Text));
                if (row.Length != 0)
                {
                    if (row[0].IsNull("BILL_NO"))
                    {
                        // GLOBAL.ds.Tables["BILL_MAS"].Rows.Add(Convert.ToInt32(txtBillNo.Text), txtBillDate.Text, System.DateTime.Today.ToShortTimeString(), Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtTotalAmt.Text), Convert.ToInt32(txtLessAmt.Text), Convert.ToInt32(txtNetAmt.Text));
                    }
                    else
                    {
                        int rowIndex = GLOBAL.ds.Tables["BILL_MAS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["BILL_DATE"] = txtBillDate.Text;
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["BILL_TIME"] = System.DateTime.Today.ToShortTimeString();
                        GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["LAB_CODE"] = txtLabNo.Text;
                        //GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["TOTAL_AMT"] = txtTotalAmt.Text;
                        //GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["LESS_AMT"] = txtLessAmt.Text;
                        //GLOBAL.ds.Tables["BILL_MAS"].Rows[rowIndex]["NET_AMT"] = txtNetAmt.Text;
                    }
                }
                //else
                //GLOBAL.ds.Tables["BILL_MAS"].Rows.Add(Convert.ToInt32(txtBillNo.Text), txtBillDate.Text, System.DateTime.Today.ToShortTimeString(), Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtTotalAmt.Text), Convert.ToInt32(txtLessAmt.Text), Convert.ToInt32(txtNetAmt.Text));
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
                //txtTotalAmt.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["TOTAL_AMT"].ToString();
                //txtLessAmt.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["LESS_AMT"].ToString();
                //txtNetAmt.Text = GLOBAL.ds.Tables["BILL_MAS"].Rows[Index]["NET_AMT"].ToString();
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
                #endregion

                #region Fill Ref. Dr Details
                DataRow[] dr = GLOBAL.ds.Tables["REF_DR_MAS"].Select("R_CODE=" + Convert.ToInt32(txtRefCode.Text));
                if (dr.Length != 0)
                {
                    if (!dr[0].IsNull("R_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["REF_DR_MAS"].Rows.IndexOf(dr[0]);
                        cmbRefName.Text = GLOBAL.ds.Tables["REF_DR_MAS"].Rows[rowIndex]["R_NAME"].ToString();
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
            //txtTotalAmt.Text = TAmt.ToString();
            NetAmt = TAmt;
            //if (Convert.ToString(txtLessAmt.Text) != "" && Convert.ToInt32(txtLessAmt.Text) != 0)
            {
                //  LessAmt = Convert.ToInt32(txtLessAmt.Text);
                NetAmt = TAmt - LessAmt;
            }
            //txtLessAmt.Text = LessAmt.ToString();
            //txtNetAmt.Text = NetAmt.ToString();
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

                if (GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Count > 0 && txtPCode.Text != "")
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

                DataTable DtPara = new DataTable();
                DtPara = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Copy();
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

                int TAmt = 0, LessAmt = 0, NetAmt = 0;
                for (int i = 0; i < dgvTestDetails.Rows.Count - 1; i++)
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

                //txtTotalAmt.Text = TAmt.ToString();
                NetAmt = TAmt;
                //if (Convert.ToString(txtLessAmt.Text) != "" && Convert.ToInt32(txtLessAmt.Text) != 0)
                {
                    //  LessAmt = Convert.ToInt32(txtLessAmt.Text);
                    NetAmt = TAmt - LessAmt;
                }
                //txtLessAmt.Text = LessAmt.ToString();
                //txtNetAmt.Text = NetAmt.ToString();

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
            //printBill();
            frmReportViewer obj = new frmReportViewer();
            obj.Build_Report("");
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

        #endregion

        private void btn_Save_Click_1(object sender, EventArgs e)
        {

        }

    }
}
