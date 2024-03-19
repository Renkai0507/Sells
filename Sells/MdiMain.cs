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
    public partial class MdiMain : Form
    {
        Form sonfrm;
        IDbServiceWrapper Db;        
        public MdiMain()
        {
            Db = new DbServiceWrapper();
            InitializeComponent();
            this.Text = this.Text + "[版本日期:" + System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString("yyyy/MM/dd HH:mm:ss") + "]";
        }
        private void newPage(Form sonfrm)
        {
            bool opened = false;
            foreach (Form son in this.MdiChildren)
            {
                if (sonfrm.Name == son.Name)
                {
                    son.Activate();
                    son.WindowState = FormWindowState.Maximized;
                    sonfrm.Dispose();
                    opened = true;
                }
            }
            if (!opened)
            {
                sonfrm.MdiParent = this;
                sonfrm.Show();
            }
        }

        private void 商品資料建檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sonfrm = new FrmProduct(Db); newPage(sonfrm);
        }

        private void 客戶資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sonfrm = new FrmCustom(Db); newPage(sonfrm);
        }

        private void 銷貨管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sonfrm = new FrmSell(Db); newPage(sonfrm);
        }

        private void 門市管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sonfrm = new FrmStore(Db); newPage(sonfrm);
        }
        private void 客戶紀錄查詢ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sonfrm = new FrmCustomRec(Db); newPage(sonfrm);
        }
        private void 查詢產品紀錄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sonfrm = new FrmProductRec(Db); newPage(sonfrm);
        }
    }
}
