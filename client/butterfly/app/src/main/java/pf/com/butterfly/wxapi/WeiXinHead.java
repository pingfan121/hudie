package pf.com.butterfly.wxapi;

import android.os.Message;
import android.widget.Toast;

import com.google.gson.Gson;
import com.tencent.mm.sdk.openapi.IWXAPI;
import com.tencent.mm.sdk.openapi.SendAuth;
import com.tencent.mm.sdk.openapi.WXAPIFactory;

import java.util.ArrayList;
import java.util.List;

import pf.com.butterfly.GlobalData;
import pf.com.butterfly.MainActivity;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.hander.MsgHandler;
import pf.com.butterfly.http.BmobHttp;
import pf.com.butterfly.http.HttpBase;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.Protocols.bored_record_items_res;
import pf.com.butterfly.message.Protocols.login_weixin_req;
import pf.com.butterfly.message.Protocols.login_weixin_res;
import pf.com.butterfly.message.net.IMsgResult;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.bored.BoredAudioItemData;
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

        String url  = "https://api.weixin.qq.com/sns/oauth2/access_token?appid="
                + wx_app_id
                + "&secret="
                + wx_app_secret
                + "&code="
                + code
                + "&grant_type=authorization_code";

        HDLog.info("获取access_token的地址"+url);

        if(http==null)
        {
            http=new BmobHttp(new IMsgHandler() {
                @Override
                public void onMsgDispose(int err,String result,Object userToken)
                {
                    OnMessage(err,result,userToken);
                }
            });
        }

        http.send(url,"");

    }
    //处理http返回
    private static void OnMessage(int err,String result,Object userToken)
    {
        HDLog.error("获取token返回....");

        if(err==-99 ||err==-100 )
        {
          //  http.errerDispose(msg);
            HDLog.error("出现错误");
            return ;
        }

        wx_result res =new Gson().fromJson(result,wx_result.class);

        HDLog.Toast(res.access_token);

        login_weixin_req req=new login_weixin_req();

        req.acc_token=res.access_token;

        NetManager.SendMsg(req,msg_result);

    }

    class wx_result
    {
        public String access_token;
        public String expires_in;
        public String refresh_token;
        public String openid;
        public String scope;
        public String unionid;
    }


    //消息返回..................
    private static IMsgResult msg_result=new IMsgResult()
    {
        @Override
        public void onError(int err, String msg)
        {
          //  HDLog.Toast(msg);

            HDLog.Toast("微信登录错误,错误码:"+err);
        }

        @Override
        public void onResult(MsgBase msg)
        {
            login_weixin_res res=(login_weixin_res)msg;

            //注册成功
            HDLog.Toast("微信登录成功");

            GlobalData.login_flag=true;
            GlobalData.userinfo=res.info;

            //更新个人信息
            UserHead.getInstance().updateInfo();
        }
    };

}
