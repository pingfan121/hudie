using Enum;
using GameLib.Util;
using hudie.error;
using messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hudie.net
{
    class NetHttp
    {
        private static LogImplement log = LogFactory.getLogger(typeof(GameApp));

        private static HttpListener listener;         //http协议

        private static int port=10012;

      //  private static string key = "123456";

       

        //开始启动
        public static void Start()
        {
            try
            {
                listener = new HttpListener();
                listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;//指定身份验证 Anonymous匿名访问
                IPAddress[] ips = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());  //绑定本机所有IP地址

                for(int i = 0; i < ips.Length; i++)                                              //设定域名
                {

                    if(ips[i].AddressFamily == AddressFamily.InterNetwork) //IPv4地址 
                    {

                        listener.Prefixes.Add("http://" + ips[i].ToString() + ":" + port.ToString() + "/");
                    }
                }

                listener.Start();
                listener.BeginGetContext(RequestHandler, null);

                log.info("链接成功...\n等待数据中...");
            }
            catch(Exception ex)
            {
                log.error("链接出错...",ex);
            }
        }

        //链接响应
        private static void RequestHandler(IAsyncResult result)
        {
            log.error("收到连接...");
            try
            {
                HttpListenerContext context = listener.EndGetContext(result);
                HttpListenerRequest request = context.Request;

                StreamReader sr = new StreamReader(request.InputStream);
                
                string webdata = sr.ReadToEnd();

                if(webdata.Length > 2)
                {
                    AnalysisData(context,webdata);
                }
                else
                {
                      log.error("数据长度错误");

                      sendErrorMsg(context, EnumMsgState.error);
                }

            }
            catch(Exception ex)
            {
                log.error(ex.Message);
                log.error(ex.StackTrace);
              
            }

            try
            {
                listener.BeginGetContext(RequestHandler, null);
            }
            catch(Exception ex)
            {
                log.error(ex.Message);
                log.error(ex.StackTrace);

                if(ex is HttpListenerException)
                {
                    log.error("错误代码:" + (ex as HttpListenerException).ErrorCode);
                }

                listener.Close();
                Thread.Sleep(10);
                Start();
            }

        }


        public static void AnalysisData(HttpListenerContext context, string data)
        {

            try
            {
                Hashtable ht = JSON.Decode<Hashtable>(data);

                if(ht.ContainsKey("CodeId"))
                {
                    int msgid = int.Parse(ht["CodeId"].ToString());

                    log.error("收到了协议号为 " + msgid + " 的消息");

                    MsgHandle.getInstance().analysis(context, msgid, data);
                }
            }
            catch(Exception ex)
            {
                log.error(data);
                log.error(ex);

                sendErrorMsg(context,EnumMsgState.error);
            }
        }
//         public static string Sign(string str)
//         {
//             return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
//         }


        static BackMsg backmsg = new BackMsg();
        public static void sendErrorMsg(HttpListenerContext context,EnumMsgState err)
        {
            HttpListenerResponse reponse = context.Response;
            StreamWriter writer = new StreamWriter(reponse.OutputStream);


            backmsg.state = (int)err;
            backmsg.msgid = 0;
            backmsg.msg = new object();

            writer.Write(JSON.Encode(backmsg));

            writer.Close();
            reponse.Close();
        }
    }
}
