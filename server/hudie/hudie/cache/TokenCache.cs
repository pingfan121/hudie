using GameLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudie.cache
{
    public class TokenCache :IObject
    {

        public static int cleantime = DateUtil.ToUnixTime(DateTime.Now);
        public static int cleaninterval = 24 * 60 * 60; //清理间隔 1天

        public string useid;
        public DateTime lasttime;

        public void OnRecycle()
        {

        }
    }
}
