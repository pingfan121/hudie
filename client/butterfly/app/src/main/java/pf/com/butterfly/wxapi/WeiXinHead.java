package pf.com.butterfly.wxapi;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.widget.Toast;

import com.google.gson.Gson;
import com.tencent.mm.sdk.openapi.IWXAPI;
import com.tencent.mm.sdk.openapi.SendAuth;
import com.tencent.mm.sdk.openapi.WXAPIFactory;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import pf.com.butterfly.GlobalData;
import pf.com.butterfly.MainActivity;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.hander.MsgHandler;
import pf.com.butterfly.http.BmobHttp;
import pf.com.butterfly.http.HttpBase;
import pf.com.butterfly.manager.DataManager;
import pf.com.butterfly.manager.MsgManager;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.Protocols.bored_record_items_res;
import pf.com.butterfly.message.Protocols.login_weixin_req;
import pf.com.butterfly.message.Protocols.login_weixin_res;
import pf.com.butterfly.message.net.IMsgResult;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.bored.BoredAudioItemData;
import pf.com.butterfly.module.info.res_user_wx_login;
import pf.com.butterfly.module.okhttp.OkHttpUtils;
import pf.com.butterfly.module.user.UserHead;
import pf.com.butterfly.util.HDLog;

/**
 * Created by admin on 2017/5/26.
 */

public class WeiXinHead
{
    private static String wx_app_id="wx075681f7f4975e1a";
    private static String wx_app_secret="b98554750c5d3747909f56cb11f9aac1";

    public static IWXAPI wx_api;




    public static String code="";
    public static String err="";


    public static HttpBase http;

    //注册app
    public static void registToWX() {
        //AppConst.WEIXIN.APP_ID是指你应用在微信开放平台上的AppID，记得替换。
        wx_api = WXAPIFactory.createWXAPI(MainActivity.main, wx_app_id, false);
        // 将该app注册到微信
        wx_api.registerApp(wx_app_id);
    }

    //授权请求....
    public static void wxLogin()
    {
        if (!wx_api.isWXAppInstalled())
        {
            HDLog.Toast("您还未安装微信客户端");
            return;
        }

        final SendAuth.Req req = new SendAuth.Req();
        req.scope = "snsapi_userinfo";
        req.state = "diandi_wx_login";
        wx_api.sendReq(req);
    }

    //获取token
    public static void getAccessToken(){

        HDLog.Toast("获取token....");

        Map<String,String> params=new HashMap<>();
        params.put("appid",wx_app_id);
        params.put("secret",wx_app_secret);
        params.put("code",code);
        params.put("grant_type","authorization_code");

        OkHttpUtils.getInstance().sendAppMsg("https://api.weixin.qq.com/sns/oauth2/access_token",params,null,handler);

    }

    private static Handler handler=new Handler()
    {
        @Override
        public void handleMessage(Message msg)
        {
            switch (msg.what)
            {
                case 0:
                {
                    Bundle bundle=msg.getData();

                    int error=bundle.getInt("error");
                    String result=bundle.getString("result");

                    if(error!=0)
                    {
                        HDLog.Toast("微信登录出错:"+result);
                        return ;
                    }

                    wx_result res =new Gson().fromJson(result,wx_result.class);

                    login_weixin_req req=new login_weixin_req();

                    req.acc_token=res.access_token;

                    Map<String,String> params=new HashMap<>();
                    params.put("wx_token",res.access_token);

                    MsgManager.sendMsg("app/module/user/wx_login",params,msg_result);


                    break;
                }
            }
        }
    };


    class wx_result
    {
        public String access_token;
        public String expires_in;
        public String refresh_token;
        public String openid;
        public String scope;
        public String unionid;
    }

    private static IMsgHandler msg_result=new IMsgHandler()
    {
        @Override
        public void onMsgDispose(int err,String result,Object userToken)
        {
            if(err!=0)
            {
                HDLog.Toast("微信登录失败");
                return ;
            }

            res_user_wx_login res =MsgManager.parseJson(result, res_user_wx_login.class);

            //注册成功
            HDLog.Toast("微信登录成功");

            DataManager.login_flag=true;

            DataManager.userinfo.name=res.name;
            DataManager.userinfo.sex=res.sex;
            DataManager.userinfo.face=res.face;

            //更新个人信息
            UserHead.getInstance().updateInfo();
        }
    };

}
