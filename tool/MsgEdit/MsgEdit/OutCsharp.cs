using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgEdit
{
    class OutCsharp
    {

        //导出文件
        public static void OutFile(Dictionary<string, Dictionary<string, msgdata>> protos)
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


        private static void CreateCodeID(Dictionary<string, Dictionary<string, msgdata>> protos)
        {
            List<string> ids = new List<string>();

            int index = 1;

            foreach(string key in protos.Keys)
            {
                foreach(string key2 in protos[key].Keys)
                {
                    msgdata data=protos[key][key2];

                    ids.Add(data.name + " = " + index + ",");
                    index++;
                }
            }

            string path = GetSetverPath();
            //写入文件
            if(!Directory.Exists(path+"\\message\\"))
            {
                Directory.CreateDirectory(path + "\\message\\");
            }

            StreamWriter sw = new StreamWriter(path + "\\message\\MsgCodeId.cs", false);

         //   sw.WriteLine("using GameServer.Define.EnumNormal;");
         //   sw.WriteLine("");
            sw.WriteLine("namespace messages");
            sw.WriteLine("{");
            sw.WriteLine("\tpublic enum MsgCodeId");
            sw.WriteLine("\t{");

            foreach(string id in ids)
            {
                  sw.WriteLine("\t\t"+id);
            }
            sw.WriteLine("\t}");
            sw.WriteLine("}");

            sw.Close();
        }

        private static void CreateProtoFiles(Dictionary<string, Dictionary<string, msgdata>> protos)
        {
            foreach(string key in protos.Keys)
            {
                foreach(string key2 in protos[key].Keys)
                {
                    msgdata data = protos[key][key2];
                    CreateProtoFiles2(data);

                }
            }
        }

        private static void CreateProtoFiles2(msgdata data)
        {
            //分割属性

            string str = data.content.Replace("\r\n","|");
            string[] attrstxt = str.Split('|');


            //属性
            List<string> attrs = new List<string>();
            List<string> states = new List<string>();
            List<string> sets = new List<string>();

            List<string> encode = new List<string>();
            List<string> decode = new List<string>();

            bool flag1 = false;
            bool flag2 = false;

            foreach(string attr in attrstxt)
            {
                string[] fenge=attr.Split(';');

                string[] temp2 = fenge[0].Split(' ');

                //状态
                states.Add("private bool " + temp2[2] + "_changed;");

                
                if(temp2[0] =="required")  //必须的
                {
                    //属性
                    attrs.Add("private " + temp2[1] + " _" + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));

                    

                    //转码
                    if(temp2[1] == "int")
                    {
                        encode.Add("by.WriteInt(" + temp2[2] + ");");
                    }
                    else if(temp2[1] == "string")
                    {
                        encode.Add("by.WriteUTF(" + temp2[2] + ");");
                    }
                    else if(temp2[1].IndexOf("info_") != -1)  //结构
                    {

                    }

                    //还原
                    if(temp2[1] == "int")
                    {
                        decode.Add(temp2[2] + " = by.ReadInt();");
                    }
                    else if(temp2[1] == "string")
                    {
                        decode.Add(temp2[2] + " = by.ReadUTF();");
                    }
                    else if(temp2[1].IndexOf("info_") != -1)  //结构
                    {

                    }

                    //set get
                    if(temp2[1] == "int")
                    {
                        sets.Add("public int " + temp2[2]);
                        sets.Add("{");
                        sets.Add("  get { return _"+temp2[2]+"; }");
                        sets.Add("  set { _" + temp2[2] + " = value ; " + temp2[2] + "_changed = true; }");
                        sets.Add("}");
                    }
                    else if(temp2[1] == "string")
                    {
                        sets.Add("public string " + temp2[2]);
                        sets.Add("{");
                        sets.Add("  get { return _" + temp2[2] + "; }");
                        sets.Add("  set { _" + temp2[2] + " = value ; " + temp2[2] + "_changed = true; }");
                        sets.Add("}");
                    }
                    else if(temp2[1].IndexOf("info_") != -1)  //结构
                    {

                    }

                }
                else if(temp2[0] == "array")  //重复的
                {
                    //属性
                    attrs.Add("public " + temp2[1] + "[] _" + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));

                    if(flag1 == false)
                    {
                        encode.Add("int i = 0;");
                        flag1 = true;
                    }

                    //转码
                    if(temp2[1] == "int")
                    {

                        encode.Add("if(" + temp2[2] + "_changed == true)");
                        encode.Add("{");
                        encode.Add("    by.WriteByte(1);");
                        encode.Add("    if (" + temp2[2] + " != null)");
                        encode.Add("    {");
                        encode.Add("        by.WriteShort((short)" + temp2[2] + ".Length);");
                        encode.Add("        for (i = 0; i < " + temp2[2] + ".Length; i++)");
                        encode.Add("        {");
                        encode.Add("            by.WriteInt(" + temp2[2] + "[i]);");
                        encode.Add("        }");
                        encode.Add("    }");
                        encode.Add("    else");
                        encode.Add("    {");
                        encode.Add("         by.WriteShort(0);");
                        encode.Add("    }");
                        encode.Add("}");
                        encode.Add("else");
                        encode.Add("{");
                        encode.Add("     by.WriteByte(0);");
                        encode.Add("}");
                    }
                    else if(temp2[1] == "string")
                    {
                        encode.Add("if(" + temp2[2] + "_changed == true)");
                        encode.Add("{");
                        encode.Add("    by.WriteByte(1);");
                        encode.Add("    if (" + temp2[2] + " != null)");
                        encode.Add("    {");
                        encode.Add("        by.WriteShort((short)" + temp2[2] + ".Length);");
                        encode.Add("        for (i = 0; i < " + temp2[2] + ".Length; i++)");
                        encode.Add("        {");
                        encode.Add("            by.WriteUTF(" + temp2[2] + "[i]);");
                        encode.Add("        }");
                        encode.Add("    }");
                        encode.Add("    else");
                        encode.Add("    {");
                        encode.Add("         by.WriteShort(0);");
                        encode.Add("    }");
                        encode.Add("}");
                        encode.Add("else");
                        encode.Add("{");
                        encode.Add("     by.WriteByte(0);");
                        encode.Add("}");
                    }
                    else if(temp2[1].IndexOf("info_") != -1)  //结构
                    {

                    }

                    if(flag2 == false)
                    {
                        decode.Add("int i = 0;");
                        flag2 = true;
                    }

                    //还原
                    if(temp2[1] == "int")
                    {
                        decode.Add(" if (by.ReadByte() > 0)");
                        decode.Add("{");
                        decode.Add("    short _count = by.ReadShort();");
                        decode.Add("    " + temp2[2] + " = new int[_count];");
                        decode.Add("    for (i = 0; i < _count; i++)");
                        decode.Add("    {");
                        decode.Add("         " + temp2[2] + "[i] = by.ReadInt();");
                        decode.Add("    }");
                        decode.Add("}");

                    }
                    else if(temp2[1] == "string")
                    {
                        decode.Add(" if (by.ReadByte() > 0)");
                        decode.Add("{");
                        decode.Add("    short _count = by.ReadShort();");
                        decode.Add("    " + temp2[2] + " = new string[_count];");
                        decode.Add("    for (i = 0; i < _count; i++)");
                        decode.Add("    {");
                        decode.Add("         " + temp2[2] + "[i] = by.ReadUTF();");
                        decode.Add("    }");
                        decode.Add("}");
                    }
                    else if(temp2[1].IndexOf("info_") != -1)  //结构
                    {

                    }


                    if(temp2[1] == "int")
                    {
                        sets.Add("public int[] " + temp2[2]);
                        sets.Add("{");
                        sets.Add("  get { return _" + temp2[2] + "; }");
                        sets.Add("  set { _" + temp2[2] + " = value ; " + temp2[2] + "_changed = true; }");
                        sets.Add("}");
                    }
                    else if(temp2[1] == "string")
                    {
                        sets.Add("public string[] " + temp2[2]);
                        sets.Add("{");
                        sets.Add("  get { return _" + temp2[2] + "; }");
                        sets.Add("  set { _" + temp2[2] + " = value ; "+temp2[2]+"_changed = true; }");
                        sets.Add("}");
                    }
                    else if(temp2[1].IndexOf("info_") != -1)  //结构
                    {

                    }
                }
            }

            string path = GetSetverPath();

            if(!Directory.Exists(path+"\\message\\Protocols\\"))
            {
                Directory.CreateDirectory(path + "\\message\\Protocols\\");
            }

            StreamWriter sw = new StreamWriter(path + "\\message\\Protocols\\" + data.name + ".cs", false);

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
            sw.WriteLine("          CodeId = MsgCodeId." + data.name+";");
            sw.WriteLine("      }");

            //写入属性

            foreach(string ss in attrs)
            {
                sw.WriteLine("      " + ss);
            }
            sw.WriteLine("");

            //写入状态
            foreach(string ss in states)
            {
                sw.WriteLine("      " + ss);
            }
            sw.WriteLine("");

            //写入encode
            sw.WriteLine("      public override void encode(ByteArray by)");
            sw.WriteLine("      {");
            foreach(string ss in encode)
            {
                sw.WriteLine("          " + ss);
            }
            sw.WriteLine("      }");
            sw.WriteLine("");

            //写入decode
            sw.WriteLine("      public override void decode(ByteArray by)");
            sw.WriteLine("      {");
            foreach(string ss in decode)
            {
                sw.WriteLine("          " + ss);
            }
            sw.WriteLine("      }");
            sw.WriteLine("");


            //set
            foreach(string ss in sets)
            {
                sw.WriteLine("      " + ss);
            }
            sw.WriteLine("");


            sw.WriteLine("\t}");
            sw.WriteLine("}");

            sw.Close();
        }

        private static void CreateProtoReq(Dictionary<string, Dictionary<string, msgdata>> protos)
        {
            foreach(string key in protos.Keys)
            {
                foreach(string key2 in protos[key].Keys)
                {
                    msgdata data = protos[key][key2];
                    CreateProtoReq2(data);
                }
            }
        }
        private static void CreateProtoReq2(msgdata data)
        {
            string path = GetSetverPath();

            if(!Directory.Exists(path + "\\message\\ProtocolsReq\\"))
            {
                Directory.CreateDirectory(path + "\\message\\ProtocolsReq\\");
            }

            if(!File.Exists(path + "\\message\\ProtocolsReq\\" + data.name + "_req.cs"))
            {
                StreamWriter sw = new StreamWriter(path + "\\message\\ProtocolsReq\\" + data.name + "_req.cs", false);
                //使用命名空间
                sw.WriteLine("using messages;");
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

            
        }

        private static void CreateprotoMapFile(Dictionary<string, Dictionary<string, msgdata>> protos)
        {
            string path = GetSetverPath();
            StreamWriter sw = new StreamWriter(path + "\\message\\MsgMap.cs", false);
            //使用命名空间
            sw.WriteLine("using messages;");
            sw.WriteLine("using messages.Protocols;");
            sw.WriteLine("");

            //定义类
            sw.WriteLine("namespace messages");
            sw.WriteLine("{");

            sw.WriteLine("public delegate void MsgHandleFun(MsgBase msg);");
            sw.WriteLine("");
            sw.WriteLine("  public partial class MsgHandle");
            sw.WriteLine("  {");

            sw.WriteLine("      public void init()");
            sw.WriteLine("      {");

            foreach(string key in protos.Keys)
            {
                foreach(string key2 in protos[key].Keys)
                {
                    msgdata data = protos[key][key2];

                    if(data.name.IndexOf("_req")!=-1)
                    sw.WriteLine("          addPro(MsgCodeId."+data.name+", handle_"+data.name+", () => { return new "+data.name+"(); });");
                
                }
            }
            
            sw.WriteLine("      }");
            sw.WriteLine("  }");
            sw.WriteLine("}");
            sw.Close();

            //addPro(MsgCodeId.login_req, handle_login_req, () => { return new login_req(); });
        }

        private static string GetSetverPath()
        {
             Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

             return config.AppSettings.Settings["serverpath"].Value;
        }
    }

   

}
