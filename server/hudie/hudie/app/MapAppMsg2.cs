using hudie.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Define.EnumNormal;

namespace hudie.app
{
	public partial class MapAppMsg
	{
		private void init_class_map(GameApp app)
		{
			class_map.Add("hudie."+"app.module.user", new app.module.user(app));
		}
		private void init_msg_map()
		{
			msg_map.Add("hudie."+"app.module.user.wx_login", ((app.module.user)class_map["hudie.app.module.user"]).wx_login);
		}
		private void init_req_map()
		{
			req_map.Add("hudie.app.module.user.wx_login",new List<string>());
			req_map["hudie.app.module.user.wx_login"].Add("wx_token");
		}
	}
}
