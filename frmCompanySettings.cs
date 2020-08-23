using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab
{
    public partial class frmCompanySettings : Lab.BaseForm
    {
        
        #region Form Events
        public frmCompanySettings()
        {
            InitializeComponent();
        }

        private void frmCompanySettings_Load(object sender, EventArgs e)
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

            //this.txtAge.Validated += new System.EventHandler(this.txtAge_Validated);
            //this.cmbPName.SelectedIndexChanged += new System.EventHandler(this.cmbPName_SelectedIndexChanged);
            //this.cmbPName.Validated += new System.EventHandler(this.cmbPName_Validated);
            //this.cmbPName.TextChanged += new System.EventHandler(this.cmbPName_TextChanged);
            //this.cmbRefName.Validated += new System.EventHandler(this.cmbRefName_Validated);
            #endregion

            #region Fill Controls
            //AutoCompleteLabNo();
            //FillPName();
            //FillRefName();
            #endregion

            LasRecord();
            ENABLE_DISABLE_CONTROLS(false);
        }
        private void frmCompanySettings_KeyDown(object sender, KeyEventArgs e)
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
            txtLabName.Text = "";
            txtAddress.Text = "";
            txtCityName.Text = "";
            txtPinCode.Text = "";
            txtPhoneNo.Text = "";
            txtMobileNo.Text = "";
            txtTime.Text = "";
            txtTechnicianName.Text = "";
        }
        private void NewRecord()
        {
            ClearAll();
            txtCompCode.Text = GetNewID("COMP_CODE", "COMP_MAS").ToString();
            //txtEntryDate.Text = System.DateTime.Today.ToShortDateString();
            ENABLE_DISABLE_CONTROLS(true);
            //cmbPName.Focus();
        }
        private void SaveRecord()
        {
            #region Save COMP_MAS
            if (GLOBAL.ds.Tables["COMP_MAS"].Rows.Count == 0 && txtLabName.Text != "")
            {
                GLOBAL.ds.Tables["COMP_MAS"].Rows.Add(Convert.ToInt32(txtCompCode.Text), txtLabName.Text, txtAddress.Text, txtCityName.Text, txtPinCode.Text, txtPhoneNo.Text, txtMobileNo.Text, txtTime.Text, System.DateTime.Today.ToShortDateString(),txtTechnicianName.Text);
            }
            else if (GLOBAL.ds.Tables["COMP_MAS"].Rows.Count > 0 && txtLabName.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["COMP_MAS"].Select("COMP_CODE=" + Convert.ToInt32(txtCompCode.Text));
                if (row.Length != 0)
                {
                    if (row[0].IsNull("COMP_CODE"))
                    {
                        GLOBAL.ds.Tables["COMP_MAS"].Rows.Add(Convert.ToInt32(txtCompCode.Text), txtLabName.Text, txtAddress.Text, txtCityName.Text, txtPinCode.Text, txtPhoneNo.Text, txtMobileNo.Text, txtTime.Text, System.DateTime.Today.ToShortDateString(),txtTechnicianName.Text);
                    }
                    else
                    {
                        int rowIndex = GLOBAL.ds.Tables["COMP_MAS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["COMP_NAME"] = txtLabName.Text;
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["COMP_ADD"] = txtAddress.Text;
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["COMP_CITY"] = txtCityName.Text;
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["COMP_PINCODE"] = txtPinCode.Text;
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["COMP_PHONE"] = txtPhoneNo.Text;
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["COMP_MOBILE"] = txtMobileNo.Text;
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["COMP_TIMING"] = txtTime.Text;
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["ENTRY_DATE"] = System.DateTime.Today.ToShortDateString();
                        GLOBAL.ds.Tables["COMP_MAS"].Rows[rowIndex]["TECHNICIAN_NAME"] = txtTechnicianName.Text;
                    }
                }
                else
                    GLOBAL.ds.Tables["COMP_MAS"].Rows.Add(Convert.ToInt32(txtCompCode.Text), txtLabName.Text, txtAddress.Text, txtCityName.Text, txtPinCode.Text, txtPhoneNo.Text, txtMobileNo.Text, txtTime.Text, System.DateTime.Today.ToShortDateString(),txtTechnicianName.Text);
            }
            #endregion
        }
        private void DeleteRecord()
        {
            if (GLOBAL.ds.Tables["COMP_MAS"].Rows.Count > 0 && txtLabName.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["COMP_MAS"].Select("COMP_CODE=" + Convert.ToInt32(txtCompCode.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("COMP_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["COMP_MAS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["COMP_MAS"].Rows.RemoveAt(rowIndex);
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
            if (GLOBAL.ds.Tables["COMP_MAS"].Rows.Count > 0)
            {
                #region Fill Company Details
                txtCompCode.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["COMP_CODE"].ToString();
                txtLabName.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["COMP_NAME"].ToString();
                txtAddress.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["COMP_ADD"].ToString();
                txtCityName.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["COMP_CITY"].ToString();
                txtPinCode.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["COMP_PINCODE"].ToString();
                txtPhoneNo.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["COMP_PHONE"].ToString();
                txtMobileNo.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["COMP_MOBILE"].ToString();
                txtTime.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["COMP_TIMING"].ToString();
                txtTechnicianName.Text = GLOBAL.ds.Tables["COMP_MAS"].Rows[Index]["TECHNICIAN_NAME"].ToString();
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
            if (txtCompCode.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["COMP_MAS"].Select("COMP_CODE=" + Convert.ToInt32(txtCompCode.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("COMP_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["COMP_MAS"].Rows.IndexOf(row[0]);
                        if (rowIndex >= 0 && rowIndex != GLOBAL.ds.Tables["COMP_MAS"].Rows.Count - 1)
                        {
                            FillRecord(rowIndex + 1);
                        }
                        else
                        {
                            FillRecord(GLOBAL.ds.Tables["COMP_MAS"].Rows.Count - 1);
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
            if (txtCompCode.Text != "")
            {
                DataRow[] row = GLOBAL.ds.Tables["COMP_MAS"].Select("COMP_CODE=" + Convert.ToInt32(txtCompCode.Text));
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("COMP_CODE"))
                    {
                        int rowIndex = GLOBAL.ds.Tables["COMP_MAS"].Rows.IndexOf(row[0]);
                        if (rowIndex > 0 && rowIndex != GLOBAL.ds.Tables["COMP_MAS"].Rows.Count)
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
            FillRecord(GLOBAL.ds.Tables["COMP_MAS"].Rows.Count - 1);
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
        private void ENABLE_DISABLE_CONTROLS(bool Val)
        {
            btn_Cancel.Enabled = Val;
            btn_Clear.Enabled = Val;
            btn_Save.Enabled = Val;
            btn_Edit.Enabled = !Val;
            btn_New.Enabled = !Val;
            btn_Delete.Enabled = !Val;

        }
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
            if (txtLabName.Text == "")
            {
                ShowMessagePrompt("Enter Laboratory Name", "");
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

        #region Text Changed Event
        private void txtLabName_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtTechnicianName_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtCityName_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtPinCode_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            ENABLE_DISABLE_CONTROLS(true);
        }
        #endregion

        #endregion
    }
}
