using GameLib.Util;
using messages.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace testserver
{
    class Program
    {
        private static string url="http://192.168.1.16:10012";
        static void Main(string[] args)
        {

            while(true)
            {
                try
                {
                    string str = Console.ReadLine();

                    string[] sss = str.Split(' ');

                    switch(sss[0])
                    {
                        case "注册":
                            {
                                register_req req = new register_req();
                                req.tel = "18789061261";
                                req.nickname = "平凡";
                                req.pass = "123456";
                                sendMsg(req);
                                break;
                            }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
               
            }

        }

        private static string sendMsg(MsgBase mb)
        {
            WebClient web = new WebClient();
            web.Headers.Add("token", "111111");

            byte[] data = Encoding.UTF8.GetBytes(JSON.Encode(mb));
            byte[] bt = web.UploadData(url, "post", data);

            string str = System.Text.Encoding.UTF8.GetString(bt);
            Console.WriteLine(str);
            return str;
        }
    }
}
