using GameDb.Logic;
using GameDb.Util;
using GameLib.Database;
using messages;
using messages.Protocols;
using System;

namespace messages
{
  public partial class MsgHandle
  {
      static public void handle_benefit_detail_req(MsgBase msg)
      {
//           Log.warn("收到了求助详细请求");
// 
//           benefit_detail_req req = msg as benefit_detail_req;
// 
//           //请求数据库数据......
// 
//           //  string str = String.Format("select * from benefit_theme limit {0},{1};", req.curr, 20);
// 
//           string str = String.Format("select * from benefit_head where  id='{0}';",req.themeid);
// 
//           DbSelect<TbBenefitHead> dbselect = new DbSelect<TbBenefitHead>(msg.db, str, null);
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
//           benefit_detail_res res = new benefit_detail_res();
// 
//           if(dbselect.ListRecord != null)
//           {
//               TbBenefitHead head = dbselect.ListRecord[0];
// 
//               res.themeid = head.Id;
//               res.name = head.Name;
//               res.addr = head.Addr;
//               res.needmoney = head.Needmoney;
//               res.nowmoney = head.Nowmoney;
//               res.detail = head.Details;
//           }
//           else
//           {
//              
//           }

          //处理结束
        //  msg.app.sendMsg(req, res);
      }
  }
}
