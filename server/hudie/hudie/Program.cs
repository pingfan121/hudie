using GameLib.Util;
using hudie.net;
using messages;
using messages.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hudie
{
    class Program
    {
        static void Main(string[] args)
        {

//             Thread testthread = new Thread(Test.OnTest);
//             testthread.IsBackground = true;
//             testthread.Start();
            
            try
            {
               
                //处理消息线程数量
                int proc_count=4;

                //初始化消息序列
               MsgHandle.getInstance().init();
               NetHttp.Start();

               GameApp[] apps = new GameApp[proc_count];

               for (int i = 0; i < proc_count;i++)
               {
                   apps[i] = new GameApp();

                   apps[i].init();
               }

               Console.WriteLine("服务器开始运行了....");

                while(true)
                {
                    Thread.Sleep(1000);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           

        }

    }
}
