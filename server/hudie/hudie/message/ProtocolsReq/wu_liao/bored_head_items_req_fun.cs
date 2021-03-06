using Enum;
using GameDb.Logic;
using GameDb.Util;
using GameLib.Database;
using GameLib.Util;
using hudie.cache;
using hudie.net;
using hudie.sql;
using hudie.tool;
using messages;
using messages.Protocols;
using System;
namespace messages
{
  public partial class MsgHandle
  {
      static public void handle_bored_head_items_req(MsgBase msg)
      {
          Log.warn("收到了无聊列表请求");
          

          bored_head_items_req req = msg as bored_head_items_req;

          //请求数据库数据......

          //  string str = String.Format("select * from benefit_theme limit {0},{1};", req.curr, 20);

          string str = String.Format("select * from bored_head where invalid ='0';");

          DbSelect<TbBoredHead> dbselect = new DbSelect<TbBoredHead>(msg.db, str, null);
          dbselect.processRequest();

          //请求数据库数据结束......


          //逻辑计算.......

          //逻辑计算结束.......


          //通知前端.....

          bored_head_items_res res = new bored_head_items_res();

          if (dbselect.ListRecord != null)
          {
              res.infos = new info_bored_head_item[dbselect.ListRecord.Count];

              int count = 0;
              foreach (TbBoredHead theme in dbselect.ListRecord)
              {
                  res.infos[count] = new info_bored_head_item();

                  res.infos[count].id= theme.Id;
                  res.infos[count].userid = theme.Useid;
                  res.infos[count].content = theme.Content;
                  res.infos[count].rownum = theme.Rownum;
                  count++;
              }
          }
          else
          {
              res.infos = new info_bored_head_item[0];
          }

          //处理结束
         // msg.app.sendMsg(req.context, res);
      }
  }
}
