package pf.com.butterfly;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.multidex.MultiDex;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.media.MediaRouter;
import android.view.View;
import android.view.Window;

import com.nostra13.universalimageloader.core.ImageLoader;
import com.nostra13.universalimageloader.core.ImageLoaderConfiguration;

import c.b.BP;
import pf.com.butterfly.module.menu.MenuModule;
import pf.com.butterfly.module.title.TitleModule;
import pf.com.butterfly.module.update.UpdateModule;
import pf.com.butterfly.util.HDLog;
import pf.com.butterfly.util.PhotoChoose;
import pf.com.butterfly.module.LogView;
import pf.com.butterfly.module.ShowPhoto;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.TestEditView;
import pf.com.butterfly.module.TestTextView;

public class MainActivity  extends AppCompatActivity
{

    public static MainActivity main;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        requestWindowFeature(Window.FEATURE_NO_TITLE);

        setContentView(R.layout.activity_main);

        main=this;

        //日志视图
        LogView.init();

        try
        {
            //初始化标题栏
            TitleModule.getInstance().init();

            //菜单视图
            MenuModule.getInstance().init(this.findViewById(R.id.drawer_layout));

            InitModule();

            //初始化图片下载器
            ImageLoader.getInstance().init(ImageLoaderConfiguration.createDefault(MainActivity.this));

            //初始化支付
            BP.init("a5a2688114fb06e9156acaaee76ca9a0");

            //测试
            ControlManager.resetView();

            //初始化网络
            NetManager.init();

            //检测版本更新
            UpdateModule.getInstance().init();
        }
        catch (Exception ex)
        {
            HDLog.error(ex);
        }

    }


    /**
     * 分割 Dex 支持
     * @param base
     */
    @Override
    protected void attachBaseContext(Context base) {
        super.attachBaseContext(base);
        MultiDex.install(this);
    }

    private void InitModule()
    {
        //初始化测试图文混排界面
        TestTextView.Init();
        //初始化测试图文编辑界面
        TestEditView.Init();
        //初始化展示图片界面
        ShowPhoto.getInstance().init();

    }

    //其他activity返回事件
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {

        PhotoChoose.onActivityResult( requestCode,  resultCode, data);
        TestEditView.onActivityResult( requestCode,  resultCode, data);

    }


    // 捕获返回键的方法2
    @Override
    public void onBackPressed()
    {
        ControlManager.Rollback();
    }

}














