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
    public partial class frmUserSettings : Form
    {
        #region Declaration
        bool chkRights;
        string Menu_Code;
        #endregion

        #region Common Function
        private void ClearAll()
        {
            txtUserId.Text = "";
            txtUserName.Text = "";
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtUserId.Enabled = true;
            txtUserName.Enabled = true;
            cboUserGroup.Enabled = true;
        }
        private bool RequiredField()
        {
            try
            {
            if (txtUserId.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter User ID ..", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserId.Focus();
            }
            else if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter User Group..", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboUserGroup.Focus();
            }
            else if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter User Name..", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserName.Focus();
            }
            else if (txtNewPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter New Password..", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNewPassword.Focus();
            }
            else if (txtConfirmPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter New Password..", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfirmPassword.Focus();
            }
            else if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                MessageBox.Show("New Password and Confirm Password does not match..", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNewPassword.Focus();
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
            else
            {
                return true;
            }
            return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void GetUserName()
        {
            try
            {
                DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select("U_CODE='" + txtUserId.Text.Trim() + "'");
                if (row.Length != 0)
                {
                    txtUserName.Text = Convert.ToString(row[0]["U_NAME"]);
                    cboUserGroup.Text = Convert.ToString(row[0]["U_GROUP"]);
                }
                else
                {
                    txtUserId.Text = "";
                    cboUserGroup.Text = "";
                    txtUserId.Focus();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void CheckDupID()
        {
            try
            {
                DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select("U_CODE='" + txtUserId.Text.Trim() + "'");
                if (row.Length != 0)
                {
                    MessageBox.Show("This ID is already Exist,please Enter another one", "ID Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserId.Text = "";
                    txtUserId.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckDupUserName()
        {
            try
            {
                DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select("U_NAME='" + txtUserName.Text.Trim() + "'");
                if (row.Length != 0)
                {
                    MessageBox.Show("This User Name is already Exist,please Enter another one", "ID Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Text = "";
                    txtUserName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LockUser()
        {
            try
            {
                txtUserId.Text = GLOBAL.loginUserId;
                txtUserName.Text = GLOBAL.loginUserName;
                cboUserGroup.Text = GLOBAL.UserGroup;

                if (GLOBAL.UserGroup.ToUpper() == "ADMIN")
                {
                    txtUserId.Enabled = false;
                    txtUserName.Enabled = false;
                    cboUserGroup.Enabled = false;
                }
                else
                {
                    txtUserId.Enabled = false;
                    txtUserName.Enabled = false;
                    cboUserGroup.Enabled = false;
                    txtOldPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    btn_NewUser.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckPassword()
        {
            try
            {
                string StrCriteria = " U_CODE='" + txtUserId.Text.Trim() + "' AND U_NAME='" + txtUserName.Text.Trim() + "'";
                
                if (GLOBAL.UserGroup.ToUpper()!="ADMIN")
                {
                    DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select(StrCriteria);
                    if (row.Length!=0)
                    {
                        string Password = Convert.ToString(row[0]["PASS"]);
                        string DcodePass;
                        DcodePass = GLOBAL.ECODE_DECODE(Password.ToUpper(), "D");
                        if (txtOldPassword.Text.Trim().ToUpper() == DcodePass.ToUpper())
                        {
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Password.Please retype it", "Invalid", MessageBoxButtons.OK);
                            txtOldPassword.Text = "";
                            txtOldPassword.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SelectedTab()
        {
            try
            {
                if (TabControl1.SelectedTab.Name.ToString() == "tabUserSettings")
                {
                    cboAllUser.Items.Clear();
                    DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select("U_GROUP='user'");
                    foreach (DataRow rw in row)
                    {
                        cboAllUser.Items.Add(rw["U_CODE"].ToString() + "-" + rw["U_NAME"].ToString());
                    }
                    ShowMenu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveNewUSer()
        {
            try
            {
                string encodePass = GLOBAL.ECODE_DECODE((txtNewPassword.Text).Trim(), "E");
                string StrCriteria = " U_CODE='" + txtUserId.Text.Trim() + "' AND U_NAME='" + txtUserName.Text.Trim() + "'";
                DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select(StrCriteria);
                if (RequiredField())
                {
                    if (row.Length != 0)
                    {
                        int rowIndex = GLOBAL.ds.Tables["USER_MAS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["USER_MAS"].Rows[rowIndex]["U_CODE"] = txtUserId.Text;
                        GLOBAL.ds.Tables["USER_MAS"].Rows[rowIndex]["U_NAME"] = txtUserName.Text;
                        GLOBAL.ds.Tables["USER_MAS"].Rows[rowIndex]["PASS"] = encodePass;
                        GLOBAL.ds.Tables["USER_MAS"].Rows[rowIndex]["U_GROUP"] = cboUserGroup.Text;
                        MessageBox.Show("User Password updated", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        GLOBAL.ds.Tables["USER_MAS"].Rows.Add(txtUserId.Text, txtUserName.Text, encodePass, cboUserGroup.Text);
                        MessageBox.Show("New User  Sucessfully Inserted", "Data Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                btn_NewUser.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void changeUserPassword()
        {
            try
            {
                string encodePass = GLOBAL.ECODE_DECODE((txtNewPassword.Text).Trim(), "E");
                if (txtNewPassword.Text != "" && txtConfirmPassword.Text != "" && (txtNewPassword.Text.Trim() == txtConfirmPassword.Text.Trim()))
                {
                    string StrCriteria = " U_CODE='" + txtUserId.Text.Trim() + "'";
                    DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select(StrCriteria);
                    if (RequiredField())
                    {
                        if (row.Length != 0)
                        {
                            int rowIndex = GLOBAL.ds.Tables["USER_MAS"].Rows.IndexOf(row[0]);
                            GLOBAL.ds.Tables["USER_MAS"].Rows[rowIndex]["U_CODE"] = txtUserId.Text;
                            GLOBAL.ds.Tables["USER_MAS"].Rows[rowIndex]["U_NAME"] = txtUserName.Text;
                            GLOBAL.ds.Tables["USER_MAS"].Rows[rowIndex]["PASS"] = encodePass;
                            GLOBAL.ds.Tables["USER_MAS"].Rows[rowIndex]["U_GROUP"] = cboUserGroup.Text;

                            MessageBox.Show("User Password updated", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowMenu()
        {
            DataGridViewCheckBoxColumn rightscheck=new DataGridViewCheckBoxColumn();
            rightscheck.Name = "RIGHTS";
            rightscheck.HeaderText = "Rights";

            menu_Grid.Columns.Clear();
            menu_Grid.Rows.Clear();

            menu_Grid.Columns.Add("MENU_CODE","Code");
            menu_Grid.Columns.Add("MENU_NAME","Menu Name");
            menu_Grid.Columns.Add(rightscheck);

            menu_Grid.Columns["MENU_CODE"].ReadOnly = true;
            menu_Grid.Columns["MENU_NAME"].ReadOnly = true;

            menu_Grid.Columns["MENU_CODE"].ValueType = typeof(System.Int32);
            menu_Grid.Columns["MENU_CODE"].Width = 100;
            menu_Grid.Columns["MENU_NAME"].Width = 156;
            menu_Grid.Columns["RIGHTS"].Width = 100;

            if (GLOBAL.ds.Tables["MENU_MAS"].Rows.Count>0)
            {
                for (int i = 0; i < GLOBAL.ds.Tables["MENU_MAS"].Rows.Count; i++)
                {
                    menu_Grid.Rows.Add();
                    menu_Grid.Rows[i].Cells["MENU_CODE"].Value = GLOBAL.ds.Tables["MENU_MAS"].Rows[i]["MENU_CODE"].ToString();
                    menu_Grid.Rows[i].Cells["MENU_NAME"].Value = GLOBAL.ds.Tables["MENU_MAS"].Rows[i]["MENU_NAME"].ToString();
                }
            }
        }
        private void SaveMenuDetail(DataGridViewCellEventArgs e)
        {
            try
            {
                Menu_Code = Convert.ToString(menu_Grid.Rows[e.RowIndex].Cells["MENU_CODE"].Value);
                string User_ID = Get_ID((cboAllUser.Text).Trim());

                string StrCriteria = " U_CODE='" + User_ID + "' AND MENU_CODE='" + Menu_Code.Trim() + "'";
                DataRow[] row = GLOBAL.ds.Tables["USER_RIGHTS"].Select(StrCriteria);

                if (chkRights)
                {
                    //bool rights=;
                    if (row.Length != 0)
                    {
                        int rowIndex = GLOBAL.ds.Tables["USER_RIGHTS"].Rows.IndexOf(row[0]);
                        GLOBAL.ds.Tables["USER_RIGHTS"].Rows[rowIndex]["U_CODE"] = User_ID;
                        GLOBAL.ds.Tables["USER_RIGHTS"].Rows[rowIndex]["MENU_CODE"] = Menu_Code;
                        GLOBAL.ds.Tables["USER_RIGHTS"].Rows[rowIndex]["RIGHTS"] = (chkRights)?1:0;
                    }
                    else
                    {
                        GLOBAL.ds.Tables["USER_RIGHTS"].Rows.Add(User_ID, Menu_Code, (chkRights) ? 1 : 0);
                    }
                }
                else
                {
                    GLOBAL.ds.Tables["USER_RIGHTS"].Rows.Remove(row[0]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string Get_ID(string name)
        {
            string code=name.Substring(0,name.IndexOf("-",0));
            return code;
        }
        private void DisplayUserRights()
        {
            try
            {
            if (cboAllUser.Text.Length>0)
            {
                menu_Grid.Rows.Clear();
                string User_ID = Get_ID((cboAllUser.Text).Trim());

                if (GLOBAL.ds.Tables["MENU_MAS"].Rows.Count > 0)
                {
                    for (int i = 0; i < GLOBAL.ds.Tables["MENU_MAS"].Rows.Count; i++)
                    {
                        menu_Grid.Rows.Add();
                        menu_Grid.Rows[i].Cells["MENU_CODE"].Value = GLOBAL.ds.Tables["MENU_MAS"].Rows[i]["MENU_CODE"].ToString();
                        menu_Grid.Rows[i].Cells["MENU_NAME"].Value = GLOBAL.ds.Tables["MENU_MAS"].Rows[i]["MENU_NAME"].ToString();

                        string Menu_Code = Convert.ToString(menu_Grid.Rows[i].Cells["MENU_CODE"].Value);
                        string StrCriteria = " U_CODE='" + User_ID + "' AND MENU_CODE='" + Menu_Code.Trim() + "'";
                        DataRow[] row = GLOBAL.ds.Tables["USER_RIGHTS"].Select(StrCriteria);
                        if (row.Length!=0)
                        {
                            foreach (DataRow rw in row)
                            {
                                menu_Grid.Rows[i].Cells["RIGHTS"].Value = Convert.ToInt32(rw["RIGHTS"]);
                            }
                        }

                    }
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Form Events
        public frmUserSettings()
        {
            InitializeComponent();
        }
        private void frmUserSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void frmUserSettings_Load(object sender, EventArgs e)
        {
            ClearAll();
            if (GLOBAL.UserGroup.ToUpper() == "ADMIN")
            {
                txtOldPassword.Enabled = false;
                LockUser();
            }
            else
            {
                TabControl1.Controls.Remove(TabControl1.TabPages["tabUserSettings"]);
                cboUserGroup.DropDownStyle = ComboBoxStyle.DropDown;
                LockUser();
            }

        }
        #endregion

        #region Control Events
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtUserId_Validated(object sender, EventArgs e)
        {
            CheckDupID();
        }
        private void btn_NewUser_Click(object sender, EventArgs e)
        {
            ClearAll();
            cboUserGroup.Items.Clear();
            cboUserGroup.Items.Add("Admin");
            cboUserGroup.Items.Add("User");
            txtUserId.Focus();
            btn_NewUser.Enabled = false;
            btn_ChangePasword.Text = "Save";
        }
        private void txtOldPassword_Validated(object sender, EventArgs e)
        {
            if (txtOldPassword.Text.Length>0)
            {
                CheckPassword();
            }
        }
        private void txtUserName_Validated(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length>0)
            {
                CheckDupUserName();
            }
        }
        private void btn_Display_Click(object sender, EventArgs e)
        {
            DisplayUserRights();
        }
        private void btn_chaneUserPass_Click(object sender, EventArgs e)
        {
            changeUserPassword();
        }
        private void btn_ChangePasword_Click(object sender, EventArgs e)
        {
            SaveNewUSer();
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTab();
        }
        #endregion

        #region Grid Events
        private void menu_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.ColumnIndex == menu_Grid.Columns["RIGHTS"].Index))
            {
                return;
            }
            else
            {
                chkRights = Convert.ToBoolean(menu_Grid.Rows[e.RowIndex].Cells[2].Value);
                SaveMenuDetail(e);
            }
        }
        #endregion
    }
}
