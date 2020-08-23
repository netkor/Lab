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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        #region Form Events
        private void frmLogin_Load(object sender, EventArgs e)
        {
            GLOBAL.LoadDB();
        }
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
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
        #endregion

        #region Common Functions
        private bool InputData()
        {
            bool flag = false;
            if (txtUserId.Text.Trim() == "")
            {
                MessageBox.Show(" UserId cannot be blank", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserId.Focus();
            }
            else if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show(" Please enter password", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }
            else
                flag = true;

            return flag;
        }
        private void GetUserName()
        {
            try
            {

            DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select("U_CODE='" +  txtUserId.Text.Trim() + "'");
            if (row.Length != 0)
            {
                txtUserName.Text = Convert.ToString(row[0]["U_NAME"]);
            }
            else
            {
                txtUserId.Text = "";
                txtUserId.Focus();
                
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        private void CheckLogin()
        {
            try
            {
            string StrCriteria="";
            if (txtUserId.Text.Trim().Length > 0 && txtPassword.Text.Trim().Length > 0)
            {
                StrCriteria = " U_CODE='" + txtUserId.Text.Trim() + "' AND U_NAME='" + txtUserName.Text.Trim() + "'";
            }
            else if (txtUserName.Text.Trim().Length > 0)
            {
                StrCriteria = " U_NAME='" + txtUserName.Text.Trim() + "'";
            }
            else if (txtUserId.Text.Trim().Length > 0)
            {
                StrCriteria = " U_CODE='" + txtUserId.Text.Trim() + "'";
            }

            string EncodePwd;
            DataRow[] row = GLOBAL.ds.Tables["USER_MAS"].Select(StrCriteria);
            if (row.Length == 0)
            {
                EncodePwd = GLOBAL.ECODE_DECODE(("Admin").Trim(), "E");
                GLOBAL.ds.Tables["USER_MAS"].Rows.Add("A", "Admin", EncodePwd, "Admin");
                MessageBox.Show("New User Created successfully", "User Created", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //try
                //{
                //    GLOBAL.ds.WriteXmlSchema(Application.StartupPath + @"\QUICK_LAB.xsd");
                //    GLOBAL.ds.WriteXml(Application.StartupPath + @"\QUICK_LAB.xml");
                //    MessageBox.Show("Record save successfully!", "S");
                //    this.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error :" + ex.Message);
                //}
                MdiMain main = new MdiMain();
                main.ShowDialog();
                this.Close();
            }

            string User="";
            string Password="";
            if (InputData())
            {
                if (row.Length != 0)
                {
                    User = Convert.ToString(row[0]["U_CODE"]);
                    Password = Convert.ToString(row[0]["PASS"]);
                }

                if (txtUserId.Text.Trim().ToUpper() == User.ToUpper())
                {
                    string DcodePass;
                    DcodePass = GLOBAL.ECODE_DECODE(Password.ToUpper(), "D");
                    if (txtPassword.Text.Trim().ToUpper() == DcodePass.ToUpper())
                    {
                        GLOBAL.loginUserId = txtUserId.Text.Trim().ToUpper();
                        GLOBAL.loginUserName = txtPassword.Text.Trim().ToUpper();
                        GLOBAL.UserGroup = Convert.ToString(row[0]["U_GROUP"]);
                        MdiMain main = new MdiMain();
                        //this.Close();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password.Please retype it", "Invalid", MessageBoxButtons.OK);
                        txtPassword.Text = "";
                        txtPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect UserId / UserName.Please retype it", "Invalid", MessageBoxButtons.OK);
                    txtUserId.Text = "";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtUserId.Focus();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Control Events
        private void txtUserId_Validated(object sender, EventArgs e)
        {
            if (txtUserId.Text.Length > 0)
                GetUserName();
        }
        private void txtUserName_Validated(object sender, EventArgs e)
        {

        }
        private void txtPassword_Validated(object sender, EventArgs e)
        {

        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();  
        }
        #endregion

    }
}


