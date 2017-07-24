using Enum;
using GameLib.Util;
using messages;
using System;
using System.Collections;
using System.Collections.Concurrent;
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
    public class HttpInfo
    {
        public string modpath;
        public string funpath;
        public HttpListenerContext context;
        public Dictionary<string, string> req_params = new Dictionary<string, string>();
    }
    class NetHttp
    {
        private static LogImplement log = LogFactory.getLogger(typeof(GameApp));

        private static HttpListener listener;         //http协议

        private static int port=10012;

      //  private static string key = "123456";


        public static ConcurrentQueue<HttpInfo> http_data = new ConcurrentQueue<HttpInfo>();
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

                string param = request.RawUrl;

                HttpInfo info= new HttpInfo();

                info.context = context;

                EnumMsgState msgerr= analysisParam(param, info);

                if(msgerr != EnumMsgState.ok)
                {
                    sendErrorMsg(info.context, msgerr);
                }
                else
                {
                    http_data.Enqueue(info);
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



        static BackMsg backmsg = new BackMsg();
        public static void sendErrorMsg(HttpListenerContext context,EnumMsgState err)
        {
            HttpListenerResponse reponse = context.Response;
            StreamWriter writer = new StreamWriter(reponse.OutputStream, Encoding.UTF8);

            backmsg.error = (int)err;
            backmsg.msg = new object();

            writer.Write(JSON.Encode(backmsg));

            writer.Close();
            reponse.Close();
        }


        public static Dictionary<string, int> mod_flag = new Dictionary<string, int>();  //模块对应标志

        public static Dictionary<string, int> fun_flag = new Dictionary<string, int>();  //模块对应标志

        public static EnumMsgState analysisParam(string urlparam,HttpInfo info)
        {
            if(urlparam.Length < 2)
            {
                return EnumMsgState.param_err;
            }

            if(urlparam.Substring(0, 1) == "/")
            {
                urlparam = urlparam.Substring(1);
            }

            int index=urlparam.IndexOf('?');

            string fun_path="";
            string param="";

            if(index==-1)
            {
                fun_path = urlparam;
            }
            else
            {
                fun_path = urlparam.Substring(0, index);
                param=urlparam.Substring(index+1);
            }

            //检测是否有处理模块
            fun_path = "hudie." + fun_path.Replace('/', '.');

            index=fun_path.LastIndexOf('.');
            string mod_path = fun_path.Substring(0, index);

            if(mod_flag.ContainsKey(mod_path) == false)
            {
                //检测有没有这个模块
                Type t = Type.GetType(mod_path);

                if(t != null)
                {
                    mod_flag.Add(mod_path, 1);
                }
                else
                {
                    mod_flag.Add(mod_path, 0);
                }
            }

            if(mod_flag[mod_path] == 0)
            {
                return EnumMsgState.module_err;
            }

          

            //验证参数
            if(param != "")
            {
                string[] temp = param.Split('&');

                foreach(var str in temp)
                {
                    string[] temp2 = str.Split('=');

                    if(temp2.Length != 2)
                    {
                        return EnumMsgState.param_err;
                    }

                    info.req_params.Add(temp2[0], temp2[1]);
                }
            }
           

            info.funpath = fun_path;
            info.modpath = mod_path;
            
            return EnumMsgState.ok;
        }
    }
}
