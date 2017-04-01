package pf.com.butterfly.message.net;

import android.os.Message;

import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.hander.MsgHandler;
import pf.com.butterfly.message.MsgMap;
import pf.com.butterfly.message.ProtocolsFun.MsgProcessor;

/**
 * Created by Administrator on 2016/6/15.
 */
public class NetManager
{
    private static NetHttp http;

    public static int WhatId=100;

    public static void init()
    {
        if(http==null)
        {
            http=new NetHttp();
            http.init();

            //初始化协议映射
            MsgProcessor.init();

            WhatId=MsgHandler.getInstance().getNewWhat();

            //切换到ui线程
            MsgHandler.getInstance().addOneDispose(WhatId,new Dispose());
        }

    }

    public static void SendMsg(MsgBase msg)
    {
        http.SendMsg(msg);
    }

    public static void DisposeMsg(MsgBase msg)
    {
        Message message=new Message();

        message.what=WhatId;
        message.obj=msg;

        MsgHandler.getInstance().sendMessage(message);
    }


}
class Dispose implements IMsgHandler
{
    //处理网络消息
    public void onMsgDispose(Object o)
    {
        MsgBase msg =(MsgBase)o;
        //  MainActivity.getInstance().ShowText(str);

        try
        {
            MsgMap.GetResultClass(msg.CodeId).MsgCallback(msg);
        }
        catch(Exception ex)
        {

        }

    }
}