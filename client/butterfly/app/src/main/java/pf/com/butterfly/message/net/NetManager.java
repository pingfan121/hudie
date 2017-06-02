package pf.com.butterfly.message.net;

import android.os.Message;

import com.google.gson.Gson;

import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.http.HttpBase;
import pf.com.butterfly.message.CSMsg;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.hander.MsgHandler;
import pf.com.butterfly.message.MsgMap;
import pf.com.butterfly.message.ProtocolsFun.MsgProcessor;
import pf.com.butterfly.util.HDLog;

/**
 * Created by Administrator on 2016/6/15.
 */
public class NetManager
{

    private static HDSend hdsend;

    private static Gson gson;

    private static String url="http://192.168.0.88:10012";

    public static void init()
    {
        if(gson !=null)
            return ;

        MsgProcessor.init();

        gson=new Gson();

        hdsend=new HDSend(new IMsgHandler()
        {
            @Override
            public void onMsgDispose(int err,String result,Object userToken)
            {
                onDispose(err,result,userToken);
            }
        });

    }

    //设置网络
    public static void SetNet(Boolean flag)
    {
        //内网
        if(flag==false)
        {
            url="http://192.168.0.88:10012";
        }
        else
        {
            //外网
            url="http://www.pfkj.online:10012";
        }
    }

    //发送数据
    public static void SendMsg(MsgBase msg)
    {
        hdsend.send(url,gson.toJson(msg));

    }

    //处理消息
    public static void onDispose(int err,String result,Object userToken)
    {
        if(err==-100)
        {
            //网络异常
            HDLog.Toast(result);

            return;
        }


        if(result != "")
        {
            CSMsg csmsg=gson.fromJson(result, CSMsg.class);

            if(csmsg.state==0)
            {
                Class cl =MsgMap.GetMsgClass(csmsg.msgid);

                MsgBase msg2=(MsgBase)gson.fromJson(csmsg.msg,cl);

                MsgMap.GetResultClass(msg2.CodeId).MsgCallback(msg2);

            }
            else
            {
                //这里显示错误状态
            }
        }
    }


}