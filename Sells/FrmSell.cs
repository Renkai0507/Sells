using Sells.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sells
{
    public partial class FrmSell : Form
    {
        IDbServiceWrapper Db;        
        List<SellInProduct> MastSells;
        List<SellInProduct> PdctSells;
        List<SellInProduct> AddNewSells;
        List<PopularProduct> AutoPdct;
        List<CustomerData> AutoCust;
        SellInProduct SelectMast;
        SellInProduct SelectPdct;
        價格類別 pricetype;

        public FrmSell(IDbServiceWrapper Db)
        {
            this.Db = Db;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dtpSellin.Value = DateTime.Now.AddMonths(-6);
            DefaultSet();
        }

        private void DefaultSet()
        {
            this.WindowState = FormWindowState.Maximized;
            //dt = Db.ProductData.TurnTable(Db.ProductData.GetAll());
            MastSells = Db.Sells.GetAllByDate(dtpSellin.Value);
            AddNewSells = new List<SellInProduct>();
            dgvSellsMonth.DataSource = MastSells;
            AutoCompleteStringCollection AcsPdct=new AutoCompleteStringCollection();
            AutoCompleteStringCollection AcsCust = new AutoCompleteStringCollection();
            AutoPdct = Db.ProductData.GetAllAuto();
            AutoCust = Db.CustomerData.GetAllAuto();
            AcsPdct.AddRange(AutoPdct.Select(X=>X.產品規格).ToArray());
            AcsCust.AddRange(AutoCust.Select(X=>X.客戶名稱).ToArray());
            txtSearchCus.AutoCompleteCustomSource = AcsCust;
            txtSearchPdct.AutoCompleteCustomSource = AcsPdct;
            客戶名稱TextBox.AutoCompleteCustomSource = AcsCust;
            光源TextBox.AutoCompleteCustomSource = AcsPdct;
            
            金額TextBox.TextChanged += delegate { Global.Numberonly(金額TextBox); };
            小計TextBox.TextChanged += delegate { Global.Numberonly(小計TextBox); };
            總金額TextBox.TextChanged += delegate { Global.Numberonly(總金額TextBox); };

            rdbClient.CheckedChanged += delegate { SetPriceType(); };
            rdbPro.CheckedChanged += delegate { SetPriceType(); };
            rdbSet.CheckedChanged += delegate { SetPriceType(); };
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCus.Text)&& string.IsNullOrWhiteSpace(txtSearchPdct.Text))
            {
                MastSells = Db.Sells.GetAllByDate(dtpSellin.Value);
                dgvSellsMonth.DataSource = MastSells;
               
                return;
            }
            MastSells = Db.Sells.GetAllBySearch(dtpSellin.Value,txtSearchCus.Text, txtSearchPdct.Text);
            dgvSellsMonth.DataSource = MastSells;
            dgvSells.DataSource = null;
            return;

        }

        private void BtnNewMast_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(銷貨單號TextBox.Text))
            {
                客戶名稱TextBox.Focus();
            }
            銷貨單號TextBox.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            //客戶編號TextBox.Text = "";
            //客戶名稱TextBox.Text = "";
            小計TextBox.Text = "";
            總金額TextBox.Text = "";
            發票編號TextBox.Text = "";
            備註TextBox.Text = "";
            //產品備註TextBox.Text = "";
            //產品編號TextBox.Text = "";
            //光源TextBox.Text = "";
            //數量TextBox.Text = "0";
            //零售價TextBox.Text = "0";
            //水電價TextBox.Text = "0";
            //安裝價TextBox.Text = "0";
            //牌價TextBox.Text = "";
            //金額TextBox.Text = "0";
            含稅Ckb.Checked = true;
            MastSells.Add(new SellInProduct() {銷貨單號=銷貨單號TextBox.Text,銷貨日期=DateTime.Now,客戶名稱= 客戶名稱TextBox.Text });
            
            dgvSellsMonth.DataSource = null;
            dgvSellsMonth.DataSource = MastSells;
            dgvSellsMonth.ClearSelection();
            dgvSellsMonth.FirstDisplayedScrollingRowIndex=dgvSellsMonth.RowCount-1;
            dgvSellsMonth.Rows[dgvSellsMonth.RowCount - 1].Selected = true;


        }
        private void BtnNewPdct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(銷貨單號TextBox.Text.Trim()))
                BtnNewMast.PerformClick();
            SelectPdct = GetnewSell();
            AddNewSells.Add(SelectPdct);
            dgvSells.DataSource = null;
            dgvSells.DataSource = AddNewSells;
            dgvSells.Refresh();
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }

        private SellInProduct GetnewSell()
        {
            SellInProduct sell = new SellInProduct()
            {
                銷貨日期 = 銷貨日期DateTimePicker.Value,
                銷貨單號=銷貨單號TextBox.Text,
                客戶名稱=客戶名稱TextBox.Text,
                客戶編號=客戶編號TextBox.Text,
                光源=光源TextBox.Text,
                金額=金額TextBox.Text,
                安裝價=安裝價TextBox.Text,
                小計=小計TextBox.Text,
                數量=數量TextBox.Text,
                發票編號=發票編號TextBox.Text,
                水電價=水電價TextBox.Text,
                產品備註=產品備註TextBox.Text,
                產品編號=產品編號TextBox.Text,
                零售價=零售價TextBox.Text,
                備註=備註TextBox.Text,                
            };
            return sell;
        }

        private void dgvSellsMonth_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSellsMonth.RowCount<=0)
            {
                return;
            }
            SelectMast = (SellInProduct)dgvSellsMonth.SelectedRows[0].DataBoundItem;
            PdctSells = Db.Sells.GetPdcByKey(SelectMast.銷貨單號);
            if (PdctSells.Count>0)
            {
                dgvSells.DataSource = PdctSells;
            }
            else if (AddNewSells.Where(X => X.銷貨單號 == SelectMast.銷貨單號).Count() > 0)
            {
                dgvSells.DataSource = AddNewSells;
            }
            else
            {
                dgvSells.DataSource = null;
            }
           
            

        }

        private void dgvSells_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSells.RowCount<=0)
            {
                return;
            }
            SelectPdct =(SellInProduct) dgvSells.SelectedRows[0].DataBoundItem;
            sellInProductBindingSource.DataSource = SelectPdct;
          

        }

        private void 光源TextBox_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode!=Keys.Enter)
            {
                return;
            }
            string KeyStr = 光源TextBox.Text;
            PopularProduct loadpdct = Db.ProductData.SinglebyName(KeyStr);
            LoadPdctData(loadpdct);


        }
        void LoadPdctData(PopularProduct loadpdct)
        {
            產品編號TextBox.Text = loadpdct.產品編號;
            光源TextBox.Text = loadpdct.產品規格;
            零售價TextBox.Text = string.IsNullOrWhiteSpace(loadpdct.零售價錢)?  "0": loadpdct.零售價錢.Trim();
            水電價TextBox.Text = string.IsNullOrWhiteSpace(loadpdct.水電價) ? "0" : loadpdct.水電價.Trim();
            安裝價TextBox.Text = string.IsNullOrWhiteSpace(loadpdct.安裝價) ? "0" : loadpdct.安裝價.Trim();
        }

        private void 數量TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Global.NumberPointonly(數量TextBox, e);
        }

        private void 數量TextBox_TextChanged(object sender, EventArgs e)
        {
            CountPrice(數量TextBox.Text);
        }
        void CountPrice(string Str)
        {
            Str = Str.Trim().Replace(" ","");
            var reg = new Regex("^[0-9]*$");
            if (!reg.IsMatch(Str))
            {
                return;
            }
            string PriceStr = "";
            string QtyStr = 數量TextBox.Text;

            switch (pricetype)
            {
                case 價格類別.零售價:
                    PriceStr = 零售價TextBox.Text;
                    break;
                case 價格類別.水電價:
                    PriceStr = 水電價TextBox.Text;
                    break;
                case 價格類別.安裝價:
                    PriceStr = 安裝價TextBox.Text;
                    break;
                default:
                    break;
            }
            int Qty = 0;
            int Price = 0;
            int.TryParse(QtyStr,out Qty);
            int.TryParse(PriceStr, out Price);
            金額TextBox.Text = PriceStr;
            小計TextBox.Text = (Qty * Price).ToString();


        }
        void SetPriceType()
        {
            if (rdbSet.Checked == true)
                pricetype = 價格類別.安裝價;
            else if (rdbClient.Checked == true)
                pricetype = 價格類別.零售價;
            else if (rdbPro.Checked == true)
                pricetype = 價格類別.安裝價;
        }

        private void 零售價TextBox_TextChanged(object sender, EventArgs e)
        {
            CountPrice(零售價TextBox.Text);
        }

        private void 水電價TextBox_TextChanged(object sender, EventArgs e)
        {
            CountPrice(水電價TextBox.Text);
        }

        private void 安裝價TextBox_TextChanged(object sender, EventArgs e)
        {
            CountPrice(安裝價TextBox.Text);
        }

        private void 客戶名稱TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            string KeyStr = 客戶名稱TextBox.Text;
            CustomerData cust = Db.CustomerData.SinglebyName(KeyStr);
            if (cust!=null)
            {
                客戶名稱TextBox.Text = cust.客戶名稱;
                客戶編號TextBox.Text = cust.客戶編號;
            }
           
        }
        
        private void rdbClient_CheckedChanged(object sender, EventArgs e)
        {
            CountPrice(數量TextBox.Text);
        }

        private void rdbPro_CheckedChanged(object sender, EventArgs e)
        {
            CountPrice(數量TextBox.Text);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            AddNewSells.ForEach(X => { Db.Sells.AddNew(X); });
            MastSells = Db.Sells.GetAllBySearch(dtpSellin.Value, txtSearchCus.Text, txtSearchPdct.Text);
            dgvSellsMonth.DataSource = MastSells;
            dgvSells.DataSource = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSell_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                return;
            }
            if (e.KeyCode == Keys.F)
            {
                    txtSearchCus.Focus();
            }
            if (e.KeyCode == Keys.Q)
            {
                    BtnNewMast.PerformClick();
                    客戶名稱TextBox.Focus();
            }
            if (e.KeyCode == Keys.W)
            {
                    BtnNewPdct.PerformClick();
                    光源TextBox.Focus();
            }
            if (e.KeyCode == Keys.S)
            {
                    BtnSave.PerformClick();
            }
            if (e.KeyCode == Keys.C)
            {
                    BtnCancel.PerformClick();
            }
            if (e.KeyCode == Keys.P)
            {
                    BtnPrint.PerformClick();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            銷貨單號TextBox.Text = "";
            客戶名稱TextBox.Text = "";
            客戶編號TextBox.Text = "";
            AddNewSells.Clear();
        }

        private void dgvSells_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) return;
            if (e.RowIndex < 0) return;
            if (dgvSells.Rows[e.RowIndex].Selected == false)
            {
                dgvSells.ClearSelection();
                dgvSells.Rows[e.RowIndex].Selected = true;
            }
            dgvSells.CurrentCell = dgvSells.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Cmspdct.Show(MousePosition.X, MousePosition.Y);
        }

        private void dgvSellsMonth_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left) return;
            //if (e.RowIndex < 0) return;
            //if (dgvSellsMonth.Rows[e.RowIndex].Selected == false)
            //{
            //    dgvSellsMonth.ClearSelection();
            //    dgvSellsMonth.Rows[e.RowIndex].Selected = true;
            //}
            //dgvSellsMonth.CurrentCell = dgvSellsMonth.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //CmsMoth.Show(MousePosition.X, MousePosition.Y);
        }

        private void 刪除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            var ask = MessageBox.Show($"確定要刪除該筆紀錄嗎?", "刪除紀錄", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ask == DialogResult.Yes)
            {
                Db.Sells.Delete(SelectPdct);
                SellInProduct delpdct = new SellInProduct();
                if (AddNewSells!=null)
                {
                    delpdct = AddNewSells.Where(X => X.項次 == SelectPdct.項次).FirstOrDefault();
                }
                
                if (delpdct!=null)
                {
                    AddNewSells.Remove(delpdct);
                }
                dgvSells.DataSource = null;

            }
        }

        private void DoDelete()
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchCus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnSearch.PerformClick();
            }
            
        }

        private void txtSearchPdct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
