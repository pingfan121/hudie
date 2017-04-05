using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudie.error
{
    class MsgStateType
    {
       
        
        private static Dictionary<int, string> errinfo = new Dictionary<int, string>();

        //根据错误码 返回错误文字
        public static string getErrText(int errno)
        {
            if(!errinfo.ContainsKey(errno))
            {
                return "";
            }
            return errinfo[errno];
        }
        static MsgStateType()
        {
            //系统消息错误  格式  四位数字  对应 错误文字

            errinfo.Add(0, "");  //无错误
            errinfo.Add(1000, "签名错误!");
            errinfo.Add(1001, "解析协议出错");
            errinfo.Add(1002, "解析协议出现问题");
            

            //模块消息错误  格式  六位数字  对应 错误文字

            errinfo.Add(100000, "缺少必要参数");   //10 对应登陆模块


        }



    }
}
