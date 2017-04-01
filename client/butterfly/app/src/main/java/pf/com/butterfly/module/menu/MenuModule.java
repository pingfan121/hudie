package pf.com.butterfly.module.menu;
import android.graphics.Point;
import android.support.v4.widget.DrawerLayout;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.R;
import pf.com.butterfly.module.benefit.BenefitHeadItemAdapter;
import pf.com.butterfly.module.benefit.BenefitModule;
import pf.com.butterfly.tease.TeaseModule;



/**
 * A fragment with a Google +1 button.
 */
public class MenuModule // implements View.OnTouchListener
 {

    private static MenuModule _instance=null;

    public static MenuModule getInstance()
    {
        if(_instance==null)
        {
            _instance=new MenuModule();
        }

        return _instance ;
    }

    private static DrawerLayout slide;//菜单布局
    private View view;  //菜单视图
    private LayoutInflater inflater;
    private MenuItemAdapter adapter=new MenuItemAdapter();
    private MenuItemAdapter2 adapter2=new MenuItemAdapter2();

    public void init( View father)
    {

        inflater= LayoutInflater.from(father.getContext());
        //菜单布局
        slide = (DrawerLayout)father;
        //菜单视图
        view= father.findViewById(R.id.module_menu);

        ListView listView=(ListView)view.findViewById(R.id.menu_item_list);

        listView.setAdapter(adapter);

        ListView listView2=(ListView)view.findViewById(R.id.menu_item_list2);

        listView2.setAdapter(adapter2);
    }

    public void ShowMenu(boolean flag)
    {
        if(flag==false)
        {
            slide.closeDrawers();
        }
        else
        {
            slide.openDrawer(Gravity.LEFT);
        }
    }

     public boolean getState()
     {
         return  slide.isDrawerOpen(Gravity.LEFT);
     }

























}
