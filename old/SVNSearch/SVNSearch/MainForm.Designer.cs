namespace SVNSearch
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Panel_background = new System.Windows.Forms.Panel();
            this.panelSerchInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBarSearch = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxSearchResult = new System.Windows.Forms.ListBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxSVNItems = new System.Windows.Forms.ComboBox();
            this.textBoxCondition = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonCurrent = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMngDb = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panel_background.SuspendLayout();
            this.panelSerchInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::SVNSearch.Properties.Resources.开场;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 476);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Panel_background
            // 
            this.Panel_background.Controls.Add(this.panelSerchInfo);
            this.Panel_background.Controls.Add(this.panelMenu);
            this.Panel_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_background.Location = new System.Drawing.Point(0, 0);
            this.Panel_background.Name = "Panel_background";
            this.Panel_background.Size = new System.Drawing.Size(630, 476);
            this.Panel_background.TabIndex = 1;
            this.Panel_background.Visible = false;
            // 
            // panelSerchInfo
            // 
            this.panelSerchInfo.Controls.Add(this.panel1);
            this.panelSerchInfo.Controls.Add(this.listBoxSearchResult);
            this.panelSerchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSerchInfo.Location = new System.Drawing.Point(0, 43);
            this.panelSerchInfo.Name = "panelSerchInfo";
            this.panelSerchInfo.Size = new System.Drawing.Size(630, 433);
            this.panelSerchInfo.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.progressBarSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 13);
            this.panel1.TabIndex = 2;
            // 
            // progressBarSearch
            // 
            this.progressBarSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.progressBarSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarSearch.Location = new System.Drawing.Point(0, 0);
            this.progressBarSearch.Name = "progressBarSearch";
            this.progressBarSearch.Size = new System.Drawing.Size(367, 13);
            this.progressBarSearch.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarSearch.TabIndex = 5;
            this.progressBarSearch.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(367, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "©2012-2014 s00227767. All rights reserved. ";
            // 
            // listBoxSearchResult
            // 
            this.listBoxSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSearchResult.FormattingEnabled = true;
            this.listBoxSearchResult.ItemHeight = 12;
            this.listBoxSearchResult.Location = new System.Drawing.Point(0, 0);
            this.listBoxSearchResult.Name = "listBoxSearchResult";
            this.listBoxSearchResult.Size = new System.Drawing.Size(630, 424);
            this.listBoxSearchResult.TabIndex = 0;
            this.listBoxSearchResult.DoubleClick += new System.EventHandler(this.listBoxSearchResult_DoubleClick);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.panel4);
            this.panelMenu.Controls.Add(this.panel3);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(630, 43);
            this.panelMenu.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxSVNItems);
            this.panel4.Controls.Add(this.textBoxCondition);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(91, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(449, 43);
            this.panel4.TabIndex = 2;
            // 
            // comboBoxSVNItems
            // 
            this.comboBoxSVNItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxSVNItems.FormattingEnabled = true;
            this.comboBoxSVNItems.Location = new System.Drawing.Point(0, 0);
            this.comboBoxSVNItems.Name = "comboBoxSVNItems";
            this.comboBoxSVNItems.Size = new System.Drawing.Size(449, 20);
            this.comboBoxSVNItems.TabIndex = 2;
            this.comboBoxSVNItems.SelectedIndexChanged += new System.EventHandler(this.comboBoxSVNItems_SelectedIndexChanged);
            // 
            // textBoxCondition
            // 
            this.textBoxCondition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxCondition.Location = new System.Drawing.Point(0, 22);
            this.textBoxCondition.Name = "textBoxCondition";
            this.textBoxCondition.Size = new System.Drawing.Size(449, 21);
            this.textBoxCondition.TabIndex = 3;
            this.textBoxCondition.Text = "输入搜索条件";
            this.textBoxCondition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCondition_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonAll);
            this.panel3.Controls.Add(this.radioButtonCurrent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(540, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 43);
            this.panel3.TabIndex = 1;
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Location = new System.Drawing.Point(7, 23);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(71, 16);
            this.radioButtonAll.TabIndex = 1;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "搜索全部";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // radioButtonCurrent
            // 
            this.radioButtonCurrent.AutoSize = true;
            this.radioButtonCurrent.Location = new System.Drawing.Point(7, 4);
            this.radioButtonCurrent.Name = "radioButtonCurrent";
            this.radioButtonCurrent.Size = new System.Drawing.Size(71, 16);
            this.radioButtonCurrent.TabIndex = 0;
            this.radioButtonCurrent.TabStop = true;
            this.radioButtonCurrent.Text = "搜索当前";
            this.radioButtonCurrent.UseVisualStyleBackColor = true;
            this.radioButtonCurrent.CheckedChanged += new System.EventHandler(this.radioButtonCurrent_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMngDb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(91, 43);
            this.panel2.TabIndex = 0;
            // 
            // btnMngDb
            // 
            this.btnMngDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMngDb.Location = new System.Drawing.Point(0, 0);
            this.btnMngDb.Name = "btnMngDb";
            this.btnMngDb.Size = new System.Drawing.Size(91, 43);
            this.btnMngDb.TabIndex = 4;
            this.btnMngDb.Text = "管理数据库";
            this.btnMngDb.UseVisualStyleBackColor = true;
            this.btnMngDb.Click += new System.EventHandler(this.btnMngDb_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 476);
            this.Controls.Add(this.Panel_background);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SVN搜索";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panel_background.ResumeLayout(false);
            this.panelSerchInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Panel_background;
        private System.Windows.Forms.Panel panelSerchInfo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ListBox listBoxSearchResult;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonCurrent;
        private System.Windows.Forms.ComboBox comboBoxSVNItems;
        private System.Windows.Forms.TextBox textBoxCondition;
        private System.Windows.Forms.Button btnMngDb;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBarSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}

