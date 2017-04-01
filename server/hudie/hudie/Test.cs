using GameLib.Util;
using messages.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace hudie
{
    class Test
    {
        public static void OnTest()
        {
            while(true)
            {
                string str = Console.ReadLine();

                switch(str)
                {
                    case "reg":
                        {
                            register_req req = new register_req();
                            req.nickname = "liuhuitao";
                            req.tel = "12345678";
                            req.pass = "123456";
                            sendMsg(req);
                            break;
                        }

                    case "req_benefit_head":
                        {
                            benefit_head_req req = new benefit_head_req();
                            string temp = sendMsg(req);

                            break;
                        }
                }
            }
        }
        private static string sendMsg(MsgBase msg)
        {

             string mm = JSON.Encode(msg);
            
          //  mm = System.Web.HttpUtility.UrlEncode(mm);

             string re = HttpPost("http://" + "192.168.1.16:10012", mm);
            Console.WriteLine("返回__{0}", re);

            return re;
        }

        private static string HttpPost(string Url, string postDataStr)
        {
            try
            {
                WebClient web = new WebClient();
                byte[] data = Encoding.Default.GetBytes(postDataStr);
                byte[] bt = web.UploadData(Url, "post", data);

                string str = System.Text.Encoding.UTF8.GetString(bt);
                return str;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
