﻿using Enum;
using GameDb.Logic;
using GameDb.Util;
using GameLib.Database;
using GameLib.Util;
using hudie.app;
using hudie.net;
using hudie.sql;
using messages;
using System;
using System.Collections.Concurrent;
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

        private MapAppMsg msg_map = new MapAppMsg();

        public ConcurrentQueue<HttpInfo> msg_data = new ConcurrentQueue<HttpInfo>();


        public void init()
        {
            backmsg = new BackMsg();

            connect = DBManager.getBenefitDB();

            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();

            //消息映射
            msg_map.init(this);
        }

        public void addMsg(HttpInfo info)
        {
            msg_data.Enqueue(info);
        }
       

        public void Run()
        {

            while (true)
            {
                HttpInfo msg = null;

                if (msg_data.TryDequeue(out msg)==true)
                {
                   
                    if (msg_map.class_map.ContainsKey(msg.modpath)==true)
                    {
                        if(msg_map.msg_map.ContainsKey(msg.funpath) == true)
                        {
                            try
                            {
                                if(msg_map.req_map.ContainsKey(msg.funpath))
                                {
                                    int flag = 0;

                                    foreach(var item in msg_map.req_map[msg.funpath])
                                    {
                                        if(msg.req_params.ContainsKey(item) == false)
                                        {
                                            flag = 1;
                                            break;
                                        }
                                    }

                                    if(flag==1)
                                    {
                                        sendErrorMsg(msg, EnumMsgState.param_err);
                                        continue;
                                    }
                                }
                                
                                msg_map.msg_map[msg.funpath](msg);
                            }
                            catch(Exception ex)
                            {
                                Log.error("处理" + msg.funpath + "出现异常");
                                Log.error(ex.Message);
                                Log.error(ex.StackTrace);

                                sendErrorMsg(msg, EnumMsgState.fun_err);
                            }
                        }
                        else
                        {
                            sendErrorMsg(msg, EnumMsgState.fun_err);
                        }
                    }
                    else
                    {
                        sendErrorMsg(msg, EnumMsgState.module_err);
                    }
                }
                else
                {
                    Thread.Sleep(20);
                }
            }
        }


        //返回消息
      
        public void sendMsg(HttpInfo reqinfo, Object msg)
        {
            HttpListenerResponse reponse = reqinfo.context.Response;
            StreamWriter writer = new StreamWriter(reponse.OutputStream,Encoding.UTF8);

            backmsg.error = 0;
            backmsg.msg = msg;

            writer.Write(JSON.Encode(backmsg));

            writer.Close();
            reponse.Close();
        }
        public void sendErrorMsg(HttpInfo reqinfo,EnumMsgState err)
        {
            try
            {
                HttpListenerResponse reponse = reqinfo.context.Response;
                StreamWriter writer = new StreamWriter(reponse.OutputStream);

                backmsg.error = (int)err;
                backmsg.msg = new object();

                writer.Write(JSON.Encode(backmsg));

                writer.Close();
                reponse.Close();
            }
            catch(Exception ex)
            {
                Log.error(ex);
            }
           
        }

        //----------数据库读取---------
        public List<T> db_Select<T>(string req) where T : TbLogic,new()
        {
            DbSelect<T> dbselect = new DbSelect<T>(connect, req, null);
            dbselect.processRequest();

            return dbselect.ListRecord;
        }

        //数据库插入
        public void db_Insert<T>(T t) where T : TbLogic, new()
        {
            DbInsert<T> dbinsert = new DbInsert<T>(connect, t, null);
            dbinsert.processRequest();
        }

    }

}
