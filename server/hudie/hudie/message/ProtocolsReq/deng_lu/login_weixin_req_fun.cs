// using GameDb.Logic;
// using GameDb.Util;
// using GameLib.Database;
// using messages;
// using System;
// using messages.Protocols;
// using System.Net;
// using System.Text;
// using GameLib.Util;
// using System.Collections.Generic;
// using Enum;
// 
// namespace messages
// {
// 
//   public class weixin_info
//   {
//       public String nickName;
//       public int sex;
//       public String province;
//       public String city;
//       public String country;
//       public String headimgurl;
//       public String[] privilege;
//       public String unionid;
//   }
//   public partial class MsgHandle
//   {
//       private static String wx_app_id = "wx075681f7f4975e1a";
// 
//       
// 
//       static public void handle_login_weixin_req(MsgBase msg)
//       {
//           Log.warn("收到了微信登陆消息");
// 
//           login_weixin_req req = msg as login_weixin_req;
// 
//           login_weixin_res res = new login_weixin_res();
// 
//           //直接去微信请求
//           WebClient wb = new WebClient();
// 
// 
//           byte[] results = wb.DownloadData(String.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", req.acc_token, wx_app_id));
// 
//           string ss = Encoding.UTF8.GetString(results);
// 
// 
//           weixin_info info = JSON.Decode<weixin_info>(ss);
// 
//          
// 
//           if(info.nickName==null)
//           {
//               //请求微信数据有错误...
//               res.state = (int)EnumMsgState.login_wx_error;
//           }
//           else
//           {
//               //没有错误...
// 
//               //查询数据是否已经有了记录
//               List<TbAppUser> users = msg.app.db_Select<TbAppUser>("select * from app_user where wx_id='" + info.unionid + "';");
// 
//               if(users == null || users.Count == 0)
//               {
//                   //没有查询到数据  插入一条
// 
//                   TbAppUser user = new TbAppUser();
//                   user.Id = ObjectId.NewObjectId().ToString();
//                   user.WxId = info.unionid;
//                   user.Sex = info.sex;
//                   user.Mobile = "";
//                   user.Mail = "";
//                   user.Pass = "";
//                   user.WbId = "";
//                   user.Name = info.nickName;
//                   user.Head = info.headimgurl;
// 
//                   user.Createtime = DateUtil.ToUnixTime2(DateTime.Now);
// 
//                   msg.app.db_Insert(user);
// 
//                   Log.warn("插入一条微信登陆数据..wx_id=" + info.unionid + "  昵称:" + info.nickName);
//               }
// 
//               res.info = new info_user();
// 
//               res.info.name = info.nickName;
//               res.info.sex = info.sex;
//               res.info.face = info.headimgurl;
//           }
//         //  Log.error(ss);
//           //通知前端
//       //    msg.app.sendMsg(req.context, res);
//       }
//   }
// }
