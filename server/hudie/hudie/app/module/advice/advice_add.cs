﻿using hudie.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Define.EnumNormal;
using GameDb.Util;
using GameDb.Logic;
using GameLib.Util;
using GameLib.Database;
using hudie.app.info;

namespace hudie.app.module
{
    public partial class advice
    {
        public void add(HttpInfo reqinfo)
        {
            Log.warn("收到了建议请求");


            //请求数据库数据......

            TbAppJianyi jianyi = new TbAppJianyi();
            jianyi.Id = ObjectId.NewObjectId().ToString();
            jianyi.Time = DateTime.Now;
            jianyi.Content = System.Web.HttpUtility.UrlDecode(reqinfo.req_params["content"]);
            jianyi.Userid = reqinfo.req_params["userid"];

            sql_struct sql = new sql_struct();

            sql.data1 = reqinfo;
            sql.cmd = new DbInsert<TbAppJianyi>(null, jianyi, null);

            app.db_Insert(sql);

            //通知前端.....

            res_advice_add res = new res_advice_add();

            res.state = 0;

            //处理结束
            app.sendMsg(reqinfo, res);

            Log.warn("建议请求处理完成");
        }
    }
}