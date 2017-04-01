using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsgEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if(!Directory.Exists("data/"))
            {
                Directory.CreateDirectory("data/");
            }

             ImageList il = new ImageList();

             il.Images.Add(Image.FromFile("ico1.png"));
             il.Images.Add(Image.FromFile("ico2.png"));
             
             treeView1.ImageList = il;
             treeView1.AfterSelect += OnNodeChange;

             MsgList.SetTreeView(treeView1);

             MsgInfo.name = tb_name;
             MsgInfo.explain = tb_shuoming;
             MsgInfo.content = tb_content;

             MsgList.ReadFileData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                //创建
                Form3 form = new Form3();
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void OnNodeChange(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode.Parent != null)
            {
                 msgdata data = MsgList.GetMsgInfo(treeView1.SelectedNode.Text);

                 if(data != null)
                 {
                     MsgInfo.SetMsgInfo(treeView1.SelectedNode, data);
                 }
                 else
                 {
                     MsgInfo.CleanData();
                 }
                
            }
            else
            {
                MsgInfo.CleanData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MsgInfo.SaveData();
        }

        private void btn_setpath_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void btn_outCsharp_Click(object sender, EventArgs e)
        {
            MsgList.OutCsharpFile(1);
        }

        private void btn_delpro_Click(object sender, EventArgs e)
        {
            MsgList.SubMsg();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MsgList.OutJavaFile(2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MsgList.OutCsharpFile(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MsgList.OutJavaFile(1);
        }

        private void tb_shuoming_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
