package pf.com.butterfly.module.main;

import android.view.View;

import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.module.LogView;
import pf.com.butterfly.module.TestEditView;
import pf.com.butterfly.module.TestTextView;
import pf.com.butterfly.module.login.LoginModule;
import pf.com.butterfly.module.main.MainModule;
import pf.com.butterfly.module.menu.MenuModule;
import pf.com.butterfly.module.register.RegisterModule;
import pf.com.butterfly.module.title.TitleModule;
import pf.com.butterfly.util.PhotoChoose;

/**
 * Created by admin on 2017/2/25.
 */
public class MainTest extends AppBaseControl
{
    private static MainTest _instance=null;

    public static MainTest getInstance()
    {
        if(_instance==null)
        {
            _instance=new MainTest();
        }

        return _instance ;
    }

    @Override
    public void init(AppBaseFragment fragment, View father)
    {
        super.init(fragment,father);

        View main_view=father.findViewById(R.id.main_view);
        view=main_view;


        //注册按钮
        main_view.findViewById(R.id.btn_zhuce).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                ModuleManager.SwitchModule(RegisterModule.class.getName());


            }
        });


        //登录按钮
        main_view.findViewById(R.id.btn_denglu).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                ModuleManager.SwitchModule(LoginModule.class.getName());

            }
        });

        //打开菜单 按钮
        main_view.findViewById(R.id.btn_caidan).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MenuModule.getInstance().ShowMenu(true);
            }
        });

        //打开图片 按钮
        main_view.findViewById(R.id.btn_photo).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                PhotoChoose.doPickPhotoAction();
            }
        });

        //打开图文混排展示 按钮
        main_view.findViewById(R.id.btn_tuwen).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                TestTextView.SetView();
            }
        });

        //打开图文编辑 按钮
        main_view.findViewById(R.id.btn_bianji).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                TestEditView.Show();
            }
        });

        //显示日志 按钮
        main_view.findViewById(R.id.btn_log).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LogView.Show();
            }
        });

        //显示日志 按钮
        main_view.findViewById(R.id.btn_main).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MainHead.getInstance().Show();
            }
        });

        this.Hide();

    }
    @Override
    public void SetTitleView()
    {
        TitleModule.getInstance().SetTitle("测试功能界面");
    }
}
