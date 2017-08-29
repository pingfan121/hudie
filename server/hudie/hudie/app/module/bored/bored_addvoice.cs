using hudie.net;
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
		public void addvoice(HttpInfo reqinfo)
        {
            Log.warn("收到了添加语音请求");

            reqinfo.user_data = app.getUserData(reqinfo);

            if(reqinfo.user_data == null)
            {
                app.sendErrorMsg(reqinfo, Enum.EnumMsgState.login_invalid);
                return;
            }

            //请求数据库数据......

            TbBoredVoice voice = new TbBoredVoice();

            voice.Id = ObjectId.NewObjectId().ToString();
            voice.Useid = reqinfo.user_data.Id;
            voice.BoredId = reqinfo.req_params["boredid"];
            voice.RecordUrl = reqinfo.req_params["voiceurl"];
            voice.RecordLen = int.Parse(reqinfo.req_params["voicelen"]);
            voice.CreateTime = DateUtil.NowToToUnixTime2();

            DbInsert<TbBoredVoice> dbselect = new DbInsert<TbBoredVoice>(null, voice, null);

            sql_struct sql = new sql_struct();

            sql.httpinfo = reqinfo;
            sql.data1 = voice;
            sql.cmd = dbselect;
            sql.fun = addvoice_back;

            //异步...
            app.db_Insert(sql);

            //更新跟帖数量

            string strsql = "update bored_head set rownum = rownum+1 where id='" + voice.BoredId+"';";

            sql_struct sql2 = new sql_struct();

            sql2.sqlstr = strsql;

            app.db_Update(sql2);
        }

        private void addvoice_back(sql_struct sql)
        {
            res_bored_addvoice res = new res_bored_addvoice();

            app.sendMsg(sql.httpinfo, res);
        }
	}
}
