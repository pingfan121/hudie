package pf.com.butterfly.message.net;

import android.os.Message;
import android.util.Log;

import com.google.gson.Gson;

import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.LinkedBlockingQueue;

import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.MsgMap;
import pf.com.butterfly.message.CSMsg;

/**
 * Created by Administrator on 2016/5/30.
 */
public class NetHttp
{

    private String url="http://192.168.0.88:10012";
    private URL realUrl; //= new URL(url);
    // 打开和URL之间的连接
    private URLConnection conn;// = realUrl.openConnection();


    //消息队列
    private LinkedBlockingQueue<MsgBase> send_queue;
    private LinkedBlockingQueue<String> recv_queue;

    private static Gson gson =new Gson();

    public NetHttp ()
    {

    }


    public void init()
    {
        try
        {
            send_queue=new LinkedBlockingQueue<MsgBase>();
            recv_queue=new LinkedBlockingQueue<String>();

            Thread thread =new Thread(new sendclass());
            thread.start();

        }
        catch (Exception ex)
        {
            Log.e("ceshi", "Net: ",ex );
        }
    }

    public String sendPost( MsgBase msg) {

        PrintWriter out = null;
        BufferedReader in = null;
        String result = "";
        URL realurl = null;

        HttpURLConnection conn = null;

        try{
            realurl = new URL(url);
            conn = (HttpURLConnection)realurl.openConnection();
            conn.setDoOutput(true);
            conn.setRequestMethod("POST");
            PrintWriter pw = new PrintWriter(conn.getOutputStream());
            pw.print(gson.toJson(msg));
            pw.flush();
            pw.close();
            in = new BufferedReader(
                    new InputStreamReader(conn.getInputStream()));

            String line;
            while ((line = in.readLine()) != null)
            {
                result += line;
            }
        }
        catch(Exception ex)
        {
            ex.printStackTrace();
        }
        return result;
    }

    //发送消息线程
    class sendclass implements Runnable
    {
       // private Gson gson=new Gson();

        @Override
        public void run()
        {
            while(true)
            {
                try
                {
                    //获取一个需要发送的消息
                    MsgBase msg =(MsgBase)send_queue.poll();

                    if(msg!=null)
                    {
                        try
                        {
                            String temp =sendPost(msg);

                            if(temp!="")
                            {
                                CSMsg csmsg=gson.fromJson(temp, CSMsg.class);

                                if(csmsg.state==0)
                                {
                                    Class cl =MsgMap.GetMsgClass(csmsg.msgid);

                                    MsgBase msg2=(MsgBase)gson.fromJson(csmsg.msg,cl);

                                    NetManager.DisposeMsg(msg2);
                                }
                                else
                                {
                                    //这里显示错误状态
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    else
                    {
                        Thread.sleep(100);
                    }

                }
                catch(Exception ex)
                {
                    Log.e("net", "sendclass: ",ex );
                }

            }
        }
    }

    //发送数据
    public void SendMsg( MsgBase msg)
    {
        send_queue.offer(msg);
    }

    //获取一个接收数据
    public String GetMsg()
    {
        return (String)recv_queue.poll();
    }



}
