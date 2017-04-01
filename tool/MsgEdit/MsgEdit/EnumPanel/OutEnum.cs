using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgEdit
{
    public class OutEnum
    {
        public static string path="";
        public static void OutEnumFile(List<EnumList> list)
        {
            path = GetSetverPath();


            if(Directory.Exists(path+"\\enum\\")==false)
            {
                Directory.CreateDirectory(path + "\\enum\\");
            }

            foreach(var item in list)
            {
                CreateEnumFile(item);
            }


        }

        private static void CreateEnumFile(EnumList info)
        {
            StreamWriter sw = new StreamWriter(path + "\\enum\\" + info.name + ".cs", false, Encoding.Unicode);

            //使用命名空间
         //   sw.WriteLine("using messages;");
         //   sw.WriteLine("");

            //定义类
            sw.WriteLine("namespace Enum");
            sw.WriteLine("{");
            sw.WriteLine("  public enum " + info.name);
            sw.WriteLine("  {");

            foreach(var item in info.info)
            {
                sw.WriteLine("      "+item.enumstr+" = "+item.index+", //"+item.explain);
            }

            sw.WriteLine("  }");
            sw.WriteLine("}");

            sw.Close();

         
        }

        private static string GetSetverPath()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            return config.AppSettings.Settings["serverpath"].Value;
        }
    }
}
