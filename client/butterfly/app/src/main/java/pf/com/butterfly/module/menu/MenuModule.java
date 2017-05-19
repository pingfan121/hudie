package pf.com.butterfly.module.menu;
import android.support.v4.widget.DrawerLayout;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.ListView;

import pf.com.butterfly.MainActivity;
import pf.com.butterfly.R;
import pf.com.butterfly.component.IItemClick;
import pf.com.butterfly.component.ItemAdapter;
import pf.com.butterfly.model.ItemData;
import pf.com.butterfly.module.advise.AdviseHead;
import pf.com.butterfly.module.benefit.BenefitHead;
import pf.com.butterfly.module.bored.BoredHead;
import pf.com.butterfly.module.set.SetingHead;
import pf.com.butterfly.module.user.UserHead;


/**
 * A fragment with a Google +1 button.
 */
public class MenuModule  implements IItemClick
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

    private ImageView iv_head;

    public void init( View father)
    {

        initValue();

        LayoutInflater inflater= LayoutInflater.from(father.getContext());
        //菜单布局
        slide = (DrawerLayout)father;
        //菜单视图
        view= father.findViewById(R.id.module_menu);

        ListView listView=(ListView)view.findViewById(R.id.menu_item_list);

        listView.setAdapter(adapter1);

        ListView listView2=(ListView)view.findViewById(R.id.menu_item_list2);

        listView2.setAdapter(adapter2);

        view.findViewById(R.id.iv_head).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                UserHead.getInstance().show();
            }
        });


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

     private ItemAdapter adapter1;
     private ItemAdapter adapter2;
     private void initValue()
     {
         adapter1=new ItemAdapter();
         adapter1.setItemClick(this);
         adapter1.setLayout(R.layout.itemlayout);
         adapter1.addData(new ItemData(R.drawable.hudie,"蝴蝶"));
         adapter1.addData(new ItemData(R.drawable.hudie,"好无聊啊"));

         adapter2=new ItemAdapter();
         adapter2.setItemClick(this);
         adapter2.setLayout(R.layout.itemlayout);
         adapter2.addData(new ItemData(R.drawable.jianyi,"建议"));
         adapter2.addData(new ItemData(R.drawable.shezhi,"设置"));
         adapter2.addData(new ItemData(R.drawable.shezhi,"退出"));
     }

     public void onItemClick(View view, ItemData data)
     {
         MenuModule.getInstance().ShowMenu(false);

         switch(data.text)
         {
             case "蝴蝶":
             {
                 BenefitHead.getInstance().show();
                 break;
             }
             case "好无聊啊":
             {
                 BoredHead.getInstance().show();
                 break;
             }
             case "建议":
             {
                 AdviseHead.getInstance().show();
                 break;
             }
             case "设置":
             {
                 SetingHead.getInstance().show();
                 break;
             }
             case "退出":
             {
                 MainActivity.main.finish();
                 break;
             }
         }
     }

























}
