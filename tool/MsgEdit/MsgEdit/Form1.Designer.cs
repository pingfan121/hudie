namespace MsgEdit
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
            if(disposing && (components != null))
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.第一个标签 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tb_content = new System.Windows.Forms.TextBox();
            this.btn_delpro = new System.Windows.Forms.Button();
            this.tb_shuoming = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btn_outCsharp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.lv_showenum = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lb_meiju = new System.Windows.Forms.ListBox();
            this.button8 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.第一个标签.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.第一个标签);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 564);
            this.tabControl1.TabIndex = 0;
            // 
            // 第一个标签
            // 
            this.第一个标签.Controls.Add(this.button3);
            this.第一个标签.Controls.Add(this.button7);
            this.第一个标签.Controls.Add(this.tb_content);
            this.第一个标签.Controls.Add(this.btn_delpro);
            this.第一个标签.Controls.Add(this.tb_shuoming);
            this.第一个标签.Controls.Add(this.tb_name);
            this.第一个标签.Controls.Add(this.btn_outCsharp);
            this.第一个标签.Controls.Add(this.label3);
            this.第一个标签.Controls.Add(this.label2);
            this.第一个标签.Controls.Add(this.treeView1);
            this.第一个标签.Controls.Add(this.label1);
            this.第一个标签.Controls.Add(this.button2);
            this.第一个标签.Controls.Add(this.button1);
            this.第一个标签.Location = new System.Drawing.Point(4, 22);
            this.第一个标签.Name = "第一个标签";
            this.第一个标签.Padding = new System.Windows.Forms.Padding(3);
            this.第一个标签.Size = new System.Drawing.Size(942, 538);
            this.第一个标签.TabIndex = 0;
            this.第一个标签.Text = "协议";
            this.第一个标签.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(380, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "保存";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(89, 18);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "修改目录";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tb_content
            // 
            this.tb_content.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_content.Location = new System.Drawing.Point(380, 265);
            this.tb_content.Multiline = true;
            this.tb_content.Name = "tb_content";
            this.tb_content.Size = new System.Drawing.Size(550, 262);
            this.tb_content.TabIndex = 5;
            // 
            // btn_delpro
            // 
            this.btn_delpro.Location = new System.Drawing.Point(255, 18);
            this.btn_delpro.Name = "btn_delpro";
            this.btn_delpro.Size = new System.Drawing.Size(75, 23);
            this.btn_delpro.TabIndex = 8;
            this.btn_delpro.Text = "删除协议";
            this.btn_delpro.UseVisualStyleBackColor = true;
            this.btn_delpro.Click += new System.EventHandler(this.btn_delpro_Click);
            // 
            // tb_shuoming
            // 
            this.tb_shuoming.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_shuoming.Location = new System.Drawing.Point(380, 148);
            this.tb_shuoming.Multiline = true;
            this.tb_shuoming.Name = "tb_shuoming";
            this.tb_shuoming.Size = new System.Drawing.Size(550, 70);
            this.tb_shuoming.TabIndex = 4;
            this.tb_shuoming.TextChanged += new System.EventHandler(this.tb_shuoming_TextChanged);
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_name.Location = new System.Drawing.Point(380, 72);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(550, 26);
            this.tb_name.TabIndex = 3;
            // 
            // btn_outCsharp
            // 
            this.btn_outCsharp.Location = new System.Drawing.Point(855, 18);
            this.btn_outCsharp.Name = "btn_outCsharp";
            this.btn_outCsharp.Size = new System.Drawing.Size(75, 23);
            this.btn_outCsharp.TabIndex = 5;
            this.btn_outCsharp.Text = "导出";
            this.btn_outCsharp.UseVisualStyleBackColor = true;
            this.btn_outCsharp.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "协议内容";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "协议说明";
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(9, 57);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(321, 470);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "协议名字";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "创建目录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "创建协议";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.lv_showenum);
            this.tabPage2.Controls.Add(this.lb_meiju);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(942, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "枚举";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(855, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "导出";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(114, 17);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 5;
            this.button11.Text = "删除枚举";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(251, 17);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 3;
            this.button9.Text = "添加";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // lv_showenum
            // 
            this.lv_showenum.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv_showenum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lv_showenum.FullRowSelect = true;
            this.lv_showenum.GridLines = true;
            this.lv_showenum.LabelEdit = true;
            this.lv_showenum.Location = new System.Drawing.Point(251, 56);
            this.lv_showenum.Name = "lv_showenum";
            this.lv_showenum.Size = new System.Drawing.Size(679, 468);
            this.lv_showenum.TabIndex = 2;
            this.lv_showenum.UseCompatibleStateImageBehavior = false;
            this.lv_showenum.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "枚举值";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "枚举字符串";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "枚举说明";
            this.columnHeader3.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "操作";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "操作";
            // 
            // lb_meiju
            // 
            this.lb_meiju.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_meiju.FormattingEnabled = true;
            this.lb_meiju.ItemHeight = 16;
            this.lb_meiju.Location = new System.Drawing.Point(16, 56);
            this.lb_meiju.Name = "lb_meiju";
            this.lb_meiju.Size = new System.Drawing.Size(217, 468);
            this.lb_meiju.TabIndex = 1;
            this.lb_meiju.SelectedIndexChanged += new System.EventHandler(this.OnChange);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(16, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 0;
            this.button8.Text = "创建枚举";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.OnCreateEnum);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 562);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.第一个标签.ResumeLayout(false);
            this.第一个标签.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 第一个标签;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox tb_shuoming;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_content;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_outCsharp;
        private System.Windows.Forms.Button btn_delpro;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListBox lb_meiju;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ListView lv_showenum;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button5;
    }
}

