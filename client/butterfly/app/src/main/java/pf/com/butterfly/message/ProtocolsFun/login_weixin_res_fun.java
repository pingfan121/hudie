package pf.com.butterfly.message.ProtocolsFun;
import android.widget.Toast;

import pf.com.butterfly.GlobalData;
import pf.com.butterfly.MainActivity;
import pf.com.butterfly.message.MsgBase;
import pf.com.butterfly.message.MsgCodeId;
import pf.com.butterfly.message.IMsgCallback;
import pf.com.butterfly.message.Protocols.login_res;
import pf.com.butterfly.message.Protocols.login_weixin_res;
import pf.com.butterfly.module.user.UserHead;

public class login_weixin_res_fun implements IMsgCallback
{
    
      public void MsgCallback(MsgBase msg)
      {
            //这是在主线程里面了
            login_weixin_res res=(login_weixin_res)msg;

            if(res.state==0)
            {
                  //注册成功
                  Toast.makeText(MainActivity.main,"微信登录成功",Toast.LENGTH_SHORT).show();

                  GlobalData.login_flag=true;
                  GlobalData.userinfo=res.info;

                  //更新个人信息
                  UserHead.getInstance().updateInfo();


            }
            else
            {
                  Toast.makeText(MainActivity.main,"微信登录错误,错误码:"+res.state,Toast.LENGTH_SHORT).show();
            }
      }
}
