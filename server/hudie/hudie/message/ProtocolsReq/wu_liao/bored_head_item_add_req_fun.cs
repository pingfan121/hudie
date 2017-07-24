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
      static public void handle_bored_head_item_add_req(MsgBase msg)
      {
          Log.warn("收到了添加无聊列表请求");


          bored_head_item_add_req req = msg as bored_head_item_add_req;

          //请求数据库数据......

          string str = String.Format("select * from bored_head where invalid ='0';");

          TbBoredHead head = new TbBoredHead();

          head.Id = ObjectId.NewObjectId().ToString();
          head.Useid = "0";
          head.Rownum = 0;
          head.Invalid = 0;
          head.Createtime = DateUtil.ToUnixTime2(DateTime.Now);
          head.Content = req.content;

          DbInsert<TbBoredHead> dbselect = new DbInsert<TbBoredHead>(msg.db, head, null);
          dbselect.processRequest();

          //请求数据库数据结束......


          //逻辑计算.......

          //逻辑计算结束.......


          //通知前端.....

          bored_head_item_add_res res = new bored_head_item_add_res();


          res.info = new info_bored_head_item();

          res.info.id = head.Id;
          res.info.userid = head.Useid;
          res.info.content = head.Content;
          res.info.rownum = head.Rownum;
       
          //处理结束
        //  msg.app.sendMsg(req.context, res);
      }
  }
}
