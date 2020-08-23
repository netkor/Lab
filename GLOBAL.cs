using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lab
{
    public static class GLOBAL
    {
        public static DataSet ds = new DataSet();

        #region Declaration

        public static string loginUserId;
        public static string loginUserName;
        public static string UserGroup;

        public static DataTable dtPARA_TYPE_MAS = new DataTable();
        public static DataTable dtPARA_VALUE_MAS = new DataTable();
        public static DataTable dtPARA_VALUE_RESULT = new DataTable();
        public static DataTable dtPARA_VALUE_COMMENTS = new DataTable();
        public static DataTable dtPARA_VALUE_METHOD = new DataTable();
        public static DataTable dtPARA_VALUE_RANGES = new DataTable();
        public static DataTable dtLAB_MAS = new DataTable();
        public static DataTable dtPATIENT_MAS = new DataTable();
        public static DataTable dtREF_DR_MAS = new DataTable();
        public static DataTable dtBILL_MAS = new DataTable();
        public static DataTable dtBILL_TRANS = new DataTable();
        public static DataTable dtREPORT_MAS = new DataTable();
        public static DataTable dtREPORT_TRANS = new DataTable();
        public static DataTable dtUSER_MAS = new DataTable();
        public static DataTable dtUSER_RIGHTS = new DataTable();
        public static DataTable dtMENU_MAS = new DataTable();
        public static DataTable dtCOMP_MAS = new DataTable();
        public static DataTable dtPRICE_LIST = new DataTable();
        #endregion

        #region Database
        public static void LoadDB()
        {
            GLOBAL.ds.Namespace = "QUICK_LAB_SCHEMA";
            GLOBAL.ds.DataSetName = "QUICK_LAB_SCHEMA";
            GLOBAL.ds.ReadXmlSchema(Application.StartupPath + @"\QUICK_LAB.xsd");
            GLOBAL.ds.ReadXml(Application.StartupPath + @"\QUICK_LAB.xml");


           // DataTable TEMP = new DataTable();
            //TEMP = GLOBAL.ds.Tables["PARA_VALUE_MAS"];

            #region remove Tables
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["PARA_TYPE_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["PARA_VALUE_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["PARA_VALUE_RESULTS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["PARA_VALUE_RANGES"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["PARA_VALUE_METHOD"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["PARA_VALUE_COMMENTS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["PATIENT_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["LAB_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["REPORT_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["REPORT_TRANS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["BILL_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["BILL_TRANS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["USER_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["USER_RIGHTS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["MENU_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["COMP_MAS"]);
            //GLOBAL.ds.Tables.Remove(GLOBAL.ds.Tables["PRICE_LIST"]);
            #endregion

            #region CHECK DB

            #region PARA_TYPE_MAS
            if (!GLOBAL.ds.Tables.Contains("PARA_TYPE_MAS"))
            {
                dtPARA_TYPE_MAS.TableName = "PARA_TYPE_MAS";

                dtPARA_TYPE_MAS.Columns.Add("PARA_TYPE_CODE");
                dtPARA_TYPE_MAS.Columns.Add("PARA_TYPE");
                dtPARA_TYPE_MAS.Columns.Add("PRICE");
                dtPARA_TYPE_MAS.Columns.Add("ORD");

                dtPARA_TYPE_MAS.Columns["PARA_TYPE_CODE"].DataType = typeof(System.Int32);
                dtPARA_TYPE_MAS.Columns["PRICE"].DataType = typeof(System.Decimal);
                dtPARA_TYPE_MAS.Columns["ORD"].DataType = typeof(System.Int32);

                dtPARA_TYPE_MAS.Columns["PRICE"].DefaultValue = 0;
                dtPARA_TYPE_MAS.Columns["ORD"].DefaultValue = 1;

                GLOBAL.ds.Tables.Add(dtPARA_TYPE_MAS);
            }
            #endregion

            #region PARA_VALUE_MAS
            if (!GLOBAL.ds.Tables.Contains("PARA_VALUE_MAS"))
            {
                dtPARA_VALUE_MAS.TableName = "PARA_VALUE_MAS";

                dtPARA_VALUE_MAS.Columns.Add("PARA_TYPE_CODE");
                dtPARA_VALUE_MAS.Columns.Add("PARA_VALUE_CODE");
                dtPARA_VALUE_MAS.Columns.Add("PARA_VALUE");
                dtPARA_VALUE_MAS.Columns.Add("TYPE");
                dtPARA_VALUE_MAS.Columns.Add("ORD");
                dtPARA_VALUE_MAS.Columns.Add("TYPE_CODE");

                dtPARA_VALUE_MAS.Columns["PARA_VALUE_CODE"].DataType = typeof(System.Int32);
                dtPARA_VALUE_MAS.Columns["PARA_TYPE_CODE"].DataType = typeof(System.Int32);
                dtPARA_VALUE_MAS.Columns["ORD"].DataType = typeof(System.Int32);
                dtPARA_VALUE_MAS.Columns["TYPE_CODE"].DataType = typeof(System.Int32);

                dtPARA_VALUE_MAS.Columns["PARA_VALUE_CODE"].ColumnName = "PARA_VALUE_CODE";
                dtPARA_VALUE_MAS.Columns["PARA_VALUE_CODE"].Caption = "No.";
                dtPARA_VALUE_MAS.Columns["ORD"].DefaultValue = 1;

                //int cnt = 0;
                //for (int i = 0; i < TEMP.Rows.Count; i++)
                //{
                //    if (Convert.ToString(TEMP.Rows[i][3]).ToUpper() == "HEADING")
                //    {
                //        cnt++;
                //        dtPARA_VALUE_MAS.Rows.Add(TEMP.Rows[i][0], TEMP.Rows[i][1], TEMP.Rows[i][2], TEMP.Rows[i][3], TEMP.Rows[i][4], cnt);

                //    }
                //    else if (Convert.ToString(TEMP.Rows[i][3]).ToUpper() == "DETAIL")
                //    {
                //        dtPARA_VALUE_MAS.Rows.Add(TEMP.Rows[i][0], TEMP.Rows[i][1], TEMP.Rows[i][2], TEMP.Rows[i][3], TEMP.Rows[i][4], cnt);

                //    }
                //    else
                //    {
                //        dtPARA_VALUE_MAS.Rows.Add(TEMP.Rows[i][0], TEMP.Rows[i][1], TEMP.Rows[i][2], TEMP.Rows[i][3], TEMP.Rows[i][4]);
                //    }
                //}

                GLOBAL.ds.Tables.Add(dtPARA_VALUE_MAS);

                
            }
            #endregion

            #region PARA_VALUE_RESULTS
            if (!GLOBAL.ds.Tables.Contains("PARA_VALUE_RESULTS"))
            {
                dtPARA_VALUE_RESULT.TableName = "PARA_VALUE_RESULTS";
                dtPARA_VALUE_RESULT.Columns.Add("PARA_VALUE_CODE");
                dtPARA_VALUE_RESULT.Columns.Add("RESULT_CODE");
                dtPARA_VALUE_RESULT.Columns.Add("RESULT_VALUE");
                dtPARA_VALUE_RESULT.Columns.Add("MESUREMENT");
                dtPARA_VALUE_RESULT.Columns.Add("ORD");
                dtPARA_VALUE_RESULT.Columns["PARA_VALUE_CODE"].DataType = typeof(System.Int32);
                dtPARA_VALUE_RESULT.Columns["RESULT_CODE"].DataType = typeof(System.Int32);
                dtPARA_VALUE_RESULT.Columns["ORD"].DataType = typeof(System.Int32);

                dtPARA_VALUE_RESULT.Columns["ORD"].DefaultValue = 1;
                GLOBAL.ds.Tables.Add(dtPARA_VALUE_RESULT);
            }
            #endregion

            #region PARA_VALUE_RANGES
            if (!GLOBAL.ds.Tables.Contains("PARA_VALUE_RANGES"))
            {
                dtPARA_VALUE_RANGES.TableName = "PARA_VALUE_RANGES";
                dtPARA_VALUE_RANGES.Columns.Add("PARA_VALUE_CODE");
                dtPARA_VALUE_RANGES.Columns.Add("RANGE_CODE");
                dtPARA_VALUE_RANGES.Columns.Add("RANGE_VALUE");
                dtPARA_VALUE_RANGES.Columns.Add("AGE_LIMIT");
                dtPARA_VALUE_RANGES.Columns.Add("ORD");

                dtPARA_VALUE_RANGES.Columns["PARA_VALUE_CODE"].DataType = typeof(System.Int32);
                dtPARA_VALUE_RANGES.Columns["RANGE_CODE"].DataType = typeof(System.Int32);
                dtPARA_VALUE_RANGES.Columns["ORD"].DataType = typeof(System.Int32);

                dtPARA_VALUE_RANGES.Columns["ORD"].DefaultValue = 1;
                GLOBAL.ds.Tables.Add(dtPARA_VALUE_RANGES);
            }
            #endregion

            #region PARA_VALUE_METHOD
            if (!GLOBAL.ds.Tables.Contains("PARA_VALUE_METHOD"))
            {
                dtPARA_VALUE_METHOD.TableName = "PARA_VALUE_METHOD";
                dtPARA_VALUE_METHOD.Columns.Add("PARA_VALUE_CODE");
                dtPARA_VALUE_METHOD.Columns.Add("METHOD_CODE");
                dtPARA_VALUE_METHOD.Columns.Add("METHOD_NAME");
                dtPARA_VALUE_METHOD.Columns.Add("ORD");

                dtPARA_VALUE_METHOD.Columns["PARA_VALUE_CODE"].DataType = typeof(System.Int32);
                dtPARA_VALUE_METHOD.Columns["METHOD_CODE"].DataType = typeof(System.Int32);
                dtPARA_VALUE_METHOD.Columns["ORD"].DataType = typeof(System.Int32);

                dtPARA_VALUE_METHOD.Columns["ORD"].DefaultValue = 1;

                GLOBAL.ds.Tables.Add(dtPARA_VALUE_METHOD);
            }
            #endregion

            #region PARA_VALUE_COMMENTS
            if (!GLOBAL.ds.Tables.Contains("PARA_VALUE_COMMENTS"))
            {
                dtPARA_VALUE_COMMENTS.TableName = "PARA_VALUE_COMMENTS";
                dtPARA_VALUE_COMMENTS.Columns.Add("COMMENT_TYPE");
                dtPARA_VALUE_COMMENTS.Columns.Add("COMMENT_VALUE");
                dtPARA_VALUE_COMMENTS.Columns.Add("PARA_VALUE_CODE");
                dtPARA_VALUE_COMMENTS.Columns["PARA_VALUE_CODE"].DataType = typeof(System.Int32);
                GLOBAL.ds.Tables.Add(dtPARA_VALUE_COMMENTS);
            }
            #endregion

            #region PATIENT_MAS
            if (!GLOBAL.ds.Tables.Contains("PATIENT_MAS"))
            {
                dtPATIENT_MAS.TableName = "PATIENT_MAS";
                dtPATIENT_MAS.Columns.Add("P_CODE"); //pk
                dtPATIENT_MAS.Columns.Add("SP_CODE"); 
                dtPATIENT_MAS.Columns.Add("P_NAME");
                dtPATIENT_MAS.Columns.Add("P_AGE");
                dtPATIENT_MAS.Columns.Add("P_SEX");
                dtPATIENT_MAS.Columns.Add("P_AREA");

                dtPATIENT_MAS.Columns["P_CODE"].DataType = typeof(System.Int32);
                dtPATIENT_MAS.Columns["SP_CODE"].DataType = typeof(System.Int32);
                GLOBAL.ds.Tables.Add(dtPATIENT_MAS);
            }
            #endregion

            #region REF_DR_MAS
            if (!GLOBAL.ds.Tables.Contains("REF_DR_MAS"))
            {
                dtREF_DR_MAS.TableName = "REF_DR_MAS";
                dtREF_DR_MAS.Columns.Add("R_CODE"); //pk
                dtREF_DR_MAS.Columns.Add("R_NAME");

                dtREF_DR_MAS.Columns["R_CODE"].DataType = typeof(System.Int32);
                GLOBAL.ds.Tables.Add(dtREF_DR_MAS);
            }
            #endregion

            #region LAB_MAS
            if (!GLOBAL.ds.Tables.Contains("LAB_MAS"))
            {
                dtLAB_MAS.TableName = "LAB_MAS";
                dtLAB_MAS.Columns.Add("LAB_CODE");
                dtLAB_MAS.Columns.Add("DLAB_CODE");
                dtLAB_MAS.Columns.Add("P_CODE");
                dtLAB_MAS.Columns.Add("R_CODE");
                dtLAB_MAS.Columns.Add("LAB_DATE");

                dtLAB_MAS.Columns["LAB_CODE"].DataType = typeof(System.Int32);
                dtLAB_MAS.Columns["DLAB_CODE"].DataType = typeof(System.Int32);
                dtLAB_MAS.Columns["P_CODE"].DataType = typeof(System.Int32);
                dtLAB_MAS.Columns["R_CODE"].DataType = typeof(System.Int32);

                GLOBAL.ds.Tables.Add(dtLAB_MAS);
            }
            #endregion

            #region REPORT_MAS
            if (!GLOBAL.ds.Tables.Contains("REPORT_MAS"))
            {
                dtREPORT_MAS.TableName = "REPORT_MAS";
                dtREPORT_MAS.Columns.Add("REPORT_NO");
                dtREPORT_MAS.Columns.Add("LAB_CODE");
                dtREPORT_MAS.Columns.Add("BILL_NO");
                dtREPORT_MAS.Columns.Add("REPORT_DATE");
                dtREPORT_MAS.Columns.Add("PARA_TYPE_CODE");
                dtREPORT_MAS.Columns["REPORT_NO"].DataType = typeof(System.Int32);
                dtREPORT_MAS.Columns["LAB_CODE"].DataType = typeof(System.Int32);
                dtREPORT_MAS.Columns["BILL_NO"].DataType = typeof(System.Int32);
                dtREPORT_MAS.Columns["PARA_TYPE_CODE"].DataType = typeof(System.Int32);
                GLOBAL.ds.Tables.Add(dtREPORT_MAS);
            }
            #endregion

            #region REPORT_TRANS
            if (!GLOBAL.ds.Tables.Contains("REPORT_TRANS"))
            {
                dtREPORT_TRANS.TableName = "REPORT_TRANS";
                dtREPORT_TRANS.Columns.Add("REPORT_NO");
                dtREPORT_TRANS.Columns.Add("REPORT_DETAILID");
                dtREPORT_TRANS.Columns.Add("PARA_TYPE_CODE");
                dtREPORT_TRANS.Columns.Add("PARA_VALUE_CODE");
                dtREPORT_TRANS.Columns.Add("PARA_VALUE");
                //dtREPORT_TRANS.Columns.Add("VALUE");
                dtREPORT_TRANS.Columns.Add("RESULT_CODE");
                dtREPORT_TRANS.Columns.Add("RESULT_VALUE");
                dtREPORT_TRANS.Columns.Add("MESUREMENT");
                dtREPORT_TRANS.Columns.Add("RANGE_CODE");
                dtREPORT_TRANS.Columns.Add("RANGE_VALUE");
                dtREPORT_TRANS.Columns.Add("AGE_LIMIT");

                dtREPORT_TRANS.Columns["REPORT_NO"].DataType = typeof(System.Int32);
                dtREPORT_TRANS.Columns["REPORT_DETAILID"].DataType = typeof(System.Int32);
                dtREPORT_TRANS.Columns["PARA_TYPE_CODE"].DataType = typeof(System.Int32);
                dtREPORT_TRANS.Columns["PARA_VALUE_CODE"].DataType = typeof(System.Int32);
                dtREPORT_TRANS.Columns["RESULT_CODE"].DataType = typeof(System.Int32);
                dtREPORT_TRANS.Columns["RANGE_CODE"].DataType = typeof(System.Int32);

                GLOBAL.ds.Tables.Add(dtREPORT_TRANS);
            }
            #endregion

            #region BILL_MAS
            if (!GLOBAL.ds.Tables.Contains("BILL_MAS"))
            {
                dtBILL_MAS.TableName = "BILL_MAS";
                dtBILL_MAS.Columns.Add("BILL_NO");  // pk
                dtBILL_MAS.Columns.Add("BILL_DATE");
                dtBILL_MAS.Columns.Add("BILL_TIME");
                dtBILL_MAS.Columns.Add("LAB_CODE");
                dtBILL_MAS.Columns.Add("TOTAL_AMT");
                dtBILL_MAS.Columns.Add("LESS_AMT");
                dtBILL_MAS.Columns.Add("NET_AMT");

                dtBILL_MAS.Columns["BILL_NO"].DataType = typeof(System.Int32);
                dtBILL_MAS.Columns["LAB_CODE"].DataType = typeof(System.Int32);
                dtBILL_MAS.Columns["TOTAL_AMT"].DataType = typeof(System.Int32);
                dtBILL_MAS.Columns["LESS_AMT"].DataType = typeof(System.Int32);
                dtBILL_MAS.Columns["NET_AMT"].DataType = typeof(System.Int32);

                GLOBAL.ds.Tables.Add(dtBILL_MAS);
            }
            #endregion

            #region BILL_TRANS
            if (!GLOBAL.ds.Tables.Contains("BILL_TRANS"))
            {
                dtBILL_TRANS.TableName = "BILL_TRANS";
                dtBILL_TRANS.Columns.Add("BILL_NO"); //fk
                dtBILL_TRANS.Columns.Add("DETAILID"); //pk
                dtBILL_TRANS.Columns.Add("PARA_TYPE_CODE");

                dtBILL_TRANS.Columns["BILL_NO"].DataType = typeof(System.Int32);
                dtBILL_TRANS.Columns["DETAILID"].DataType = typeof(System.Int32);
                dtBILL_TRANS.Columns["PARA_TYPE_CODE"].DataType = typeof(System.Int32);

                GLOBAL.ds.Tables.Add(dtBILL_TRANS);
            }
            #endregion

            #region USER_MAS
            if (!GLOBAL.ds.Tables.Contains("USER_MAS"))
            {
                dtUSER_MAS.TableName = "USER_MAS";
                dtUSER_MAS.Columns.Add("U_CODE"); //pk
                dtUSER_MAS.Columns.Add("U_NAME");
                dtUSER_MAS.Columns.Add("PASS");
                dtUSER_MAS.Columns.Add("U_GROUP");

                //dtUSER_MAS.Columns["U_CODE"].DataType = typeof(System.Int32);
                GLOBAL.ds.Tables.Add(dtUSER_MAS);
            }
            #endregion

            #region USER_RIGHTS
            if (!GLOBAL.ds.Tables.Contains("USER_RIGHTS"))
            {
                dtUSER_RIGHTS.TableName = "USER_RIGHTS";
                dtUSER_RIGHTS.Columns.Add("U_CODE"); //pk
                dtUSER_RIGHTS.Columns.Add("MENU_CODE");
                dtUSER_RIGHTS.Columns.Add("RIGHTS");

                //dtUSER_RIGHTS.Columns["U_CODE"].DataType = typeof(System.Int32);
                dtUSER_RIGHTS.Columns["MENU_CODE"].DataType = typeof(System.Int32);
                GLOBAL.ds.Tables.Add(dtUSER_RIGHTS);
            }
            #endregion

            #region COMP_MAS
            if (!GLOBAL.ds.Tables.Contains("COMP_MAS"))
            {
                dtCOMP_MAS.TableName = "COMP_MAS";
                dtCOMP_MAS.Columns.Add("COMP_CODE"); //pk
                dtCOMP_MAS.Columns.Add("COMP_NAME");
                dtCOMP_MAS.Columns.Add("COMP_ADD");
                dtCOMP_MAS.Columns.Add("COMP_CITY");
                dtCOMP_MAS.Columns.Add("COMP_PINCODE");
                dtCOMP_MAS.Columns.Add("COMP_PHONE");
                dtCOMP_MAS.Columns.Add("COMP_MOBILE");
                dtCOMP_MAS.Columns.Add("COMP_TIMING");
                dtCOMP_MAS.Columns.Add("ENTRY_DATE");
                dtCOMP_MAS.Columns.Add("TECHNICIAN_NAME");

                //dtCOMP_MAS.Columns["COMP_CODE"].DataType = typeof(System.Int32);
                GLOBAL.ds.Tables.Add(dtCOMP_MAS);
            }
            #endregion

            #region MENU_MAS
            if (!GLOBAL.ds.Tables.Contains("MENU_MAS"))
            {
                dtMENU_MAS.TableName = "MENU_MAS";
                dtMENU_MAS.Columns.Add("MENU_CODE"); //pk
                dtMENU_MAS.Columns.Add("MENU_NAME");
                dtMENU_MAS.Columns.Add("MENU_GROUP");

                dtMENU_MAS.Columns["MENU_CODE"].DataType = typeof(System.Int32);
                GLOBAL.ds.Tables.Add(dtMENU_MAS);
            }
            #endregion

            #region PRICE_LIST
            if (!GLOBAL.ds.Tables.Contains("PRICE_LIST"))
            {
                dtPRICE_LIST.TableName = "PRICE_LIST";
                dtPRICE_LIST.Columns.Add("PRICE_CODE"); //pk
                dtPRICE_LIST.Columns.Add("PARA_TYPE_CODE");
                dtPRICE_LIST.Columns.Add("PARA_TYPE");
                dtPRICE_LIST.Columns.Add("PRICE");

                dtPRICE_LIST.Columns["PRICE_CODE"].DataType = typeof(System.Int32);
                dtPRICE_LIST.Columns["PARA_TYPE_CODE"].DataType = typeof(System.Int32);
                dtPARA_TYPE_MAS.Columns["PRICE"].DataType = typeof(System.Decimal);
                GLOBAL.ds.Tables.Add(dtPRICE_LIST);
            }
            #endregion

            #region Menu Entry
            if (GLOBAL.ds.Tables["MENU_MAS"].Rows.Count == 0)
            {
                string[] Master = { "New Entry", "Print Bill" };
                string[] Report = { "Blood Sugar Estimation", "Heamogram report", "Bio-Chemistry report", "Urine Examination", "Urine Pregnancy Test", "Antenatal Profile", "Antibody Detection For HIV-I & II","Mantoux Test" };
                string[] User = { "User Settings", "Database","View"};
                string[] Settings = { "Report Settings","Laboratory Settings","Menu Settings","Test Price Settings"};

                int Id = 1;
                for (int i = 0; i < Master.Length; i++)
                {
                    GLOBAL.ds.Tables["MENU_MAS"].Rows.Add(Id, Master[i], "MASTER");
                    Id++;
                }
                for (int i = 0; i < User.Length; i++)
                {
                    GLOBAL.ds.Tables["MENU_MAS"].Rows.Add(Id, User[i], "USER");
                    Id++;
                }
                for (int i = 0; i < Settings.Length; i++)
                {
                    GLOBAL.ds.Tables["MENU_MAS"].Rows.Add(Id, Settings[i], "SETTINGS");
                    Id++;
                }
                for (int i = 0; i < Report.Length; i++)
                {
                    GLOBAL.ds.Tables["MENU_MAS"].Rows.Add(Id, Report[i], "REPORT");
                    Id++;
                }
            }
            #endregion

            
            #region Assign Tables
            /*
            if (GLOBAL.ds.Tables.Count != 0)
            {
                dtPARA_TYPE_MAS = GLOBAL.ds.Tables["PARA_TYPE_MAS"];
                dtPARA_VALUE_MAS = GLOBAL.ds.Tables["PARA_VALUE_MAS"];
                dtPARA_VALUE_RESULT = GLOBAL.ds.Tables["PARA_VALUE_RESULTS"];
                dtPARA_VALUE_RANGES = GLOBAL.ds.Tables["PARA_VALUE_RANGES"];
                dtPARA_VALUE_METHOD = GLOBAL.ds.Tables["PARA_VALUE_METHOD"];
                dtPATIENT_MAS = GLOBAL.ds.Tables["PATIENT_MAS"];
                dtREF_DR_MAS = GLOBAL.ds.Tables["REF_DR_MAS"];
                dtLAB_MAS = GLOBAL.ds.Tables["LAB_MAS"];
                dtBILL_MAS = GLOBAL.ds.Tables["Bill_MAS"];
                dtBILL_TRANS = GLOBAL.ds.Tables["Bill_TRANS"];
                dtREPORT_MAS = GLOBAL.ds.Tables["REPORT_MAS"];
                dtREPORT_TRANS = GLOBAL.ds.Tables["REPORT_TRANS"];
                dtUSER_MAS = GLOBAL.ds.Tables["USER_MAS"];
                dtUSER_RIGHTS = GLOBAL.ds.Tables["USER_RIGHTS"];
                dtMENU_MAS = GLOBAL.ds.Tables["MENU_MAS"];
                dtCOMP_MAS = GLOBAL.ds.Tables["COMP_MAS"];
                dtPRICE_LIST= GLOBAL.ds.Tables["PRICE_LIST"];
            } */
            #endregion
            /*
            dtPARA_TYPE_MAS = null;
            dtPARA_VALUE_MAS = null;
            dtPARA_VALUE_RESULT = null;
            dtPARA_VALUE_RANGES = null;
            dtPARA_VALUE_METHOD = null;
            dtPATIENT_MAS = null;
            dtREF_DR_MAS = null;
            dtLAB_MAS = null;
            dtREPORT_MAS = null;
            dtREPORT_TRANS = null;
            dtBILL_MAS = null;
            dtBILL_TRANS = null;
            dtUSER_MAS = null;
            dtUSER_RIGHTS = null;
            dtMENU_MAS = null;
            dtCOMP_MAS = null; 
            dtPRICE_LIST = null; 
            */

            #endregion
        }
        public static void SaveDB()
        {
            try
            {
                GLOBAL.ds.WriteXmlSchema(Application.StartupPath + @"\QUICK_LAB.xsd");
                GLOBAL.ds.WriteXml(Application.StartupPath + @"\QUICK_LAB.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #region Password Encryption Decryption
        public static string ECODE_DECODE(string StrVal, string StrTo)
        {
            //StrS -> String to Encode OR Decode
            //StrTo -> Flag indicating what to do -(E)ncode, (D)ecode
            try
            {
            int IntLen, IntCnt, IntPos;
            string StrPass, StrChar;
            //StrChar = StrChar * 1;
            string StrECode, StrDCode;

            StrECode = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StrDCode = ")(*&^%$#@!";

            for (IntLen = 1; IntLen <= 52; IntLen++)
            {
                StrDCode = StrDCode + Convert.ToChar(IntLen + 160);
            }

            StrPass = "";
            IntLen = StrVal.Trim().Length;

            for (IntCnt = 0; IntCnt < IntLen; IntCnt++)
            {
                StrChar = StrVal.Substring(IntCnt, 1);
                IntPos = (StrTo == "E") ? StrECode.IndexOf(StrChar, 1) : StrDCode.IndexOf(StrChar, 1);
                StrPass = StrPass + ((StrTo == "E") ? StrDCode.Substring(IntPos, 1) : StrECode.Substring(IntPos, 1));
            }
            return StrPass;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        #endregion

    }
}
