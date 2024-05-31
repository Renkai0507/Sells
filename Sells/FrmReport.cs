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
    public partial class FrmReport : Form
    {
        IDbServiceWrapper Db;
        Searchkey search;
        List<PopularProduct> AutoPdct;
        List<CustomerData> AutoCust;
        List<PdctRpt> pdctrpt;
        List<CustRpt> CustRpt;
        public FrmReport(IDbServiceWrapper Db)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;           
            dtpStart.Value = DateTime.Now.AddDays(-DateTime.Now.AddMonths(-1).Day + 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1) .AddDays(-1);
           
            //dtppdctEnd.Value = DateTime.Now.AddDays(dtpCustStart.Value.AddMonths(1).Day - 1);
            //dtpCustEnd.Value = DateTime.Now.AddDays(dtpCustStart.Value.AddMonths(1).Day-1);
            this.Db = Db;
            AutoCompleteStringCollection AcsPdct = new AutoCompleteStringCollection();
            AutoCompleteStringCollection AcsCust = new AutoCompleteStringCollection();
            AutoPdct = Db.ProductData.GetAllAuto();
            AutoCust = Db.CustomerData.GetAllAuto();
            AcsPdct.AddRange(AutoPdct.Select(X => X.產品規格).ToArray());
            AcsCust.AddRange(AutoCust.Select(X => X.客戶名稱).ToArray());
        }

        private void BtnPdct_Click(object sender, EventArgs e)
        {
            search = new Searchkey();
            DateTime Startday = dtpStart.Value;
            DateTime Endday = dtpEnd.Value;
            search.StartDay = Startday.ToString($"yyyy/{Startday.Month}/{Startday.Day}");
            search.EndDay = dtpEnd.Value.ToString($"yyyy/{Endday.Month}/{Endday.Day}");
            search.SearchStr = dgvCust.Text.Trim();
            if (string.IsNullOrEmpty(dgvCust.Text.Trim())&&string.IsNullOrEmpty(txtCust.Text.Trim()))
            {
                var pdcts= Db.PdctRpt.GetAllByDate(search);
                var custs = Db.CustRpt.GetAllByDate(search);
                CountPrice(pdcts);
                dgvPdct.DataSource = pdcts;
                dgvCust.DataSource = custs;
            }
            //else
                //Db.Sells.GetRptSearch(search);
            
        }

        private void CountPrice(List<PdctRpt> pdcts)
        {
            //int total = 0;
            //pdcts.ForEach(X=>
            //{
            //    int cnt = 0;
            //    if (int.TryParse(X.總金額, out cnt))
            //    {
            //        total+=cnt
            //    } 
                
            //});
        }
    }
}
