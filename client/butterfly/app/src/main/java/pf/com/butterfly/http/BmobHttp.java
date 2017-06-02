package pf.com.butterfly.http;

import android.os.Message;

import com.google.gson.Gson;

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
import pf.com.butterfly.util.MixFun;

/**
 * 使用post 发送字节类型的数据
 */
public class BmobHttp extends HttpBase
{
    private String content_type="application/json";

    public static String YZM_url="https://api.bmob.cn/1/requestSmsCode";  //验证码网址
    public static String FILE_url="https://api.bmob.cn/2/files/";  //文件上传网址

    public BmobHttp(IMsgHandler handler)
    {
        super(handler);
    }
    public void setContentType(String contenttype)
    {
        content_type=contenttype;
    }

    @Override
    public void SetHttpHeader(HttpURLConnection conn)
    {
        conn.setRequestProperty("X-Bmob-Application-Id","a5a2688114fb06e9156acaaee76ca9a0");
        conn.setRequestProperty("X-Bmob-REST-API-Key","603fc86123b6ad09a9e9c264103fb5a4");
        conn.setRequestProperty("Content-Type",content_type);
    }

    @Override
    public String DisposeException(Exception ex)
    {
        return ex.getMessage();

    }
    public void sendAudioFile(String path)
    {
        byte[] data= MixFun.readFileSdcardFile(path);

        this.send(FILE_url+MixFun.randName(".amr"),data);

    }

    public void errerDispose(int err,String result)
    {
        if(err==-100)
        {
            //请求出现异常了....
            HDLog.Toast(result);
            return ;
        }

        if(err==-99)
        {
            errinfo res =new Gson().fromJson(result,errinfo.class);

            if(res!=null)
            {
                HDLog.Toast("Bmob错误码:"+res.code+"  error:"+res.error);
                return;
            }
        }
    }


    public class fileback
    {
         public String filename;
         public String url;
         public String cdnname;
    }

    public class errinfo
    {
        public int code;
        public String error;
    }


}
