package pf.com.butterfly.http;

import android.os.Message;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.net.HttpURLConnection;
import java.net.URL;

import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.hander.MsgHandler;
import pf.com.butterfly.util.HDLog;

/**
 * 使用post 发送字节类型的数据
 */
public class BmobHttp extends HttpBase
{
    public BmobHttp(int what)
    {
        super(what);
    }

    public BmobHttp(IMsgHandler handler)
    {
        super(handler);
    }

    @Override
    public void SetHttpHeader(HttpURLConnection conn)
    {
        conn.setRequestProperty("X-Bmob-Application-Id","a5a2688114fb06e9156acaaee76ca9a0");
        conn.setRequestProperty("X-Bmob-REST-API-Key","603fc86123b6ad09a9e9c264103fb5a4");
        conn.setRequestProperty("Content-Type","application/json");
    }

    @Override
    public String DisposeException(Exception ex)
    {
        return ex.getMessage();

    }


}
