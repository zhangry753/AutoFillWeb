namespace FillWebsite {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.pathText = new System.Windows.Forms.TextBox();
            this.selectPathBtn = new System.Windows.Forms.Button();
            this.doBtn1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pageText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.excelModelBtn = new System.Windows.Forms.Button();
            this.stopBtn1 = new System.Windows.Forms.Button();
            this.processLabel1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.siteText = new System.Windows.Forms.ComboBox();
            this.processLabel2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.asinText = new System.Windows.Forms.TextBox();
            this.stopBtn2 = new System.Windows.Forms.Button();
            this.doBtn2 = new System.Windows.Forms.Button();
            this.selectSavePathBtn = new System.Windows.Forms.Button();
            this.savePathText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cookieText = new System.Windows.Forms.TextBox();
            this.howToGetCookieBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pathText
            // 
            this.pathText.Location = new System.Drawing.Point(152, 26);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(237, 25);
            this.pathText.TabIndex = 0;
            // 
            // selectPathBtn
            // 
            this.selectPathBtn.Location = new System.Drawing.Point(395, 18);
            this.selectPathBtn.Name = "selectPathBtn";
            this.selectPathBtn.Size = new System.Drawing.Size(146, 36);
            this.selectPathBtn.TabIndex = 1;
            this.selectPathBtn.Text = "选择文件";
            this.selectPathBtn.UseVisualStyleBackColor = true;
            this.selectPathBtn.Click += new System.EventHandler(this.selectPathBtn_Click);
            // 
            // doBtn1
            // 
            this.doBtn1.Location = new System.Drawing.Point(152, 94);
            this.doBtn1.Name = "doBtn1";
            this.doBtn1.Size = new System.Drawing.Size(96, 30);
            this.doBtn1.TabIndex = 3;
            this.doBtn1.Text = "开始填写";
            this.doBtn1.UseVisualStyleBackColor = true;
            this.doBtn1.Click += new System.EventHandler(this.doBtn1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "excel路径";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 129);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(587, 206);
            this.tabControl.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.excelModelBtn);
            this.tabPage1.Controls.Add(this.stopBtn1);
            this.tabPage1.Controls.Add(this.doBtn1);
            this.tabPage1.Controls.Add(this.selectPathBtn);
            this.tabPage1.Controls.Add(this.processLabel1);
            this.tabPage1.Controls.Add(this.pathText);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 177);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "填写评价";
            // 
            // pageText
            // 
            this.pageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pageText.Location = new System.Drawing.Point(128, 96);
            this.pageText.Name = "pageText";
            this.pageText.Size = new System.Drawing.Size(21, 18);
            this.pageText.TabIndex = 17;
            this.pageText.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "页往前填写(0表示末尾页)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(105, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "从";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(249, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(292, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "再次运行前请务必删除已完成填写的行！！";
            // 
            // excelModelBtn
            // 
            this.excelModelBtn.Location = new System.Drawing.Point(395, 60);
            this.excelModelBtn.Name = "excelModelBtn";
            this.excelModelBtn.Size = new System.Drawing.Size(146, 29);
            this.excelModelBtn.TabIndex = 13;
            this.excelModelBtn.Text = "excel模板";
            this.excelModelBtn.UseVisualStyleBackColor = true;
            this.excelModelBtn.Click += new System.EventHandler(this.excelModelBtn_Click);
            // 
            // stopBtn1
            // 
            this.stopBtn1.Enabled = false;
            this.stopBtn1.Location = new System.Drawing.Point(293, 94);
            this.stopBtn1.Name = "stopBtn1";
            this.stopBtn1.Size = new System.Drawing.Size(96, 30);
            this.stopBtn1.TabIndex = 11;
            this.stopBtn1.Text = "停止";
            this.stopBtn1.UseVisualStyleBackColor = true;
            this.stopBtn1.Click += new System.EventHandler(this.stopBtn1_Click);
            // 
            // processLabel1
            // 
            this.processLabel1.AutoSize = true;
            this.processLabel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.processLabel1.Location = new System.Drawing.Point(67, 140);
            this.processLabel1.Name = "processLabel1";
            this.processLabel1.Size = new System.Drawing.Size(52, 15);
            this.processLabel1.TabIndex = 10;
            this.processLabel1.Text = "进度：";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.siteText);
            this.tabPage2.Controls.Add(this.processLabel2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.asinText);
            this.tabPage2.Controls.Add(this.stopBtn2);
            this.tabPage2.Controls.Add(this.doBtn2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(579, 177);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "获取订单号";
            // 
            // siteText
            // 
            this.siteText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siteText.FormattingEnabled = true;
            this.siteText.Items.AddRange(new object[] {
            "全部站点",
            "美国",
            "加拿大",
            "英国",
            "德国",
            "法国",
            "日本",
            "西班牙",
            "意大利"});
            this.siteText.Location = new System.Drawing.Point(152, 58);
            this.siteText.Name = "siteText";
            this.siteText.Size = new System.Drawing.Size(237, 23);
            this.siteText.TabIndex = 18;
            // 
            // processLabel2
            // 
            this.processLabel2.AutoSize = true;
            this.processLabel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.processLabel2.Location = new System.Drawing.Point(83, 140);
            this.processLabel2.Name = "processLabel2";
            this.processLabel2.Size = new System.Drawing.Size(52, 15);
            this.processLabel2.TabIndex = 17;
            this.processLabel2.Text = "进度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(85, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "国家：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(83, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "ASIN：";
            // 
            // asinText
            // 
            this.asinText.Location = new System.Drawing.Point(152, 27);
            this.asinText.Name = "asinText";
            this.asinText.Size = new System.Drawing.Size(237, 25);
            this.asinText.TabIndex = 15;
            // 
            // stopBtn2
            // 
            this.stopBtn2.Enabled = false;
            this.stopBtn2.Location = new System.Drawing.Point(293, 103);
            this.stopBtn2.Name = "stopBtn2";
            this.stopBtn2.Size = new System.Drawing.Size(96, 30);
            this.stopBtn2.TabIndex = 14;
            this.stopBtn2.Text = "停止";
            this.stopBtn2.UseVisualStyleBackColor = true;
            this.stopBtn2.Click += new System.EventHandler(this.stopBtn2_Click);
            // 
            // doBtn2
            // 
            this.doBtn2.Location = new System.Drawing.Point(152, 103);
            this.doBtn2.Name = "doBtn2";
            this.doBtn2.Size = new System.Drawing.Size(96, 30);
            this.doBtn2.TabIndex = 14;
            this.doBtn2.Text = "开始获取";
            this.doBtn2.UseVisualStyleBackColor = true;
            this.doBtn2.Click += new System.EventHandler(this.doBtn2_Click);
            // 
            // selectSavePathBtn
            // 
            this.selectSavePathBtn.Location = new System.Drawing.Point(399, 58);
            this.selectSavePathBtn.Name = "selectSavePathBtn";
            this.selectSavePathBtn.Size = new System.Drawing.Size(146, 26);
            this.selectSavePathBtn.TabIndex = 1;
            this.selectSavePathBtn.Text = "选择文件";
            this.selectSavePathBtn.UseVisualStyleBackColor = true;
            this.selectSavePathBtn.Click += new System.EventHandler(this.selectSavePathBtn_Click);
            // 
            // savePathText
            // 
            this.savePathText.Location = new System.Drawing.Point(156, 61);
            this.savePathText.Name = "savePathText";
            this.savePathText.Size = new System.Drawing.Size(237, 25);
            this.savePathText.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "订单号保存路径";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pageText);
            this.panel2.Controls.Add(this.cookieText);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.howToGetCookieBtn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.savePathText);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.selectSavePathBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 129);
            this.panel2.TabIndex = 14;
            // 
            // cookieText
            // 
            this.cookieText.Location = new System.Drawing.Point(156, 21);
            this.cookieText.Name = "cookieText";
            this.cookieText.Size = new System.Drawing.Size(237, 25);
            this.cookieText.TabIndex = 0;
            // 
            // howToGetCookieBtn
            // 
            this.howToGetCookieBtn.Location = new System.Drawing.Point(400, 17);
            this.howToGetCookieBtn.Name = "howToGetCookieBtn";
            this.howToGetCookieBtn.Size = new System.Drawing.Size(145, 33);
            this.howToGetCookieBtn.TabIndex = 12;
            this.howToGetCookieBtn.Text = "如何获取cookie";
            this.howToGetCookieBtn.UseVisualStyleBackColor = true;
            this.howToGetCookieBtn.Click += new System.EventHandler(this.howToGetCookieBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "请输入Cookie";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 335);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "网页自动填写";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button selectPathBtn;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.Button doBtn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cookieText;
        private System.Windows.Forms.Label processLabel1;
        private System.Windows.Forms.Button stopBtn1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox savePathText;
        private System.Windows.Forms.Button selectSavePathBtn;
        private System.Windows.Forms.Button howToGetCookieBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button doBtn2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox asinText;
        private System.Windows.Forms.Button stopBtn2;
        private System.Windows.Forms.Label processLabel2;
        private System.Windows.Forms.ComboBox siteText;
        private System.Windows.Forms.Button excelModelBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pageText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

