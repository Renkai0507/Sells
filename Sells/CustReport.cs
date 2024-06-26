using Microsoft.Reporting.WinForms;
using Sells.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sells
{
    public partial class CustReport : Form
    {
        List<SellInProduct> Rptlist;
        List<CustomerData> cust;
        IDbServiceWrapper Db;
        public CustReport(List<SellInProduct> rpt, IDbServiceWrapper _Db )
        {
            this.Db = _Db;
            Rptlist = rpt;
            cust = new List<CustomerData>();
            cust.Add(Db.CustomerData.SinglebyKey(rpt.First().客戶編號));
            if (cust==null)
            {
                cust.Add(Db.CustomerData.SinglebyName(rpt.First().客戶名稱));
            }
            InitializeComponent();
            //var ps = new System.Drawing.Printing.PageSettings();
            //ps.Landscape = false;
            //reportViewer1.SetPageSettings(ps);
        }

        private void Report_Load(object sender, EventArgs e)
        {
            ReportDataSource rpt = new ReportDataSource("DataSet1", Rptlist);
            ReportDataSource custds = new ReportDataSource("DataSet2", cust);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rpt);
            this.reportViewer1.LocalReport.DataSources.Add(custds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
