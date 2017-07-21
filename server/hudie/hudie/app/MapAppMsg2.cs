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
		private void init_class_map()
		{
			class_map.Add("hudie."+"app.module.user", new app.module.user());
		}
		private void init_msg_map()
		{
			msg_map.Add("hudie."+"app.module.user.userinfo", ((app.module.user)class_map["hudie.app.module.user"]).userinfo);
			msg_map.Add("hudie."+"app.module.user.test2", ((app.module.user)class_map["hudie.app.module.user"]).test2);
			msg_map.Add("hudie."+"app.module.user.login", ((app.module.user)class_map["hudie.app.module.user"]).login);
		}
	}
}
