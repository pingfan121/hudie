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
using GameLib.Util;

namespace hudie.app.module
{
	public partial class bored
	{
        public void getlist(HttpInfo reqinfo)
        {
            //请求数据库数据......
            string str = String.Format("select * from bored_head where invalid_time ='{0}';",DateUtil.ToUnixTime2(DateTime.Now.Date));

            DbSelect<TbBoredHead> dbselect = new DbSelect<TbBoredHead>(null, str, null);
            //请求数据库数据结束......

            sql_struct sql = new sql_struct();

            sql.httpinfo = reqinfo;
            sql.cmd = dbselect;
            sql.fun = getlist_back;

            app.db_Select(sql);
        }

        private void getlist_back(sql_struct sql)
        {
            DbSelect<TbBoredHead> dbselect = sql.cmd as DbSelect<TbBoredHead>;

            res_bored_getlist res = new res_bored_getlist();

            if(dbselect.ListRecord != null)
            {
                res.list = new info_bored[dbselect.ListRecord.Count];

                int count = 0;
                foreach(TbBoredHead theme in dbselect.ListRecord)
                {
                    res.list[count] = new info_bored();

                    res.list[count].id = theme.Id;
                    res.list[count].userid = theme.Useid;
                    res.list[count].content = theme.Content;
                    res.list[count].rownum = theme.Rownum;
                    count++;
                }
            }
            else
            {
                res.list = new info_bored[0];
            }

            app.sendMsg(sql.httpinfo, res);
        }
    }
}
