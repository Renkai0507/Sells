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
    public partial class FrmProduct : Form
    {
        IDbServiceWrapper Db;
        PopularProduct prodct;        
        BtnStatus Btn;
        List<PopularProduct> Allprodct;
        public FrmProduct(IDbServiceWrapper _Db)
        {
            Db = _Db;
            //dt = new DataTable();
            InitializeComponent();
            DefaultSet();
        }

        private void DefaultSet()
        {
            this.WindowState = FormWindowState.Maximized;
            //dt = Db.ProductData.TurnTable(Db.ProductData.GetAll());            
            txtSearch.AutoCompleteCustomSource = Global.AcsPdct;
            Allprodct = Db.ProductData.GetAll();
            DgvProduct.DataSource = Allprodct;
            進價價錢TextBox.TextChanged += delegate { Global.Numberonly(進價價錢TextBox); };
            水電價TextBox.TextChanged += delegate { Global.Numberonly(水電價TextBox); };
            零售價TextBox.TextChanged += delegate { Global.Numberonly(零售價TextBox); };
            安裝價TextBox.TextChanged += delegate { Global.Numberonly(安裝價TextBox); };
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            Btn = BtnStatus.New;
            SetNewStatus();
            SetButtonStatus();
        }
        void SetNewStatus()
        {
            產品編號TextBox1.Text = "";
            進價價錢TextBox.Text = "";
            水電價TextBox.Text = "";
            產品規格TextBox1.Text = "";
            零售價TextBox.Text = "";
            安裝價TextBox.Text = "";
            單位TextBox.Text = "";
            地址TextBox.Text = "";
            備註TextBox.Text = "";
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Btn = BtnStatus.Edit;
            SetButtonStatus();
        }

        private void SetButtonStatus()
        {
            switch (Btn)
            {
                case BtnStatus.New:
                    BtnNew.Enabled = false;
                    BtnEdit.Enabled = true;
                    產品編號TextBox1.Enabled = true;
                    BtnSave.Enabled = true;
                    DgvProduct.Enabled = false;
                    BtnCancel.Enabled = true;
                    break;
                case BtnStatus.Edit:
                    BtnNew.Enabled = true;
                    BtnEdit.Enabled = false;
                    產品編號TextBox1.Enabled = false;
                    BtnSave.Enabled = true;
                    DgvProduct.Enabled = true;
                    BtnCancel.Enabled = true;
                    break;
                case BtnStatus.Cancel:
                    BtnNew.Enabled = true;
                    BtnEdit.Enabled = true;
                    產品編號TextBox1.Enabled = false;
                    BtnSave.Enabled = false;
                    DgvProduct.Enabled = true;
                    BtnCancel.Enabled = false;
                    break;
                case BtnStatus.Delete:
                    BtnNew.Enabled = true;
                    BtnEdit.Enabled = true;
                    產品編號TextBox1.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                    break;
                default:
                    BtnNew.Enabled = true;
                    BtnEdit.Enabled = true;
                    產品編號TextBox1.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                    break;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(產品編號TextBox1.Text))
            {
                MessageBox.Show("產品編號空白");
                return;
            }
            if (string.IsNullOrEmpty(產品規格TextBox1.Text))
            {
                MessageBox.Show("產品規格空白");
                return;
            }
            GetModel();
            DialogResult dialog = new DialogResult();
            switch (Btn)
            {
                case BtnStatus.New:
                    dialog = MessageBox.Show($"確定要新增{prodct.產品規格}({prodct.產品編號})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes && prodct != null)
                    {
                        Db.ProductData.AddNew(prodct);
                    }
                    
                    break;
                case BtnStatus.Edit:
                    dialog = MessageBox.Show($"確定要修改{prodct.產品規格}({prodct.產品編號})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes && prodct != null)
                    {
                        Db.ProductData. Edit(prodct);
                    }
                   
                    break;                
                case BtnStatus.Delete:
                    dialog = MessageBox.Show($"確定要刪除{prodct.產品規格}({prodct.產品編號})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes && prodct != null)
                    {
                        Db.ProductData.Delete(prodct);
                    }
                    break;
                default:
                    break;
            }
            Allprodct = Db.ProductData.GetAll();
            DgvProduct.DataSource = Allprodct;
            Btn = BtnStatus.Cancel;
            SetButtonStatus();


        }

        private void GetModel()
        {
            prodct = new PopularProduct()
            {
                產品編號 = 產品編號TextBox1.Text,
                進價價錢 = 進價價錢TextBox.Text,
                水電價 = 水電價TextBox.Text,
                產品規格 = 產品規格TextBox1.Text,
                零售價錢 = 零售價TextBox.Text,
                安裝價 = 安裝價TextBox.Text,
                單位 = 單位TextBox.Text,
                地址 = 地址TextBox.Text, 備註 = 備註TextBox.Text,進貨日期=進貨日期DateTimePicker.Value.Date
            };            
        }
        private void SetModel(PopularProduct prodct)
        {
             產品編號TextBox1.Text= prodct.產品編號;
             進價價錢TextBox.Text= prodct.進價價錢;
             水電價TextBox.Text = prodct.水電價;
             產品規格TextBox1.Text = prodct.產品規格;
             零售價TextBox.Text = prodct.零售價錢;
             安裝價TextBox.Text = prodct.安裝價;
             單位TextBox.Text = prodct.單位;
             地址TextBox.Text = prodct.地址;
             備註TextBox.Text = prodct.備註;
             進貨日期DateTimePicker.Value = prodct.進貨日期;
            
        }

        private void FrmProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                return;
            }
            if (e.KeyCode==Keys.F)
            {
                    txtSearch.Focus();
            }
            if (e.KeyCode == Keys.Q)
            {
                    BtnNew.PerformClick();
                    產品編號TextBox1.Focus();
            }
            if (e.KeyCode == Keys.W)
            {
                    BtnEdit.PerformClick();
                    產品規格TextBox1.Focus();
            }
            if (e.KeyCode == Keys.S)
            {
                    BtnSave.PerformClick();
            }
            if (e.KeyCode == Keys.C)
            {
                    BtnCancel.PerformClick();
            }
            if (e.KeyCode == Keys.D)
            {
                    BtnDelete.PerformClick();
            }
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectcnt= DgvProduct.SelectedRows.Count;
            if (selectcnt <= 0) return;
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show($"確定要刪除{selectcnt}筆產品?", "刪除提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog != DialogResult.Yes && prodct != null)
            {
                return;
            }
            for (int i = 0; i < selectcnt; i++)
            {
                var pdct =(PopularProduct) DgvProduct.SelectedRows[i].DataBoundItem;
                Db.ProductData.Delete(pdct);
            }
           
        }


        private void DgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvProduct.SelectedRows.Count== 0)
            {
                return;
            }
            if (DgvProduct.SelectedRows[0].DataBoundItem != null)
            {
                try
                {
                    prodct =(PopularProduct) DgvProduct.SelectedRows[0].DataBoundItem;

                    SetModel(prodct);
                }
                catch (Exception EX)
                {
                    EX = EX;
                }
            }
            else prodct = null;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Btn = BtnStatus.Cancel;
            SetButtonStatus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Allprodct.Clear();
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                Allprodct = Db.ProductData.GetAll();
                DgvProduct.DataSource = Allprodct;
                return;
            }
            var single = Db.ProductData.SinglebyName(txtSearch.Text.Trim());
            if (single != null)
            {
                Allprodct.Add(single);
            }

            if (Allprodct.Count == 0)
            {
                Allprodct = Db.ProductData.SearchAll(txtSearch.Text.Trim());
            }

            if (Allprodct.Count == 0)
            {
                Allprodct = Db.ProductData.LikeSearchAll(txtSearch.Text.Trim());
            }
            DgvProduct.DataSource = null;
            DgvProduct.DataSource = Allprodct;
            DgvProduct.Refresh();
            //if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            //{
            //    Allprodct = Db.ProductData.GetAll();
            //    DgvProduct.DataSource = Allprodct;
            //    return;
            //}
            //Allprodct = Db.ProductData.SearchAll(txtSearch.Text.Trim());
            //DgvProduct.DataSource = Allprodct;

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {

        }

        private void 產品編號TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
           


        }
       

        private void 產品編號TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void 水電價TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
