
namespace Sells
{
    partial class MdiMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基本資料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品資料建檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客戶資料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.銷貨管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.門市管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客戶紀錄查詢ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查詢產品紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本資料ToolStripMenuItem,
            this.銷貨管理ToolStripMenuItem,
            this.門市管理ToolStripMenuItem,
            this.客戶紀錄查詢ToolStripMenuItem,
            this.查詢產品紀錄ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1306, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基本資料ToolStripMenuItem
            // 
            this.基本資料ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.商品資料建檔ToolStripMenuItem,
            this.客戶資料ToolStripMenuItem});
            this.基本資料ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.基本資料ToolStripMenuItem.Name = "基本資料ToolStripMenuItem";
            this.基本資料ToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.基本資料ToolStripMenuItem.Text = "基本資料";
            // 
            // 商品資料建檔ToolStripMenuItem
            // 
            this.商品資料建檔ToolStripMenuItem.Name = "商品資料建檔ToolStripMenuItem";
            this.商品資料建檔ToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.商品資料建檔ToolStripMenuItem.Text = "商品資料建檔";
            this.商品資料建檔ToolStripMenuItem.Click += new System.EventHandler(this.商品資料建檔ToolStripMenuItem_Click);
            // 
            // 客戶資料ToolStripMenuItem
            // 
            this.客戶資料ToolStripMenuItem.Name = "客戶資料ToolStripMenuItem";
            this.客戶資料ToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.客戶資料ToolStripMenuItem.Text = "客戶資料";
            this.客戶資料ToolStripMenuItem.Click += new System.EventHandler(this.客戶資料ToolStripMenuItem_Click);
            // 
            // 銷貨管理ToolStripMenuItem
            // 
            this.銷貨管理ToolStripMenuItem.Name = "銷貨管理ToolStripMenuItem";
            this.銷貨管理ToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.銷貨管理ToolStripMenuItem.Text = "銷貨管理";
            this.銷貨管理ToolStripMenuItem.Click += new System.EventHandler(this.銷貨管理ToolStripMenuItem_Click);
            // 
            // 門市管理ToolStripMenuItem
            // 
            this.門市管理ToolStripMenuItem.Name = "門市管理ToolStripMenuItem";
            this.門市管理ToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.門市管理ToolStripMenuItem.Text = "門市管理";
            this.門市管理ToolStripMenuItem.Click += new System.EventHandler(this.門市管理ToolStripMenuItem_Click);
            // 
            // 客戶紀錄查詢ToolStripMenuItem
            // 
            this.客戶紀錄查詢ToolStripMenuItem.Name = "客戶紀錄查詢ToolStripMenuItem";
            this.客戶紀錄查詢ToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.客戶紀錄查詢ToolStripMenuItem.Text = "客戶紀錄查詢";
            this.客戶紀錄查詢ToolStripMenuItem.Click += new System.EventHandler(this.客戶紀錄查詢ToolStripMenuItem_Click);
            // 
            // 查詢產品紀錄ToolStripMenuItem
            // 
            this.查詢產品紀錄ToolStripMenuItem.Name = "查詢產品紀錄ToolStripMenuItem";
            this.查詢產品紀錄ToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.查詢產品紀錄ToolStripMenuItem.Text = "查詢產品紀錄";
            this.查詢產品紀錄ToolStripMenuItem.Click += new System.EventHandler(this.查詢產品紀錄ToolStripMenuItem_Click);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // MdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 737);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MdiMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批發系統";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 基本資料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品資料建檔ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客戶資料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 銷貨管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 門市管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客戶紀錄查詢ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查詢產品紀錄ToolStripMenuItem;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
    }
}

