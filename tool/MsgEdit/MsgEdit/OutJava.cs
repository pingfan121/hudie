//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MsgEdit
//{
//    class OutJava
//    {
//        public static int type = 1;

//        //导出文件
//        public static void OutFile(List<DirectoryData> protos)
//        {
//            //先生协议id文件
//            CreateCodeID(protos);

//            //导出协议文件
//            CreateProtoFiles(protos);

//            //导出协议处理文件
//            CreateProtoReq(protos);

//            //导出协议映射处理函数文件
//            CreateprotoMapFile(protos);

//        }


//        private static void CreateCodeID(List<DirectoryData> protos)
//        {
//            List<string> ids = new List<string>();

//            int index = 1;

//            foreach(DirectoryData dir in protos)
//            {
//                foreach(msgdata data in dir.protos)
//                {

//                    ids.Add("public static int " + data.name + " = " + index + ";");
//                    index++;
//                }
//            }

//            string path = GetJavaPath();
//            //写入文件
//            if(!Directory.Exists(path + "\\message\\"))
//            {
//                Directory.CreateDirectory(path + "\\message\\");
//            }

//            StreamWriter sw = new StreamWriter(path + "\\message\\MsgCodeId.java", false);

//            //定义类
//            String pack = path + "\\message";
//            index = pack.IndexOf("java\\");
//            pack = pack.Substring(index + 5);
//            pack = pack.Replace("\\", ".");
//            sw.WriteLine("package " + pack + ";");

//            sw.WriteLine("");
//            sw.WriteLine("");
//            sw.WriteLine("public class MsgCodeId");
//            sw.WriteLine("{");

//            foreach(string id in ids)
//            {
//                sw.WriteLine("\t\t" + id);
//            }
//            sw.WriteLine("}");

//            sw.Close();
//        }

//        private static void CreateProtoFiles(List<DirectoryData> protos)
//        {
//            foreach(DirectoryData dir in protos)
//            {
//                foreach(msgdata data in dir.protos)
//                {
//                    CreateProtoFiles2(data);

//                }
//            }
//        }

//        private static void CreateProtoFiles2(msgdata data)
//        {
//            //分割属性

//            string str = data.content.Replace("\r\n", "|");
//            string[] attrstxt = str.Split('|');


//            //属性
//            List<string> attrs = new List<string>();

//            //             List<string> encode = new List<string>();
//            // 
//            //             List<string> decode = new List<string>();
//            //             


//            foreach(string attr in attrstxt)
//            {
//                string[] fenge = attr.Split(';');

//                string[] temp2 = fenge[0].Split(' ');


//                if(temp2[0] == "required")  //必须的
//                {
//                    //解码
//                    if(temp2[1] == "int")
//                    {
//                        //属性
//                        attrs.Add("public int " + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));

//                        //                         //编码
//                        //                         encode.Add("json.put(\"" + temp2[2] + "\"," + temp2[2] + ");");
//                        // 
//                        //                         //解码
//                        //                         decode.Add(temp2[2] + " = json.getInt(\"" + temp2[2] + "\");");

//                    }
//                    else if(temp2[1] == "string")
//                    {
//                        //属性
//                        attrs.Add("public String " + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));

//                        //                         //编码
//                        //                         encode.Add("json.put(\"" + temp2[2] + "\"," + temp2[2] + ");");
//                        // 
//                        //                         //解码
//                        //                         decode.Add(temp2[2] + " = json.getString(\"" + temp2[2] + "\");");
//                    }
//                    else if(temp2[1].IndexOf("info_") != -1)
//                    {
//                        //属性
//                        attrs.Add("public " + temp2[1] + " " + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));

//                        //                         //编码
//                        //                         encode.Add("json.put(\"" + temp2[2] + "\"," + temp2[2] +".toString()"+ ");");
//                        // 
//                        //                         //解码
//                        //                         decode.Add(temp2[2] + " = new " + temp2[1]+"();");
//                        //                         decode.Add(temp2[2] + ".decode(new JSONObject(json.getString(\""+temp2[2]+"\")));");
//                    }
//                }
//                else if(temp2[0] == "array")  //重复的
//                {
//                    //解码
//                    if(temp2[1] == "int")
//                    {
//                        //属性
//                        attrs.Add("public int[] " + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));

//                        //                         //编码
//                        //                         encode.Add(" SetArrayInt(" + temp2[2] + ",\"" + temp2[2] + "\",json);");
//                        // 
//                        //                         //解码
//                        //                         decode.Add(temp2[2] + " = getArrayInt(\"" + temp2[2] + "\",json);");
//                    }
//                    else if(temp2[1] == "string")
//                    {
//                        //属性
//                        attrs.Add("public String[] " + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));

//                        //                         //编码
//                        //                         encode.Add(" SetArrayStr(" + temp2[2] + ",\"" + temp2[2] + "\",json);");
//                        // 
//                        //                         //解码
//                        //                         decode.Add(temp2[2] + " = getArrayStr(\"" + temp2[2] + "\",json);");
//                    }
//                    else if(temp2[1].IndexOf("info_") != -1)
//                    {
//                        //属性
//                        attrs.Add("public " + temp2[1] + "[] " + temp2[2] + ";    //" + (fenge.Length == 2 ? fenge[1] : ""));

//                        //                          //编码
//                        //                         encode.Add("jsonarry = new JSONArray();");
//                        //                         encode.Add(" for(int i = 0; i < " + temp2[2] + ".length; i++)");
//                        //                         encode.Add("{");
//                        //                         encode.Add("    jsonarry.put(" + temp2[2] + "[i].toString());");
//                        //                         encode.Add("}");
//                        //                         encode.Add("json.put(\"" + temp2[2] + "\", jsonarry);");
//                        // 
//                        //                         //解码
//                        //                         decode.Add("JSONArray array = json.getJSONArray(\"" + temp2[2] + "\");");
//                        // 
//                        //                         decode.Add(temp2[2] + " = new " + temp2[1] + "[ array.length()];");
//                        //                         decode.Add(" for(int i = 0; i < array.length(); i++)");
//                        //                         decode.Add(" {");
//                        //                         decode.Add("     " + temp2[2] + "[i] = new " + temp2[1]+"();");
//                        //                         decode.Add("     " + temp2[2] + "[i].decode(new JSONObject(array.getString(i)));");
//                        //                         decode.Add(" }");
//                    }
//                }
//            }

//            string path = GetJavaPath();

//            if(!Directory.Exists(path + "\\message\\Protocols\\"))
//            {
//                Directory.CreateDirectory(path + "\\message\\Protocols\\");
//            }

//            StreamWriter sw = new StreamWriter(path + "\\message\\Protocols\\" + data.name + ".java", false);

//            //定义类
//            String pack = path + "\\message";
//            int index = pack.IndexOf("java\\");
//            pack = pack.Substring(index + 5);
//            pack = pack.Replace("\\", ".");
//            sw.WriteLine("package " + pack + ".Protocols;");

//            //导入包
//            sw.WriteLine("import android.util.Log;");
//            sw.WriteLine("import org.json.JSONArray;");
//            sw.WriteLine("import org.json.JSONObject;");

//            sw.WriteLine("import " + pack + ".MsgBase;");
//            sw.WriteLine("import " + pack + ".MsgCodeId;");


//            //定义类
//            sw.WriteLine("  public class " + data.name + " extends MsgBase");
//            sw.WriteLine("  {");

//            //构造函数
//            sw.WriteLine("      public " + data.name + "()");
//            sw.WriteLine("      {");
//            sw.WriteLine("          CodeId = MsgCodeId." + data.name + ";");
//            sw.WriteLine("      }");

//            //写入属性

//            foreach(string ss in attrs)
//            {
//                sw.WriteLine("      " + ss);
//            }

//            sw.WriteLine("");

//            //             //编码函数
//            //             sw.WriteLine("\t\t@Override");
//            //             sw.WriteLine("\t\tpublic void encode() {");
//            //             sw.WriteLine("\t\tsuper.encode();");
//            //             sw.WriteLine("\t\ttry");
//            //             sw.WriteLine("\t\t{");
//            // 
//            //             foreach(string ss in encode)
//            //             {
//            //                 sw.WriteLine("\t\t\t\t" + ss);
//            //             }
//            // 
//            //             sw.WriteLine("\t\t}");
//            //             sw.WriteLine("\t\tcatch (Exception ex)");
//            //             sw.WriteLine("\t\t{");
//            //             sw.WriteLine("");
//            //             sw.WriteLine("\t\t}");
//            //             sw.WriteLine("\t\t}");
//            // 
//            //             //解码函数
//            //             sw.WriteLine("\t\t@Override");
//            //             sw.WriteLine("\t\tpublic void decode(JSONObject json) {");
//            //             sw.WriteLine("\t\tsuper.decode(json);");
//            //             sw.WriteLine("\t\ttry");
//            //             sw.WriteLine("\t\t{");
//            // 
//            //             foreach(string ss in decode)
//            //             {
//            //                 sw.WriteLine("\t\t\t\t" + ss);
//            //             }
//            // 
//            //             sw.WriteLine("\t\t}");
//            //             sw.WriteLine("\t\tcatch (Exception ex)");
//            //             sw.WriteLine("\t\t{");
//            //             sw.WriteLine("");
//            //             sw.WriteLine("\t\t}");
//            //             sw.WriteLine("\t\t}");

//            sw.WriteLine("}");

//            sw.Close();
//        }

//        private static void CreateProtoReq(List<DirectoryData> protos)
//        {
//            foreach(DirectoryData dir in protos)
//            {
//                foreach(msgdata data in dir.protos)
//                {
//                    if(data.name.IndexOf("_req") == -1)
//                    {
//                        CreateProtoReq2(data);
//                    }

//                }
//            }
//        }
//        private static void CreateProtoReq2(msgdata data)
//        {
//            string path = GetJavaPath();

//            if(!Directory.Exists(path + "\\message\\ProtocolsFun\\"))
//            {
//                Directory.CreateDirectory(path + "\\message\\ProtocolsFun\\");
//            }

//            if(File.Exists(path + "\\message\\ProtocolsFun\\" + data.name + "_fun.java"))
//            {
//                return;
//            }

//            StreamWriter sw = new StreamWriter(path + "\\message\\ProtocolsFun\\" + data.name + "_fun.java", false);


//            //定义类
//            String pack = path + "\\message";
//            int index = pack.IndexOf("java\\");
//            pack = pack.Substring(index + 5);
//            pack = pack.Replace("\\", ".");
//            sw.WriteLine("package " + pack + ".ProtocolsFun;");

//            sw.WriteLine("import " + pack + ".MsgBase;");
//            sw.WriteLine("import " + pack + ".MsgCodeId;");
//            sw.WriteLine("import " + pack + ".IMsgCallback;");
//            sw.WriteLine("import " + pack + ".Protocols." + data.name + ";");
//            sw.WriteLine("");

//            sw.WriteLine("public class " + data.name + "_fun implements IMsgCallback");
//            sw.WriteLine("{");


//            sw.WriteLine("    ");
//            sw.WriteLine("      public void MsgCallback" + "(MsgBase msg)");
//            sw.WriteLine("      {");
//            sw.WriteLine("      ");
//            sw.WriteLine("      }");

//            sw.WriteLine("}");
//            sw.Close();
//        }

//        private static void CreateprotoMapFile(List<DirectoryData> protos)
//        {
//            string path = GetJavaPath();
//            StreamWriter sw = new StreamWriter(path + "\\message\\ProtocolsFun\\MsgProcessor.java", false);

//            //定义类
//            String pack = path + "\\message";
//            int index = pack.IndexOf("java\\");
//            pack = pack.Substring(index + 5);
//            pack = pack.Replace("\\", ".");
//            sw.WriteLine("package " + pack + ".ProtocolsFun;");

//            sw.WriteLine("import " + pack + ".MsgBase;");
//            sw.WriteLine("import " + pack + ".MsgCodeId;");
//            sw.WriteLine("import " + pack + ".MsgMap;");
//            sw.WriteLine("import " + pack + ".Protocols.*;");


//            //定义类
//            sw.WriteLine("");
//            sw.WriteLine("public class MsgProcessor");
//            sw.WriteLine("{");

//            //初始化函数
//            sw.WriteLine("\t\tpublic static void init()");
//            sw.WriteLine("\t\t{");

//            foreach(DirectoryData dir in protos)
//            {
//                foreach(msgdata data in dir.protos)
//                {
//                    if(data.name.IndexOf("_req") == -1)
//                        sw.WriteLine("\t\t\t\t MsgMap.reslutmap.put(MsgCodeId." + data.name + ",new " + data.name + "_fun());");
//                }
//            }

//            sw.WriteLine("");
//            sw.WriteLine("");
//            sw.WriteLine("");
//            sw.WriteLine("");

//            foreach(DirectoryData dir in protos)
//            {
//                foreach(msgdata data in dir.protos)
//                {
//                    if(data.name.IndexOf("_req") == -1)
//                        sw.WriteLine("\t\t\t\t MsgMap.msgmap.put(MsgCodeId." + data.name + ", " + data.name + ".class);");
//                }
//            }

//            sw.WriteLine("\t\t}");
//            sw.WriteLine("}");
//            sw.Close();

//        }

//        private static string GetJavaPath()
//        {
//            if(type == 1)
//            {
//                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

//                return config.AppSettings.Settings["clientpath"].Value;
//            }
//            else
//            {
//                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

//                return config.AppSettings.Settings["clienttestpath"].Value;
//            }

//        }
//    }



//}
