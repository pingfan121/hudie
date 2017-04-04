package pf.com.butterfly.module.set;

import android.os.Message;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.ListView;

import com.google.gson.Gson;

import pf.com.butterfly.MainActivity;
import pf.com.butterfly.R;
import pf.com.butterfly.base.AppBaseControl;
import pf.com.butterfly.base.AppBaseFragment;
import pf.com.butterfly.base.AppBaseViewControl;
import pf.com.butterfly.component.IItemClick;
import pf.com.butterfly.component.ItemSelectAdapter;
import pf.com.butterfly.component.ItemSelectData;
import pf.com.butterfly.hander.IMsgHandler;
import pf.com.butterfly.http.BmobHttp;
import pf.com.butterfly.message.Protocols.register_req;
import pf.com.butterfly.message.net.NetManager;
import pf.com.butterfly.model.ItemData;
import pf.com.butterfly.module.benefit.BenefitDonationPayItemData;
import pf.com.butterfly.module.title.TitleModule;
import pf.com.butterfly.util.HDLog;

/**
 * Created by admin on 2017/3/3.
 */
public class SetingHead extends AppBaseViewControl
{
    private static SetingHead _instance;

    public static SetingHead getInstance()
    {
        if (_instance == null)
        {
            _instance = new SetingHead();
        }

        return _instance;
    }

    private ItemSelectAdapter adapter;

    protected void initValue()
    {
        layout=R.layout.seting_head;

        title="设置";

        adapter=new ItemSelectAdapter();

        adapter.addData(new ItemSelectData(R.drawable.shezhi,"内网",1,R.drawable.pay_select2,R.drawable.pay_select1));
        adapter.addData(new ItemSelectData(R.drawable.shezhi,"外网",0,R.drawable.pay_select2,R.drawable.pay_select1));

        adapter.setItemClick(new IItemClick()
        {
            @Override
            public void onItemClick(View view, ItemData data)
            {
                //设置网络.....
                if(data.text.equals("内网"))
                {
                    NetManager.SetNet(false);
                }
                else
                {
                    NetManager.SetNet(true);
                }

                //遍历
                for( int i=0;i<adapter.getCount();i++)
                {
                    ItemSelectData itemdata=(ItemSelectData)adapter.getItem(i);

                    itemdata.select=0;
                }

                ((ItemSelectData)data).select=1;

                adapter.notifyDataSetChanged();
            }
        });
    }

    protected void initControl()
    {

        ListView lv=(ListView)view.findViewById(R.id.lv_net);

        lv.setAdapter(adapter);

    }
}