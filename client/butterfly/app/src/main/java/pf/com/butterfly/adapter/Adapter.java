package pf.com.butterfly.adapter;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.BaseAdapter;

import java.util.ArrayList;
import java.util.List;

import pf.com.butterfly.R;
import pf.com.butterfly.model.BenefitItemData;
import pf.com.butterfly.module.benefit.BenefitDetail;
import pf.com.butterfly.module.benefit.BenefitHeadItem;

/**
 * Created by admin on 2017/5/17.
 */

public class Adapter<T> extends BaseAdapter
{
    public List<T> datas=new ArrayList<T>();

    @Override
    public int getCount() {
        return datas.size();
    }

    @Override
    public Object getItem(int i) {
        return datas.get(i);
    }

    public T getDataItem(int i) {
        return datas.get(i);
    }

    @Override
    public long getItemId(int i) {
        return i;
    }


    private int layoutid;
    private String itemclassname;

    //设置项布局和处理类
    public Adapter(int layout_id,String item_name)
    {
        layoutid=layout_id;
        itemclassname=item_name;
    }


    @Override
    public View getView(int i, View view, ViewGroup viewGroup)
    {
        if(view==null)
        {
            LayoutInflater inflater= LayoutInflater.from(viewGroup.getContext());

            view= inflater.inflate(layoutid,null);

            DataItem item=null;
            try
            {
                Class cc=Class.forName(itemclassname);
                item=(DataItem)cc.newInstance();
            }
            catch (Exception ex)
            {

            }


            item.init(view);
            item.setData((Object)datas.get(i));
            view.setTag(item);

        }
        else
        {
            ((DataItem) view.getTag()).setData((Object)datas.get(i));
        }
        return view;
    }


    public void AddOneItem(T t)
    {
        datas.add(t);

        this.notifyDataSetChanged();
    }

    public void SubOneItem(T t)
    {
        if(datas.size()>0)
        {
            datas.remove(t);
            this.notifyDataSetChanged();
        }
    }
}
