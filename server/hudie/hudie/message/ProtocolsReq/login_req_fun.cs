using Enum;
using GameDb.Logic;
using GameDb.Util;
using GameLib.Database;
using hudie.net;
using hudie.sql;
using hudie.sql.proc;
using hudie.tool;
using messages;
using messages.Protocols;
using System;

namespace messages
{
  public partial class MsgHandle
  {
      static public void handle_login_req(MsgBase msg)
      {
          Log.warn("收到了登陆消息");

          login_req req = msg as login_req;

          login_res res = new login_res();


          if (pf.IsMobile(req.tel))
          {
              string str = String.Format("select * from account where mobile ='{0}'", req.tel);

              DbSelect<TbUser> dbselect = new DbSelect<TbUser>(msg.db, str, null);
              dbselect.processRequest();

              if (dbselect.ListRecord != null && dbselect.ListRecord.Count != 0)
              {
                  //有手机号

                  if (req.pass == dbselect.ListRecord[0].Pass)
                  {
                      res.token = dbselect.ListRecord[0].Id;

                      //放进缓存
                  }
                  else
                  {
                      //密码错误
                      res.state = (int)EnumMsgState.login_password_err;
                  }

              }
              else
              {
                  //没有注册
                  res.state = (int)EnumMsgState.login_mob_not_reg;
              }
          }
          else
          {
              //没有注册
              res.state = (int)EnumMsgState.login_mob_not_reg;
          }


          //通知前端
          msg.app.sendMsg(req.context, res);
      }
  }
}
