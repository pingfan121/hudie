using GameLib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudie.cache
{
    public class Cache
    {
        public static Dictionary<string, TokenCache> tokens = new Dictionary<string, TokenCache>();


        //----------------------token的操作--------------------------
        public static void AddTokenCache(string token,string userid)
        {
            TokenCache temp =ObjectPool.getObject<TokenCache>();
            temp.useid = userid;
            temp.lasttime = DateTime.Now;
        }



        public static void update(int currtime)
        {
            //清理token

            if(currtime - TokenCache.cleantime > TokenCache.cleaninterval)
            {
                //清理
                lock(tokens)
                {

                }
            }
        }
    }
}
