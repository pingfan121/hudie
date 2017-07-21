using hudie.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameServer.Define.EnumNormal;
using GameDb.Util;

namespace hudie.app.module
{
	public partial class user
	{
		public void test2(GameApp app, HttpInfo info)
		{
            Log.error("收到测试消息");

            app.sendMsg(info.context, "测试成功");
		}
	}
}
