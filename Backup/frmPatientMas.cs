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
    public partial class frmPatientMas : BaseForm
    {
        #region Form Events
        public frmPatientMas()
        {
            InitializeComponent();
        }
        private void frmPatientMas_Load(object sender, EventArgs e)
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
            #endregion

            #region Fill Controls
            AutoCompleteLabNo();
            AutoCompleteDLabNo();
            AutoCompleteSPCode();
            FillPName();
            FillRefName();
            #endregion

            LasRecord();
            ENABLE_DISABLE_CONTROLS(false);
        }
        private void frmPatientMas_KeyDown(object sender, KeyEventArgs e)
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
            txtAddress.Text = "";
            txtAge.Text = "";
            txtEntryDate.Text = "";
            txtLabNo.Text = "";
            txtPCode.Text = "";
            cmbPName.Text = "";
            cmbSex.Text = "";
            txtRefCode.Text = "";
            cmbRefName.Text = "";
            txtDLabNo.Text = "";
            txtSPCode.Text = "";
        }
        private void NewRecord()
        {
            ClearAll();
            txtLabNo.Text = GetNewID("LAB_CODE","LAB_MAS").ToString();
            txtDLabNo.Text = GetTodayNewID("DLAB_CODE", "LAB_MAS").ToString();
            txtEntryDate.Text = System.DateTime.Today.ToShortDateString();
            ENABLE_DISABLE_CONTROLS(true);
            cmbPName.Focus();
        }
        private void SaveRecord()
        {
            #region Save LAB_MAS
            if (GLOBAL.ds.Tables["LAB_MAS"].Rows.Count == 0 && txtPCode.Text != "")
            {
                GLOBAL.ds.Tables["LAB_MAS"].Rows.Add(Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtDLabNo.Text), Convert.ToInt32(txtPCode.Text), Convert.ToInt32(txtRefCode.Text), txtEntryDate.Text);
            }
            else if (GLOBAL.ds.Tables["LAB_MAS"].Rows.Count > 0 && txtPCode.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["LAB_MAS"].Select("LAB_CODE=" + Convert.ToInt32(txtLabNo.Text));
                if (row.Length != 0)
                {
                    if (row[0].IsNull("LAB_CODE"))
                    {
                        GLOBAL.ds.Tables["LAB_MAS"].Rows.Add(Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtDLabNo.Text), Convert.ToInt32(txtPCode.Text), Convert.ToInt32(txtRefCode.Text), txtEntryDate.Text);
                    }
                    else
                    {
                        int rowIndex = GLOBAL.ds.Tables["LAB_MAS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["LAB_MAS"].Rows[rowIndex]["DLAB_CODE"] = txtDLabNo.Text;
                        GLOBAL.ds.Tables["LAB_MAS"].Rows[rowIndex]["P_CODE"] = txtPCode.Text;
                        GLOBAL.ds.Tables["LAB_MAS"].Rows[rowIndex]["R_CODE"] = txtRefCode.Text;
                        GLOBAL.ds.Tables["LAB_MAS"].Rows[rowIndex]["LAB_DATE"] = txtEntryDate.Text;
                        
                    }
                }
                else
                    GLOBAL.ds.Tables["LAB_MAS"].Rows.Add(Convert.ToInt32(txtLabNo.Text), Convert.ToInt32(txtDLabNo.Text), Convert.ToInt32(txtPCode.Text), Convert.ToInt32(txtRefCode.Text), txtEntryDate.Text);
            }
            #endregion

            #region Save PATIENT_MAS
            if (GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Count == 0 && txtPCode.Text != "")
            {
                GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Add(Convert.ToInt32(txtPCode.Text), txtSPCode.Text == "" ? 0 : Convert.ToInt32(txtSPCode.Text), cmbPName.Text, txtAge.Text, cmbSex.Text, txtAddress.Text);
            }
            else if (GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Count > 0)
            {
                DataRow[] rowp = GLOBAL.ds.Tables["PATIENT_MAS"].Select("P_CODE=" + Convert.ToInt32(txtPCode.Text));
                if (rowp.Length != 0)
                {
                    if (rowp[0].IsNull("P_CODE"))
                    {
                        GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Add(Convert.ToInt32(txtPCode.Text), txtSPCode.Text == "" ? 0 : Convert.ToInt32(txtSPCode.Text), cmbPName.Text, txtAge.Text, cmbSex.Text, txtAddress.Text);
                    }
                    else
                    {
                        int rowIndex = GLOBAL.ds.Tables["PATIENT_MAS"].Rows.IndexOf(rowp[0]);
                        GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["P_NAME"] = cmbPName.Text;
                        GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["P_AGE"] = txtAge.Text;
                        GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["P_SEX"] = cmbSex.Text;
                        GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["P_AREA"] = txtAddress.Text;
                        GLOBAL.ds.Tables["PATIENT_MAS"].Rows[rowIndex]["SP_CODE"] = txtSPCode.Text == "" ? 0 : Convert.ToInt32(txtSPCode.Text);
                    }
                }
                else
                    GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Add(Convert.ToInt32(txtPCode.Text), txtSPCode.Text==""? 0 : Convert.ToInt32(txtSPCode.Text), cmbPName.Text, txtAge.Text, cmbSex.Text, txtAddress.Text);
            }
            #endregion

            #region Save REF_DR_MAS
            if (GLOBAL.ds.Tables["REF_DR_MAS"].Rows.Count == 0 && txtRefCode.Text != "")
            {
                GLOBAL.ds.Tables["REF_DR_MAS"].Rows.Add(Convert.ToInt32(txtRefCode.Text), cmbRefName.Text);
            }
            else if (GLOBAL.ds.Tables["REF_DR_MAS"].Rows.Count > 0)
            {
                DataRow[] rowp = GLOBAL.ds.Tables["REF_DR_MAS"].Select("R_CODE=" + Convert.ToInt32(txtRefCode.Text));
                if (rowp.Length != 0)
                {
                    if (rowp[0].IsNull("R_CODE"))
                    {
                        GLOBAL.ds.Tables["REF_DR_MAS"].Rows.Add(Convert.ToInt32(txtRefCode.Text), cmbRefName.Text);
                    }
                    else
                    {
                        int rowIndex = GLOBAL.ds.Tables["REF_DR_MAS"].Rows.IndexOf(rowp[0]);
                        GLOBAL.ds.Tables["REF_DR_MAS"].Rows[rowIndex]["R_NAME"] = cmbRefName.Text;
                    }
                }
                else
                    GLOBAL.ds.Tables["REF_DR_MAS"].Rows.Add(Convert.ToInt32(txtRefCode.Text), cmbRefName.Text);
            }
            #endregion
        }
        private void DeleteRecord()
        {
            if (GLOBAL.ds.Tables["LAB_MAS"].Rows.Count > 0 && txtPCode.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["LAB_MAS"].Select("LAB_CODE=" + Convert.ToInt32(txtLabNo.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("LAB_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["LAB_MAS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["LAB_MAS"].Rows.RemoveAt(rowIndex);
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
            if (GLOBAL.ds.Tables["LAB_MAS"].Rows.Count > 0)
            {
                #region Fill Lab Details
                txtLabNo.Text = GLOBAL.ds.Tables["LAB_MAS"].Rows[Index]["LAB_CODE"].ToString();
                txtDLabNo.Text = GLOBAL.ds.Tables["LAB_MAS"].Rows[Index]["DLAB_CODE"].ToString();
                txtPCode.Text = GLOBAL.ds.Tables["LAB_MAS"].Rows[Index]["P_CODE"].ToString();
                txtRefCode.Text = GLOBAL.ds.Tables["LAB_MAS"].Rows[Index]["R_CODE"].ToString();
                txtEntryDate.Text = GLOBAL.ds.Tables["LAB_MAS"].Rows[Index]["LAB_DATE"].ToString();
                #endregion

                #region Fill Patient Details
                DataRow[] rowp = GLOBAL.ds.Tables["PATIENT_MAS"].Select("P_CODE=" + Convert.ToInt32(txtPCode.Text));
                if (rowp.Length != 0)
                {
                    if (!rowp[0].IsNull("P_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["PATIENT_MAS"].Rows.IndexOf(rowp[0]);
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
            }
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
                DataRow[] row = GLOBAL.ds.Tables["LAB_MAS"].Select("LAB_CODE=" + Convert.ToInt32(txtLabNo.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("LAB_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["LAB_MAS"].Rows.IndexOf(row[0]);
                        if (rowIndex >= 0 && rowIndex != GLOBAL.ds.Tables["LAB_MAS"].Rows.Count - 1)
                        {
                            FillRecord(rowIndex + 1);
                        }
                        else
                        {
                            FillRecord(GLOBAL.ds.Tables["LAB_MAS"].Rows.Count - 1);
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
            if (txtLabNo.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["LAB_MAS"].Select("LAB_CODE=" + Convert.ToInt32(txtLabNo.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("LAB_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["LAB_MAS"].Rows.IndexOf(row[0]);
                        if (rowIndex > 0 && rowIndex != GLOBAL.ds.Tables["LAB_MAS"].Rows.Count)
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
            FillRecord(GLOBAL.ds.Tables["LAB_MAS"].Rows.Count - 1);
        }
        #endregion

        #region Common Functions
        private int GetNewID(string FieldName,string TableName)
        {
            int nextId = 0;
            if (GLOBAL.ds.Tables[TableName].Rows.Count == 0)
            {
                nextId = 1;
            }
            else 
            {
                DataRow row = GLOBAL.ds.Tables[TableName].Select(""+ FieldName + "=MAX("+ FieldName+")")[0];
                nextId = Convert.ToInt32(row[FieldName]) + 1;
            }
                
            return nextId;
        }
        private int GetTodayNewID(string FieldName, string TableName)
        {
            int nextId = 0;

            DataTable dttemp = new DataTable();
            GLOBAL.ds.Tables[TableName].DefaultView.RowFilter = "LAB_DATE='" + System.DateTime.Today.ToShortDateString() + "'";
            dttemp = GLOBAL.ds.Tables[TableName].DefaultView.ToTable();

            if (dttemp.Rows.Count == 0)
            {
                nextId = 1;
            }
            else
            {
                DataRow row = dttemp.Select("" + FieldName + "=MAX(" + FieldName + ")")[0];
                nextId = Convert.ToInt32(row[FieldName]) + 1;
            }

            return nextId;
        }
        private void FillPateintDetail(string Code,string SPCode)
        {
            if (GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Count>0)
            {
                DataRow[] row=null;
                if (Code != "")
                {
                    row = GLOBAL.ds.Tables["PATIENT_MAS"].Select("P_CODE=" + Code);
                }
                else if (SPCode != "")
                {
                    row = GLOBAL.ds.Tables["PATIENT_MAS"].Select("SP_CODE=" + SPCode);
                }

                if (row.Length != 0)
                {
                    if (!row[0].IsNull("P_AGE") || !row[0].IsNull("P_SEX") || !row[0].IsNull("P_AREA"))
                    {
                        cmbPName.Text = row[0]["P_NAME"].ToString();
                        txtAge.Text = row[0]["P_AGE"].ToString();
                        cmbSex.Text = row[0]["P_SEX"].ToString();
                        txtAddress.Text = row[0]["P_AREA"].ToString();
                        txtSPCode.Text = row[0]["SP_CODE"].ToString();
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
        private void AutoCompleteDLabNo()
        {
            AutoCompleteStringCollection strDLabNo = new AutoCompleteStringCollection();
            for (int i = 0; i < GLOBAL.ds.Tables["LAB_MAS"].Rows.Count; i++)
            {
                if (Convert.ToString(GLOBAL.ds.Tables["LAB_MAS"].Rows[i]["LAB_DATE"])==System.DateTime.Today.ToShortDateString())
                {
                    strDLabNo.Add(GLOBAL.ds.Tables["LAB_MAS"].Rows[i]["DLAB_CODE"].ToString());    
                }
            }

            txtDLabNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDLabNo.AutoCompleteCustomSource = strDLabNo;
            txtDLabNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void AutoCompleteSPCode()
        {
            AutoCompleteStringCollection strSPCode = new AutoCompleteStringCollection();
            for (int i = 0; i < GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Count; i++)
            {
                strSPCode.Add(GLOBAL.ds.Tables["PATIENT_MAS"].Rows[i]["SP_CODE"].ToString());
            }

            txtSPCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSPCode.AutoCompleteCustomSource = strSPCode;
            txtSPCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        private void ENABLE_DISABLE_CONTROLS(bool Val)
        {
            btn_Cancel.Enabled = Val;
            btn_Clear.Enabled = Val;
            btn_Save.Enabled = Val;
            btn_Edit.Enabled = !Val;
            btn_New.Enabled = !Val;
            btn_Delete.Enabled = !Val;

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
            NextRecord();
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
        private void cmbPName_Validated(object sender, EventArgs e)
        {
            if (cmbPName.SelectedValue!=null)
            {
                txtPCode.Text = cmbPName.SelectedValue.ToString();
            }
            if (txtPCode.Text == "" && cmbPName.Text != "") //if (txtPCode.Text == "" && cmbPName.Text != "")
            {
                txtPCode.Text = GetNewID("P_CODE", "PATIENT_MAS").ToString();
            }
            else if (txtPCode.Text != "" && cmbPName.Text != "")
            {
                FillPateintDetail(txtPCode.Text,"");
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
        private void chkNewSugarPatient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewSugarPatient.Checked == true)
            {
                if (txtSPCode.Text.Length == 0)
                {
                    txtSPCode.Text = GetNewID("SP_CODE", "PATIENT_MAS").ToString(); ;

                }
            }
            else
            {
                txtSPCode.Text = "";
            }
        }
        private void txtSPCode_Validated(object sender, EventArgs e)
        {
            if (txtSPCode.Text != "")
            {
                FillPateintDetail("",txtSPCode.Text);
            }
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
        private void txtEntryDate_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        
        #endregion
    }
}
