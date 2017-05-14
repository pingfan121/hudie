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

        //检测版本更新
        UpdateModule.getInstance().init();

        //初始化支付
        BP.init("a5a2688114fb06e9156acaaee76ca9a0");

        //初始化网络
        NetManager.init();

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

    //-------------------------------下面是测试---------------------------


    //Activity创建或者从后台重新回到前台时被调用
    @Override
    protected void onStart() {
        super.onStart();
       HDLog.info("onStart called.");
    }

    //Activity从后台重新回到前台时被调用
    @Override
    protected void onRestart() {
        super.onRestart();
        HDLog.info("onRestart called.");

    }

    //测试
    //Activity创建或者从被覆盖、后台重新回到前台时被调用
    @Override
    protected void onResume() {
        super.onResume();
        HDLog.info("onResume called.");

        main=this;

        //获取主视图
        View view=this.findViewById(R.id.main_aaa);

        LogView.init();


        //嘿嘿
        //创建函数在前后台切换的时候回多次调用 所以初始化函数要多多注意 不要重复创建视图

        try
        {

            //初始化mainactivity内部的的各个的视图

            InitModule();

            //初始化菜单
            MenuModule.getInstance().init(this.findViewById(R.id.drawer_layout));


            //初始化标题栏
            TitleModule.getInstance().init(view);


            //初始化图片下载器
            ImageLoader.getInstance().init(ImageLoaderConfiguration.createDefault(MainActivity.this));

            //初始化支付


            //测试
            ControlManager.resetView();


        }
        catch (Exception ex)
        {
            HDLog.error(ex);
        }
    }

    //Activity被覆盖到下面或者锁屏时被调用
    @Override
    protected void onPause() {
        super.onPause();
        HDLog.info("onPause called.");
        //有可能在执行完onPause或onStop后,系统资源紧张将Activity杀死,所以有必要在此保存持久数据
    }

    //退出当前Activity或者跳转到新Activity时被调用
    @Override
    protected void onStop() {
        super.onStop();
        HDLog.info("onStop called.");
    }

    //退出当前Activity时被调用,调用之后Activity就结束了
    @Override
    protected void onDestroy() {
        super.onDestroy();
        HDLog.info("onDestory called.");
    }

    /**
     * Activity被系统杀死时被调用.
     * 例如:屏幕方向改变时,Activity被销毁再重建;当前Activity处于后台,系统资源紧张将其杀死.
     * 另外,当跳转到其他Activity或者按Home键回到主屏时该方法也会被调用,系统是为了保存当前View组件的状态.
     * 在onPause之前被调用.
     */
    @Override
    protected void onSaveInstanceState(Bundle outState) {
        HDLog.info("onSaveInstanceState called. put param: ");
        super.onSaveInstanceState(outState);
    }

    /**
     * Activity被系统杀死后再重建时被调用.
     * 例如:屏幕方向改变时,Activity被销毁再重建;当前Activity处于后台,系统资源紧张将其杀死,用户又启动该Activity.
     * 这两种情况下onRestoreInstanceState都会被调用,在onStart之后.
     */
    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);

        HDLog.info("回复状态???");
    }




}














