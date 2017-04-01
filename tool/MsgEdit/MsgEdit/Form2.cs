using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsgEdit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tb1.Text!="")
            {
                try
                {
                    int a = int.Parse(tb2.Text);

                    MsgList.AddDirectory(a,tb1.Text);

                    this.Close();

                }
                catch(Exception ex)
                {

                }
               
                
            }
           
        }
    }
}
