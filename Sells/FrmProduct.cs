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
        DataTable dt;
        BtnStatus Btn;
        public FrmProduct(IDbServiceWrapper _Db)
        {
            Db = _Db;
            dt = new DataTable();
            InitializeComponent();
            DefaultSet();
        }

        private void DefaultSet()
        {
            this.WindowState = FormWindowState.Maximized;
            dt = Db.ProductData.TurnTable(Db.ProductData.GetAll());
            DgvProduct.DataSource = dt ;             
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            Btn = BtnStatus.New;
            SetNewStatus();
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

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            switch (Btn)
            {
                case BtnStatus.New:
                    GetModel();
                    Db.ProductData.AddNew(prodct);
                    break;
                case BtnStatus.Edit:
                    break;
                case BtnStatus.Delete:
                    break;
                default:
                    break;
            }


        }

        private void GetModel()
        {
            prodct = new PopularProduct()
            {
                產品編號 = 產品編號TextBox1.Text,
                進價價錢 = 進價價錢TextBox.Text,
                水電價 = 水電價TextBox.Text,
                產品規格 = 產品規格TextBox1.Text,
                零售價 = 零售價TextBox.Text,
                安裝價 = 安裝價TextBox.Text,
                單位 = 單位TextBox.Text,
                地址 = 地址TextBox.Text, 備註 = 備註TextBox.Text,進貨日期=進貨日期DateTimePicker.Value.Date
            };            
        }
    }
}
