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
      static public void handle_advise_cteate_req(MsgBase msg)
      {
          Log.warn("收到了建议请求");

          advise_cteate_req req = msg as advise_cteate_req;

          //请求数据库数据......

          //  string str = String.Format("select * from benefit_theme limit {0},{1};", req.curr, 20);

          TbAppAdvice jianyi = new TbAppAdvice();
          jianyi.Id = ObjectId.NewObjectId().ToString();
          jianyi.CreateTime = DateUtil.ToUnixTime2(DateTime.Now);
          jianyi.Content = req.content;
          jianyi.Userid = req.userid;

          DbInsert<TbAppAdvice> dbinsert = new DbInsert<TbAppAdvice>(msg.db, jianyi, null);
          dbinsert.processRequest();

          //请求数据库数据结束......


          //逻辑计算.......

          //逻辑计算结束.......


          //通知前端.....

          advise_cteate_res res = new advise_cteate_res();

          res.state = 0;

          //处理结束
        //  msg.app.sendMsg(req, res);

          Log.warn("建议请求处理完成");
      }
  }
}
