using GameLib.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsgEdit
{
    class msgdata
    {
        public int index;
        public string name="";
        public string explain="";
        public string content="";
    }
    class DirectoryData
    {
        public int index;
        public string name = "";
        public string dic_name = "";
        public List<msgdata> protos = new List<msgdata>();
    }

    class MsgList
    {
        public static  TreeView tv;

        public static List<DirectoryData> alldata = new List<DirectoryData>();

        public static Dictionary<TreeNode, DirectoryData> dir_map = new Dictionary<TreeNode, DirectoryData>();
        public static Dictionary<TreeNode, msgdata> proto_map = new Dictionary<TreeNode, msgdata>();

        public static void SetTreeView(TreeView treeview)
        {
            tv = treeview;

            tv.HideSelection = false;

            tv.DrawMode = TreeViewDrawMode.OwnerDrawText;
            tv.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);
        }

        //在绘制节点事件中，按自已想的绘制
        private static void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //e.DrawDefault = true; //我这里用默认颜色即可，只需要在TreeView失去焦点时选中节点仍然突显
            //return;

            if((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为绿底白字
                e.Graphics.FillRectangle(Brushes.DarkBlue, e.Node.Bounds);

                Font nodeFont = e.Node.NodeFont;
                if(nodeFont == null)
                    nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }

            if((e.State & TreeNodeStates.Focused) != 0)
            {
                using(Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width,
                    focusBounds.Height);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }

        }

        //添加一个目录
        public static void AddDirectory(int index,string name)
        {
            Dictionary<string, msgdata> temp = new Dictionary<string, msgdata>();

            DirectoryData dir = new DirectoryData();
            dir.index = index;
            dir.name = name;

            dir.dic_name = OutCsharp2.HanZiZhuanPinYin(name);

            alldata.Add(dir);

            UpdateTree();
        }

        //删除一个目录
        public static void SubDirectory(DirectoryData dir)
        {
            alldata.Remove(dir);

            UpdateTree();
        }

        //添加一个协议
        public static void AddMsg(string name)
        {
            msgdata msg = new msgdata();
            msg.name = name;

            DirectoryData dir = GetCurrDir();

            dir.protos.Add(msg);

            UpdateTree();

            tv.SelectedNode = GetNodeForProto(msg);

            tv.SelectedNode.ExpandAll();
        }

        //删除一个协议
        public static void SubMsg()
        {

            DirectoryData dir = GetCurrDir();

            msgdata msg = GetCurrProto();

            dir.protos.Remove(msg);

            UpdateTree();

            tv.SelectedNode = GetNodeForDir(dir);
        }
       

        
        public static  msgdata GetMsgInfo(string name)
        {
            foreach(DirectoryData dir in alldata)
            {
                foreach(msgdata msg in dir.protos)
                {
                    if(msg.name == name)
                        return msg;
                }
            }
            return null;
        }

        public static void ResetMsgData()
        {
            msgdata msg = GetCurrProto();

            UpdateTree();

            tv.SelectedNode = GetNodeForProto(msg);
        }

        //获取当前目录
        public static DirectoryData GetCurrDir()
        {
            if(tv.SelectedNode.ImageIndex == 0)
            {
                return dir_map[tv.SelectedNode];
            }
            else
            {
                return dir_map[tv.SelectedNode.Parent];
            }
        }

        //获取当前协议
        public static msgdata GetCurrProto()
        {
            if(tv.SelectedNode.ImageIndex == 1)
            {
                return proto_map[tv.SelectedNode];
            }
            return null;
        }

        //根据目录 获取节点
        public static TreeNode GetNodeForDir(DirectoryData dir)
        {
            foreach(var item in dir_map)
            {
                if(item.Value == dir)
                {
                    return item.Key;
                }
            }
            return null;
        }

        //根据目录 获取节点
        public static TreeNode GetNodeForProto(msgdata msg)
        {
            foreach(var item in proto_map)
            {
                if(item.Value == msg)
                {
                    return item.Key;
                }
            }
            return null;
        }


        //读取数据
        public static void ReadFileData()
        {
            if(File.Exists("data/data.txt"))
            {
                StreamReader sr = new StreamReader("data/data.txt");
                string str = sr.ReadToEnd();

                try
                {
                    alldata = JSON.Decode<List<DirectoryData>>(str);
                }
                catch(Exception ex)
                {
                    alldata = new List<DirectoryData>();
                }

                if(alldata == null)
                {
                    alldata = new List<DirectoryData>();
                }
               

                sr.Close();

                UpdateTree();
            }
        }



        //更新树

        public static void UpdateTree()
        {
            tv.Nodes.Clear();

            dir_map.Clear();
            proto_map.Clear();

            //排序
            alldata.Sort(ListSort);

            foreach(DirectoryData dir in alldata)
            {
                TreeNode node = new TreeNode();
                node.Text = dir.index+" "+dir.name;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;

                dir_map.Add(node, dir);

                foreach(msgdata msg in dir.protos)
                {
                    TreeNode node2 = new TreeNode();
                    node2.Text = msg.name;
                    node2.ImageIndex = 1;
                    node2.SelectedImageIndex = 1;

                    proto_map.Add(node2, msg);

                    node.Nodes.Add(node2);
                }

                tv.Nodes.Add(node);
            }

            tv.HideSelection = false;

            WriteFileData();
        }


        private static int ListSort(DirectoryData data1,DirectoryData data2)
        {
            return data1.index > data2.index?1:0;
        }

        //写入协议数据
        public static void WriteFileData()
        {
            StreamWriter sw = new StreamWriter("data/data.txt", false);

            sw.Write(JSON.Encode(alldata));
            sw.Close();
        }


        //导出协议文件
        public static void OutProtocolFile()
        {
            OutCsharp2.OutFile(alldata);
            OutJava.OutFile(alldata);
        }

    }
}
