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
          login_req req = msg as login_req;

          Log.warn("�յ��˵�½��Ϣ");

          int err = 0;
          string id = "";
          string reason = "";

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
                      err = 0;
                      id = dbselect.ListRecord[0].Id;
                      reason = "��¼�ɹ�";
                  }
                  else
                  {
                      err = -1;
                      reason = "�������...";
                  }


              }
              else
              {
                  err = -2;
                  reason = "�ֻ�û��ע��";
              }
          }
          else
          {
              err = -3;
              reason = "�ֻ��Ÿ�ʽ����ȷ";
          }


          //֪ͨǰ��
          login_res res = new login_res();

          res.state = err;
          res.token = id;
          res.reason = reason;

          //����
          msg.app.sendMsg(req.context, res);
      }
  }
}
