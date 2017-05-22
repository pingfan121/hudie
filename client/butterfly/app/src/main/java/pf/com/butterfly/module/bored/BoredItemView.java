package pf.com.butterfly.module.bored;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import org.w3c.dom.Text;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.adapter.AdapterItemView;

/**
 * Created by admin on 2017/5/20.
 */

public class BoredItemView extends AdapterItemView
{

    private ImageView iv_icon;
    private TextView tv_name;
    private TextView tv_rownum;
    private TextView tv_text;


    @Override
    public void init(View view)
    {
        iv_icon=(ImageView)view.findViewById(R.id.iv_face);

        tv_name=(TextView)view.findViewById(R.id.tv_name);
        tv_rownum=(TextView)view.findViewById(R.id.tv_rownum);
        tv_text=(TextView)view.findViewById(R.id.tv_text);
    }

    @Override
    public void setData(AdapterItemData obj)
    {
        BoredHeadItemData data=(BoredHeadItemData)obj;

       // iv_icon.setImageResource();
        tv_name.setText(data.name);
        tv_rownum.setText("跟帖:"+data.num);
        tv_text.setText(data.text);

    }
}

