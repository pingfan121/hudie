package pf.com.butterfly.module.login;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.module.register.RegisterHead;

/**
 * Created by admin on 2017/3/5.
 */
public class LoginModule extends AppBaseFragment
{


    @Override
    protected void initView(LayoutInflater inflater, ViewGroup container,
                            Bundle savedInstanceState)
    {

        view = inflater.inflate(R.layout.module_login, container, false);

        //初始化各个页面
        //登录界面
        LoginHead.getInstance().init(this,view);

        //设置第一个控制器
        SetFirstControl(LoginHead.getInstance());
    }

}
