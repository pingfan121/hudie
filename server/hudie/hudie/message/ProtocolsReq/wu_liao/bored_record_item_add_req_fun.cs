using GameDb.Logic;
using GameDb.Util;
using GameLib.Database;
using messages;
using System;
using messages.Protocols;
using GameLib.Util;

namespace messages
{
  public partial class MsgHandle
  {
      static public void handle_bored_record_item_add_req(MsgBase msg)
      {
//           Log.warn("收到了添加语音列表请求");
// 
// 
//           bored_record_item_add_req req = msg as bored_record_item_add_req;
// 
//           //请求数据库数据......
// 
//           TbBoredHeadDetail head = new TbBoredHeadDetail();
// 
//           head.Id = ObjectId.NewObjectId().ToString();
//           head.Useid = "0";
//           head.Headid = req.head_id;
//           head.RecordUrl = req.url;
//           head.RecordLen = req.time;
//           head.Createtime = DateUtil.ToUnixTime2(DateTime.Now);
// 
//           DbInsert<TbBoredHeadDetail> dbselect = new DbInsert<TbBoredHeadDetail>(msg.db, head, null);
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
//           bored_record_item_add_res res = new bored_record_item_add_res();
// 
// 
//           res.info = new info_bored_record_item();
// 
//           res.info.id = head.Id;
//           res.info.userid = head.Useid;
//           res.info.recordurl = head.RecordUrl;
//           res.info.recordlength = head.RecordLen;
// 
//           //处理结束
//         //  msg.app.sendMsg(req.context, res);
      }
  }
}
