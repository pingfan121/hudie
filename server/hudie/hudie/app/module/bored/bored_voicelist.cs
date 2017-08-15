using hudie.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Define.EnumNormal;
 using GameDb.Util;
using GameDb.Logic;
using GameLib.Database;
using hudie.app.info;

namespace hudie.app.module
{
	public partial class bored
	{
		public void voicelist(HttpInfo reqinfo)
		{
            Log.warn("收到了语音列表请求");

            //请求数据库数据......

            string str = String.Format("select * from bored_head_detail where headid ='{0}';", reqinfo.req_params["bored_id"]);


            DbSelect<TbBoredHeadDetail> dbselect = new DbSelect<TbBoredHeadDetail>(null, str, null);

            sql_struct sql = new sql_struct();
            sql.httpinfo = reqinfo;
            sql.cmd = dbselect;
            sql.fun = voicelist_back;

            app.db_Select(sql);

          
		}

        private void voicelist_back(sql_struct sql)
        {
            DbSelect<TbBoredHeadDetail> dbselect = sql.cmd as DbSelect<TbBoredHeadDetail>;

            res_bored_voicelist res = new res_bored_voicelist();

            if (dbselect.ListRecord != null)
            {
                res.list = new info_bored_voice[dbselect.ListRecord.Count];

                int count = 0;
                foreach (TbBoredHeadDetail theme in dbselect.ListRecord)
                {
                    res.list[count] = new info_bored_voice();

                    res.list[count].id = theme.Id;
                    res.list[count].boredid = theme.Headid;
                    res.list[count].voice_url = theme.RecordUrl;
                    res.list[count].voice_len = theme.RecordLen;
                    count++;
                }
            }
            else
            {
                res.list = new info_bored_voice[0];
            }

            app.sendMsg(sql.httpinfo, res);
        }
	}
}
