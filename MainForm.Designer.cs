namespace RSATool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.btnGenerate = new System.Windows.Forms.Button();
			this.btnEncrypt = new System.Windows.Forms.Button();
			this.btnDecrypt = new System.Windows.Forms.Button();
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpKey = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tbPrivateKey = new System.Windows.Forms.TextBox();
			this.tbPublicKey = new System.Windows.Forms.TextBox();
			this.tbClientPublicKey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tbSource = new System.Windows.Forms.TextBox();
			this.tbResult = new System.Windows.Forms.TextBox();
			this.btnLoad = new System.Windows.Forms.Button();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.tcMain.SuspendLayout();
			this.tpKey.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(12, 13);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(85, 23);
			this.btnGenerate.TabIndex = 0;
			this.btnGenerate.Text = "生成密钥(&G)";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// btnEncrypt
			// 
			this.btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEncrypt.Location = new System.Drawing.Point(616, 13);
			this.btnEncrypt.Name = "btnEncrypt";
			this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
			this.btnEncrypt.TabIndex = 1;
			this.btnEncrypt.Text = "加密(&E)";
			this.btnEncrypt.UseVisualStyleBackColor = true;
			this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
			// 
			// btnDecrypt
			// 
			this.btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDecrypt.Location = new System.Drawing.Point(706, 13);
			this.btnDecrypt.Name = "btnDecrypt";
			this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
			this.btnDecrypt.TabIndex = 2;
			this.btnDecrypt.Text = "解密(&D)";
			this.btnDecrypt.UseVisualStyleBackColor = true;
			this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
			// 
			// tcMain
			// 
			this.tcMain.Controls.Add(this.tpKey);
			this.tcMain.Controls.Add(this.tabPage2);
			this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcMain.Location = new System.Drawing.Point(0, 0);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(793, 554);
			this.tcMain.TabIndex = 3;
			// 
			// tpKey
			// 
			this.tpKey.Controls.Add(this.tableLayoutPanel1);
			this.tpKey.Location = new System.Drawing.Point(4, 22);
			this.tpKey.Name = "tpKey";
			this.tpKey.Padding = new System.Windows.Forms.Padding(3);
			this.tpKey.Size = new System.Drawing.Size(785, 528);
			this.tpKey.TabIndex = 0;
			this.tpKey.Text = "密钥";
			this.tpKey.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tbPrivateKey, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbPublicKey, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbClientPublicKey, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(779, 522);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tbPrivateKey
			// 
			this.tbPrivateKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPrivateKey.Location = new System.Drawing.Point(23, 3);
			this.tbPrivateKey.Multiline = true;
			this.tbPrivateKey.Name = "tbPrivateKey";
			this.tbPrivateKey.Size = new System.Drawing.Size(753, 272);
			this.tbPrivateKey.TabIndex = 0;
			// 
			// tbPublicKey
			// 
			this.tbPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPublicKey.Location = new System.Drawing.Point(23, 281);
			this.tbPublicKey.Multiline = true;
			this.tbPublicKey.Name = "tbPublicKey";
			this.tbPublicKey.ReadOnly = true;
			this.tbPublicKey.Size = new System.Drawing.Size(753, 116);
			this.tbPublicKey.TabIndex = 1;
			// 
			// tbClientPublicKey
			// 
			this.tbClientPublicKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbClientPublicKey.Location = new System.Drawing.Point(23, 403);
			this.tbClientPublicKey.Multiline = true;
			this.tbClientPublicKey.Name = "tbClientPublicKey";
			this.tbClientPublicKey.Size = new System.Drawing.Size(753, 116);
			this.tbClientPublicKey.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 400);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 122);
			this.label1.TabIndex = 3;
			this.label1.Text = "对方公钥";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 278);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 122);
			this.label2.TabIndex = 4;
			this.label2.Text = "我的公钥↓可公开";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 278);
			this.label3.TabIndex = 5;
			this.label3.Text = "我的私钥↓务必保密";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.tableLayoutPanel2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(785, 528);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "文本";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.tbSource, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tbResult, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(779, 522);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// tbSource
			// 
			this.tbSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSource.Location = new System.Drawing.Point(3, 3);
			this.tbSource.Multiline = true;
			this.tbSource.Name = "tbSource";
			this.tbSource.Size = new System.Drawing.Size(773, 255);
			this.tbSource.TabIndex = 0;
			// 
			// tbResult
			// 
			this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbResult.Location = new System.Drawing.Point(3, 264);
			this.tbResult.Multiline = true;
			this.tbResult.Name = "tbResult";
			this.tbResult.ReadOnly = true;
			this.tbResult.Size = new System.Drawing.Size(773, 255);
			this.tbResult.TabIndex = 1;
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(103, 13);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(85, 23);
			this.btnLoad.TabIndex = 4;
			this.btnLoad.Text = "加载密钥(&L)";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.btnEncrypt);
			this.pnlBottom.Controls.Add(this.btnLoad);
			this.pnlBottom.Controls.Add(this.btnGenerate);
			this.pnlBottom.Controls.Add(this.btnDecrypt);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 554);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(793, 47);
			this.pnlBottom.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(793, 601);
			this.Controls.Add(this.tcMain);
			this.Controls.Add(this.pnlBottom);
			this.Name = "MainForm";
			this.Text = "RSA 加密解密工具";
			this.tcMain.ResumeLayout(false);
			this.tpKey.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.pnlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpKey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbPrivateKey;
        private System.Windows.Forms.TextBox tbPublicKey;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TextBox tbClientPublicKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

