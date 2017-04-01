package pf.com.butterfly.http;

import android.os.Message;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.net.HttpURLConnection;
import java.net.URL;

import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.hander.MsgHandler;
import pf.com.butterfly.util.HDLog;

/**
 * Created by admin on 2017/4/2.
 */
public class HttpBase extends Thread
{
    private String url="";
    private int what=0;
    private int flag=0;

    private byte[] data;

    public HttpBase(int what)
    {
        this.what=what;
    }

    public HttpBase(IMsgHandler handler)
    {
        this.what=MsgHandler.getInstance().getNewWhat();
        MsgHandler.getInstance().addOneDispose(what,handler);
    }


    public void send(String url,String data)
    {
        try
        {
            send(url,data.getBytes("UTF-8"),0);
        }
        catch (Exception ex)
        {

        }
    }

    public void send(String url,String data,int flag)
    {
        try
        {
            send(url,data.getBytes("UTF-8"),flag);

        }
        catch (Exception ex)
        {

        }
    }

    public void send(String url,byte[] data)
    {
        send(url,data,0);
    }

    public void send(String url,byte[] data,int flag)
    {
        try
        {

            SendThread thread=new SendThread(this,what,flag,url,data);
            thread.start();
        }
        catch (Exception ex)
        {

        }
    }




    public void SetHttpHeader(HttpURLConnection conn)
    {

    }

    public String DisposeException(Exception ex)
    {
        return ex.getMessage();
    }
}
class SendThread extends Thread
{
    private HttpBase http;

    private String url="";
    private int what=0;
    private int flag=0;

    private byte[] data;


    public SendThread(HttpBase http,int what,int flag,String url,byte[] data)
    {
        this.http=http;
        this.what=what;
        this.flag=flag;
        this.url=url;
        this.data=data;
    }

    @Override
    public void run()
    {

        Message message=new Message();

        message.what=what;
        message.arg1=flag;

        String temp="";

        HttpURLConnection conn = null;

        PrintWriter out = null;
        BufferedReader in = null;

        URL realurl = null;

        String result = "";

        try
        {




            realurl = new URL(url);
            conn = (HttpURLConnection)realurl.openConnection();
            conn.setDoOutput(true);
            conn.setRequestMethod("POST");
//            conn.setRequestProperty("X-Bmob-Application-Id","a5a2688114fb06e9156acaaee76ca9a0");
//            conn.setRequestProperty("X-Bmob-REST-API-Key","603fc86123b6ad09a9e9c264103fb5a4");
//            conn.setRequestProperty("Content-Type","application/json");
            http.SetHttpHeader(conn);

            OutputStream temp_out = conn.getOutputStream();
            temp_out.write(data);
            temp_out.flush();
            temp_out.close();

            in = new BufferedReader(
                    new InputStreamReader(conn.getInputStream()));

            String line;
            while ((line = in.readLine()) != null)
            {
                result += line;
            }

            message.obj=result;
        }
        catch (Exception ex)
        {
            HDLog.error("SendPost出现异常");



            try
            {
                in = new BufferedReader(
                        new InputStreamReader(conn.getErrorStream()));

                String line;
                while ((line = in.readLine()) != null)
                {
                    result += line;
                }

                message.obj=result;
                message.arg2=-99;
            }
            catch (Exception ex2)
            {
                message.obj= ex.getMessage();
                message.arg2=-100;
            }



        }

        MsgHandler.getInstance().sendMessage(message);
    }
}
