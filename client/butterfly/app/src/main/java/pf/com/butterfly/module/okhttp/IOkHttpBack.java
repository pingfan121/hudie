package pf.com.butterfly.module.okhttp;

/**
 * Created by admin on 2017/7/27.
 */

public interface IOkHttpBack
{
    void httpback(String path,int error,String result,Object userToken);
}
