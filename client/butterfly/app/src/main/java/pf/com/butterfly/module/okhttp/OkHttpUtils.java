package pf.com.butterfly.module.okhttp;

/**
 * Created by admin on 2017/7/26.
 */

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;

import com.google.gson.Gson;

import java.io.IOException;
import java.util.Iterator;
import java.util.Map;
import java.util.concurrent.TimeUnit;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Headers;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import pf.com.butterfly.manager.MsgManager;
import pf.com.butterfly.module.info.MsgData;

/**
 * HTTP通讯结构处理器
 *
 */
public class OkHttpUtils
{
    private static final byte[] LOCKER = new byte[0];
    private static OkHttpUtils mInstance;
    private OkHttpClient mOkHttpClient;

    private OkHttpUtils()
    {
        okhttp3.OkHttpClient.Builder ClientBuilder = new okhttp3.OkHttpClient.Builder();
        ClientBuilder.readTimeout(30, TimeUnit.SECONDS);//读取超时
        ClientBuilder.connectTimeout(10, TimeUnit.SECONDS);//连接超时
        ClientBuilder.writeTimeout(60, TimeUnit.SECONDS);//写入超时
        mOkHttpClient = ClientBuilder.build();
    }

    public static OkHttpUtils getInstance()
    {
        if (mInstance == null)
        {
            synchronized (LOCKER)
            {
                if (mInstance == null)
                {
                    mInstance = new OkHttpUtils();
                }
            }
        }
        return mInstance;
    }

    /**
     * 设置请求头
     * @param headersParams
     * @return
     */
    private Headers SetHeaders(Map<String, String> headersParams){
        Headers headers=null;
        okhttp3.Headers.Builder headersbuilder=new okhttp3.Headers.Builder();

        if(headersParams != null)
        {
            Iterator<String> iterator = headersParams.keySet().iterator();
            String key = "";
            while (iterator.hasNext()) {
                key = iterator.next().toString();
                headersbuilder.add(key, headersParams.get(key));
                Log.d("get http", "get_headers==="+key+"===="+headersParams.get(key));
            }
        }
        headers=headersbuilder.build();

        return headers;
    }

//    /**
//     * post请求参数
//     * @param BodyParams
//     * @return
//     */
//    private RequestBody SetRequestBody(Map<String, String> BodyParams){
//        RequestBody body=null;
//        okhttp3.FormBody.Builde formEncodingBuilder=new okhttp3.FormBody.Builder();
//        if(BodyParams != null){
//            Iterator<String> iterator = BodyParams.keySet().iterator();
//            String key = "";
//            while (iterator.hasNext()) {
//                key = iterator.next().toString();
//                formEncodingBuilder.add(key, BodyParams.get(key));
//                Log.d("post http", "post_Params==="+key+"===="+BodyParams.get(key));
//            }
//        }
//        body=formEncodingBuilder.build();
//        return body;
//
//    }

//    /**
//     * Post上传图片的参数
//     * @param BodyParams
//     * @param fileParams
//     * @return
//     */
//    private RequestBody SetFileRequestBody(Map<String, String> BodyParams,Map<String, String> fileParams){
//        //带文件的Post参数
//        RequestBody body=null;
//      okhttp3.MultipartBody.Builder MultipartBodyBuilder=new okhttp3.MultipartBody.Builder();
//        MultipartBodyBuilder.setType(MultipartBody.FORM);
//        RequestBody fileBody = null;
//
//        if(BodyParams != null){
//            Iterator<String> iterator = BodyParams.keySet().iterator();
//            String key = "";
//            while (iterator.hasNext()) {
//                key = iterator.next().toString();
//                MultipartBodyBuilder.addFormDataPart(key, BodyParams.get(key));
//                Log.d("post http", "post_Params==="+key+"===="+BodyParams.get(key));
//            }
//        }
//
//        if(fileParams != null){
//            Iterator<String> iterator = fileParams.keySet().iterator();
//            String key = "";
//            int i=0;
//            while (iterator.hasNext()) {
//                key = iterator.next().toString();
//                i++;
//                MultipartBodyBuilder.addFormDataPart(key, fileParams.get(key));
//                Log.d("post http", "post_Params==="+key+"===="+fileParams.get(key));
//                fileBody = RequestBody.create(HttpVariable.Media_Type.MEDIA_TYPE_PNG, new File(fileParams.get(key)));
//                MultipartBodyBuilder.addFormDataPart(key, i+".png", fileBody);
//            }
//        }
//
//
//
//        body=MultipartBodyBuilder.build();
//        return body;
//
//    }

    /**
     * get方法连接拼加参数
     * @param mapParams
     * @return
     */
    private String setUrlParams( Map<String, String> mapParams){
        String strParams = "";
        if(mapParams != null){
            Iterator<String> iterator = mapParams.keySet().iterator();
            String key = "";
            while (iterator.hasNext()) {
                key = iterator.next().toString();
                strParams += "&"+ key + "=" + mapParams.get(key);
            }
        }

        if(strParams.length()>0)
        {
            strParams = strParams.substring(1);
            strParams="?"+strParams;
        }

        return strParams;
    }


    public void sendAppMsg(String reqUrl, Map<String, String> params, Object userToken, final Handler handler)
    {

        okhttp3.Request.Builder RequestBuilder = new okhttp3.Request.Builder();
        RequestBuilder.url(reqUrl + setUrlParams(params));//添加URL地址

        RequestBuilder.tag(userToken);//添加请求标签
        RequestBuilder.addHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
        Request request = RequestBuilder.build();

        Call call = mOkHttpClient.newCall(request);
        call.enqueue(new Callback()
        {
            @Override
            public void onFailure(Call arg0, IOException arg1)
            {
                httpback(arg0.request().url().toString(),-1,"通讯错误404",arg0.request().tag(),handler);
            }

            @Override
            public void onResponse(Call call, Response response) throws IOException
            {

                if (response.code() == 200)
                {
                    try
                    {
                        String Result = response.body().string();

//                        Gson gson = new Gson();
//
//                        MsgData msgdata=gson.fromJson(Result, MsgData.class);
//
//                        String data=gson.toJson(msgdata.msg);

                        httpback(call.request().url().toString(),0,Result,call.request().tag(),handler);

                    }
                    catch (Exception e)
                    {
                        httpback(call.request().url().toString(),-3,"数据异常-"+response.code(),call.request().tag(),handler);
                    }
                }
                else
                {
                    httpback(call.request().url().toString(),-2,"通讯异常-"+response.code(),call.request().tag(),handler);
                }
            }
        });
    }

    public void httpback(String path, int error, String result, Object userToken,Handler handler)
    {
        Message msg=new Message();
        Bundle bundle=new Bundle();
        bundle.putInt("error",error);
        bundle.putString("result",result);
        msg.setData(bundle);
        msg.obj=userToken;
        msg.what=0;

        handler.sendMessage(msg);
    }

}
