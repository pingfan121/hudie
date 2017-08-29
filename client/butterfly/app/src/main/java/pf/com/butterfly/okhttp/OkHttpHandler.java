package pf.com.butterfly.okhttp;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;

import pf.com.butterfly.module.info.MsgData;
import pf.com.butterfly.util.HDLog;
import pf.com.butterfly.util.MyGson;

/**
 * Created by admin on 2017/8/29.
 */

public class OkHttpHandler extends Handler
{
    public static final int what_app_msg=0;

    public static final int what_bmob_msg=1;
    public static final int what_other_msg=2;

    private static final byte[] LOCKER = new byte[0];
    private static OkHttpHandler mInstance;

    public static OkHttpHandler getInstance()
    {
        if (mInstance == null)
        {
            synchronized (LOCKER)
            {
                if (mInstance == null)
                {
                    mInstance = new OkHttpHandler();
                }
            }
        }
        return mInstance;
    }

    @Override
    public void handleMessage(Message msg)
    {
        switch (msg.what)
        {
            case what_app_msg:
            {
                try
                {
                    OnAppMsg(msg);
                }
                catch (Exception ex)
                {
                    HDLog.error(ex);

                    HDLog.Toast("消息处理出现异常请查看日志");
                }

                break;
            }
            case what_bmob_msg:
            {
                try
                {
                    OnBmobMsg(msg);
                }
                catch (Exception ex)
                {
                    HDLog.error(ex);

                    HDLog.Toast("消息处理出现异常请查看日志");
                }

                break;
            }
            case what_other_msg:
            {
                try
                {
                    OnOtherMsg(msg);
                }
                catch (Exception ex)
                {
                    HDLog.error(ex);

                    HDLog.Toast("消息处理出现异常请查看日志");
                }

                break;
            }
        }

        super.handleMessage(msg);
    }

    public void OnAppMsg(Message msg)
    {
        Bundle bundle = msg.getData();
        String result = bundle.getString("result");
        int err = bundle.getInt("error");

        if (err == 0)
        {
            MsgData msgdata = MyGson.parseJson(result, MsgData.class);

            result = MyGson.toJson(msgdata.msg);

            err = msgdata.error;
        }

        IMsgback imsg = (IMsgback) msg.obj;

        if (err < 0)
        {
            HDLog.error(result);
        } else if (err > 0)
        {
            HDLog.error("错误码:" + err);
        }

        if (imsg != null)
        {
            imsg.onMsgDispose(err, result, null);
        }
    }

    public void OnBmobMsg(Message msg)
    {
        Bundle bundle = msg.getData();
        String result = bundle.getString("result");
        int err = bundle.getInt("error");

        IMsgback imsg = (IMsgback) msg.obj;


        if (imsg != null)
        {
            imsg.onMsgDispose(err, result, null);
        }
    }
    public void OnOtherMsg(Message msg)
    {
        Bundle bundle = msg.getData();
        String result = bundle.getString("result");
        int err = bundle.getInt("error");

        HDLog.error("得到消息:"+err+" "+result);

        IMsgback imsg = (IMsgback) msg.obj;


        if (imsg != null)
        {
            imsg.onMsgDispose(err, result, null);
        }
    }
}
