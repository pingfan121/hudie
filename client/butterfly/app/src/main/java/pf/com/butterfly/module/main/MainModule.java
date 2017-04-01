package pf.com.butterfly.module.main;


import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.module.main.MainHead;
import pf.com.butterfly.module.title.TitleModule;


/**
 * A fragment with a Google +1 button.
 */
public class MainModule extends AppBaseFragment {



    @Override
    protected void initView(LayoutInflater inflater, ViewGroup container,
                            Bundle savedInstanceState)
    {

        view = inflater.inflate(R.layout.module_main, container, false);

        //初始化各个页面
        //蝴蝶主页
        MainHead.getInstance().init(this,view);
        MainTest.getInstance().init(this,view);



        //设置第一个控制器
        SetFirstControl(MainHead.getInstance());

    }

}
