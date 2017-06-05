package pf.com.butterfly.module;

import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import pf.com.butterfly.R;
import pf.com.butterfly.adapter.AdapterItemData;
import pf.com.butterfly.adapter.ListViewAdapter;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.message.Protocols.bored_head_item_add_req;
import pf.com.butterfly.message.Protocols.bored_head_item_add_res;
import pf.com.butterfly.message.Protocols.bored_head_items_req;
import pf.com.butterfly.message.Protocols.bored_head_items_res;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.module.bored.BoredDetail;
import pf.com.butterfly.module.bored.BoredHead;
import pf.com.butterfly.module.bored.BoredHeadItemData;
import pf.com.butterfly.module.bored.BoredItemView;
import pf.com.butterfly.util.HDLog;

/**
 * Created by admin on 2017/6/3.
 */

public class DebugHead extends AppBaseViewControl
{
    private static DebugHead _instance;

    public static DebugHead getInstance()
    {
        if(_instance==null)
        {
            _instance=new DebugHead();
        }

        return _instance;
    }

    public void initValue()
    {
        title="调试信息";
        layout= R.layout.debug_head;
        layer=ControlLayer.debug_layer;
    }

    private TextView tv;

    @Override
    public void initControl()
    {
        tv=(TextView)view.findViewById(R.id.t_log);

        view.findViewById(R.id.btn_clean).setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                HDLog.logs="";
                tv.setText(HDLog.logs);
            }
        });
    }

    @Override
    protected void reShow()
    {

        HDLog.info("----------------------------");

        tv.setText(HDLog.logs);
    }
}
