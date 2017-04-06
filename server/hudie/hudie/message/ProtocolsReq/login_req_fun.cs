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
          Log.warn("�յ��˵�½��Ϣ");

          login_req req = msg as login_req;

          login_res res = new login_res();


          if (pf.IsMobile(req.tel))
          {
              string str = String.Format("select * from account where mobile ='{0}'", req.tel);

              DbSelect<TbUser> dbselect = new DbSelect<TbUser>(msg.db, str, null);
              dbselect.processRequest();

              if (dbselect.ListRecord != null && dbselect.ListRecord.Count != 0)
              {
                  //���ֻ���

                  if (req.pass == dbselect.ListRecord[0].Pass)
                  {
                      res.token = dbselect.ListRecord[0].Id;

                      //�Ž�����
                  }
                  else
                  {
                      //�������
                      res.state = (int)EnumMsgState.login_password_err;
                  }

              }
              else
              {
                  //û��ע��
                  res.state = (int)EnumMsgState.login_mob_not_reg;
              }
          }
          else
          {
              //û��ע��
              res.state = (int)EnumMsgState.login_mob_not_reg;
          }


          //֪ͨǰ��
          msg.app.sendMsg(req.context, res);
      }
  }
}
