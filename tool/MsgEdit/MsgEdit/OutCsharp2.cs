using GameLib.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MsgEdit
{
    class OutCsharp2
    {
        public static int type = 1;
        //导出文件
        public static void OutFile(List<DirectoryData> protos)
        {
            //先生协议id文件
            CreateCodeID(protos);

            //导出协议文件
            CreateProtoFiles(protos);

            //导出协议处理文件
            CreateProtoReq(protos);

            //导出协议映射处理函数文件
            CreateprotoMapFile(protos);

        }


        private static void CreateCodeID(List<DirectoryData> protos)
        {
            List<string> ids = new List<string>();

            int index = 1;

            foreach(DirectoryData dir in protos)
            {
                foreach(msgdata data in dir.protos)
                {
                    ids.Add(data.name + " = " + index + ",");
                    index++;
                }
            }

            string path = GetSetverPath();
            //写入文件
            if(!Directory.Exists(path + "\\message\\"))
            {
                Directory.CreateDirectory(path + "\\message\\");
            }

            StreamWriter sw = new StreamWriter(path + "\\message\\MsgCodeId.cs",false,Encoding.Unicode);

            //   sw.WriteLine("using GameServer.Define.EnumNormal;");
            //   sw.WriteLine("");
            sw.WriteLine("namespace messages");
            sw.WriteLine("{");
            sw.WriteLine("\tpublic enum MsgCodeId");
            sw.WriteLine("\t{");

            foreach(string id in ids)
            {
                sw.WriteLine("\t\t" + id);
            }
            sw.WriteLine("\t}");
            sw.WriteLine("}");

            sw.Close();
        }

        private static void CreateProtoFiles(List<DirectoryData> protos)
        {
            foreach(DirectoryData dir in protos)
            {
                foreach(msgdata data in dir.protos)
                {
                    CreateProtoFiles2(data,dir.dic_name);
                }
            }
        }

        private static void CreateProtoFiles2(msgdata data,string dir_name)
        {
            //分割属性

            string str = data.content.Replace("\r\n", "|");
            string[] attrstxt = str.Split('|');


            //属性
            List<string> attrs = new List<string>();
            List<string> sets = new List<string>();

          
            bool flag1 = false;
            bool flag2 = false;

            foreach(string attr in attrstxt)
            {
                string[] fenge = attr.Split(';');

                string[] temp2 = fenge[0].Split(' ');


                if(temp2[0] == "required")  //必须的
                {
                    //属性
                    attrs.Add("public " + temp2[1] + " " + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));
                }
                else if(temp2[0] == "array")  //重复的
                {
                    //属性
                    attrs.Add("public " + temp2[1] + "[] " + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));
                }
            }

            string path = GetSetverPath();

            string path2 = "\\message\\Protocols\\";


            if(!Directory.Exists(path + path2))
            {
                Directory.CreateDirectory(path + path2);
            }

            path2 += dir_name + "\\";

            if(!Directory.Exists(path + path2))
            {
                Directory.CreateDirectory(path + path2);
            }

            StreamWriter sw = new StreamWriter(path + path2 + data.name + ".cs", false, Encoding.Unicode);

            //使用命名空间
            sw.WriteLine("using messages;");
            sw.WriteLine("");

            //定义类
            sw.WriteLine("namespace messages.Protocols");
            sw.WriteLine("{");
            sw.WriteLine("  public class " + data.name + " : MsgBase");
            sw.WriteLine("  {");

            //构造函数
            sw.WriteLine("      public " + data.name + "()");
            sw.WriteLine("      {");
            sw.WriteLine("          CodeId = MsgCodeId." + data.name + ";");
            sw.WriteLine("      }");

            //写入属性

            foreach(string ss in attrs)
            {
                sw.WriteLine("      " + ss);
            }
           
            sw.WriteLine("");


            sw.WriteLine("\t}");
            sw.WriteLine("}");

            sw.Close();
        }

        private static void CreateProtoReq(List<DirectoryData> protos)
        {
            foreach(DirectoryData dir in protos)
            {
              
                foreach(msgdata data in dir.protos)
                {
                    if(data.name.IndexOf("_req")!=-1)
                    {
                        CreateProtoReq2(data,dir.dic_name);
                    }
                   
                }
            }
        }
        private static void CreateProtoReq2(msgdata data,string dir_name)
        {
            string path = GetSetverPath();

            string path2 = "\\message\\ProtocolsReq\\";


            if(!Directory.Exists(path +path2))
            {
                Directory.CreateDirectory(path + path2);
            }

            path2 += dir_name + "\\";

            if(!Directory.Exists(path + path2))
            {
                Directory.CreateDirectory(path + path2);
            }

            if(File.Exists(path +path2 + data.name + "_fun.cs"))
            {
                return;
            }


            StreamWriter sw = new StreamWriter(path + path2 + data.name + "_fun.cs", false, Encoding.Unicode);
                //使用命名空间
                sw.WriteLine("using GameDb.Logic;");
                sw.WriteLine("using GameDb.Util;");
                sw.WriteLine("using GameLib.Database;");
                sw.WriteLine("using messages;");
                sw.WriteLine("using System;");
                sw.WriteLine("using messages.Protocols;");

                sw.WriteLine("");

                //定义类
                sw.WriteLine("namespace messages");
                sw.WriteLine("{");
                sw.WriteLine("  public partial class MsgHandle");
                sw.WriteLine("  {");

                sw.WriteLine("      static public void handle_" + data.name + "(MsgBase msg)");
                sw.WriteLine("      {");
                sw.WriteLine("      ");
                sw.WriteLine("      }");

                sw.WriteLine("  }");
                sw.WriteLine("}");
                sw.Close();
            


        }

        private static void CreateprotoMapFile(List<DirectoryData> protos)
        {
            string path = GetSetverPath();
            StreamWriter sw = new StreamWriter(path + "\\message\\MsgProcessor.cs", false, Encoding.Unicode);
            //使用命名空间
            sw.WriteLine("using messages;");
            sw.WriteLine("using messages.Protocols;");
            sw.WriteLine("using System.Collections.Generic;");
            sw.WriteLine("");

            //定义类
            sw.WriteLine("namespace messages");
            sw.WriteLine("{");
       //     sw.WriteLine("  public delegate void MsgHandleFun(MsgBase msg);");
            sw.WriteLine("");
            sw.WriteLine("  public partial class MsgHandle");
            sw.WriteLine("  {");

            //获取函数
            sw.WriteLine("       public void init()");
            sw.WriteLine("      {");

            foreach(DirectoryData dir in protos)
            {
                foreach(msgdata data in dir.protos)
                {

                    if(data.name.IndexOf("_req") != -1)
                        sw.WriteLine("           pros.Add(MsgCodeId."+data.name+",new "+data.name+"());");
                }
            }

            foreach(DirectoryData dir in protos)
            {
                foreach(msgdata data in dir.protos)
                {

                    if(data.name.IndexOf("_req") != -1)
                        sw.WriteLine("           profuns.Add(MsgCodeId." + data.name + ",handle_" + data.name+");");
                }
            }

            sw.WriteLine("      }");
            sw.WriteLine("  }");
            sw.WriteLine("}");
            sw.Close();

        }

        private static string GetSetverPath()
        {
            if(type == 1)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                return config.AppSettings.Settings["serverpath"].Value;
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                return config.AppSettings.Settings["servertestpath"].Value;
            }
           
        }

        public static string HanZiZhuanPinYin(string name)
        {
            WebClient web = new WebClient();

            string showapi_appid = "35119";
            string showapi_sign = "996ddf1386994f73b05292db6099f91e";
            string content = name;

            string str = String.Format("http://route.showapi.com/99-38?showapi_appid={0}&content={1}&showapi_sign={2}", showapi_appid, content, showapi_sign);

            byte[] bt = web.DownloadData(str);

            str = System.Text.Encoding.UTF8.GetString(bt);

            Hashtable ht = JSON.Decode<Hashtable>(str);

            string temp = ht["showapi_res_body"].ToString();

            ht = JSON.Decode<Hashtable>(temp);

            string py = ht["data"].ToString();

            py = py.Replace(' ', '_');

            return py;
        }

    }



}
