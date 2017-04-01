package pf.com.butterfly.module.login;

import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.message.Protocols.login_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.title.TitleModule;

/**
 * Created by admin on 2017/3/3.
 */
public class LoginHead extends AppBaseControl
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

    private EditText et_mobile;
    private EditText et_password;
    private Button btn_login;

    @Override
    public void init(AppBaseFragment fragment,View father)
    {
        super.init(fragment,father);

        view=father.findViewById(R.id.login_head);

        et_mobile=(EditText)view.findViewById(R.id.et_mobile);
        et_password=(EditText)view.findViewById(R.id.et_password);
        btn_login=(Button) view.findViewById(R.id.btn_login);

        btn_login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnLoginBtn();
            }
        });

        view.setVisibility(View.INVISIBLE);

    }

    //登录按钮事件
    private void OnLoginBtn()
    {
        //验证手机号
        String mob=et_mobile.getText().toString();

        String pass=et_password.getText().toString();

        //发送消息

        login_req req=new login_req();
        req.tel=mob;
        req.pass=pass;

        NetManager.SendMsg(req);
    }

    @Override
    public void SetTitleView()
    {
        TitleModule.getInstance().SetTitle("登录");
    }

}
