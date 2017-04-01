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
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_delpro = new System.Windows.Forms.Button();
            this.btn_setpath = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_outCsharp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tb_content = new System.Windows.Forms.TextBox();
            this.tb_shuoming = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.第一个标签.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.第一个标签);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(946, 564);
            this.tabControl1.TabIndex = 0;
            // 
            // 第一个标签
            // 
            this.第一个标签.Controls.Add(this.button7);
            this.第一个标签.Controls.Add(this.button6);
            this.第一个标签.Controls.Add(this.button4);
            this.第一个标签.Controls.Add(this.btn_delpro);
            this.第一个标签.Controls.Add(this.btn_setpath);
            this.第一个标签.Controls.Add(this.button5);
            this.第一个标签.Controls.Add(this.btn_outCsharp);
            this.第一个标签.Controls.Add(this.groupBox1);
            this.第一个标签.Controls.Add(this.treeView1);
            this.第一个标签.Controls.Add(this.button2);
            this.第一个标签.Controls.Add(this.button1);
            this.第一个标签.Location = new System.Drawing.Point(4, 22);
            this.第一个标签.Name = "第一个标签";
            this.第一个标签.Padding = new System.Windows.Forms.Padding(3);
            this.第一个标签.Size = new System.Drawing.Size(938, 538);
            this.第一个标签.TabIndex = 0;
            this.第一个标签.Text = "协议";
            this.第一个标签.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(90, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "修改目录";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(766, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(73, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "C#导出测试";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(638, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Java导出";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_delpro
            // 
            this.btn_delpro.Location = new System.Drawing.Point(263, 6);
            this.btn_delpro.Name = "btn_delpro";
            this.btn_delpro.Size = new System.Drawing.Size(75, 23);
            this.btn_delpro.TabIndex = 8;
            this.btn_delpro.Text = "删除协议";
            this.btn_delpro.UseVisualStyleBackColor = true;
            this.btn_delpro.Click += new System.EventHandler(this.btn_delpro_Click);
            // 
            // btn_setpath
            // 
            this.btn_setpath.Location = new System.Drawing.Point(440, 6);
            this.btn_setpath.Name = "btn_setpath";
            this.btn_setpath.Size = new System.Drawing.Size(75, 23);
            this.btn_setpath.TabIndex = 7;
            this.btn_setpath.Text = "路径设置";
            this.btn_setpath.UseVisualStyleBackColor = true;
            this.btn_setpath.Click += new System.EventHandler(this.btn_setpath_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(543, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Java导出测试";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_outCsharp
            // 
            this.btn_outCsharp.Location = new System.Drawing.Point(845, 6);
            this.btn_outCsharp.Name = "btn_outCsharp";
            this.btn_outCsharp.Size = new System.Drawing.Size(75, 23);
            this.btn_outCsharp.TabIndex = 5;
            this.btn_outCsharp.Text = "C#导出";
            this.btn_outCsharp.UseVisualStyleBackColor = true;
            this.btn_outCsharp.Click += new System.EventHandler(this.btn_outCsharp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.tb_content);
            this.groupBox1.Controls.Add(this.tb_shuoming);
            this.groupBox1.Controls.Add(this.tb_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(371, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 503);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(269, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "保存";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tb_content
            // 
            this.tb_content.Location = new System.Drawing.Point(104, 203);
            this.tb_content.Multiline = true;
            this.tb_content.Name = "tb_content";
            this.tb_content.Size = new System.Drawing.Size(345, 249);
            this.tb_content.TabIndex = 5;
            // 
            // tb_shuoming
            // 
            this.tb_shuoming.Location = new System.Drawing.Point(104, 101);
            this.tb_shuoming.Multiline = true;
            this.tb_shuoming.Name = "tb_shuoming";
            this.tb_shuoming.Size = new System.Drawing.Size(345, 60);
            this.tb_shuoming.TabIndex = 4;
            this.tb_shuoming.TextChanged += new System.EventHandler(this.tb_shuoming_TextChanged);
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(104, 35);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(345, 21);
            this.tb_name.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "协议内容";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "协议说明";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "协议名字";
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 35);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(338, 503);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "创建目录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "创建协议";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(938, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 第一个标签;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_shuoming;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_content;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_setpath;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btn_outCsharp;
        private System.Windows.Forms.Button btn_delpro;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
    }
}

