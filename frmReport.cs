using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
namespace Lab
{
    public partial class frmReport : Lab.BaseForm
    {
        delegate void SetComboBoxCellType(int iRowIndex);
        bool bIsComboBox = false;
        int PARATYPECODE;
        int ReportNo = 0;
        int BillNo = 0;
        int LabNo = 0;

        #region Form Event
        public frmReport(int code)
        {
            PARATYPECODE = code;
            InitializeComponent();
        }
        private void frmReport_Load(object sender, EventArgs e)
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
            this.txtBillNo.Validated += new System.EventHandler(this.txtBillNo_Validated);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            #endregion

            #region Fill Controls
            AutoCompleteLabNo();
            AutoCompleteBillNo();
            FillPName();
            FillRefName();
            #endregion

            //GLOBAL.ds.Tables["REPORT_MAS"].DefaultView.RowFilter = "";
            //GLOBAL.ds.Tables["REPORT_MAS"].DefaultView.RowFilter= "PARA_TYPE_CODE =" + PARATYPECODE;

            if (GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count == 0)
                NewRecord();
            else
            {
                //int 
                //FillRecord();
                LasRecord();
                ENABLE_DISABLE_CONTROLS(false);
            }
                
            #region Set Grid
            //SetGrid_ReportTrans();
            //DisplayRecordOfBillTrans();
            #endregion

            ENABLE_DISABLE_CONTROLS(false);
        }
        private void frmReport_KeyDown(object sender, KeyEventArgs e)
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
            txtReportNo.Text = "";
            txtBillNo.Text = "";
            txtReportDate.Text = "";
            txtAddress.Text = "";
            txtAge.Text = "";
            txtLabNo.Text = "";
            txtPCode.Text = "";
            cmbPName.Text = "";
            cmbSex.Text = "";
            txtRefCode.Text = "";
            cmbRefName.Text = "";
            //dgvTestDetails.DataSource = null;
            
        }
        private void NewRecord()
        {
            ClearAll();
            txtReportNo.Text = GetNewID("REPORT_NO", "REPORT_MAS").ToString();
            txtReportDate.Text = System.DateTime.Today.ToShortDateString();
            ReportNo = Convert.ToInt32(txtReportNo.Text);
            ENABLE_DISABLE_CONTROLS(true);
            SetGrid_ReportTrans();
            txtLabNo.Focus();
        }
        private void SaveRecord()
        {
            
            #region Save REPORT_MAS
            if (GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count == 0 && txtLabNo.Text != "")
            {
                GLOBAL.ds.Tables["REPORT_MAS"].Rows.Add(Convert.ToInt32(txtReportNo.Text), Convert.ToInt32(txtLabNo.Text), txtBillNo.Text == "" ? 0 : Convert.ToInt32(txtBillNo.Text), txtReportDate.Text,PARATYPECODE);
            }
            else if (GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count > 0 && txtReportNo.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["REPORT_MAS"].Select("REPORT_NO=" + Convert.ToInt32(txtReportNo.Text));
                if (row.Length != 0)
                {
                    if (row[0].IsNull("REPORT_NO"))
                    {
                        GLOBAL.ds.Tables["REPORT_MAS"].Rows.Add(Convert.ToInt32(txtReportNo.Text), Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtBillNo.Text), txtReportDate.Text,PARATYPECODE);
                    }
                    else
                    {
                        int rowIndex = GLOBAL.ds.Tables["REPORT_MAS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["REPORT_MAS"].Rows[rowIndex]["REPORT_DATE"] = txtReportDate.Text;
                        GLOBAL.ds.Tables["REPORT_MAS"].Rows[rowIndex]["BILL_NO"] = txtBillNo.Text;
                        GLOBAL.ds.Tables["REPORT_MAS"].Rows[rowIndex]["LAB_CODE"] = txtLabNo.Text;
                        GLOBAL.ds.Tables["REPORT_MAS"].Rows[rowIndex]["PARA_TYPE_CODE"] = PARATYPECODE;

                    }
                }
                else
                    GLOBAL.ds.Tables["REPORT_MAS"].Rows.Add(Convert.ToInt32(txtReportNo.Text), Convert.ToInt32(txtLabNo.Text), BillNo, txtReportDate.Text,PARATYPECODE);
            }
            #endregion

            #region Save REPORT_TRANS
            if (GLOBAL.ds.Tables["REPORT_TRANS"].Rows.Count == 0 && txtLabNo.Text != "")
            {
                for (int i = 0; i < dgvTestDetails.Rows.Count ; i++)
                {
                    if (Convert.ToString( dgvTestDetails.Rows[i].Cells["RESULT_VALUE"].Value) != "")
                    {
                        GLOBAL.ds.Tables["REPORT_TRANS"].Rows.Add(dgvTestDetails.Rows[i].Cells["REPORT_NO"].Value,
                            dgvTestDetails.Rows[i].Cells["REPORT_DETAILID"].Value, dgvTestDetails.Rows[i].Cells["PARA_TYPE_CODE"].Value,
                            Convert.ToString(dgvTestDetails.Rows[i].Cells["PARA_VALUE_CODE"].Value),
                            Convert.ToString(dgvTestDetails.Rows[i].Cells["PARA_VALUE"].Value),
                            dgvTestDetails.Rows[i].Cells["RESULT_CODE"].Value, dgvTestDetails.Rows[i].Cells["RESULT_VALUE"].Value,
                            dgvTestDetails.Rows[i].Cells["MESUREMENT"].Value, dgvTestDetails.Rows[i].Cells["RANGE_CODE"].Value,
                            dgvTestDetails.Rows[i].Cells["RANGE_VALUE"].Value, dgvTestDetails.Rows[i].Cells["AGE_LIMIT"].Value);
                    }
                }
            }
            else if (GLOBAL.ds.Tables["REPORT_TRANS"].Rows.Count > 0 && txtReportNo.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["REPORT_TRANS"].Select("REPORT_NO=" + Convert.ToInt32(txtReportNo.Text));
                if (row.Length != 0)
                {
                    if (row[0].IsNull("REPORT_NO"))
                    {
                    }
                    else
                    {
                        foreach (DataRow irow in row)
                        {
                            int rowIndex = GLOBAL.ds.Tables["REPORT_TRANS"].Rows.IndexOf(irow);
                            if (Convert.ToString(irow["RESULT_VALUE"]) != "")
                            {
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["REPORT_NO"] = irow["REPORT_NO"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["REPORT_DETAILID"] = irow["REPORT_DETAILID"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["PARA_TYPE_CODE"] = irow["PARA_TYPE_CODE"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["PARA_VALUE_CODE"] = irow["PARA_VALUE_CODE"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["PARA_VALUE"] = irow["PARA_VALUE"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["RESULT_CODE"] = irow["RESULT_CODE"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["RESULT_VALUE"] = irow["RESULT_VALUE"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["MESUREMENT"] = irow["MESUREMENT"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["RANGE_CODE"] = irow["RANGE_CODE"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["RANGE_VALUE"] = irow["RANGE_VALUE"];
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows[rowIndex]["AGE_LIMIT"] = irow["AGE_LIMIT"];
                            }
                            else if (Convert.ToString(irow["RESULT_VALUE"]) == "")
                            {
                                //GLOBAL.ds.Tables["REPORT_TRANS"].Rows.RemoveAt(rowIndex);
                                int ReportDtId = Convert.ToInt32(irow["REPORT_DETAILID"]);
                                for (int i = 0; i < dgvTestDetails.RowCount; i++)
                                {
                                    if (Convert.ToInt32(dgvTestDetails.Rows[i].Cells["REPORT_DETAILID"].Value) == ReportDtId)
                                    {
                                        dgvTestDetails.Rows.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                   
                    }
                }
                else
                {
                    for (int i = 0; i < dgvTestDetails.Rows.Count ; i++)
                    {
                        if (Convert.ToString(dgvTestDetails.Rows[i].Cells["RESULT_VALUE"].Value) != "")
                        {
                            GLOBAL.ds.Tables["REPORT_TRANS"].Rows.Add(dgvTestDetails.Rows[i].Cells["REPORT_NO"].Value,
                            dgvTestDetails.Rows[i].Cells["REPORT_DETAILID"].Value, dgvTestDetails.Rows[i].Cells["PARA_TYPE_CODE"].Value,
                            Convert.ToString(dgvTestDetails.Rows[i].Cells["PARA_VALUE_CODE"].Value),
                            Convert.ToString(dgvTestDetails.Rows[i].Cells["PARA_VALUE"].Value),
                            dgvTestDetails.Rows[i].Cells["RESULT_CODE"].Value,
                            dgvTestDetails.Rows[i].Cells["RESULT_VALUE"].Value, dgvTestDetails.Rows[i].Cells["MESUREMENT"].Value,
                            dgvTestDetails.Rows[i].Cells["RANGE_CODE"].Value, dgvTestDetails.Rows[i].Cells["RANGE_VALUE"].Value,
                            dgvTestDetails.Rows[i].Cells["AGE_LIMIT"].Value);
                        }
                    }
                }
                //GLOBAL.ds.Tables["REPORT_MAS"].Rows.Add(Convert.ToInt32(txtReportNo.Text), Convert.ToInt32(txtLabNo.

            }
            #endregion
        }
        private void DeleteRecord()
        {
            if (GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count > 0 && txtReportNo.Text != "")
            {
                if (GLOBAL.ds.Tables["REPORT_TRANS"].Rows.Count > 0 && txtReportNo.Text != "")
                {
                    DataRow[] row = GLOBAL.ds.Tables["REPORT_TRANS"].Select("REPORT_NO=" + Convert.ToInt32(txtReportNo.Text));
                    if (row.Length != 0)
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (!row[i].IsNull("REPORT_NO"))
                            {
                                int rowIndex = GLOBAL.ds.Tables["REPORT_TRANS"].Rows.IndexOf(row[i]);
                                GLOBAL.ds.Tables["REPORT_TRANS"].Rows.RemoveAt(rowIndex);
                            }
                        }
                    }
                }

                DataRow[] rw = GLOBAL.ds.Tables["REPORT_MAS"].Select("REPORT_NO=" + Convert.ToInt32(txtReportNo.Text));
                if (rw.Length != 0)
                {
                    if (!rw[0].IsNull("REPORT_NO"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["REPORT_MAS"].Rows.IndexOf(rw[0]);
                        GLOBAL.ds.Tables["REPORT_MAS"].Rows.RemoveAt(rowIndex);
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
            if (GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count > 0 && Index < GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count)
            {
                DataRow[] drow = GLOBAL.ds.Tables["REPORT_MAS"].Select("PARA_TYPE_CODE=" + PARATYPECODE);
                if (drow.Length != 0)
                {
                    if (Convert.ToInt32(GLOBAL.ds.Tables["REPORT_MAS"].Rows[Index]["PARA_TYPE_CODE"].ToString()) == PARATYPECODE)
                    {
                        #region Master
                        #region Fill Report Mas
                        txtReportNo.Text = GLOBAL.ds.Tables["REPORT_MAS"].Rows[Index]["REPORT_NO"].ToString();
                        txtBillNo.Text = GLOBAL.ds.Tables["REPORT_MAS"].Rows[Index]["BILL_NO"].ToString();
                        txtReportDate.Text = GLOBAL.ds.Tables["REPORT_MAS"].Rows[Index]["REPORT_DATE"].ToString();
                        txtLabNo.Text = GLOBAL.ds.Tables["REPORT_MAS"].Rows[Index]["LAB_CODE"].ToString();
                        ReportNo = Convert.ToInt32(txtReportNo.Text);
                        #endregion
                        #endregion
                    }
                    else
                    {
                        #region Master
                        txtReportNo.Text = drow[drow.Length-1]["REPORT_NO"].ToString();
                        txtBillNo.Text = drow[drow.Length-1]["BILL_NO"].ToString();
                        txtReportDate.Text = drow[drow.Length-1]["REPORT_DATE"].ToString();
                        txtLabNo.Text = drow[drow.Length-1]["LAB_CODE"].ToString();
                        ReportNo = Convert.ToInt32(txtReportNo.Text);
                        #endregion
                    }

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

                    #region Grid Details
                    SetGrid_ReportTrans();
                    #endregion
                }
                else
                    NewRecord();
            }
            else
                NewRecord();
        }
        #endregion

        #region Navigation Functions
        private void FirstRecord()
        {
            FillRecord(0);
        }
        private void NextRecord()
        {
            if (txtLabNo.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["REPORT_MAS"].Select("REPORT_NO=" + Convert.ToInt32(txtReportNo.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("REPORT_NO"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["REPORT_MAS"].Rows.IndexOf(row[0]);
                        if (rowIndex >= 0 && rowIndex != GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count - 1)
                        {
                            FillRecord(rowIndex + 1);
                        }
                        else
                        {
                            FillRecord(GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count - 1);
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
                DataRow[] row = GLOBAL.ds.Tables["REPORT_MAS"].Select("REPORT_NO=" + Convert.ToInt32(txtReportNo.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("REPORT_NO"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["REPORT_MAS"].Rows.IndexOf(row[0]);
                        if (rowIndex > 0 && rowIndex != GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count)
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
            FillRecord(GLOBAL.ds.Tables["REPORT_MAS"].Rows.Count - 1);
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
            LabNo = Convert.ToInt32(Code);
            if (GLOBAL.ds.Tables["LAB_MAS"].Rows.Count > 0)
            {
                DataRow[] row = GLOBAL.ds.Tables["LAB_MAS"].Select("LAB_CODE=" + LabNo);
                if (row.Length == 0)
                {
                    ShowMessagePrompt(" Lab No is not exist", "");
                    txtLabNo.Text = "";
                    txtLabNo.Focus();
                    return;
                }
                else if (row.Length != 0)
                {
                    ShowMessagePrompt("","");
                    if (!row[0].IsNull("P_CODE") || !row[0].IsNull("R_CODE"))
                    {
                        txtPCode.Text = row[0]["P_CODE"].ToString();
                        txtRefCode.Text = row[0]["R_CODE"].ToString();
                    }
                }

                DataRow[] rw = GLOBAL.ds.Tables["BILL_MAS"].Select("LAB_CODE=" + Code);
                if (rw.Length != 0)
                {
                    if (!rw[0].IsNull("BILL_NO"))
                    {
                        txtBillNo.Text = rw[0]["BILL_NO"].ToString();
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
            SetGrid_ReportTrans();
        }
        private void FillBillDetail(string Code)
        {
            BillNo = Convert.ToInt32(Code);
            if (GLOBAL.ds.Tables["BILL_MAS"].Rows.Count > 0)
            {
                DataRow[] rw = GLOBAL.ds.Tables["BILL_MAS"].Select("BILL_NO=" + Code);
                if (rw.Length == 0)
                {
                    ShowMessagePrompt(" Bill No is not exist", "");
                    //ClearAll();
                    txtBillNo.Text = "";
                    return;
                }
                else if (rw.Length != 0)
                {
                    ShowMessagePrompt("", "");
                    if (!rw[0].IsNull("BILL_NO"))
                    {
                        txtLabNo.Text = rw[0]["LAB_CODE"].ToString();
                    }
                }


                DataRow[] row = GLOBAL.ds.Tables["LAB_MAS"].Select("LAB_CODE=" + Convert.ToInt32(txtLabNo.Text));
                if (row.Length == 0)
                {
                    ShowMessagePrompt(" Lab No is not exist", "");
                    //ClearAll();

                    return;
                }
                else if (row.Length != 0)
                {
                    ShowMessagePrompt("", "");
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
            SetGrid_ReportTrans();
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
        private void AutoCompleteBillNo()
        {
            AutoCompleteStringCollection strBillNo = new AutoCompleteStringCollection();
            for (int i = 0; i < GLOBAL.ds.Tables["BILL_MAS"].Rows.Count; i++)
            {
                strBillNo.Add(GLOBAL.ds.Tables["BILL_MAS"].Rows[i]["BILL_NO"].ToString());
            }

            txtBillNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBillNo.AutoCompleteCustomSource = strBillNo;
            txtBillNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            pnlMas.Enabled = Val;
            pnlGrid.Enabled = Val;

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
        private void ReportInExcel()
        {
            Excel.Application oXL = new Excel.Application();
            Excel.Workbook theWorkbook;
            Excel.Worksheet worksheet;

            if (File.Exists(Application.StartupPath + @"\Report.xls"))
            {
                File.Delete(Application.StartupPath + @"\Report.xls");
            }

            theWorkbook = oXL.Workbooks.Open(Application.StartupPath + @"\Report.xlt", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, Type.Missing, Type.Missing);

            worksheet = (Excel.Worksheet)theWorkbook.Sheets[1];
            
            Excel.Range RngDate = worksheet.get_Range("Date", "Date"); Excel.Range RngAge = worksheet.get_Range("AGE", "AGE");
            Excel.Range RngPName = worksheet.get_Range("P_NAME", "P_NAME");
            Excel.Range RngRName = worksheet.get_Range("R_NAME", "R_NAME");
            Excel.Range RngParaType = worksheet.get_Range("PARA_TYPE", "PARA_TYPE"); 
            Excel.Range RngParaValue = worksheet.get_Range("PARA_VALUE", "PARA_VALUE");
            Excel.Range RngResultValue = worksheet.get_Range("RESULT_VALUE", "RESULT_VALUE");
            Excel.Range RngRangeMethod = worksheet.get_Range("RANGE_METHOD", "RANGE_METHOD");

            
            DataRow[] row = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("PARA_TYPE_CODE=" + PARATYPECODE);
            if (row.Length != 0)
            {
                if (!row[0].IsNull("PARA_TYPE_CODE"))
                {
                    int rowIndex = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows.IndexOf(row[0]);
                    RngParaType.Value2 = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[rowIndex]["PARA_TYPE"];
                }
            }

            RngAge.Value2 = txtAge.Text;
            RngDate.Value2 = txtReportDate.Text;
            RngPName.Value2 = cmbPName.Text;
            RngRName.Value2 = cmbRefName.Text;
            //RngParaType.Value2 = PARATYPECODE;
            int IRow = 0;
            for (int j = 0; j < GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows.Count - 1; j++)
            {
                DataRow[] drow = GLOBAL.ds.Tables["REPORT_TRANS"].Select("REPORT_NO=" + Convert.ToInt32(txtReportNo.Text) + "AND PARA_TYPE_CODE=" + PARATYPECODE + " AND PARA_VALUE='" + Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE"]) + "'");
                if (drow.Length!=0)
                {
                    //find type ord
                    if (!Convert.IsDBNull(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["TYPE_CODE"]))
                    {
                        int intTypeOrd = Convert.ToInt32(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["TYPE_CODE"]);
                        DataRow[] jrow = GLOBAL.ds.Tables["PARA_VALUE_MAS"].Select("TYPE_CODE=" + intTypeOrd + " AND TYPE='HEADING'");
                        if (jrow.Length != 0)
                        {
                            if (!jrow[0].IsNull("PARA_VALUE_CODE"))
                            {
                                int rowIndex = GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows.IndexOf(jrow[0]);
                                string strHead = Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[rowIndex]["PARA_VALUE"]);
                                //int TypeOrd = GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[rowIndex]["TYPE_ORD"];
                                IRow++;
                                RngParaValue.set_Item(IRow, 1, Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[rowIndex]["PARA_VALUE"]));
                                Excel.Range rg = worksheet.get_Range("B" + (RngParaValue.Row + IRow - 1), "B" + (RngParaValue.Row + IRow - 1));
                                rg.Select();
                                rg.Font.Bold = true;
                                IRow++;
                                continue;
                            }
                        }
                    }
                    //if (PARATYPECODE == Convert.ToInt32(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_TYPE_CODE"]) && Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["TYPE"]).ToUpper() == "HEADING")
                    //{
                    //    IRow++;
                    //    RngParaValue.set_Item(IRow, 1, Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE"]));
                    //    Excel.Range rg = worksheet.get_Range("B" + (RngParaValue.Row + IRow - 1), "B" + (RngParaValue.Row + IRow - 1));
                    //    rg.Select();
                    //    rg.Font.Bold = true;
                    //    IRow++;
                    //    continue;
                    //}
                    if (PARATYPECODE == Convert.ToInt32(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_TYPE_CODE"]) && Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["TYPE"]).ToUpper() != "HEADING")
                    {
                        if (Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["TYPE"]).ToUpper() != "DETAIL")
                            IRow++;

                        int intParaValueCode = Convert.ToInt32(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE_CODE"]);
                        RngParaValue.set_Item(IRow, 1, Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE"]));

                        bool flag = false;
                        for (int i = 0; i < dgvTestDetails.Rows.Count ; i++)
                        {
                            if (Convert.ToInt32(dgvTestDetails.Rows[i].Cells["PARA_VALUE_CODE"].Value) == intParaValueCode)
                            {
                                RngResultValue.set_Item(IRow, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["RESULT_VALUE"].Value) + "  " + Convert.ToString(dgvTestDetails.Rows[i].Cells["MESUREMENT"].Value));
                                RngRangeMethod.set_Item(IRow, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["RANGE_VALUE"].Value));
                                IRow++;
                                flag = true;
                                break;
                            }
                            if (flag)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }
                }
            }
            //for (int i = 0; i < dgvTestDetails.Rows.Count - 1; i++)
            //{
            //    RngParaValue.set_Item(i + 1, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["PARA_VALUE"].Value));
            //    RngResultValue.set_Item(i + 1, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["RESULT_VALUE"].Value) + Convert.ToString(dgvTestDetails.Rows[i].Cells["MESUREMENT"].Value));
            //    RngRangeMethod.set_Item(i + 1, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["RANGE_VALUE"].Value));
            //}
            
            oXL.ActiveWorkbook.SaveAs(Application.StartupPath + @"\Report", Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            
            //oXL.ActiveWorkbook.PrintOut(1, 1, 1, false, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //worksheet.PrintOut(1, 1, 1, false, Missing.Value, Missing.Value, Missing.Value, Missing.Value);                
            
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
            xlApp.Workbooks.Open(Application.StartupPath + @"\Report.xls", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, Type.Missing, Type.Missing);
            
            MessageBox.Show("Press Enter To Continue.......", "", MessageBoxButtons.OK);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            xlApp.Workbooks.Close();
            xlApp.Application.Quit();
            Marshal.FinalReleaseComObject(xlApp);
            xlApp = null;

        }

        #endregion

        #region Datagrid Report Trans
        private void SetGrid()
        {
            try
            {
                dgvTestDetails.Columns["REPORT_NO"].HeaderText = "RepNo";
                dgvTestDetails.Columns["REPORT_NO"].Width = 30;
                dgvTestDetails.Columns["REPORT_NO"].ReadOnly = true;
                dgvTestDetails.Columns["REPORT_NO"].ValueType = typeof(System.Int32);
                dgvTestDetails.Columns["REPORT_NO"].Visible = false;

                dgvTestDetails.Columns["REPORT_DETAILID"].HeaderText = "RepDtNo";
                dgvTestDetails.Columns["REPORT_DETAILID"].Width = 30;
                dgvTestDetails.Columns["REPORT_DETAILID"].ReadOnly = true;
                dgvTestDetails.Columns["REPORT_DETAILID"].ValueType = typeof(System.Int32);
                dgvTestDetails.Columns["REPORT_DETAILID"].Visible = false;

                //dgvTestDetails.Columns["LAB_CODE"].HeaderText = "LabNo";
                //dgvTestDetails.Columns["LAB_CODE"].Width = 30;
                //dgvTestDetails.Columns["LAB_CODE"].ReadOnly = true;
                //dgvTestDetails.Columns["LAB_CODE"].ValueType = typeof(System.Int32);
                //dgvTestDetails.Columns["LAB_CODE"].Visible = false;

                dgvTestDetails.Columns["PARA_TYPE_CODE"].HeaderText = "TestNo";
                dgvTestDetails.Columns["PARA_TYPE_CODE"].Width = 30;
                dgvTestDetails.Columns["PARA_TYPE_CODE"].ReadOnly = true;
                dgvTestDetails.Columns["PARA_TYPE_CODE"].ValueType = typeof(System.Int32);
                dgvTestDetails.Columns["PARA_TYPE_CODE"].Visible = false;

                dgvTestDetails.Columns["PARA_VALUE_CODE"].HeaderText = "No.";
                dgvTestDetails.Columns["PARA_VALUE_CODE"].Width = 30;
                dgvTestDetails.Columns["PARA_VALUE_CODE"].ReadOnly = true;
                dgvTestDetails.Columns["PARA_VALUE_CODE"].ValueType = typeof(System.Int32);
                dgvTestDetails.Columns["PARA_VALUE_CODE"].Visible = false;

                dgvTestDetails.Columns["PARA_VALUE"].HeaderText = "Parameter";
                dgvTestDetails.Columns["PARA_VALUE"].Width = 300;
                //dgvTestDetails.Columns["PARA_VALUE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTestDetails.Columns["PARA_VALUE"].ReadOnly = true;
                dgvTestDetails.Columns["PARA_VALUE"].DefaultCellStyle.BackColor = Color.Gainsboro;
                dgvTestDetails.Columns["PARA_VALUE"].DefaultCellStyle.ForeColor = Color.Black;

                dgvTestDetails.Columns["RESULT_CODE"].HeaderText = "No.";
                dgvTestDetails.Columns["RESULT_CODE"].Width = 30;
                dgvTestDetails.Columns["RESULT_CODE"].ReadOnly = true;
                dgvTestDetails.Columns["RESULT_CODE"].ValueType = typeof(System.Int32);
                dgvTestDetails.Columns["RESULT_CODE"].Visible = false;

                dgvTestDetails.Columns["RESULT_VALUE"].HeaderText = "Result";
                dgvTestDetails.Columns["RESULT_VALUE"].Width = 300;
                dgvTestDetails.Columns["RESULT_VALUE"].Frozen = false;
                //dgvTestDetails.Columns["RESULT_VALUE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                
                dgvTestDetails.Columns["MESUREMENT"].HeaderText = "Mesurement";
                dgvTestDetails.Columns["MESUREMENT"].Width = 150;
                dgvTestDetails.Columns["MESUREMENT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvTestDetails.Columns["MESUREMENT"].ReadOnly = true;
                dgvTestDetails.Columns["MESUREMENT"].DefaultCellStyle.BackColor = Color.Gainsboro;
                dgvTestDetails.Columns["MESUREMENT"].DefaultCellStyle.ForeColor = Color.Black;

                dgvTestDetails.Columns["RANGE_CODE"].HeaderText = "No.";
                dgvTestDetails.Columns["RANGE_CODE"].Width = 30;
                dgvTestDetails.Columns["RANGE_CODE"].ReadOnly = true;
                dgvTestDetails.Columns["RANGE_CODE"].ValueType = typeof(System.Int32);
                dgvTestDetails.Columns["RANGE_CODE"].Visible = false;

                dgvTestDetails.Columns["RANGE_VALUE"].HeaderText = "Range";
                //dgvTestDetails.Columns["RANGE_VALUE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTestDetails.Columns["RANGE_VALUE"].Width = 300;
                dgvTestDetails.Columns["RANGE_VALUE"].ReadOnly = true;
                dgvTestDetails.Columns["RANGE_VALUE"].DefaultCellStyle.BackColor = Color.Gainsboro;
                dgvTestDetails.Columns["RANGE_VALUE"].DefaultCellStyle.ForeColor = Color.Black;

                dgvTestDetails.Columns["AGE_LIMIT"].HeaderText = "Age";
                dgvTestDetails.Columns["AGE_LIMIT"].Width = 150;
                dgvTestDetails.Columns["AGE_LIMIT"].ReadOnly= true;
                dgvTestDetails.Columns["AGE_LIMIT"].ValueType = typeof(System.Int32);
                dgvTestDetails.Columns["AGE_LIMIT"].Visible = true;
                dgvTestDetails.Columns["AGE_LIMIT"].DefaultCellStyle.BackColor = Color.Gainsboro;
                dgvTestDetails.Columns["AGE_LIMIT"].DefaultCellStyle.ForeColor = Color.Black;
                //dgvTestDetails.Columns["AGE_LIMIT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void SetGrid_ReportTrans()
        {
            try
            {
                GLOBAL.ds.Tables["REPORT_TRANS"].DefaultView.RowFilter = "";
                if (ReportNo != 0)
                {
                    GLOBAL.ds.Tables["REPORT_TRANS"].DefaultView.RowFilter = "REPORT_NO=" + ReportNo;
                    //dgvTestDetails.DataSource = null;
                    if (GLOBAL.ds.Tables["REPORT_TRANS"].DefaultView.Count==0)
                    {
                        DisplayDefaultRecordOfReportTrans();
                    }
                    else
                        dgvTestDetails.DataSource = GLOBAL.ds.Tables["REPORT_TRANS"].DefaultView;
                }
                else
                {
                    //dgvTestDetails.DataSource = GLOBAL.ds.Tables["REPORT_TRANS"];
                    DisplayDefaultRecordOfReportTrans();
                }

                //GLOBAL.ds.Tables["REPORT_TRANS"].DefaultView.RowFilter = "";
                //GLOBAL.ds.Tables["REPORT_TRANS"].DefaultView.RowFilter = "LAB_CODE=" + LabNo + " AND PARA_TYPE_CODE=" + PARATYPECODE;

                ////dgvTestDetails.DataSource = null;
                //if (GLOBAL.ds.Tables["REPORT_TRANS"].DefaultView.Count > 0)
                //{
                //    dgvTestDetails.DataSource = GLOBAL.ds.Tables["REPORT_TRANS"].DefaultView;
                //}
                //else
                //{
                //    DisplayDefaultRecordOfReportTrans();
                //}

                SetGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void DisplayDefaultRecordOfReportTrans()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("REPORT_NO");
                dt.Columns.Add("REPORT_DETAILID");
                dt.Columns.Add("PARA_TYPE_CODE");
                dt.Columns.Add("PARA_VALUE_CODE");
                dt.Columns.Add("PARA_VALUE");
                dt.Columns.Add("RESULT_CODE");
                dt.Columns.Add("RESULT_VALUE");
                dt.Columns.Add("MESUREMENT");
                dt.Columns.Add("RANGE_CODE");
                dt.Columns.Add("RANGE_VALUE");
                dt.Columns.Add("AGE_LIMIT");

                dt.Columns["REPORT_NO"].DataType = typeof(System.Int32);
                dt.Columns["REPORT_NO"].DefaultValue = ReportNo;

                dt.Columns["REPORT_DETAILID"].DataType = typeof(System.Int32);
                
                dt.Columns["PARA_TYPE_CODE"].DataType = typeof(System.Int32);
                dt.Columns["PARA_TYPE_CODE"].DefaultValue = PARATYPECODE;
                dt.Columns["PARA_VALUE_CODE"].DataType = typeof(System.Int32);
                dt.Columns["RESULT_CODE"].DataType = typeof(System.Int32);
                dt.Columns["RANGE_CODE"].DataType = typeof(System.Int32);
                //dt.Columns["AGE_LIMIT"].DataType = typeof(System.Int32);

                int nextId = 0;
                string ParaTypeCode = Convert.ToString(PARATYPECODE);// Convert.ToString(GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows[2]["PARA_TYPE_CODE"]);
                for (int j = 0; j < GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows.Count - 1; j++)
                {
                    if (ParaTypeCode == Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_TYPE_CODE"]) && Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["TYPE"]).ToUpper() != "HEADING")
                    {

                        if (GLOBAL.ds.Tables["REPORT_TRANS"].Rows.Count == 0 && dt.Rows.Count == 0)
                        {
                            nextId = 1;
                            //dgvTestDetails.Rows[e.RowIndex].Cells["DETAILID"].Value = nextId;
                            //dgvTestDetails.Rows[e.RowIndex].Cells["BILL_NO"].Value = BillNo;
                        }
                        else //if (e.RowIndex == dgvTestDetails.Rows.Count - 2)
                        {
                            //if (LabNo != 0)
                            //{
                            DataRow row;
                            if (dt.Rows.Count > 0)
                                row = dt.Select("REPORT_DETAILID=MAX(REPORT_DETAILID)")[0];
                            else
                                row = GLOBAL.ds.Tables["REPORT_TRANS"].Select("REPORT_DETAILID=MAX(REPORT_DETAILID)")[0];

                            nextId = Convert.ToInt32(row["REPORT_DETAILID"]) + 1;
                            //dgvTestDetails.Rows[e.RowIndex].Cells["REPORT_DETAILID"].Value = nextId;

                            //}
                        }

                        //if (nextId == 14)
                        //{
                        //    nextId = nextId;
                        //}
                        //if ( nextId == 15)
                        //{
                        //    nextId = nextId;
                        //}
                        //if (nextId == 16 )
                        //{
                        //    nextId = nextId;
                        //}
                        //if (nextId == 17)
                        //{
                        //    nextId = nextId;
                        //}
                        string Mesurement = "";
                        Int32 ResultCode = 0;
                        string ResultValue = "";
                        DataRow[] dr = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Select("PARA_VALUE_CODE=" + Convert.ToInt32(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE_CODE"]));
                        if (dr.Length!=0)
                        {
                            //if (Convert.ToString(dr[0]["RESULT_VALUE"].ToString()).ToUpper() == "VALUE")
                            //{

                                ResultCode =  Convert.ToInt32(dr[0]["RESULT_CODE"].ToString());
                                ResultValue = Convert.ToString(dr[0]["RESULT_VALUE"].ToString());
                                if (ResultValue.ToUpper() == "VALUE" || ResultValue.ToUpper() == "MIN_SEC")
                                {
                                    ResultValue = "";
                                }
                                Mesurement = Convert.ToString(dr[0]["MESUREMENT"].ToString());
                                //GLOBAL.ds.Tables["REPORT_TRANS"].Rows[i]["MESUREMENT"] = Convert.ToString(dr["MESUREMENT"].ToString());
                            //}
                        }

                        string AgeLimit = "";
                        Int32 RangeCode = 0;
                        string RangeValue = "";
                        DataRow[] drw = GLOBAL.ds.Tables["PARA_VALUE_RANGES"].Select("PARA_VALUE_CODE=" + Convert.ToInt32(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE_CODE"]));


                        if (drw.Length != 0 && drw.Length > 1 && txtAge.Text.Length>0)
                        {
                            //if (Convert.ToString(dr["RESULT_VALUE"].ToString()).ToUpper() == "VALUE")
                            //{

                            bool flag = false;
                            foreach (DataRow iRow in drw)
                            {
                                string strAgeLimit = Convert.ToString(iRow["AGE_LIMIT"].ToString());
                                if (strAgeLimit.Contains("-"))
                                {
                                    int PAge = Convert.ToInt32(txtAge.Text);
                                    string[] AgeArr = strAgeLimit.Split('-');
                                    if (PAge >= Convert.ToInt32(AgeArr[0]) && PAge <= Convert.ToInt32(AgeArr[1]))
                                    {
                                        RangeCode = Convert.ToInt32(iRow["RANGE_CODE"].ToString());
                                        RangeValue = Convert.ToString(iRow["RANGE_VALUE"].ToString());
                                        AgeLimit = Convert.ToString(iRow["AGE_LIMIT"].ToString());
                                        flag = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    switch (cmbSex.Text.ToUpper().Trim())
                                    {
                                        case "FEMALE":
                                        case "WOMEN":
                                            if (Convert.ToString(iRow["AGE_LIMIT"].ToString()).Substring(0, 1) == "F" || Convert.ToString(iRow["AGE_LIMIT"].ToString()).Substring(0, 1) == "W")
                                            {
                                                RangeCode = Convert.ToInt32(iRow["RANGE_CODE"].ToString());
                                                RangeValue = Convert.ToString(iRow["RANGE_VALUE"].ToString());
                                                AgeLimit = Convert.ToString(iRow["AGE_LIMIT"].ToString());
                                                if (Convert.ToInt32(txtAge.Text) > 12)
                                                {
                                                    flag = true;
                                                    break;
                                                }
                                            }
                                            break;
                                        case "MALE":
                                        case "MEN":
                                            if (Convert.ToString(iRow["AGE_LIMIT"].ToString()).Substring(0, 1) == "M")   
                                            {
                                                RangeCode = Convert.ToInt32(iRow["RANGE_CODE"].ToString());
                                                RangeValue = Convert.ToString(iRow["RANGE_VALUE"].ToString());
                                                AgeLimit = Convert.ToString(iRow["AGE_LIMIT"].ToString());
                                                if (Convert.ToInt32(txtAge.Text) > 12)
                                                {
                                                    flag = true;
                                                    break;
                                                }
                                            }
                                            break;
                                    }
                                }

                                if (flag)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        else if (drw.Length != 0 && drw.Length == 1)
                        {
                            RangeCode = Convert.ToInt32(drw[0]["RANGE_CODE"].ToString());
                            RangeValue = Convert.ToString(drw[0]["RANGE_VALUE"].ToString());
                            AgeLimit = Convert.ToString(drw[0]["AGE_LIMIT"].ToString());
                        }       
                        //GLOBAL.ds.Tables["REPORT_TRANS"].Rows.Add(ReportNo, nextId, ParaTypeCode, Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE_CODE"]), Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE"]), ResultCode, ResultValue, Mesurement, RangeCode, RangeValue, AgeLimit);
                        dt.Rows.Add(ReportNo, nextId, ParaTypeCode, Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE_CODE"]), Convert.ToString(GLOBAL.ds.Tables["PARA_VALUE_MAS"].Rows[j]["PARA_VALUE"]),ResultCode,ResultValue,Mesurement,RangeCode,RangeValue,AgeLimit);
                    }
                }
                                
                //dgvTestDetails.DataSource = GLOBAL.ds.Tables["REPORT_TRANS"];
                dgvTestDetails.DataSource = dt;
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
            ShowMessagePrompt("", "");
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
            ReportInExcel();
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

        private void txtBillNo_Validated(object sender, EventArgs e)
        {
            if (txtBillNo.Text != "")
            {
                FillBillDetail(txtBillNo.Text);
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
        private void txtBillNo_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);

        }
        private void txtLabNo_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtReportDate_TextChanged(object sender, EventArgs e)
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
        #endregion

        #region Grid Events
        private void dgvTestDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SetComboBoxCellType objChangeCellType = new SetComboBoxCellType(ChangeCellToComboBox);

                if (e.ColumnIndex == this.dgvTestDetails.Columns["RESULT_VALUE"].Index)
                {
                    this.dgvTestDetails.BeginInvoke(objChangeCellType, e.RowIndex);
                    bIsComboBox = false;
                }
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

                if (bIsComboBox == false && dgvTestDetails.Rows.Count > iRowIndex)
                {
                    DataGridViewComboBoxCell dgComboCell = new DataGridViewComboBoxCell();
                    dgComboCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    dgComboCell.FlatStyle = FlatStyle.Flat;
                    dgComboCell.DropDownWidth = 200;

                    Int32 ParaValueCode = Convert.ToInt32(dgvTestDetails.Rows[iRowIndex].Cells["PARA_VALUE_CODE"].Value);
                    if (ParaValueCode != 0)
                    {
                        DataRow[] rw = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Select("PARA_VALUE_CODE=" + ParaValueCode);

                        if (rw.Length != 0)
                        {
                            string Result = rw[0]["RESULT_VALUE"].ToString();
                            if (Result.ToUpper() != "VALUE" && Result.ToUpper() != "MIN_SEC")
                            {
                                DataTable dt = new DataTable();

                                dt = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"];
                                dt.Rows.Add(ParaValueCode);
                                dt.DefaultView.RowFilter = "";
                                dt.DefaultView.RowFilter = "PARA_VALUE_CODE=" + ParaValueCode;

                                dgComboCell.DataSource = dt.DefaultView;
                                dgComboCell.ValueMember = "RESULT_VALUE";
                                dgComboCell.DisplayMember = "RESULT_VALUE";

                                dgvTestDetails.Rows[iRowIndex].Cells[dgvTestDetails.CurrentCell.ColumnIndex] = dgComboCell;
                                bIsComboBox = true;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message.ToString());
            }
        }
        private void dgvTestDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        private void dgvTestDetails_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgvTestDetails.Columns["RESULT_VALUE"].Index )
            {
                string VAL = Convert.ToString(this.dgvTestDetails.Rows[e.RowIndex].Cells["RESULT_VALUE"].Value);
                int ParaValCode = Convert.ToInt32(this.dgvTestDetails.Rows[e.RowIndex].Cells["PARA_VALUE_CODE"].Value);
                DataRow[] drow = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"].Select("RESULT_VALUE='" + Convert.ToString(VAL) + "' AND PARA_VALUE_CODE=" + ParaValCode);
                if (drow.Length != 0)
                {
                    int code = Convert.ToInt32(drow[0]["RESULT_CODE"]);
                    dgvTestDetails.Rows[e.RowIndex].Cells["RESULT_CODE"].Value = code;
                    dgvTestDetails.Rows[e.RowIndex].Cells["RESULT_VALUE"].Value = VAL;
                }
            }
        }
        #endregion

        
    }
}
