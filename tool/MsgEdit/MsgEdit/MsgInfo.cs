using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsgEdit
{
    class MsgInfo
    {

        public static TextBox name;
        public static TextBox explain;
        public static TextBox content;

        private static msgdata msg_data=null;

        private static TreeNode treenode=null;

       
        public static void SetMsgInfo(TreeNode node,msgdata data)
        {
            msg_data = data;
            treenode = node;

            name.Text = data.name;
            explain.Text = data.explain;
            content.Text = data.content;
        }

        public static void SaveData()
        {
            if(treenode == null)
                return;

              string old = msg_data.name;
              msg_data.name=name.Text;
              msg_data.explain  =explain.Text;
              msg_data.content =content.Text;

              treenode.Text = msg_data.name;

              MsgList.ResetMsgData();
        }

        public static void CleanData()
        {
            treenode = null;
            msg_data = null;

            name.Text = "";
            explain.Text = "";
            content.Text = "";
        }

        

    }
}
