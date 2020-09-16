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
    public partial class frmExtraReport : Lab.BaseForm
    {
        #region Form Events
        public frmExtraReport()
        {
            InitializeComponent();
        }

        private void frmExtraReport_Load(object sender, EventArgs e)
        {
            this.cmbPName.Validated += new System.EventHandler(this.cmbPName_Validated);
            this.cmbRefName.Validated += new System.EventHandler(this.cmbRefName_Validated);
            this.cmbTestName.Validated += new System.EventHandler(this.cmbTestName_Validated);
   
            FillPName();
            FillRefName();
            FillTestName();
        }

        private void frmExtraReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion
        #region Common Functions

        private void FillPateintDetail(string Code, string SPCode)
        {
            if (GLOBAL.ds.Tables["PATIENT_MAS"].Rows.Count > 0)
            {
                DataRow[] row = null;
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
        private void FillTestDetail(string Code)
        {
            if (GLOBAL.ds.Tables["PARA_TYPE_MAS"].Rows.Count > 0)
            {
                DataRow[] row = GLOBAL.ds.Tables["PARA_TYPE_MAS"].Select("PARA_TYPE_CODE=" + Code);
                if (row.Length != 0)
                {
                    if (!row[0].IsNull("PARA_TYPE"))
                    {
                        cmbTestName.Text = row[0]["PARA_TYPE"].ToString();
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
        private void FillTestName()
        {
            cmbTestName.DataSource = GLOBAL.ds.Tables["PARA_TYPE_MAS"];
            cmbTestName.DisplayMember = "PARA_TYPE";
            cmbTestName.ValueMember = "PARA_TYPE_CODE";
        }
        #endregion
        #region Combo And Text Events
        private void cmbPName_Validated(object sender, EventArgs e)
        {
            if (cmbPName.SelectedValue != null)
            {
                txtPCode.Text = cmbPName.SelectedValue.ToString();
            }
            if (txtPCode.Text == "" && cmbPName.Text != "") //if (txtPCode.Text == "" && cmbPName.Text != "")
            {
                //txtPCode.Text = GetNewID("P_CODE", "PATIENT_MAS").ToString();
            }
            else if (txtPCode.Text != "" && cmbPName.Text != "")
            {
                FillPateintDetail(txtPCode.Text, "");
            }
        }
        private void cmbRefName_Validated(object sender, EventArgs e)
        {
            if (cmbRefName.SelectedValue != null)
            {
                txtRefCode.Text = cmbRefName.SelectedValue.ToString();
            }
            if (txtRefCode.Text == "" && cmbRefName.Text != "")
            {
                //txtRefCode.Text = GetNewID("R_CODE", "REF_DR_MAS").ToString();
            }
            else if (txtRefCode.Text != "" && cmbRefName.Text != "")
            {
                FillReferenceDetail(txtRefCode.Text);
            }
        }
        private void cmbTestName_Validated(object sender, EventArgs e)
        {
            if (cmbTestName.SelectedValue != null)
            {
                txtTestCode.Text = cmbTestName.SelectedValue.ToString();
            }
            if (txtTestCode.Text == "" && cmbTestName.Text != "")
            {
                //txtRefCode.Text = GetNewID("R_CODE", "REF_DR_MAS").ToString();
            }
            else if (txtTestCode.Text != "" && cmbTestName.Text != "")
            {
                FillTestDetail(txtTestCode.Text);
            }
        }
        #endregion
        #region Print Report

        private void BillInExcel()
        {
            //Excel.Application oXL = new Excel.Application();
            //Excel.Workbook theWorkbook;
            //Excel.Worksheet worksheet;

            //if (File.Exists(Application.StartupPath + @"\BillReport.xls"))
            //{
            //    File.Delete(Application.StartupPath + @"\BillReport.xls");
            //}

            //theWorkbook = oXL.Workbooks.Open(Application.StartupPath + @"\Bill.xlt", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, Type.Missing, Type.Missing);

            //worksheet = (Excel.Worksheet)theWorkbook.Sheets[1];


            //Excel.Range RngBillNo = worksheet.get_Range("Bill_No", "Bill_No"); Excel.Range RngBillDate = worksheet.get_Range("Bill_Date", "Bill_Date");
            //Excel.Range RngPName = worksheet.get_Range("P_NAME", "P_NAME"); Excel.Range RngPAdd = worksheet.get_Range("P_ADD", "P_ADD");
            //Excel.Range RngRName = worksheet.get_Range("R_NAME", "R_NAME"); Excel.Range RngSrNo = worksheet.get_Range("SRNO", "SRNO");
            //Excel.Range RngTestName = worksheet.get_Range("TEST_NAME", "TEST_NAME"); Excel.Range RngAmount = worksheet.get_Range("Amount", "Amount");
            //Excel.Range RngTotal = worksheet.get_Range("Total", "Total"); Excel.Range RngRelief = worksheet.get_Range("Relief", "Relief");
            //Excel.Range RngAddLess = worksheet.get_Range("Add_Less", "Add_Less"); Excel.Range RngNetAmount = worksheet.get_Range("Net_Amount", "Net_Amount");
            //Excel.Range RngRemarks = worksheet.get_Range("Remarks", "Remarks"); Excel.Range RngRsInWords = worksheet.get_Range("Rs_In_Words", "Rs_In_Words");

            //Excel.Range RngCompName = worksheet.get_Range("COMP_NAME", "COMP_NAME");
            //Excel.Range RngCompAdd = worksheet.get_Range("COMP_ADD", "COMP_ADD");
            //Excel.Range RngCompCity = worksheet.get_Range("COMP_CITY_PIN", "COMP_CITY_PIN");
            //Excel.Range RngCompPhone = worksheet.get_Range("COMP_PHONE", "COMP_PHONE");
            //Excel.Range RngCompTime = worksheet.get_Range("COMP_TIME", "COMP_TIME");

            //if (GLOBAL.ds.Tables["COMP_MAS"].Rows.Count > 0)
            //{
            //    RngCompName.Value2 = GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_NAME"];
            //    RngCompAdd.Value2 = GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_ADD"];
            //    RngCompCity.Value2 = GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_CITY"] + "-" + GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_PINCODE"];
            //    RngCompPhone.Value2 = "Phone No " + GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_PHONE"] + ", (M)" + GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_MOBILE"];
            //    RngCompTime.Value2 = GLOBAL.ds.Tables["COMP_MAS"].Rows[0]["COMP_TIMING"];
            //}

            //RngBillNo.Value2 = txtBillNo.Text;
            //RngBillDate.Value2 = txtBillDate.Text;
            //RngPName.Value2 = cmbPName.Text;
            //RngPAdd.Value2 = txtAddress.Text;
            //RngRName.Value2 = cmbRefName.Text;

            //for (int i = 0; i < dgvTestDetails.Rows.Count - 1; i++)
            //{
            //    RngSrNo.set_Item(i + 1, 1, i + 1);
            //    RngTestName.set_Item(i + 1, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["PARA_TYPE"].Value));
            //    RngAmount.set_Item(i + 1, 1, Convert.ToString(dgvTestDetails.Rows[i].Cells["PRICE"].Value));
            //}

            //RngTotal.Value2 = txtTotalAmt.Text;
            //RngRelief.Value2 = txtLessAmt.Text;
            //RngAddLess.Value2 = 0;
            //RngNetAmount.Value2 = txtNetAmt.Text;
            //RngRemarks.Value2 = "";
            //RngRsInWords.Value2 = NumbersToWords(Convert.ToInt32(txtNetAmt.Text));

            //oXL.ActiveWorkbook.SaveAs(Application.StartupPath + @"\BillReport", Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing,
            //                          Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            //Marshal.FinalReleaseComObject(worksheet);
            //oXL.Workbooks.Close();
            //Marshal.FinalReleaseComObject(theWorkbook);
            //oXL.Application.Quit();
            //Marshal.FinalReleaseComObject(oXL);
            //oXL = null;

            //Excel.Application xlApp = new Excel.Application();  // create new Excel application
            //xlApp.Visible = true;                               // application becomes visible
            //xlApp.Workbooks.Open(Application.StartupPath + @"\BillReport.xls", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, Type.Missing, Type.Missing);

            //MessageBox.Show("Press Enter To Continue.......", "", MessageBoxButtons.OK);

            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            //xlApp.Workbooks.Close();
            //xlApp.Application.Quit();
            //Marshal.FinalReleaseComObject(xlApp);
            //xlApp = null;

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
