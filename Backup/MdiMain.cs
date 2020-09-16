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
    public partial class MdiMain : Form
    {

        //private System.Windows.Forms.ToolStripMenuItem NewReportToolStripMenuItem;
        private int childFormNumber = 0;

        public MdiMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void newEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatientMas ObjPatientMas = new frmPatientMas();
            ObjPatientMas.MdiParent = this;
            ObjPatientMas.Show();
        }

        private void printBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBill objbill = new frmBill();
            objbill.MdiParent = this;
            objbill.Show();
        }

        private void MdiMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = GLOBAL.UserGroup +  " : " + GLOBAL.loginUserName;
            if (GLOBAL.ds.Tables["MENU_MAS"].Rows.Count > 0)
            {
                for (int i = 0; i < GLOBAL.ds.Tables["MENU_MAS"].Rows.Count; i++)
                {
                    bool Right = false;
                    if (GLOBAL.UserGroup.ToUpper() != "ADMIN")
                    {
                        DataRow[] row = GLOBAL.ds.Tables["USER_RIGHTS"].Select("U_CODE='" + GLOBAL.loginUserId + "' AND MENU_CODE='" + Convert.ToString(GLOBAL.ds.Tables["MENU_MAS"].Rows[i]["MENU_CODE"]) + "'");

                        if (row.Length != 0)
                        {
                            if (Convert.ToInt32(row[0]["RIGHTS"]) == 1)
                            {
                                Right = true;
                            }
                        }
                    }
                    else
                        Right = true;

                    if (Right)
                    {
                        string name = Convert.ToString(GLOBAL.ds.Tables["MENU_MAS"].Rows[i]["MENU_CODE"]) + "ToolStripMenuItem";
                        System.Windows.Forms.ToolStripMenuItem MenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        MenuItem.Name = name;
                        MenuItem.Text = Convert.ToString(GLOBAL.ds.Tables["MENU_MAS"].Rows[i]["MENU_NAME"]);
                        MenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
                        
                        switch (Convert.ToString(GLOBAL.ds.Tables["MENU_MAS"].Rows[i]["MENU_GROUP"]).ToUpper())
                        {
                            case "MASTER":
                                this.patientsToolStripMenuItem.DropDownItems.Add(MenuItem);
                                break;
                            case "REPORT":
                                this.reportsToolStripMenuItem.DropDownItems.Add(MenuItem);
                                break;
                            case "USER":
                                this.viewMenu.DropDownItems.Add(MenuItem);
                                break;
                            case "SETTINGS":
                                this.settingsToolStripMenuItem.DropDownItems.Add(MenuItem);
                                break;
                        }
                    }
                }
            }

            //this.NewReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            //this.NewReportToolStripMenuItem.Name = "NewReportToolStripMenuItem";
            //this.NewReportToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            //this.NewReportToolStripMenuItem.Text = "New Report";
            //this.NewReportToolStripMenuItem.Click += new System.EventHandler(this.heamogramReportToolStripMenuItem_Click);
            //this.reportsToolStripMenuItem.DropDownItems.Add(NewReportToolStripMenuItem);
            if (GLOBAL.ds.Tables["COMP_MAS"].Rows.Count == 0)
            {
                frmCompanySettings objpara = new frmCompanySettings();
                objpara.MdiParent = this;
                objpara.Show();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void testSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParameter objpara = new frmParameter();
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void MdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GLOBAL.SaveDB();
        }

        private void databaswToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabase objpara = new frmDatabase();
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void MdiMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                //this.Close();
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport objpara = new frmReport(1);
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void bloodSugarEstimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmReport objpara = new frmReport(1);
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void heamogramReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport objpara = new frmReport(2);
            objpara.MdiParent = this;
            objpara.Show();
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                DataRow[] row=GLOBAL.ds.Tables["MENU_MAS"].Select("MENU_NAME='"+ Convert.ToString(sender) + "'");
                if (row.Length!=0)
                {
                    ClickEvent(Convert.ToString(row[0]["MENU_CODE"]),Convert.ToString(sender).ToUpper(), Convert.ToString(row[0]["MENU_GROUP"]));
                }
        }

        private void ClickEvent(string ID,string NAME, string Group)
        {
            switch (Group.ToUpper())
            {
                case "MASTER":
                    if (NAME=="NEW ENTRY")
                    {
                        frmPatientMas ObjPatientMas = new frmPatientMas();
                        ObjPatientMas.MdiParent = this;
                        ObjPatientMas.Show();
                    }
                    else if (NAME == "PRINT BILL")
                    {
                        frmBill objbill = new frmBill();
                        objbill.MdiParent = this;
                        objbill.Show();
                    }
                    break;
                case "REPORT":
                    DataRow[] rw = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("PARA_TYPE='" + NAME + "'");
                    if (rw.Length != 0)
                    {
                        frmReport objReport = new frmReport(Convert.ToInt32(rw[0]["PARA_TYPE_CODE"]));
                        objReport.MdiParent = this;
                        objReport.Show();
                    }
                    break;
                case "USER":
                    if (NAME == "USER SETTINGS")
                    {
                        frmUserSettings objUser = new frmUserSettings();
                        objUser.MdiParent = this;
                        objUser.Show();
                    }
                    else if (NAME == "DATABASE")
                    {
                        frmDatabase objDB = new frmDatabase();
                        objDB.MdiParent = this;
                        objDB.Show();
                    }
                    else if (NAME == "VIEW")
                    {
                        frmExtraReport objDB = new frmExtraReport();
                        objDB.MdiParent = this;
                        objDB.Show();
                    }
                    break;
                case "SETTINGS":
                    if (NAME == "REPORT SETTINGS")
                    {
                        frmParameter objpara = new frmParameter();
                        objpara.MdiParent = this;
                        objpara.Show();
                    }
                    else if (NAME == "LABORATORY SETTINGS")
                    {
                        frmCompanySettings objpara = new frmCompanySettings();
                        objpara.MdiParent = this;
                        objpara.Show();
                    }
                    else if (NAME == "MENU SETTINGS")
                    {
                        frmMenuSettings objpara = new frmMenuSettings();
                        objpara.MdiParent = this;
                        objpara.Show();
                    }
                    else if (NAME == "TEST PRICE SETTINGS")
                    {
                        frmPriceList objpara = new frmPriceList();
                        objpara.MdiParent = this;
                        objpara.Show();
                    }
                    break;
            }
            
        }
        private void bioChemistryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport objpara = new frmReport(3);
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void urineExaminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport objpara = new frmReport(4);
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void antibodyDetectionForHIViToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport objpara = new frmReport(7);
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void urinePregnancyTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport objpara = new frmReport(5);
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void antenatalProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport objpara = new frmReport(6);
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void MantouxTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport objpara = new frmReport(8);
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void userSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserSettings objpara = new frmUserSettings();
            objpara.MdiParent = this;
            objpara.Show();
        }

        private void MdiMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();           
        }

    }
}
