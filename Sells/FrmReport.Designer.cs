
namespace Sells
{
    partial class FrmReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label8;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvPdct = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvCust = new System.Windows.Forms.DataGridView();
            this.銷貨日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.銷貨單號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPdct = new System.Windows.Forms.TextBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.txtCust = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnPdct = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.產品編號DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.產品名稱DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.數量DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.單價DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.總金額DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdctRptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.客戶編號DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客戶名稱DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.總金額DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custRptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPdct)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCust)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdctRptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.custRptBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(8, 70);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(61, 16);
            label5.TabIndex = 27;
            label5.Text = "搜尋(H)";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(9, 29);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 16);
            label4.TabIndex = 36;
            label4.Text = "開始時間:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(9, 60);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(76, 16);
            label7.TabIndex = 37;
            label7.Text = "結束時間:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(297, 59);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(76, 16);
            label6.TabIndex = 42;
            label6.Text = "產品名稱:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(297, 24);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(76, 16);
            label8.TabIndex = 41;
            label8.Text = "客戶名稱:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 123);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1302, 629);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPdct);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1294, 599);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "產品";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvPdct
            // 
            this.dgvPdct.AllowUserToAddRows = false;
            this.dgvPdct.AllowUserToDeleteRows = false;
            this.dgvPdct.AutoGenerateColumns = false;
            this.dgvPdct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPdct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.產品編號DataGridViewTextBoxColumn,
            this.產品名稱DataGridViewTextBoxColumn,
            this.數量DataGridViewTextBoxColumn,
            this.單價DataGridViewTextBoxColumn,
            this.總金額DataGridViewTextBoxColumn});
            this.dgvPdct.DataSource = this.pdctRptBindingSource;
            this.dgvPdct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPdct.Location = new System.Drawing.Point(4, 4);
            this.dgvPdct.Name = "dgvPdct";
            this.dgvPdct.ReadOnly = true;
            this.dgvPdct.RowTemplate.Height = 24;
            this.dgvPdct.Size = new System.Drawing.Size(1286, 591);
            this.dgvPdct.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvCust);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1294, 599);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "客戶";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvCust
            // 
            this.dgvCust.AllowUserToAddRows = false;
            this.dgvCust.AllowUserToDeleteRows = false;
            this.dgvCust.AutoGenerateColumns = false;
            this.dgvCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCust.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.銷貨日期,
            this.銷貨單號,
            this.客戶編號DataGridViewTextBoxColumn,
            this.客戶名稱DataGridViewTextBoxColumn,
            this.總金額DataGridViewTextBoxColumn1});
            this.dgvCust.DataSource = this.custRptBindingSource;
            this.dgvCust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCust.Location = new System.Drawing.Point(4, 4);
            this.dgvCust.Name = "dgvCust";
            this.dgvCust.ReadOnly = true;
            this.dgvCust.RowTemplate.Height = 24;
            this.dgvCust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCust.Size = new System.Drawing.Size(1286, 591);
            this.dgvCust.TabIndex = 1;
            this.dgvCust.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCust_CellDoubleClick);
            // 
            // 銷貨日期
            // 
            this.銷貨日期.DataPropertyName = "銷貨日期";
            this.銷貨日期.HeaderText = "銷貨日期";
            this.銷貨日期.Name = "銷貨日期";
            this.銷貨日期.ReadOnly = true;
            this.銷貨日期.Visible = false;
            // 
            // 銷貨單號
            // 
            this.銷貨單號.DataPropertyName = "銷貨單號";
            this.銷貨單號.HeaderText = "銷貨單號";
            this.銷貨單號.Name = "銷貨單號";
            this.銷貨單號.ReadOnly = true;
            this.銷貨單號.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPdct);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Controls.Add(label8);
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.txtCust);
            this.groupBox2.Controls.Add(label7);
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(702, 111);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "紀錄搜尋(F)";
            // 
            // txtPdct
            // 
            this.txtPdct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPdct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPdct.Location = new System.Drawing.Point(379, 53);
            this.txtPdct.Name = "txtPdct";
            this.txtPdct.Size = new System.Drawing.Size(158, 27);
            this.txtPdct.TabIndex = 40;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(91, 53);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 27);
            this.dtpEnd.TabIndex = 38;
            // 
            // txtCust
            // 
            this.txtCust.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCust.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCust.Location = new System.Drawing.Point(379, 20);
            this.txtCust.Name = "txtCust";
            this.txtCust.Size = new System.Drawing.Size(158, 27);
            this.txtCust.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnPdct, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(543, 14);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.72881F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.27119F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(77, 90);
            this.tableLayoutPanel2.TabIndex = 29;
            // 
            // BtnPdct
            // 
            this.BtnPdct.BackgroundImage = global::Sells.Properties.Resources.SearchIcon;
            this.BtnPdct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPdct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPdct.Location = new System.Drawing.Point(3, 3);
            this.BtnPdct.Name = "BtnPdct";
            this.BtnPdct.Size = new System.Drawing.Size(71, 60);
            this.BtnPdct.TabIndex = 26;
            this.BtnPdct.TabStop = false;
            this.BtnPdct.UseVisualStyleBackColor = true;
            this.BtnPdct.Click += new System.EventHandler(this.BtnPdct_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(91, 18);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 27);
            this.dtpStart.TabIndex = 35;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1317, 756);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // 產品編號DataGridViewTextBoxColumn
            // 
            this.產品編號DataGridViewTextBoxColumn.DataPropertyName = "產品編號";
            this.產品編號DataGridViewTextBoxColumn.HeaderText = "產品編號";
            this.產品編號DataGridViewTextBoxColumn.Name = "產品編號DataGridViewTextBoxColumn";
            this.產品編號DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 產品名稱DataGridViewTextBoxColumn
            // 
            this.產品名稱DataGridViewTextBoxColumn.DataPropertyName = "產品名稱";
            this.產品名稱DataGridViewTextBoxColumn.HeaderText = "產品名稱";
            this.產品名稱DataGridViewTextBoxColumn.Name = "產品名稱DataGridViewTextBoxColumn";
            this.產品名稱DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 數量DataGridViewTextBoxColumn
            // 
            this.數量DataGridViewTextBoxColumn.DataPropertyName = "數量";
            this.數量DataGridViewTextBoxColumn.HeaderText = "數量";
            this.數量DataGridViewTextBoxColumn.Name = "數量DataGridViewTextBoxColumn";
            this.數量DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 單價DataGridViewTextBoxColumn
            // 
            this.單價DataGridViewTextBoxColumn.DataPropertyName = "單價";
            this.單價DataGridViewTextBoxColumn.HeaderText = "單價";
            this.單價DataGridViewTextBoxColumn.Name = "單價DataGridViewTextBoxColumn";
            this.單價DataGridViewTextBoxColumn.ReadOnly = true;
            this.單價DataGridViewTextBoxColumn.Visible = false;
            // 
            // 總金額DataGridViewTextBoxColumn
            // 
            this.總金額DataGridViewTextBoxColumn.DataPropertyName = "總金額";
            this.總金額DataGridViewTextBoxColumn.HeaderText = "總金額";
            this.總金額DataGridViewTextBoxColumn.Name = "總金額DataGridViewTextBoxColumn";
            this.總金額DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pdctRptBindingSource
            // 
            this.pdctRptBindingSource.DataSource = typeof(Sells.Models.PdctRpt);
            // 
            // 客戶編號DataGridViewTextBoxColumn
            // 
            this.客戶編號DataGridViewTextBoxColumn.DataPropertyName = "客戶編號";
            this.客戶編號DataGridViewTextBoxColumn.HeaderText = "客戶編號";
            this.客戶編號DataGridViewTextBoxColumn.Name = "客戶編號DataGridViewTextBoxColumn";
            this.客戶編號DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 客戶名稱DataGridViewTextBoxColumn
            // 
            this.客戶名稱DataGridViewTextBoxColumn.DataPropertyName = "客戶名稱";
            this.客戶名稱DataGridViewTextBoxColumn.HeaderText = "客戶名稱";
            this.客戶名稱DataGridViewTextBoxColumn.Name = "客戶名稱DataGridViewTextBoxColumn";
            this.客戶名稱DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 總金額DataGridViewTextBoxColumn1
            // 
            this.總金額DataGridViewTextBoxColumn1.DataPropertyName = "總金額";
            this.總金額DataGridViewTextBoxColumn1.HeaderText = "總金額";
            this.總金額DataGridViewTextBoxColumn1.Name = "總金額DataGridViewTextBoxColumn1";
            this.總金額DataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // custRptBindingSource
            // 
            this.custRptBindingSource.DataSource = typeof(Sells.Models.CustRpt);
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 756);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmReport";
            this.Text = "FrmStore";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReport_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPdct)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCust)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pdctRptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.custRptBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvPdct;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvCust;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BtnPdct;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.TextBox txtCust;
        private System.Windows.Forms.TextBox txtPdct;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource pdctRptBindingSource;
        private System.Windows.Forms.BindingSource custRptBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 銷貨日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 銷貨單號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶編號DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶名稱DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 總金額DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 產品編號DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 產品名稱DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 數量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 單價DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 總金額DataGridViewTextBoxColumn;
    }
}