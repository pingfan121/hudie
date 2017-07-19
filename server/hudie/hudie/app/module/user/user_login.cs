using GameDb.Util;
using hudie.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudie.app.module
{
    public partial class user
    {
        public void login(GameApp app, HttpInfo info)
        {
            Log.error("收到登陆消息");

            app.sendMsg(info.context, "登陆成功");
        }
    }
}
