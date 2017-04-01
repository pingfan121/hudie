package pf.com.butterfly.module.register;

import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.message.Protocols.register_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.title.TitleModule;

/**
 * Created by admin on 2017/3/3.
 */
public class RegisterHead extends AppBaseControl
{
    private static RegisterHead _instance;

    public static RegisterHead getInstance()
    {
        if(_instance==null)
        {
            _instance=new RegisterHead();
        }
        return _instance;
    }


    protected EditText et_mobile;
    protected EditText et_password;
    protected EditText et_nickname;
    protected Button btn_register;

    @Override
    public void init(AppBaseFragment fragment,View father)
    {
        super.init(fragment,father);

        view=father.findViewById(R.id.register_head);

        et_mobile=(EditText)view.findViewById(R.id.et_mobile);
        et_password=(EditText)view.findViewById(R.id.et_password);
        et_nickname=(EditText)view.findViewById(R.id.et_name);
        btn_register=(Button) view.findViewById(R.id.btn_register);

        btn_register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                OnRegisterBtn();
            }
        });

        view.setVisibility(View.INVISIBLE);
    }

    //登录按钮事件
    private void OnRegisterBtn()
    {
        //验证手机号
        String mob=et_mobile.getText().toString();

        String pass=et_password.getText().toString();

        String name=et_nickname.getText().toString();

        //发送消息

        register_req req=new register_req();

        req.tel=mob;
        req.pass=pass;
        req.nickname=name;

        NetManager.SendMsg(req);

    }

    @Override
    public void SetTitleView()
    {
        TitleModule.getInstance().SetTitle("注册");
    }


}
