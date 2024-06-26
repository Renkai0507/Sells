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
            txtPdct.AutoCompleteCustomSource = Global.AcsPdct;
            txtCust.AutoCompleteCustomSource = Global.AcsCust;
            BtnPdct_Click(null,null);
        }

        private void BtnPdct_Click(object sender, EventArgs e)
        {
            search = new Searchkey();
            DateTime Startday = dtpStart.Value;
            DateTime Endday = dtpEnd.Value;
            search.StartDay = Startday.ToString($"yyyy/{Startday.Month}/{Startday.Day}");
            search.EndDay = dtpEnd.Value.ToString($"yyyy/{Endday.Month}/{Endday.Day}");
            search.SearchCust = txtCust.Text.Trim();
            search.SearchPdct = txtPdct.Text.Trim();
            //都沒資料
            if (string.IsNullOrEmpty(txtCust.Text.Trim()))
            {
                dgvCust.Columns[0].Visible = false;
                dgvCust.Columns[1].Visible = false;
                var custs = Db.CustRpt.GetAllByDate(search);
                AllCustPrice(custs);                
            }
            else
            {
                dgvCust.Columns[0].Visible = true;
                dgvCust.Columns[1].Visible = true;
                var custs = Db.CustRpt.SearchByDate(search);
                dgvCust.DataSource = custs;
            }
             if (string.IsNullOrEmpty(txtPdct.Text.Trim()))
            {
                var pdcts = Db.PdctRpt.GetAllByDate(search);
                AllPdctPrice(pdcts);
            }
            else
            {
                var pdcts = Db.PdctRpt.SearchByDate(search);
                AllPdctPrice(pdcts);
            }
            
            //else
                //Db.Sells.GetRptSearch(search);
            
        }

        private void AllPdctPrice(List<PdctRpt> AllPdcts)
        {
            List<PdctRpt> pdctRpt = new List<PdctRpt>();
            List<string> AllpdctStr = AllPdcts.Select(X => X.產品編號).Distinct().ToList();
            AllpdctStr.ForEach(X =>
            {
                var allprice = AllPdcts.Where(Y => Y.產品編號 == X).ToList();
                string Total = "0";
                string Qty = "0";
                for (int i = 0; i < allprice.Count(); i++)
                {
                    int tmpprice = 0;
                    int tmpqty = 0;
                    int.TryParse(allprice[i].總金額, out tmpprice);
                    int.TryParse(allprice[i].數量, out tmpqty);
                    Total = (int.Parse(Total) + tmpprice).ToString();
                    Qty = (int.Parse(Qty) + tmpqty).ToString();
                }
                PdctRpt tmp = new PdctRpt();
                tmp.產品編號 = X;
                tmp.產品名稱 = AllPdcts.Where(Y => Y.產品編號 == X).FirstOrDefault().產品名稱;
                tmp.總金額 = Total;
                tmp.數量 = Qty;
                pdctRpt.Add(tmp);
            });
            dgvPdct.DataSource = pdctRpt;
        }

        private void AllCustPrice(List<CustRpt> Allcusts)
        {
            List<CustRpt> custRpt = new List<CustRpt>();
            List<string> AllcustStr = Allcusts.Select(X => X.客戶編號).Distinct().ToList();
            AllcustStr.ForEach(X => 
            {
               var allprice = Allcusts.Where(Y=>Y.客戶編號==X).Select(Y => Y.總金額).ToList();
               string Total = "0";
               for (int i = 0; i < allprice.Count(); i++)
               {
                   int tmpprice = 0;
                   int.TryParse(allprice[i], out tmpprice);
                   Total = (int.Parse(Total) + tmpprice).ToString();
               }
                CustRpt tmp = new CustRpt();
                tmp.客戶編號 = X;
                tmp.客戶名稱 = Allcusts.Where(Y => Y.客戶編號 == X).FirstOrDefault().客戶名稱;
                tmp.總金額 = Total.ToString();
                custRpt.Add(tmp);
            });
            dgvCust.DataSource = custRpt;
        }

        private void FrmReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                return;
            }
            if (e.KeyCode == Keys.Q)
            {
                tabControl1.SelectedIndex = 0;
                return;
            }
            if (e.KeyCode == Keys.E)
            {
                tabControl1.SelectedIndex = 1;
                return;
            }
            if (e.KeyCode == Keys.F)
            {
                txtCust.Focus();
            }
            if (e.KeyCode == Keys.H)
            {
                BtnPdct.PerformClick();
            }
        }

        private void dgvCust_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            search = new Searchkey();
            DateTime Startday = dtpStart.Value;
            DateTime Endday = dtpEnd.Value;
            search.StartDay = Startday.ToString($"yyyy/{Startday.Month}/{Startday.Day}");
            search.EndDay = dtpEnd.Value.ToString($"yyyy/{Endday.Month}/{Endday.Day}");
            var rpt = (CustRpt)dgvCust.SelectedRows[0].DataBoundItem;
            search.SearchCust = rpt.客戶名稱;
            List<SellInProduct> Custsells;
            if (dgvCust.Columns[0].Visible)
            {
                Custsells = Db.Sells.SearchByCust(search);
            }
            else
            {
                Custsells = Db.Sells.SearchByCust(search);                
            }
            CustReport frm = new CustReport(Custsells,Db);
            frm.Show();
        }
    }
}
