package pf.com.butterfly.module.register;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.module.register.RegisterHead;

/**
 * Created by admin on 2017/3/5.
 */
public class RegisterModule extends AppBaseFragment
{


    @Override
    protected void initView(LayoutInflater inflater, ViewGroup container,
                            Bundle savedInstanceState)
    {

        view = inflater.inflate(R.layout.module_register, container, false);


        //注册界面
        RegisterHead.getInstance().init(this,view);

        //设置第一个控制器
        SetFirstControl(RegisterHead.getInstance());
    }

}
