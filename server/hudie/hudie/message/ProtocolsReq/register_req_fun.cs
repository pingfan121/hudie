using Enum;
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

          register_res res = new register_res();

          string id = "";


          if (pf.IsMobile(req.tel))
          {
              string str = String.Format("select * from app_user where mobile ='{0}'", req.tel);

              DbSelect<TbUser> dbselect = new DbSelect<TbUser>(msg.db, str, null);
              dbselect.processRequest();

              if (dbselect.ListRecord != null && dbselect.ListRecord.Count != 0)
              {
                  //�Ѿ�������ֻ�����
                  res.state = (int)EnumMsgState.reg_mob_exist;
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

              }
          }
          else
          {
              //�ֻ��Ÿ�ʽ����ȷ
              res.state = (int)EnumMsgState.reg_mob_format_err;
          }

          //���߿ͻ��˰�
          //����
          msg.app.sendMsg(req.context, res);
      }
  }
}
