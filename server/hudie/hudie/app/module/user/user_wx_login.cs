using hudie.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Define.EnumNormal;
 using GameDb.Util;
using System.Net;
using Enum;
using GameLib.Util;
using GameDb.Logic;
using hudie.app.info;
using GameLib.Database;

namespace hudie.app.module
{
    public class weixin_info
    {
        public String nickName;
        public int sex;
        public String province;
        public String city;
        public String country;
        public String headimgurl;
        public String[] privilege;
        public String unionid;
    }

	public partial class user
	{
        private static String wx_app_id = "wx075681f7f4975e1a";

        private static HashSet<string> login_reqing = new HashSet<string>();

        //远程测试微信登陆是需要跨线程的
       // private static  public ConcurrentQueue<HttpInfo> login_wait = new ConcurrentQueue<HttpInfo>();



		public void wx_login(HttpInfo reqinfo)
		{
		      Log.warn("收到了微信登陆消息");

              string wx_token = reqinfo.req_params["wx_token"];


              if(login_reqing.Contains(wx_token) == true)
              {
                  app.sendErrorMsg(reqinfo, EnumMsgState.error);
                  return;
              }

              //直接去微信请求
              WebClient wb = new WebClient();

              wb.DownloadDataCompleted += weixin_back;

              wb.DownloadDataAsync(new Uri(String.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}", wx_token, wx_app_id)), reqinfo);
		}

        public void weixin_back(object sender, DownloadDataCompletedEventArgs e)
        {
              HttpInfo reqinfo=(HttpInfo)e.UserState;

            try
            {
                string ss = Encoding.UTF8.GetString(e.Result);
                weixin_info info = JSON.Decode<weixin_info>(ss);

                if(info.nickName==null)
                {
                    //请求微信数据有错误...
                    app.sendErrorMsg(reqinfo, EnumMsgState.login_wx_error);
                    return;
                }
                else
                {
                    //没有错误...

                    sql_struct sql = new sql_struct();

                    DbSelect<TbAppUser> select = new DbSelect<TbAppUser>(null, "select * from app_user where wx_id='" + info.unionid + "';",null);

                    sql.httpinfo = reqinfo;
                    sql.data1 = info;
                    sql.cmd = select;
                    sql.fun = wx_login_sql_back;

                    app.db_Select(sql);
                }
            }
            catch(Exception ex)
            {
                log.error(ex);
                app.sendErrorMsg(reqinfo, EnumMsgState.login_wx_error);
                return;
            }
        }

        private void wx_login_sql_back(sql_struct sql)
        {
            HttpInfo reqinfo = sql.httpinfo;
            weixin_info info = sql.data1 as weixin_info;

            DbSelect<TbAppUser> user_select = sql.cmd as DbSelect<TbAppUser>;

            if(user_select.ListRecord == null || user_select.ListRecord.Count == 0)
            {
                    //没有查询到数据  插入一条

                    TbAppUser user = new TbAppUser();
                    user.Id = ObjectId.NewObjectId().ToString();
                    user.WxId = info.unionid;
                    user.Sex = info.sex;
                    user.Mobile = "";
                    user.Mail = "";
                    user.Pass = "";
                    user.WbId = "";
                    user.Name = info.nickName;
                    user.Head = info.headimgurl;

                    user.Createtime = DateUtil.ToUnixTime2(DateTime.Now);

                    sql = new sql_struct();

                    sql.cmd = new DbInsert<TbAppUser>(null, user, null);

                    app.db_Insert(sql);

                    Log.warn("插入一条微信登陆数据..wx_id=" + info.unionid + "  昵称:" + info.nickName);
            }
            res_user_wx_login res = new res_user_wx_login();

            res.name = info.nickName;
            res.sex = info.sex;
            res.face = info.headimgurl;

            app.sendMsg(reqinfo, res);
        }
	}
}
