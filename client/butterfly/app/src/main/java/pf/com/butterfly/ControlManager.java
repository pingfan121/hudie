package pf.com.butterfly;


import android.view.View;

import java.util.Stack;

import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.module.main.MainHead;
import pf.com.butterfly.module.menu.MenuModule;

/**
 * Created by Administrator on 2016/6/10.
 */
public class ControlManager
{
    public static Stack<AppBaseViewControl> controls=new Stack<AppBaseViewControl>();


    public static void resetView()
    {
        if(controls.size()==0)
        {
            MainHead.getInstance().show();
        }
        else
        {
            controls.peek().show();
        }
    }

    public static void show(AppBaseViewControl control)
    {
        if(controls.size()>0)
        {
            if(controls.peek()==control)
            {
                return;
            }

            controls.peek().getView().setVisibility(View.INVISIBLE);
        }

        controls.push(control);

    }

    public static void hide(AppBaseViewControl control)
    {
        if(controls.size()==0)
        {
            return;
        }

        if(controls.peek()!=control)
        {
            return;
        }

        controls.pop();

        if(controls.size()==0)
        {
            return;
        }

        controls.peek().show();


    }

    public static void Rollback()
    {
        if(controls.size()==0)
            return;

        if(MenuModule.getInstance().getState()==true)
        {
            MenuModule.getInstance().ShowMenu(false);
            return;
        }

        if(controls.size()==1)
        {
            MenuModule.getInstance().ShowMenu(true);
            return;
        }

        controls.peek().hide();
    }

}

























