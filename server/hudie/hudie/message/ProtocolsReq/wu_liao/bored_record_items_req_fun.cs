using GameDb.Logic;
using GameDb.Util;
using GameLib.Database;
using messages;
using System;
using messages.Protocols;

namespace messages
{
  public partial class MsgHandle
  {
      static public void handle_bored_record_items_req(MsgBase msg)
      {
//           Log.warn("收到了语音列表请求");
// 
// 
//           bored_record_items_req req = msg as bored_record_items_req;
// 
//           //请求数据库数据......
// 
//           string str = String.Format("select * from bored_head_detail where headid ='{0}';", req.head_id);
// 
// 
//           DbSelect<TbBoredHeadDetail> dbselect = new DbSelect<TbBoredHeadDetail>(msg.db, str, null);
//           dbselect.processRequest();
// 
//           //请求数据库数据结束......
// 
// 
//           //逻辑计算.......
// 
//           //逻辑计算结束.......
// 
// 
//           //通知前端.....
// 
//           bored_record_items_res res = new bored_record_items_res();
// 
//           if (dbselect.ListRecord != null)
//           {
//               res.infos = new info_bored_record_item[dbselect.ListRecord.Count];
// 
//               int count = 0;
//               foreach (TbBoredHeadDetail theme in dbselect.ListRecord)
//               {
//                   res.infos[count] = new info_bored_record_item();
// 
//                   res.infos[count].id = theme.Id;
//                   res.infos[count].headid = theme.Headid;
//                   res.infos[count].recordurl = theme.RecordUrl;
//                   res.infos[count].recordlength = theme.RecordLen;
//                   count++;
//               }
//           }
//           else
//           {
//               res.infos = new info_bored_record_item[0];
//           }

          //处理结束
         // msg.app.sendMsg(req, res);
      }
  }
}
