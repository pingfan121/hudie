package pf.com.butterfly.module.menu;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import pf.com.butterfly.ModuleManager;
import pf.com.butterfly.R;
import pf.com.butterfly.module.ViewClick;
import pf.com.butterfly.module.advise.AdviseModule;
import pf.com.butterfly.module.benefit.BenefitModule;

/**
 * Created by Administrator on 2016/6/23.
 */

public class MenuItemAdapter2 extends BaseAdapter
{

    private List<MenuItemData> itemdatas=new ArrayList<MenuItemData>();

    public MenuItemAdapter2() {
        super();

        initItemData();

    }


    private void initItemData()
    {

        //菜单列数据1
        MenuItemData data=new MenuItemData();
        data.init(R.drawable.jianyi,"建议","建议");
        itemdatas.add(data);

        data=new MenuItemData();
        data.init(R.drawable.shezhi,"设置","设置");
        itemdatas.add(data);
    }

    @Override
    public int getCount() {
        return itemdatas.size();
    }

    @Override
    public Object getItem(int i) {
        return (Object)itemdatas.get(i);
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup)
    {
        if(view==null)
        {
            LayoutInflater inflater= LayoutInflater.from(viewGroup.getContext());

            view= inflater.inflate(R.layout.slidemenu_menuitem,null);
        }

        MenuItemData data=itemdatas.get(i);
        ((ImageView)view.findViewById(R.id.itemicon)).setImageResource(data.icon);
        ((TextView)view.findViewById(R.id.itemtext)).setText(data.title);
        view.setTag(data.modname);

        view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                onItemClick(view);
            }
        });
        view.setOnTouchListener(ViewClick.touchLis);

        return view;
    }


    public void onItemClick(View view)
    {
        Log.e("菜单被点击了", "被点击了");

        MenuModule.getInstance().ShowMenu(false);

        String tag = (String)view.getTag();

        switch (tag)
        {
            case "建议":
            {
                ModuleManager.SwitchModule(AdviseModule.class.getName());
                break;
            }
            case "设置":
            {
                break;
            }
        }

    }




}


