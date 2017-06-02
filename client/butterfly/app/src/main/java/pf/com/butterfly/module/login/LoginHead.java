package pf.com.butterfly.module.login;

import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.message.Protocols.login_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.title.TitleModule;
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
