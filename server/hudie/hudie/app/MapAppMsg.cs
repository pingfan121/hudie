using hudie.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudie.app
{
    public delegate void msg_dispose(GameApp app, HttpInfo info);
    public class MapAppMsg
    {
        public Dictionary<string,Object> class_map=new Dictionary<string,object>();

        public Dictionary<string, msg_dispose> msg_map = new Dictionary<string, msg_dispose>();

        public void init()
        {
         
            init_class_map();

            init_msg_map();
        }

        private void init_class_map()
        {
            class_map.Add("hudie."+"app.module.user", new app.module.user());
        }

        private void init_msg_map()
        {
            app.module.user user_ins = (app.module.user)class_map["hudie." + "app.module.user"];

            msg_map.Add("hudie." + "app.module.user.login", user_ins.login);
        }

    }
}
