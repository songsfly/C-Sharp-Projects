namespace CheckBeforCommit
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnChooseDir = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtongb232 = new System.Windows.Forms.RadioButton();
            this.radioButtonutf8 = new System.Windows.Forms.RadioButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textBoxFileType = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 22);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.textBoxDir);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(537, 22);
            this.panel6.TabIndex = 2;
            // 
            // textBoxDir
            // 
            this.textBoxDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDir.Location = new System.Drawing.Point(0, 0);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(537, 21);
            this.textBoxDir.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnChooseDir);
            this.panel3.Controls.Add(this.btnAll);
            this.panel3.Controls.Add(this.btnChange);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(537, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 22);
            this.panel3.TabIndex = 1;
            // 
            // btnChooseDir
            // 
            this.btnChooseDir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChooseDir.Location = new System.Drawing.Point(1, 0);
            this.btnChooseDir.Name = "btnChooseDir";
            this.btnChooseDir.Size = new System.Drawing.Size(75, 22);
            this.btnChooseDir.TabIndex = 2;
            this.btnChooseDir.Text = "选择文件夹";
            this.btnChooseDir.UseVisualStyleBackColor = true;
            this.btnChooseDir.Click += new System.EventHandler(this.btnChooseDir_Click);
            // 
            // btnAll
            // 
            this.btnAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAll.Location = new System.Drawing.Point(76, 0);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 22);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "全部检查";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnChange
            // 
            this.btnChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChange.Location = new System.Drawing.Point(151, 0);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 22);
            this.btnChange.TabIndex = 0;
            this.btnChange.Text = "增量检查";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 307);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listBoxResults);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(763, 307);
            this.panel4.TabIndex = 0;
            // 
            // listBoxResults
            // 
            this.listBoxResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.HorizontalScrollbar = true;
            this.listBoxResults.ItemHeight = 12;
            this.listBoxResults.Location = new System.Drawing.Point(0, 21);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(763, 280);
            this.listBoxResults.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(763, 21);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件类型（用\',\'分割）";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.radioButtongb232);
            this.panel7.Controls.Add(this.radioButtonutf8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(495, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(268, 21);
            this.panel7.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "请选择目标文件的编码格式";
            // 
            // radioButtongb232
            // 
            this.radioButtongb232.AutoSize = true;
            this.radioButtongb232.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioButtongb232.Location = new System.Drawing.Point(156, 0);
            this.radioButtongb232.Name = "radioButtongb232";
            this.radioButtongb232.Size = new System.Drawing.Size(59, 21);
            this.radioButtongb232.TabIndex = 6;
            this.radioButtongb232.TabStop = true;
            this.radioButtongb232.Text = "GB2312";
            this.radioButtongb232.UseVisualStyleBackColor = true;
            // 
            // radioButtonutf8
            // 
            this.radioButtonutf8.AutoSize = true;
            this.radioButtonutf8.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioButtonutf8.Location = new System.Drawing.Point(215, 0);
            this.radioButtonutf8.Name = "radioButtonutf8";
            this.radioButtonutf8.Size = new System.Drawing.Size(53, 21);
            this.radioButtonutf8.TabIndex = 5;
            this.radioButtonutf8.TabStop = true;
            this.radioButtonutf8.Text = "UTF-8";
            this.radioButtonutf8.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.textBoxFileType);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(131, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(364, 21);
            this.panel8.TabIndex = 3;
            // 
            // textBoxFileType
            // 
            this.textBoxFileType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFileType.Location = new System.Drawing.Point(0, 0);
            this.textBoxFileType.Name = "textBoxFileType";
            this.textBoxFileType.Size = new System.Drawing.Size(364, 21);
            this.textBoxFileType.TabIndex = 2;
            this.textBoxFileType.Text = ".h,.hpp,.c,.cpp,.inc";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 329);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "合入前静态检测工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnChooseDir;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox textBoxFileType;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtongb232;
        private System.Windows.Forms.RadioButton radioButtonutf8;
    }
}

