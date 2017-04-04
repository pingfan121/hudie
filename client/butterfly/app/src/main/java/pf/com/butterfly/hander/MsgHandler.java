package pf.com.butterfly.hander;

import android.os.Handler;
import android.os.Message;
import android.util.Log;

import java.util.HashMap;
import java.util.Map;

import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.MsgMap;


/**
 * Created by Administrator on 2016/6/2.
 */
public class MsgHandler extends Handler
{
    private static MsgHandler _instance=null;

    private HashMap<Integer,IMsgHandler> dises = new HashMap<Integer,IMsgHandler>();

    public int what=100;

    public static MsgHandler getInstance()
    {
        if(_instance==null)
        {
            _instance=new MsgHandler();
        }

        return _instance;
    }
    public int getNewWhat()
    {
       return what++;
    }


   public synchronized void   addOneDispose(int what,IMsgHandler dispose)
   {

       if (dises.containsKey(what) == false)
       {
           dises.put(what, dispose);
       }
       else
       {
           //已经添加过处理接口了
           System.out.print("已经添加过处理接口的消息号:" + what);
       }

   }

    public  void removeWhat(int what)
    {
        if (dises.containsKey(what) == true)
        {
            dises.remove(what);
        }
    }

    @Override
    public void handleMessage(Message msg)
    {
        super.handleMessage(msg);

        if(dises.containsKey(msg.what))
        {
            dises.get(msg.what).onMsgDispose(msg);
        }
        else
        {
            //没有找到消息
            System.out.print("没有找到对应处理接口的消息号:"+msg.what);
        }

    }


}
