using GameDb.Logic;
using GameDb.Util;
using GameLib.Database;
using GameLib.Util;
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
      static public void handle_register_req(MsgBase msg)
      {
          Log.warn("�յ���ע����Ϣ");

          register_req req = msg as register_req;

          int err = 0;
          string reason = "";
          string id = "";


          if (pf.IsMobile(req.tel))
          {
              string str = String.Format("select * from account where mobile ='{0}'", req.tel);

              DbSelect<TbUser> dbselect = new DbSelect<TbUser>(msg.db, str, null);
              dbselect.processRequest();

              if (dbselect.ListRecord != null && dbselect.ListRecord.Count != 0)
              {
                  //�Ѿ�������ֻ�����
                  err = -1;
                  reason = "�ֻ����Ѿ�����";
              }
              else
              {
                  TbUser account = new TbUser();

                  account.Id = ObjectId.NewObjectId();
                  account.Mobile = req.tel;
                  account.Pass = req.pass;
                  account.Createtime = DateTime.Now;
                  account.Mail = "";

                  //����һ���û�����
                  DbInsert<TbUser> dbinsert = new DbInsert<TbUser>(msg.db, account, null);
                  dbinsert.processRequest();

                  id = account.Id;

                  err = 0;
              }
          }
          else
          {
              err = -2;
              reason = "�ֻ��Ÿ�ʽ����ȷ";
          }

          //���߿ͻ��˰�

          register_res res = new register_res();

          res.state = err;
          res.token = id;
          res.reason = reason;

          //����
          msg.app.sendMsg(req.context, res);
      }
  }
}
