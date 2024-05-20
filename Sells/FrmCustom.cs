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
    public partial class FrmCustom : Form
    {

        IDbServiceWrapper Db;
        CustomerData customer;
        BtnStatus Btn;
        List<CustomerData> Allcustomer;
        public FrmCustom(IDbServiceWrapper _Db)
        {
            Db = _Db;
            InitializeComponent();
            DefaultSet();
        }

        private void DefaultSet()
        {
            this.WindowState = FormWindowState.Maximized;
            //dt = Db.ProductData.TurnTable(Db.ProductData.GetAll());
            Allcustomer = Db.CustomerData.GetAll();
            dgvcustomer.DataSource = Allcustomer;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            Btn = BtnStatus.New;
            SetNewStatus();
            SetButtonStatus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Btn = BtnStatus.Cancel;
            SetNewStatus();
            SetButtonStatus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(客戶編號TextBox.Text))
            {
                MessageBox.Show("客戶編號空白");
                return;
            }
            if (string.IsNullOrEmpty(客戶名稱TextBox.Text))
            {
                MessageBox.Show("客戶規格空白");
                return;
            }
            GetModel();
            DialogResult dialog = new DialogResult();
            switch (Btn)
            {
                case BtnStatus.New:
                    dialog = MessageBox.Show($"確定要新增{customer.客戶名稱}({customer.客戶編號})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes && customer != null)
                    {
                       Db.CustomerData.AddNew(customer);
                    }

                    break;
                case BtnStatus.Edit:
                    dialog = MessageBox.Show($"確定要修改{customer.客戶名稱}({customer.客戶編號})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes && customer != null)
                    {
                        Db.CustomerData.Edit(customer);
                    }

                    break;
                case BtnStatus.Delete:
                    dialog = MessageBox.Show($"確定要刪除{customer.客戶名稱}({customer.客戶編號})?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes && customer != null)
                    {
                        Db.CustomerData.Delete(customer);
                    }
                    break;
                default:
                    break;
            }
            Allcustomer = Db.CustomerData.GetAll();
            dgvcustomer.DataSource = Allcustomer;
            Btn = BtnStatus.Cancel;
            SetButtonStatus();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show($"確定要刪除{customer.客戶名稱}({customer.客戶編號})?", "刪除提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes && customer != null)
            {
                Db.CustomerData.Delete(customer);
            }
        }
        void SetNewStatus()
        {
            客戶編號TextBox.Text = "";
            客戶名稱TextBox.Text = "";
            公司電話TextBox.Text = "";
            聯絡人TextBox.Text = "";
            電話TextBox.Text = "";
            公司傳真TextBox.Text = "";            
            地址TextBox.Text = "";
            送貨地址TextBox.Text = "";
            月結日期TextBox.Text = "";
            發票抬頭TextBox.Text = "";
            業務TextBox.Text = "";
            手機號碼TextBox.Text = "";
            備註TextBox.Text = "";
            屬性TextBox.Text = "";
            emailTextBox.Text = "";
        }
        private void SetButtonStatus()
        {
            switch (Btn)
            {
                case BtnStatus.New:
                    BtnNew.Enabled = false;
                    BtnEdit.Enabled = true;
                    客戶編號TextBox.Enabled = true;
                    BtnSave.Enabled = true;
                    dgvcustomer.Enabled = false;
                    BtnCancel.Enabled = true;
                    break;
                case BtnStatus.Edit:
                    BtnNew.Enabled = true;
                    BtnEdit.Enabled = false;
                    客戶編號TextBox.Enabled = false;
                    BtnSave.Enabled = true;
                    dgvcustomer.Enabled = false;
                    BtnCancel.Enabled = true;
                    break;
                case BtnStatus.Cancel:
                    BtnNew.Enabled = true;
                    BtnEdit.Enabled = true;
                    客戶編號TextBox.Enabled = true;
                    BtnSave.Enabled = false;
                    dgvcustomer.Enabled = true;
                    BtnCancel.Enabled = false;
                    break;
                case BtnStatus.Delete:
                    BtnNew.Enabled = true;
                    BtnEdit.Enabled = true;
                    客戶編號TextBox.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                    break;
                default:
                    BtnNew.Enabled = true;
                    BtnEdit.Enabled = true;
                    客戶編號TextBox.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                    break;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Btn = BtnStatus.Edit;
            //SetNewStatus();
            SetButtonStatus();
        }
        private void GetModel()
        {
            customer = new CustomerData()
            {
                客戶編號= 客戶編號TextBox.Text,
                客戶名稱= 客戶名稱TextBox.Text,
                email= emailTextBox.Text,
                備註= 備註TextBox.Text,
                公司傳真= 公司傳真TextBox.Text,
                公司電話 = 公司電話TextBox.Text,
                地址= 地址TextBox.Text,
                屬性= 屬性TextBox.Text,
                手機號碼= 手機號碼TextBox.Text,
                月結日期= 月結日期TextBox.Text,
                業務= 業務TextBox.Text,
                發票抬頭= 發票抬頭TextBox.Text,
                聯絡人= 聯絡人TextBox.Text,
                送貨地址= 送貨地址TextBox.Text,
                電話= 電話TextBox.Text
            };
        }

        private void FrmCustom_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                return;
            }
            if (e.KeyCode == Keys.F)
            {
                    txtSearch.Focus();
            }
            if (e.KeyCode == Keys.Q)
            {
                    BtnNew.PerformClick();
                    客戶名稱TextBox.Focus();
            }
            if (e.KeyCode == Keys.W)
            {
                    BtnEdit.PerformClick();
                    客戶名稱TextBox.Focus();
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

        private void dgvcustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvcustomer.SelectedRows.Count == 0)
            {
                return;
            }
            if (dgvcustomer.SelectedRows[0].DataBoundItem != null)
            {
                try
                {
                    customer = (CustomerData)dgvcustomer.SelectedRows[0].DataBoundItem;

                    SetModel(customer);
                }
                catch (Exception EX)
                {
                    EX = EX;
                }
            }
            else customer = null;
        }

        private void SetModel(CustomerData customer)
        {
            客戶編號TextBox.Text = customer.客戶編號;
            客戶名稱TextBox.Text = customer.客戶名稱;
            公司電話TextBox.Text = customer.公司電話;
            公司傳真TextBox.Text = customer.公司傳真;
            聯絡人TextBox.Text = customer.聯絡人;
            電話TextBox.Text = customer.電話;
            地址TextBox.Text = customer.地址;
            送貨地址TextBox.Text = customer.送貨地址;
            月結日期TextBox.Text = customer.月結日期;
            發票抬頭TextBox.Text = customer.發票抬頭;
            業務TextBox.Text = customer.業務;
            手機號碼TextBox.Text = customer.手機號碼;
            備註TextBox.Text = customer.備註;
            emailTextBox.Text = customer.email;
            屬性TextBox.Text = customer.屬性;
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                Allcustomer = Db.CustomerData.GetAll();
                dgvcustomer.DataSource = Allcustomer;
                return;
            }
            Allcustomer = Db.CustomerData.SearchAll(txtSearch.Text.Trim());
            dgvcustomer.DataSource = Allcustomer;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
