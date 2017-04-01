using GameDb.Util;
using GameLib.Database;
using GameLib.Util;
using hudie.error;
using hudie.net;
using hudie.sql;
using messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hudie
{
    public class GameApp
    {
        private IDbConnect connect;

        public BackMsg backmsg;

        public void init()
        {
            backmsg = new BackMsg();

            connect = DBManager.getBenefitDB();

            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }
       

        public void Run()
        {

            while (true)
            {
                MsgBase msg = MsgHandle.getInstance().getMessage();

                if (msg != null)
                {
                   
                    MsgCodeId codeId = msg.CodeId;
                    if ( MsgHandle.getInstance().profuns.ContainsKey(codeId))
                    {
                        try
                        {
                            msg.db = connect;
                            msg.app = this;
                            MsgHandle.getInstance().profuns[codeId](msg);
                            msg.db = null;

                            //消息可以使用对象池  这里暂时不使用...
                        }
                        catch (Exception ex)
                        {
                            Log.error("处理" + codeId + "出现异常");
                            Log.error(ex.Message);
                            Log.error(ex.StackTrace);
                        }
                    }
                }
                else
                {
                    Thread.Sleep(20);
                }
            }
        }


        //返回消息
      
        public void sendMsg(HttpListenerContext context, MsgBase msg)
        {
            HttpListenerResponse reponse = context.Response;
            StreamWriter writer = new StreamWriter(reponse.OutputStream);

          
            backmsg.state = 0;
            backmsg.reason = "";
            backmsg.msgid = (int)msg.CodeId;
            backmsg.msg=JSON.Encode(msg);

            writer.Write(JSON.Encode(backmsg));

            writer.Close();
            reponse.Close();
        }
        public void sendErrorMsg(HttpListenerContext context,int err)
        {
            HttpListenerResponse reponse = context.Response;
            StreamWriter writer = new StreamWriter(reponse.OutputStream);


            backmsg.state = err;
            backmsg.reason = MsgStateType.getErrText(err);
            backmsg.msgid = 0;
            backmsg.msg = new object();

            writer.Write(JSON.Encode(backmsg));

            writer.Close();
            reponse.Close();
        }

    }

}
