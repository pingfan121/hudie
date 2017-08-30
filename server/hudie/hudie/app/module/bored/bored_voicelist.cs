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

            string str = String.Format("select * from bored_voice where bored_id ='{0}';", reqinfo.req_params["boredid"]);

            DbSelect<TbBoredVoice> dbselect = new DbSelect<TbBoredVoice>(null, str, null);

            sql_struct sql = new sql_struct();
            sql.httpinfo = reqinfo;
            sql.cmd = dbselect;
            sql.fun = voicelist_back;

            app.db_Select(sql);

          
		}

        private void voicelist_back(sql_struct sql)
        {
            DbSelect<TbBoredVoice> dbselect = sql.cmd as DbSelect<TbBoredVoice>;

            res_bored_voicelist res = new res_bored_voicelist();

            if (dbselect.ListRecord != null)
            {
                res.list = new info_bored_voice[dbselect.ListRecord.Count];

                int count = 0;
                foreach(TbBoredVoice theme in dbselect.ListRecord)
                {
                    res.list[count] = new info_bored_voice();

                    res.list[count].id = theme.Id;
                    res.list[count].userid = theme.Useid;
                    res.list[count].username = theme.UserName;
                    res.list[count].userface = theme.UserFace;
                    res.list[count].boredid = theme.BoredId;
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
