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
	public partial class bored
	{
		public void add(HttpInfo reqinfo)
		{
            Log.warn("收到了无聊模块添加请求");

            reqinfo.user_data = app.getUserData(reqinfo);

            if(reqinfo.user_data == null)
            {
                app.sendErrorMsg(reqinfo, Enum.EnumMsgState.login_invalid);
                return;
            }

            //请求数据库数据......

            TbBoredHead head = new TbBoredHead();

            head.Id = ObjectId.NewObjectId().ToString();
            head.Useid = reqinfo.user_data.Id;
            head.UserName = reqinfo.user_data.Name;
            head.UserFace = reqinfo.user_data.Head;
            head.Rownum = 0;
            head.InvalidTime = DateUtil.ToUnixTime2(DateTime.Now.Date);
            head.CreateTime = DateUtil.ToUnixTime2(DateTime.Now);

            head.Content = reqinfo.req_params["content"];

            DbInsert<TbBoredHead> dbselect = new DbInsert<TbBoredHead>(null, head, null);
         
            sql_struct sql=new sql_struct();

            sql.httpinfo=reqinfo;
            sql.data1 = head;
            sql.cmd=dbselect;
            sql.fun = add_back;

            //异步...
            app.db_Insert(sql);
		}

        private void add_back(sql_struct sql)
        {

            TbBoredHead head = sql.data1 as TbBoredHead;

            res_bored_add res = new res_bored_add();

            res.info= new info_bored();

            res.info.id = head.Id;
            res.info.userid = head.Useid;
            res.info.content = head.Content;
            res.info.rownum = head.Rownum;

            app.sendMsg(sql.httpinfo, res);
        }
	}
}
