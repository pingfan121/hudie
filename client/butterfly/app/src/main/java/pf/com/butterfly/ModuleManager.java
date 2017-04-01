package pf.com.butterfly;


import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;

import java.util.List;
import java.util.Stack;

import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.module.main.MainModule;
import pf.com.butterfly.module.menu.MenuModule;
import pf.com.butterfly.util.HDLog;

/**
 * Created by Administrator on 2016/6/10.
 */
public class ModuleManager
{
    public static MainActivity main;

    private static FragmentManager fm;
    private static FragmentTransaction transaction;


    public static String currmod="";

    public static void init(MainActivity mainActivity)
   {
       main=mainActivity;
       fm = main.getFragmentManager();

       if(currmod.equals(""))
       {
           HDLog.info("走了这里...");
           SwitchModule(MainModule.class.getName());
       }
       else
       {
           HDLog.info("走了这里22...");
           reset();
       }
   }

    public static void reset()
    {
        AppBaseFragment currfra=(AppBaseFragment)fm.findFragmentByTag(currmod);

        if(currfra!=null)
        {
            HDLog.info("不是空的...");

            transaction = fm.beginTransaction();
            transaction.show(currfra);
            transaction.commit();

            currfra.resetTitleView();

            HDLog.info("不是空的22...");
        }
        else
        {
            HDLog.info("是空的...");

            String temp=currmod;

            currmod="";

            SwitchModule(temp);
        }

        return ;
    }


    //切换系统  //一级显示
    public static void SwitchModule(String  modname)
    {
        if(currmod.equals(modname))
        {
            return;
        }

        if(currmod!="")
        {
            Fragment currfra=fm.findFragmentByTag(currmod);
            if(currfra!=null)
            {
                transaction = fm.beginTransaction();
                transaction.hide(currfra);
                transaction.commit();
            }
        }

        AppBaseFragment fra=(AppBaseFragment)fm.findFragmentByTag(modname);

        if(fra==null)
        {
            try {
                Class onwClass = Class.forName(modname);
                try {
                    fra =(AppBaseFragment)(onwClass.newInstance());

                } catch (InstantiationException e) {

                } catch (IllegalAccessException e) {
                }
            } catch (ClassNotFoundException e) {
            }

            if(fra!=null)
            {
                transaction = fm.beginTransaction();
                transaction.add(R.id.fragment_view,fra,modname);
                transaction.hide(fra);
                transaction.commit();
            }

        }

        if(fra != null)
        {
            transaction = fm.beginTransaction();
            transaction.show(fra);
            transaction.commit();
            currmod=modname;

            fra.resetTitleView();
        }

    }

    public static void CloseModule(String modname)
    {

        if(modname!=currmod)
        {
            return ;
        }

        Rollback();
    }

    public static void Rollback()
    {

        //假设菜单是打开的 先关闭
        if(MenuModule.getInstance().getState()==true)
        {
            MenuModule.getInstance().ShowMenu(false);
            return ;
        }

        AppBaseFragment currfra=(AppBaseFragment)fm.findFragmentByTag(currmod);

        if(currfra==null)
        {
            return ;
        }

        //将退回交给模块自己处理
        if(currfra.rollback()==true)
            return;

        //如果当前模块是主模块
        if(currmod==MainModule.class.getName())
        {
            MenuModule.getInstance().ShowMenu(true);
            return;
        }
        else
        {
//            transaction = fm.beginTransaction();
//            transaction.hide(currfra);
//            transaction.commit();
//
//            AppBaseFragment mainfra=(AppBaseFragment)fm.findFragmentByTag(MainModule.class.getName());
//
//            if(mainfra!=null)
//            {
//                transaction = fm.beginTransaction();
//                transaction.show(mainfra);
//                transaction.commit();
//
//                mainfra.resetTitleView();
//            }
//            currmod=MainModule.class.getName();

              SwitchModule(MainModule.class.getName());
        }
    }

}

























