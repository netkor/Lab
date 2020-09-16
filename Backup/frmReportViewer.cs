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
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("BILL_NO");
            dt.Columns.Add("DETAILID");
            dt.Columns.Add("PARA_TYPE_CODE");
            dt.Columns.Add("PARA_TYPE");
            dt.Columns.Add("PRICE");

            //dt = GLOBAL.ds.Tables["BILL_TRANS"];
            //dt.Merge(GLOBAL.ds.Tables["PARA_TYPE_MAS"], false, MissingSchemaAction.Add);

            //DataTable dtAB = (from a in GLOBAL.ds.Tables["BILL_TRANS"].AsEnumerable()
            //                  join ab in GLOBAL.ds.Tables["PARA_TYPE_MAS"].AsEnumerable()
            //                  on a["PARA_TYPE_CODE"].ToString() equals ab["PARA_TYPE_CODE"].ToString()
            //                  select a).CopyToDataTable();

            IEnumerable<DataRow> ans = (from a in GLOBAL.ds.Tables["BILL_TRANS"].AsEnumerable()
                                            join ab in GLOBAL.ds.Tables["PARA_TYPE_MAS"].AsEnumerable()
                                            on a["PARA_TYPE_CODE"].ToString() equals ab["PARA_TYPE_CODE"].ToString()
                                            select dt.LoadDataRow(new object[]
                                                {
                                                    a.Field<Int32>("BILL_NO"),
                                                    a.Field<Int32>("DETAILID"),
                                                    a.Field<Int32>("PARA_TYPE_CODE"),
                                                    ab.Field<String>("PARA_TYPE"),
                                                    ab.Field<Int32>("PRICE")

                                                },false));
                                            


            //var result = from dataRows1 in GLOBAL.ds.Tables["BILL_TRANS"].AsEnumerable()
            //                join dataRows2 in GLOBAL.ds.Tables["PARA_TYPE_MAS"].AsEnumerable()
            //                on dataRows1.Field("PARA_TYPE_CODE") equals dataRows2.Field("PARA_TYPE_CODE")
            //             select dt.LoadDataRow(new object[]
            //                {
            //                    dataRows1.Field("BILL_NO"),
            //                    dataRows1.Field("DETAILID"),
            //                    dataRows1.Field("PARA_TYPE_CODE"),
            //                    dataRows2.Field("PARA_TYPE"),
            //                    dataRows2.Field("PRICE")
            //                }, false);


            //var result = from dataRows1 in GLOBAL.ds.Tables["BILL_TRANS"].AsEnumerable()
            //                              join dataRows2 in GLOBAL.ds.Tables["PARA_TYPE_MAS"].AsEnumerable()
            //                              on dataRows1.Field<Int32>("PARA_TYPE_CODE") equals dataRows2.Field<Int32>("PARA_TYPE_CODE")
            //                              select new
            //                {
            //                    Bill_No=dataRows1.Field<Int32>("BILL_NO"),
            //                    DetailId= dataRows1.Field<Int32>("DETAILID"),
            //                     Para_Type_code=dataRows1.Field<Int32>("PARA_TYPE_CODE"),
            //                    Para_Type=dataRows2.Field<String>("PARA_TYPE"),
            //                    Price= dataRows2.Field<Int32>("PRICE")
            //                };
            
            //IEnumerable<DataRow> result = from dataRows1 in GLOBAL.ds.Tables["BILL_TRANS"].AsEnumerable()
            //                              join dataRows2 in GLOBAL.ds.Tables["PARA_TYPE_MAS"].AsEnumerable()
            //                              on dataRows1.Field<Int32>("PARA_TYPE_CODE") equals dataRows2.Field<Int32>("PARA_TYPE_CODE")
            //                              select dataRows1

            //var result = GLOBAL.ds.Tables["BILL_TRANS"].AsEnumerable().Intersect(GLOBAL.ds.Tables["PARA_TYPE_MAS"].AsEnumerable(),
            //            DataRowComparer.Default);

            //foreach (DataRow dr in result)
            //{
            //    MessageBox.Show(dr["BILL_NO"] + " " +
            //    dr["DETAILID"] + " " + dr["PARA_TYPE"] + " " +
            //    dr["PRICE"]);
            //}

            //dt = result.CopyToDataTable();

        }

        public void Build_Report(string ReportName)
        {
            temp rpt = new temp();
            rpt.SetDataSource(GLOBAL.ds);
            crystalReportViewer1.ReportSource = rpt;
            this.ShowDialog();
        }
    }
}
