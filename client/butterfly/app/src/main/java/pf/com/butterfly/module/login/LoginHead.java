package pf.com.butterfly.module.login;

import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import pf.com.butterfly.GlobalData;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.message.Protocols.info_user;
import pf.com.butterfly.message.Protocols.login_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.ControlLayer;
import pf.com.butterfly.module.title.TitleModule;
import pf.com.butterfly.module.user.UserHead;
import pf.com.butterfly.wxapi.WeiXinHead;

/**
 * Created by admin on 2017/3/3.
 */
public class LoginHead extends AppBaseViewControl
{
    private static LoginHead _instance;

    public static LoginHead getInstance()
    {
        if(_instance==null)
        {
            _instance=new LoginHead();
        }

        return _instance;
    }

    protected void initValue()
    {
        title="登录";
        layout=R.layout.login_head;
        layer= ControlLayer.module_login;
    }



    @Override
    public void initControl()
    {

        //微信登录按钮
        view.findViewById(R.id.btn_wx_login).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view)
            {
                WeiXinHead.wxLogin();

//                GlobalData.login_flag=true;
//
//                info_user info=new info_user();
//
//                info.name="测试数据";
//                info.sex=1;
//                info.face="http://wx.qlogo.cn/mmopen/PdibpV1sFDHd7jGjouGwGr5yfNGzrfu47C63VVicRgxY19Cr5vddE1Sq41X0cgicLu1xJcxibGXqxORGGgR7a0ogYtyYgASZ7RTf/0";
//
//                GlobalData.userinfo=info;
//
//                UserHead.getInstance().updateInfo();
            }
        });


    }

    //登录按钮事件
    private void OnLoginBtn()
    {
//        //验证手机号
//        String mob=et_mobile.getText().toString();
//
//        String pass=et_password.getText().toString();
//
//        //发送消息
//
//        login_req req=new login_req();
//        req.tel=mob;
//        req.pass=pass;
//
//        NetManager.SendMsg(req);
    }

}
